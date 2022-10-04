using App.Common;
using System.Net.Sockets;

namespace App.WindowsService;

public class ChatService : IDisposable
{
  #region properties
  private List<NetworkClient> Clients { get; } = new();
  private readonly ILogger<ChatService> _logger;
  private readonly JokeService _jokeService;
  #endregion

  #region Constructor
  public ChatService(ILogger<ChatService> logger, JokeService jokeService) =>
    (_logger, _jokeService) = (logger, jokeService);
  #endregion

  public async Task ExecuteAsync()
  {
    _logger.LogInformation("ChatService starting");
    _logger.LogDebug("Creating TcpListener");
    var port = 9999;
    TcpListener _listener = TcpListener.Create(port);
    _listener.Start();
    _logger.LogInformation("Listening on port {port}", port);

    // Main loop
    while (true)
    {
      await HandleIncomingMessagesAsync();
      await HandleDisconnectedClientsAsync();
      await AcceptPendingClientsAsync(_listener);
      await Task.Delay(100);
    }
  }

  /// <summary>
  /// receive pending messages and pass them on.
  /// </summary>
  /// <returns></returns>
  private async Task HandleIncomingMessagesAsync()
  {
    foreach (var client in Clients.Where(client => client.DataAvailable))
    {
      var message = client.Receive();
      if (!string.IsNullOrEmpty(message))
        await BroadcastAsync($"{message} ({client.Name})");
    }
  }

  /// <summary>
  /// Remove disconnected clients and broadcast a message about them leaving.
  /// </summary>
  /// <returns></returns>
  private async Task HandleDisconnectedClientsAsync()
  {
    foreach (var client in Clients.Where(client => client.Disconnected))
    {
      _logger.LogInformation("{name} has disconnected", client.Name);
      string message = $"{client.Name} has disconnected";
      await BroadcastAsync(message);
    }
    Clients.RemoveAll(client => client.Disconnected);
  }

  /// <summary>
  /// Clients waiting for connection is added to client list.
  /// Existing clients are notified of connected client.
  /// </summary>
  /// <param name="listener"></param>
  /// <returns></returns>
  private async Task AcceptPendingClientsAsync(TcpListener listener)
  {
    while (listener.Pending())
    {
      _logger.LogDebug("client pending");
      TcpClient tcpClient = await listener.AcceptTcpClientAsync();
      _logger.LogInformation("Client connected");
      var client = new NetworkClient(_logger, tcpClient);
      var name = await client.ReceiveAsync();
      client.Name = name;
      _logger.LogInformation("Name: {name}", name);
      await client.SendAsync($"Welcome to the chat {name}, here is a free joke:");
      var joke = _jokeService.GetJoke();
      await client.SendAsync($"{joke}");
      Console.WriteLine($"{name} connected");
      await BroadcastAsync($"{name} connected");
      Clients.Add(client);
    }
  }

  /// <summary>
  /// Sending a message to all connected clients.
  /// </summary>
  /// <param name="message"></param>
  /// <returns></returns>
  private async Task BroadcastAsync(string message)
  {
    foreach (var client in Clients)
    {
        foreach (var client in Clients)
        {
            await client.SendAsync(message);
        }
    }
  }

    #region IDisposable
    // To detect redundant calls
    private bool _disposedValue;
    // Public implementation of Dispose pattern.
    public void Dispose() => Dispose(true);
    public void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Clients.ForEach(client => client.Dispose());
            }
            _disposedValue = true;
        }
    }
    #endregion
}
