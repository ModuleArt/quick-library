namespace QuickLibrary
{
	partial class DownloadForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadForm));
			this.progressBar1 = new QuickLibrary.QlibProgressBar();
			this.statusLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.updateButton = new System.Windows.Forms.Button();
			this.closeBtn = new QuickLibrary.QlibTitlebarButton();
			this.titleLabel = new System.Windows.Forms.Label();
			this.infoTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.DarkMode = false;
			this.progressBar1.Location = new System.Drawing.Point(10, 71);
			this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(320, 23);
			this.progressBar1.TabIndex = 3;
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(10, 42);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 10);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(135, 19);
			this.statusLabel.TabIndex = 14;
			this.statusLabel.Text = "downloading update";
			// 
			// cancelButton
			// 
			this.cancelButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatAppearance.BorderSize = 0;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelButton.Location = new System.Drawing.Point(175, 104);
			this.cancelButton.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(155, 32);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "cancel";
			this.cancelButton.UseVisualStyleBackColor = false;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// updateButton
			// 
			this.updateButton.BackColor = System.Drawing.SystemColors.ControlLight;
			this.updateButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.updateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.updateButton.FlatAppearance.BorderSize = 0;
			this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.updateButton.Location = new System.Drawing.Point(10, 104);
			this.updateButton.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.updateButton.Name = "updateButton";
			this.updateButton.Size = new System.Drawing.Size(155, 32);
			this.updateButton.TabIndex = 0;
			this.updateButton.Text = "install";
			this.updateButton.UseVisualStyleBackColor = false;
			this.updateButton.Visible = false;
			this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
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
			this.closeBtn.TabIndex = 2;
			this.closeBtn.UseVisualStyleBackColor = true;
			this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
			// 
			// titleLabel
			// 
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.titleLabel.Location = new System.Drawing.Point(10, 7);
			this.titleLabel.Margin = new System.Windows.Forms.Padding(0);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(64, 19);
			this.titleLabel.TabIndex = 17;
			this.titleLabel.Text = "updating";
			// 
			// DownloadForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(340, 148);
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.updateButton);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.progressBar1);
			this.Draggable = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DownloadForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update downloader";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadForm_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private QlibProgressBar progressBar1;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button updateButton;
		private System.Windows.Forms.Label titleLabel;
		private QlibTitlebarButton closeBtn;
		private System.Windows.Forms.ToolTip infoTooltip;
	}
}