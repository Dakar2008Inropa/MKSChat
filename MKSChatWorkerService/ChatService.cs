using App.Common;
using System.Net.Sockets;

namespace App.WindowsService;

public class ChatService : IDisposable
{
  public List<ChatClient> Clients { get; } = new();
  private Mutex mutex = new();
  private TcpListener? _listener { get; set; }
  private readonly ILogger<WindowsBackgroundService> _logger;
  public ChatService(ILogger<WindowsBackgroundService> logger) =>
      (_logger) = (logger);
  ~ChatService()
  {
    mutex.Dispose();
  }
  public async Task ExecuteAsync()
  {
    _logger.LogInformation("ChatService starting");
    _logger.LogDebug("Creating TcpListener");
    var port = 9999;
    _listener = TcpListener.Create(port);
    _listener.Start();
    _logger.LogInformation("Listening on port {port}", port);

    Task t = new(async () =>
    {
      while (true)
      {
        mutex.WaitOne();
        var copy = new ChatClient[Clients.Count];
        Clients.CopyTo(copy);
        mutex.ReleaseMutex();
        copy.ToList().ForEach(client =>
        {
          try
          {
            if (client.Stream.DataAvailable)
            {
              var message = client.Receive();
              Broadcast($"{message} ({client.Name})");
            }
          }
          catch (Exception ex)
          {
            _logger.LogInformation(ex, "{name} has disconnected", client.Name);
            string? disconnectedClientName = client.Name;
            mutex.WaitOne();
            if (Clients.Remove(client))
            {
              Console.WriteLine($"{disconnectedClientName} has disconnected");
            }
            mutex.ReleaseMutex();
          }
        });
        await Task.Delay(100);
      }
    });
    t.Start();

    while (true)
    {
      _logger.LogDebug("Waiting for client");
      TcpClient tcpClient = await _listener.AcceptTcpClientAsync();
      _logger.LogInformation("Client connected");
      var client = new ChatClient(tcpClient);
      var name = await client.ReceiveAsync();
      client.Name = name;
      _logger.LogInformation("Name: {name}", name);
      Console.WriteLine($"{name} connected");
      await BroadcastAsync($"{name} connected");
      mutex.WaitOne();
      Clients.Add(client);
      mutex.ReleaseMutex();
    }
  }

  private async Task BroadcastAsync(string message)
  {
    List<ChatClient> dead_clients = new();
    foreach (var client in Clients)
    {
      try
      {
        await client.SendAsync(message);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        dead_clients.Add(client);
      }
    }
    mutex.WaitOne();
    dead_clients.ForEach(client => Clients.Remove(client));
    mutex.ReleaseMutex();
  }
  private void Broadcast(string message)
  {
    List<ChatClient> dead_clients = new();
    foreach (var client in Clients)
    {
      try
      {
        client.Send(message);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        dead_clients.Add(client);
      }
    }
    mutex.WaitOne();
    dead_clients.ForEach(client => Clients.Remove(client));
    mutex.ReleaseMutex();
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

