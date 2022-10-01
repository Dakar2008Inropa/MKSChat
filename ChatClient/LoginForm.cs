namespace ChatClient
{
  public partial class LoginForm : Form
  {
    public LoginForm()
    {
      InitializeComponent();
    }

    public string? UserName { get; set; }

    private void tbName_TextChanged(object sender, EventArgs e)
    {
      UserName = tbName.Text;
    }
  }
}