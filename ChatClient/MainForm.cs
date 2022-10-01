using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ChatClient
{
  public partial class MainForm : Form
  {
    App.Common.ChatClient? server { get; set; }

    public MainForm()
    {
      InitializeComponent();
    }

    public string? UserName { get; private set; }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      var loginForm = new LoginForm();
      if (loginForm.ShowDialog() == DialogResult.OK)
      {
        UserName = loginForm.UserName;
        var tcpClient = new TcpClient();
        await tcpClient.ConnectAsync(IPAddress.Parse("127.0.0.1"), 9999);
        server = new App.Common.ChatClient(tcpClient);
        await server.SendAsync(UserName!);
        while (true)
        {
          var message = await server.ReceiveAsync();
          if (!string.IsNullOrEmpty(message))
            tbChatbox.AppendText(message + Environment.NewLine);
          await Task.Delay(100);
        }
      }
    }

    private async void tbInput_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        e.SuppressKeyPress = true;
        var input = (TextBox)sender;
        if (server is null)
          return;
        await server.SendAsync(input.Text);
        input.Clear();
      }
    }
  }
}
