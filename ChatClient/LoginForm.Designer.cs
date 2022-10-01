namespace ChatClient
{
  partial class LoginForm
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.lblUsername = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Location = new System.Drawing.Point(12, 16);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(60, 15);
      this.lblUsername.TabIndex = 0;
      this.lblUsername.Text = "&Username";
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(12, 34);
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(238, 23);
      this.tbName.TabIndex = 1;
      this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
      // 
      // btnLogin
      // 
      this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnLogin.Location = new System.Drawing.Point(256, 34);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(75, 23);
      this.btnLogin.TabIndex = 2;
      this.btnLogin.Text = "&Ok";
      this.btnLogin.UseVisualStyleBackColor = true;
      // 
      // LoginForm
      // 
      this.AcceptButton = this.btnLogin;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(343, 75);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.tbName);
      this.Controls.Add(this.lblUsername);
      this.Name = "LoginForm";
      this.Text = "Login";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Label lblUsername;
    private TextBox tbName;
    private Button btnLogin;
  }
}