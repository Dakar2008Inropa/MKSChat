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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
      this.lblUsername = new System.Windows.Forms.Label();
      this.tbName = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblUsername
      // 
      this.lblUsername.Location = new System.Drawing.Point(5, 5);
      this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(382, 22);
      this.lblUsername.TabIndex = 0;
      this.lblUsername.Text = "&Username";
      this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tbName
      // 
      this.tbName.Location = new System.Drawing.Point(5, 32);
      this.tbName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
      this.tbName.Name = "tbName";
      this.tbName.Size = new System.Drawing.Size(382, 23);
      this.tbName.TabIndex = 1;
      this.tbName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
      // 
      // btnLogin
      // 
      this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnLogin.Location = new System.Drawing.Point(5, 60);
      this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(382, 25);
      this.btnLogin.TabIndex = 2;
      this.btnLogin.Text = "&Ok";
      this.btnLogin.UseVisualStyleBackColor = true;
      // 
      // LoginForm
      // 
      this.AcceptButton = this.btnLogin;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(392, 91);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.tbName);
      this.Controls.Add(this.lblUsername);
      this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LoginForm";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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