using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace App.Common;

public sealed class ChatClient : IDisposable
{
  private TcpClient TcpClient { get; }
  private NetworkStream Stream { get; }
  public String? Name { get; set; }

  //public string Name { get; private set; } = String.Empty;

  public ChatClient(TcpClient tcpClient)
  {
    TcpClient = tcpClient;
    Stream = tcpClient.GetStream();
  }

  public async Task<string> ReceiveAsync()
  {
    var buffer = new byte[1_024];
    int received = await Stream.ReadAsync(buffer);

    var message = Encoding.UTF8.GetString(buffer, 0, received);
    return message;
  }

  public async Task SendAsync(string message)
  {
    byte[] msg = Encoding.UTF8.GetBytes(message);
    await Stream.WriteAsync(msg);
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