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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.btnLogin = new System.Windows.Forms.Button();
      this.tbInput = new System.Windows.Forms.TextBox();
      this.tbChatbox = new System.Windows.Forms.TextBox();
      this.connectedLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnLogin
      // 
      this.btnLogin.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btnLogin.Location = new System.Drawing.Point(8, 5);
      this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(784, 34);
      this.btnLogin.TabIndex = 0;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
      // 
      // tbInput
      // 
      this.tbInput.AcceptsReturn = true;
      this.tbInput.Enabled = false;
      this.tbInput.Location = new System.Drawing.Point(8, 415);
      this.tbInput.Name = "tbInput";
      this.tbInput.Size = new System.Drawing.Size(784, 23);
      this.tbInput.TabIndex = 1;
      this.tbInput.Text = "You must login to start chatting...";
      this.tbInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.tbInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInput_KeyDown);
      // 
      // tbChatbox
      // 
      this.tbChatbox.Location = new System.Drawing.Point(8, 45);
      this.tbChatbox.Multiline = true;
      this.tbChatbox.Name = "tbChatbox";
      this.tbChatbox.Size = new System.Drawing.Size(784, 364);
      this.tbChatbox.TabIndex = 2;
      // 
      // connectedLabel
      // 
      this.connectedLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.connectedLabel.ForeColor = System.Drawing.Color.Green;
      this.connectedLabel.Location = new System.Drawing.Point(8, 5);
      this.connectedLabel.Name = "connectedLabel";
      this.connectedLabel.Size = new System.Drawing.Size(784, 34);
      this.connectedLabel.TabIndex = 3;
      this.connectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.connectedLabel.Visible = false;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 445);
      this.Controls.Add(this.tbChatbox);
      this.Controls.Add(this.tbInput);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.connectedLabel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MainForm";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Chat";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

        #endregion

        private Button btnLogin;
    private TextBox tbInput;
    private TextBox tbChatbox;
        private Label connectedLabel;
    }
}