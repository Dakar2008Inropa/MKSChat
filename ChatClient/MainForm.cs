using App.Common;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace ChatClient
{
  public partial class MainForm : Form
  {
    private ILogger<MainForm> _logger;
    NetworkClient? server { get; set; }

    public MainForm(ILogger<MainForm> logger)
    {
      _logger = logger;
      InitializeComponent();
    }

    public string? UserName { get; private set; }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
      var loginForm = new LoginForm();
      if (loginForm.ShowDialog() == DialogResult.OK)
      {
        UserName = loginForm.UserName;

        const string ipString = "127.0.0.1";
        try
        {
          server = await NetworkClient.ConnectAsync(_logger, IPAddress.Parse(ipString), 9999);
          await server.SendAsync(UserName!);
          connectedLabel.Visible = true;
          connectedLabel.Text = $"Connected as {UserName}";
          tbInput.Clear();
          tbInput.Enabled = true;
          tbInput.Focus();
          btnLogin.Visible = false;
          while (true)
          {
            var message = await server.ReceiveAsync();
            if (!string.IsNullOrEmpty(message))
              tbChatbox.AppendText(message + Environment.NewLine);
            await Task.Delay(100);
          }

        }
        catch (Exception ex)
        {
          _logger.LogError("Error connecting to {ipString} ({message})", ipString, ex.Message);
          MessageBox.Show($"Error connecting to {ipString} ({ex.Message})");
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