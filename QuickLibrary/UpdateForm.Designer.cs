namespace QuickLibrary
{
	partial class UpdateForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
			this.buttonYes = new System.Windows.Forms.Button();
			this.boxReleaseNotes = new System.Windows.Forms.CheckBox();
			this.ReleaseNotes = new System.Windows.Forms.WebBrowser();
			this.titlePanel = new System.Windows.Forms.Panel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.closeBtn = new QuickLibrary.QlibTitlebarButton();
			this.infoTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.messageTextBox = new System.Windows.Forms.TextBox();
			this.titlePanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonYes
			// 
			this.buttonYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonYes.BackColor = System.Drawing.SystemColors.ControlLight;
			this.buttonYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.buttonYes.FlatAppearance.BorderSize = 0;
			this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonYes.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.buttonYes.Location = new System.Drawing.Point(202, 118);
			this.buttonYes.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
			this.buttonYes.Name = "buttonYes";
			this.buttonYes.Size = new System.Drawing.Size(128, 32);
			this.buttonYes.TabIndex = 1;
			this.buttonYes.Text = "download";
			this.buttonYes.UseVisualStyleBackColor = false;
			// 
			// boxReleaseNotes
			// 
			this.boxReleaseNotes.Appearance = System.Windows.Forms.Appearance.Button;
			this.boxReleaseNotes.BackColor = System.Drawing.SystemColors.ControlLight;
			this.boxReleaseNotes.FlatAppearance.BorderSize = 0;
			this.boxReleaseNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.boxReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.boxReleaseNotes.Location = new System.Drawing.Point(10, 118);
			this.boxReleaseNotes.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
			this.boxReleaseNotes.Name = "boxReleaseNotes";
			this.boxReleaseNotes.Size = new System.Drawing.Size(128, 32);
			this.boxReleaseNotes.TabIndex = 0;
			this.boxReleaseNotes.Text = "whats new";
			this.boxReleaseNotes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.boxReleaseNotes.UseVisualStyleBackColor = false;
			this.boxReleaseNotes.CheckedChanged += new System.EventHandler(this.boxReleaseNotes_CheckedChanged);
			// 
			// ReleaseNotes
			// 
			this.ReleaseNotes.AllowNavigation = false;
			this.ReleaseNotes.AllowWebBrowserDrop = false;
			this.ReleaseNotes.IsWebBrowserContextMenuEnabled = false;
			this.ReleaseNotes.Location = new System.Drawing.Point(10, 160);
			this.ReleaseNotes.Margin = new System.Windows.Forms.Padding(0, 0, 9, 0);
			this.ReleaseNotes.MinimumSize = new System.Drawing.Size(20, 20);
			this.ReleaseNotes.Name = "ReleaseNotes";
			this.ReleaseNotes.ScriptErrorsSuppressed = true;
			this.ReleaseNotes.Size = new System.Drawing.Size(320, 190);
			this.ReleaseNotes.TabIndex = 3;
			this.ReleaseNotes.Visible = false;
			this.ReleaseNotes.WebBrowserShortcutsEnabled = false;
			// 
			// titlePanel
			// 
			this.titlePanel.Controls.Add(this.titleLabel);
			this.titlePanel.Controls.Add(this.closeBtn);
			this.titlePanel.Location = new System.Drawing.Point(0, 0);
			this.titlePanel.Margin = new System.Windows.Forms.Padding(0);
			this.titlePanel.Name = "titlePanel";
			this.titlePanel.Size = new System.Drawing.Size(340, 32);
			this.titlePanel.TabIndex = 8;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.titleLabel.Location = new System.Drawing.Point(10, 7);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(32, 19);
			this.titleLabel.TabIndex = 16;
			this.titleLabel.Text = "title";
			// 
			// closeBtn
			// 
			this.closeBtn.DarkImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.DarkImage")));
			this.closeBtn.DarkMode = false;
			this.closeBtn.FlatAppearance.BorderSize = 0;
			this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
			this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeBtn.ForeColor = System.Drawing.Color.Black;
			this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
			this.closeBtn.IsRed = true;
			this.closeBtn.LightImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.LightImage")));
			this.closeBtn.Location = new System.Drawing.Point(308, 0);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(32, 32);
			this.closeBtn.TabIndex = 1;
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// messageTextBox
			// 
			this.messageTextBox.BackColor = System.Drawing.SystemColors.Control;
			this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.messageTextBox.Location = new System.Drawing.Point(10, 42);
			this.messageTextBox.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.messageTextBox.Multiline = true;
			this.messageTextBox.Name = "messageTextBox";
			this.messageTextBox.Size = new System.Drawing.Size(320, 66);
			this.messageTextBox.TabIndex = 43;
			this.messageTextBox.Text = "message";
			// 
			// UpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(340, 360);
			this.Controls.Add(this.messageTextBox);
			this.Controls.Add(this.titlePanel);
			this.Controls.Add(this.buttonYes);
			this.Controls.Add(this.ReleaseNotes);
			this.Controls.Add(this.boxReleaseNotes);
			this.Draggable = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(320, 39);
			this.Name = "UpdateForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update available!";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateForm_KeyDown);
			this.titlePanel.ResumeLayout(false);
			this.titlePanel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.CheckBox boxReleaseNotes;
		private System.Windows.Forms.WebBrowser ReleaseNotes;
		private System.Windows.Forms.Button buttonYes;
		private System.Windows.Forms.Panel titlePanel;
		private System.Windows.Forms.Label titleLabel;
		private QlibTitlebarButton closeBtn;
		private System.Windows.Forms.ToolTip infoTooltip;
		private System.Windows.Forms.TextBox messageTextBox;
	}
}