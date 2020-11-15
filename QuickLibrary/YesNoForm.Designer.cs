namespace QuickLibrary
{
	partial class YesNoForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YesNoForm));
			this.yesBtn = new System.Windows.Forms.Button();
			this.infoTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.titleLabel = new System.Windows.Forms.Label();
			this.closeBtn = new QuickLibrary.QlibTitlebarButton();
			this.textBox = new System.Windows.Forms.TextBox();
			this.noBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// yesBtn
			// 
			this.yesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.yesBtn.BackColor = System.Drawing.SystemColors.ControlLight;
			this.yesBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.yesBtn.FlatAppearance.BorderSize = 0;
			this.yesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.yesBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.yesBtn.Location = new System.Drawing.Point(10, 116);
			this.yesBtn.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.yesBtn.Name = "yesBtn";
			this.yesBtn.Size = new System.Drawing.Size(260, 32);
			this.yesBtn.TabIndex = 0;
			this.yesBtn.Text = "yes";
			this.yesBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.yesBtn.UseVisualStyleBackColor = false;
			this.yesBtn.Click += new System.EventHandler(this.yesBtn_Click);
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
			this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.closeBtn.DarkImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.DarkImage")));
			this.closeBtn.FlatAppearance.BorderSize = 0;
			this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
			this.closeBtn.IsRed = true;
			this.closeBtn.LightImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.LightImage")));
			this.closeBtn.Location = new System.Drawing.Point(248, 0);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(32, 32);
			this.closeBtn.TabIndex = 3;
			this.closeBtn.UseVisualStyleBackColor = true;
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Location = new System.Drawing.Point(10, 42);
			this.textBox.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(260, 64);
			this.textBox.TabIndex = 4;
			this.textBox.Text = "message";
			// 
			// noBtn
			// 
			this.noBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.noBtn.BackColor = System.Drawing.SystemColors.ControlLight;
			this.noBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.noBtn.FlatAppearance.BorderSize = 0;
			this.noBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.noBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.noBtn.Location = new System.Drawing.Point(10, 158);
			this.noBtn.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.noBtn.Name = "noBtn";
			this.noBtn.Size = new System.Drawing.Size(260, 32);
			this.noBtn.TabIndex = 1;
			this.noBtn.Text = "no";
			this.noBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.noBtn.UseVisualStyleBackColor = false;
			this.noBtn.Visible = false;
			this.noBtn.Click += new System.EventHandler(this.noBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cancelBtn.BackColor = System.Drawing.SystemColors.ControlLight;
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.cancelBtn.FlatAppearance.BorderSize = 0;
			this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cancelBtn.Location = new System.Drawing.Point(10, 200);
			this.cancelBtn.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.Size = new System.Drawing.Size(260, 32);
			this.cancelBtn.TabIndex = 2;
			this.cancelBtn.Text = "cancel";
			this.cancelBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cancelBtn.UseVisualStyleBackColor = false;
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// YesNoForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(280, 242);
			this.CloseButton = this.closeBtn;
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.cancelBtn);
			this.Controls.Add(this.noBtn);
			this.Controls.Add(this.textBox);
			this.Controls.Add(this.yesBtn);
			this.Draggable = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "YesNoForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update available!";
			this.TitleLabel = this.titleLabel;
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UpdateForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button yesBtn;
		private System.Windows.Forms.ToolTip infoTooltip;
		private System.Windows.Forms.Label titleLabel;
		private QlibTitlebarButton closeBtn;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Button noBtn;
		private System.Windows.Forms.Button cancelBtn;
	}
}