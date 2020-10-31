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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.boxReleaseNotes = new System.Windows.Forms.CheckBox();
			this.ReleaseNotes = new System.Windows.Forms.WebBrowser();
			this.currentLabel = new System.Windows.Forms.Label();
			this.latestLabel = new System.Windows.Forms.Label();
			this.latestReleaseLink = new System.Windows.Forms.LinkLabel();
			this.currentVersionLink = new System.Windows.Forms.LinkLabel();
			this.browserTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.titlePanel = new System.Windows.Forms.Panel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.closeBtn = new QuickLibrary.QlibTitlebarButton();
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
			this.buttonYes.Location = new System.Drawing.Point(294, 158);
			this.buttonYes.Margin = new System.Windows.Forms.Padding(0);
			this.buttonYes.Name = "buttonYes";
			this.buttonYes.Size = new System.Drawing.Size(96, 32);
			this.buttonYes.TabIndex = 1;
			this.buttonYes.Text = "Download";
			this.buttonYes.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label1.Location = new System.Drawing.Point(10, 42);
			this.label1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "There is a new version of {0} available!";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.label2.Location = new System.Drawing.Point(10, 71);
			this.label2.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(228, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Would you like to download it now?";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// boxReleaseNotes
			// 
			this.boxReleaseNotes.Appearance = System.Windows.Forms.Appearance.Button;
			this.boxReleaseNotes.BackColor = System.Drawing.SystemColors.ControlLight;
			this.boxReleaseNotes.FlatAppearance.BorderSize = 0;
			this.boxReleaseNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.boxReleaseNotes.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.boxReleaseNotes.Location = new System.Drawing.Point(10, 158);
			this.boxReleaseNotes.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
			this.boxReleaseNotes.Name = "boxReleaseNotes";
			this.boxReleaseNotes.Size = new System.Drawing.Size(96, 32);
			this.boxReleaseNotes.TabIndex = 0;
			this.boxReleaseNotes.Text = "What\'s new?";
			this.boxReleaseNotes.UseVisualStyleBackColor = false;
			this.boxReleaseNotes.CheckedChanged += new System.EventHandler(this.boxReleaseNotes_CheckedChanged);
			// 
			// ReleaseNotes
			// 
			this.ReleaseNotes.AllowNavigation = false;
			this.ReleaseNotes.AllowWebBrowserDrop = false;
			this.ReleaseNotes.IsWebBrowserContextMenuEnabled = false;
			this.ReleaseNotes.Location = new System.Drawing.Point(10, 200);
			this.ReleaseNotes.Margin = new System.Windows.Forms.Padding(0, 0, 9, 0);
			this.ReleaseNotes.MinimumSize = new System.Drawing.Size(20, 20);
			this.ReleaseNotes.Name = "ReleaseNotes";
			this.ReleaseNotes.ScriptErrorsSuppressed = true;
			this.ReleaseNotes.Size = new System.Drawing.Size(380, 190);
			this.ReleaseNotes.TabIndex = 3;
			this.ReleaseNotes.Visible = false;
			this.ReleaseNotes.WebBrowserShortcutsEnabled = false;
			// 
			// currentLabel
			// 
			this.currentLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.currentLabel.AutoSize = true;
			this.currentLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.currentLabel.Location = new System.Drawing.Point(10, 100);
			this.currentLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.currentLabel.Name = "currentLabel";
			this.currentLabel.Size = new System.Drawing.Size(107, 19);
			this.currentLabel.TabIndex = 4;
			this.currentLabel.Text = "Current version:";
			this.currentLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// latestLabel
			// 
			this.latestLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.latestLabel.AutoSize = true;
			this.latestLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.latestLabel.Location = new System.Drawing.Point(10, 129);
			this.latestLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.latestLabel.Name = "latestLabel";
			this.latestLabel.Size = new System.Drawing.Size(95, 19);
			this.latestLabel.TabIndex = 5;
			this.latestLabel.Text = "Latest release:";
			this.latestLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// latestReleaseLink
			// 
			this.latestReleaseLink.AutoSize = true;
			this.latestReleaseLink.Location = new System.Drawing.Point(105, 129);
			this.latestReleaseLink.Margin = new System.Windows.Forms.Padding(0);
			this.latestReleaseLink.Name = "latestReleaseLink";
			this.latestReleaseLink.Size = new System.Drawing.Size(46, 19);
			this.latestReleaseLink.TabIndex = 6;
			this.latestReleaseLink.TabStop = true;
			this.latestReleaseLink.Text = "v0.0.0";
			this.browserTooltip.SetToolTip(this.latestReleaseLink, "Open release page in browser");
			this.latestReleaseLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.latestReleaseLink_LinkClicked);
			// 
			// currentVersionLink
			// 
			this.currentVersionLink.AutoSize = true;
			this.currentVersionLink.Location = new System.Drawing.Point(117, 100);
			this.currentVersionLink.Margin = new System.Windows.Forms.Padding(0);
			this.currentVersionLink.Name = "currentVersionLink";
			this.currentVersionLink.Size = new System.Drawing.Size(46, 19);
			this.currentVersionLink.TabIndex = 7;
			this.currentVersionLink.TabStop = true;
			this.currentVersionLink.Text = "v0.0.0";
			this.browserTooltip.SetToolTip(this.currentVersionLink, "Open release page in browser");
			this.currentVersionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.currentVersionLink_LinkClicked);
			// 
			// titlePanel
			// 
			this.titlePanel.Controls.Add(this.titleLabel);
			this.titlePanel.Controls.Add(this.closeBtn);
			this.titlePanel.Location = new System.Drawing.Point(0, 0);
			this.titlePanel.Margin = new System.Windows.Forms.Padding(0);
			this.titlePanel.Name = "titlePanel";
			this.titlePanel.Size = new System.Drawing.Size(400, 32);
			this.titlePanel.TabIndex = 8;
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.titleLabel.Location = new System.Drawing.Point(10, 7);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(114, 19);
			this.titleLabel.TabIndex = 16;
			this.titleLabel.Text = "Update available!";
			// 
			// closeBtn
			// 
			this.closeBtn.DarkImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.DarkImage")));
			this.closeBtn.FlatAppearance.BorderSize = 0;
			this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
			this.closeBtn.IsRed = true;
			this.closeBtn.LightImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.LightImage")));
			this.closeBtn.Location = new System.Drawing.Point(368, 0);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(32, 32);
			this.closeBtn.TabIndex = 1;
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// UpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(400, 400);
			this.Controls.Add(this.titlePanel);
			this.Controls.Add(this.currentVersionLink);
			this.Controls.Add(this.latestReleaseLink);
			this.Controls.Add(this.latestLabel);
			this.Controls.Add(this.buttonYes);
			this.Controls.Add(this.ReleaseNotes);
			this.Controls.Add(this.currentLabel);
			this.Controls.Add(this.boxReleaseNotes);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox boxReleaseNotes;
		private System.Windows.Forms.WebBrowser ReleaseNotes;
		private System.Windows.Forms.Button buttonYes;
		private System.Windows.Forms.Label latestLabel;
		private System.Windows.Forms.Label currentLabel;
		private System.Windows.Forms.LinkLabel latestReleaseLink;
		private System.Windows.Forms.LinkLabel currentVersionLink;
		private System.Windows.Forms.ToolTip browserTooltip;
		private System.Windows.Forms.Panel titlePanel;
		private System.Windows.Forms.Label titleLabel;
		private QlibTitlebarButton closeBtn;
	}
}