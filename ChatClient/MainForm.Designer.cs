namespace ChatClient
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btnLogin = new System.Windows.Forms.Button();
      this.tbInput = new System.Windows.Forms.TextBox();
      this.tbChatbox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(12, 12);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(75, 23);
      this.btnLogin.TabIndex = 0;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // tbInput
      // 
      this.tbInput.AcceptsReturn = true;
      this.tbInput.Location = new System.Drawing.Point(12, 415);
      this.tbInput.Name = "tbInput";
      this.tbInput.Size = new System.Drawing.Size(776, 23);
      this.tbInput.TabIndex = 1;
      this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
      // 
      // tbChatbox
      // 
      this.tbChatbox.Location = new System.Drawing.Point(12, 41);
      this.tbChatbox.Multiline = true;
      this.tbChatbox.Name = "tbChatbox";
      this.tbChatbox.Size = new System.Drawing.Size(776, 368);
      this.tbChatbox.TabIndex = 2;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.tbChatbox);
      this.Controls.Add(this.tbInput);
      this.Controls.Add(this.btnLogin);
      this.Name = "MainForm";
      this.Text = "MainForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private Button btnLogin;
    private TextBox tbInput;
    private TextBox tbChatbox;
  }
}