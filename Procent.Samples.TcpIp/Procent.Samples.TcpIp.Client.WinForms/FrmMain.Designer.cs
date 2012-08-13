namespace Procent.Samples.TcpIp.Client.WinForms
{
	partial class FrmMain
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
			System.Windows.Forms.Label label1;
			System.Windows.Forms.SplitContainer splitContainer1;
			System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
			this.tbConversation = new System.Windows.Forms.TextBox();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.tbReceiver = new System.Windows.Forms.TextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.lblState = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			splitContainer1 = new System.Windows.Forms.SplitContainer();
			tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			label1.Dock = System.Windows.Forms.DockStyle.Fill;
			label1.Location = new System.Drawing.Point(3, 86);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(54, 37);
			label1.TabIndex = 3;
			label1.Text = "Receiver:";
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			splitContainer1.Location = new System.Drawing.Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(this.tbConversation);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
			splitContainer1.Size = new System.Drawing.Size(609, 385);
			splitContainer1.SplitterDistance = 258;
			splitContainer1.TabIndex = 5;
			// 
			// tbConversation
			// 
			this.tbConversation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbConversation.Location = new System.Drawing.Point(0, 0);
			this.tbConversation.Multiline = true;
			this.tbConversation.Name = "tbConversation";
			this.tbConversation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbConversation.Size = new System.Drawing.Size(609, 258);
			this.tbConversation.TabIndex = 0;
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 4;
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.239738F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.41544F));
			tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(label1, 0, 1);
			tableLayoutPanel1.Controls.Add(this.tbReceiver, 1, 1);
			tableLayoutPanel1.Controls.Add(this.tbMessage, 0, 0);
			tableLayoutPanel1.Controls.Add(this.btnSend, 2, 1);
			tableLayoutPanel1.Controls.Add(this.lblState, 3, 1);
			tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 2;
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
			tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
			tableLayoutPanel1.Size = new System.Drawing.Size(609, 123);
			tableLayoutPanel1.TabIndex = 6;
			// 
			// tbMessage
			// 
			tableLayoutPanel1.SetColumnSpan(this.tbMessage, 4);
			this.tbMessage.Location = new System.Drawing.Point(3, 3);
			this.tbMessage.Multiline = true;
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(603, 80);
			this.tbMessage.TabIndex = 4;
			// 
			// tbReceiver
			// 
			this.tbReceiver.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbReceiver.Location = new System.Drawing.Point(63, 89);
			this.tbReceiver.Name = "tbReceiver";
			this.tbReceiver.Size = new System.Drawing.Size(30, 20);
			this.tbReceiver.TabIndex = 1;
			this.tbReceiver.Text = "0";
			this.tbReceiver.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbReceiver_KeyPress);
			// 
			// btnSend
			// 
			this.btnSend.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btnSend.Location = new System.Drawing.Point(99, 89);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(485, 31);
			this.btnSend.TabIndex = 2;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// lblState
			// 
			this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblState.Location = new System.Drawing.Point(590, 86);
			this.lblState.Name = "lblState";
			this.lblState.Size = new System.Drawing.Size(16, 37);
			this.lblState.TabIndex = 5;
			// 
			// FrmMain
			// 
			this.AcceptButton = this.btnSend;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 385);
			this.Controls.Add(splitContainer1);
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FrmMain";
			this.Load += new System.EventHandler(this.FrmMain_Load);
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel1.PerformLayout();
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.ResumeLayout(false);
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox tbConversation;
		private System.Windows.Forms.TextBox tbReceiver;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.Label lblState;
	}
}