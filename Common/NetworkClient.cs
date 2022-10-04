using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace App.Common;

public sealed class NetworkClient : IDisposable
{
  private readonly ILogger _logger;
  private TcpClient TcpClient { get; }
  private NetworkStream Stream { get; }

  public String? Name { get; set; }
  public bool Disconnected { get; private set; }
  public bool DataAvailable => Stream.DataAvailable;

  public NetworkClient(ILogger logger, TcpClient tcpClient) =>
    (_logger, TcpClient, Stream) = (logger!, tcpClient, tcpClient.GetStream());

  public static async Task<NetworkClient> ConnectAsync(ILogger logger, IPAddress iPAddress, int port)
  {
    TcpClient tcpClient = new();
    await tcpClient.ConnectAsync(iPAddress, port);
    return new NetworkClient(logger, tcpClient);
  }

  public async Task<string> ReceiveAsync()
  {
    var buffer = new byte[1_024];
    try
    {
      int received = await Stream.ReadAsync(buffer);
      var message = Encoding.UTF8.GetString(buffer, 0, received);
      return message;
    }
    catch (Exception)
    {
      Disconnected = true;
      return string.Empty;
    }
  }

  public string Receive()
  {
    var buffer = new byte[1_024];
    try
    {
      int received = Stream.Read(buffer);
      var message = Encoding.UTF8.GetString(buffer, 0, received);
      return message;
    }
    catch (Exception ex)
    {
      Disconnected = true;
      _logger.LogDebug(ex, "Client disconnected ({Name})", Name);
      return string.Empty;
    }
  }

  public async Task SendAsync(string message)
  {
    byte[] msg = Encoding.UTF8.GetBytes(message);
    try
    {
      await Stream.WriteAsync(msg);
    }
    catch (Exception ex)
    {
      Disconnected = true;
      _logger.LogDebug(ex, "Client disconnected ({Name})", Name);
    }
  }

  public void Send(string message)
  {
    byte[] msg = Encoding.UTF8.GetBytes(message);
    try
    {
      Stream.Write(msg);
    }
    catch (Exception ex)
    {
      Disconnected = true;
      _logger.LogDebug(ex, "Client disconnected ({Name})", Name);
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
        Stream.Dispose();
        TcpClient.Dispose();
      }
      _disposedValue = true;
    }
  }
  #endregion
}