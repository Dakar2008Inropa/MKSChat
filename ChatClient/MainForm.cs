using System.Net;
using System.Net.Sockets;

namespace ChatClient
{
  public partial class MainForm : Form
  {
    App.Common.ChatClient? server { get; set; }

    bool userLoggedIn = false;

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
        connectedLabel.Visible = true;
        connectedLabel.Text = $"Connected as {UserName}";
        tbInput.Clear();
        tbInput.Enabled = true;
        tbInput.Focus();
        btnLogin.Visible = false;
        var tcpClient = new TcpClient();
        await tcpClient.ConnectAsync(IPAddress.Parse("127.0.0.1"), 9999);
        server = new App.Common.ChatClient(tcpClient);
        await server.SendAsync(UserName!);
        userLoggedIn = true;
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

    private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (userLoggedIn)
      {
        if (server is not null)
        {
          await server.SendAsync($"{UserName} has left the chat.");
          server.Dispose();
        }
      }
    }
  }
}