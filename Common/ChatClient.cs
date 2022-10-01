using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace App.Common;

public sealed class ChatClient : IDisposable
{
  private TcpClient TcpClient { get; }
  public NetworkStream Stream { get; }
  public String? Name { get; set; }
  public bool Dead { get; private set; }

  public ChatClient(TcpClient tcpClient)
  {
    TcpClient = tcpClient;
    Stream = tcpClient.GetStream();
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
      Dead = true;
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
    catch (Exception)
    {
      Dead = true;
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
    catch (Exception)
    {
      Dead = true;
    }
  }

  public void Send(string message)
  {
    byte[] msg = Encoding.UTF8.GetBytes(message);
    try
    {
      Stream.Write(msg);
    }
    catch (Exception)
    {
      Dead = true;
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