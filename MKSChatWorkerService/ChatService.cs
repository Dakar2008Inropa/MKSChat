using App.Common;
using System.Net.Sockets;

namespace App.WindowsService;

public class ChatService : IDisposable
{
  public List<NetworkClient> Clients { get; } = new();
  //private Mutex mutex = new();
  private TcpListener? _listener { get; set; }
  private readonly ILogger<WindowsBackgroundService> _logger;
  public ChatService(ILogger<WindowsBackgroundService> logger) =>
      (_logger) = (logger);
  ~ChatService()
  {
    //mutex.Dispose();
  }
  public async Task ExecuteAsync()
  {
    _logger.LogInformation("ChatService starting");
    _logger.LogDebug("Creating TcpListener");
    var port = 9999;
    _listener = TcpListener.Create(port);
    _listener.Start();
    _logger.LogInformation("Listening on port {port}", port);

    //Task t = new(async () =>
    //{
    while (true)
    {
      //mutex.WaitOne();
      foreach (var client in Clients)
      {
        if (client.Stream.DataAvailable)
        {
          var message = client.Receive();
          if (!string.IsNullOrEmpty(message))
            Broadcast($"{message} ({client.Name})");
        }
      }

      List<NetworkClient> deadies = new();
      foreach (var client in Clients)
      {
        if (client.Dead)
          deadies.Add(client);
      }
      foreach (var client in deadies)
      {
        Clients.Remove(client);
        _logger.LogInformation("{name} has disconnected", client.Name);
        Console.WriteLine($"{client.Name} has disconnected");
      }
      //mutex.ReleaseMutex();

      await Task.Delay(100);
      //}
      //});
      //t.Start();

      //while (true)
      //{
      _logger.LogDebug("Waiting for client");
      if (_listener.Pending())
      {
        TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
        _logger.LogInformation("Client connected");
        var client = new NetworkClient(tcpClient);
        var name = await client.ReceiveAsync();
        client.Name = name;
        _logger.LogInformation("Name: {name}", name);
        Console.WriteLine($"{name} connected");
        await BroadcastAsync($"{name} connected");
        //mutex.WaitOne();
        Clients.Add(client);
        //mutex.ReleaseMutex();
      }
    }
  }

  private async Task BroadcastAsync(string message)
  {
    foreach (var client in Clients)
    {
      await client.SendAsync(message);
    }
  }
  private void Broadcast(string message)
  {
    foreach (var client in Clients)
    {
      client.Send(message);
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

