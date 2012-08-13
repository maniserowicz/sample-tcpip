namespace Procent.Samples.TcpIp.Client.WinForms
{
	partial class FrmLogin
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
			this.tbId = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbId
			// 
			this.tbId.Location = new System.Drawing.Point(12, 12);
			this.tbId.Name = "tbId";
			this.tbId.Size = new System.Drawing.Size(100, 20);
			this.tbId.TabIndex = 0;
			this.tbId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbId_KeyPress);
			this.tbId.Validating += new System.ComponentModel.CancelEventHandler(this.tbValidation_NumberEntered);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(12, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(12, 38);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(100, 20);
			this.tbPassword.TabIndex = 2;
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(117, 94);
			this.ControlBox = false;
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.tbId);
			this.Name = "FrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbId;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox tbPassword;
	}
}