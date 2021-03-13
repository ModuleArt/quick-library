namespace QuickLibrary
{
	partial class OkForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OkForm));
			this.infoTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.titleLabel = new System.Windows.Forms.Label();
			this.closeBtn = new QuickLibrary.QlibTitlebarButton();
			this.textBox = new System.Windows.Forms.TextBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
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
			this.closeBtn.DarkMode = false;
			this.closeBtn.FlatAppearance.BorderSize = 0;
			this.closeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
			this.closeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
			this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.closeBtn.ForeColor = System.Drawing.Color.Black;
			this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
			this.closeBtn.IsRed = true;
			this.closeBtn.LightImage = ((System.Drawing.Image)(resources.GetObject("closeBtn.LightImage")));
			this.closeBtn.Location = new System.Drawing.Point(248, 0);
			this.closeBtn.Margin = new System.Windows.Forms.Padding(0);
			this.closeBtn.Name = "closeBtn";
			this.closeBtn.Size = new System.Drawing.Size(32, 32);
			this.closeBtn.TabIndex = 1;
			this.closeBtn.UseVisualStyleBackColor = true;
			// 
			// textBox
			// 
			this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox.BackColor = System.Drawing.SystemColors.Control;
			this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox.Location = new System.Drawing.Point(10, 42);
			this.textBox.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.Size = new System.Drawing.Size(260, 64);
			this.textBox.TabIndex = 2;
			this.textBox.Text = "message";
			// 
			// okBtn
			// 
			this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.okBtn.BackColor = System.Drawing.SystemColors.ControlLight;
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.okBtn.FlatAppearance.BorderSize = 0;
			this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.okBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.okBtn.Location = new System.Drawing.Point(10, 116);
			this.okBtn.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
			this.okBtn.Name = "okBtn";
			this.okBtn.Size = new System.Drawing.Size(260, 32);
			this.okBtn.TabIndex = 0;
			this.okBtn.Text = "ok";
			this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.okBtn.UseVisualStyleBackColor = false;
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// OkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.ClientSize = new System.Drawing.Size(280, 158);
			this.CloseButton = this.closeBtn;
			this.Controls.Add(this.closeBtn);
			this.Controls.Add(this.titleLabel);
			this.Controls.Add(this.okBtn);
			this.Controls.Add(this.textBox);
			this.Draggable = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OkForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Update available!";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OkForm_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolTip infoTooltip;
		private System.Windows.Forms.Label titleLabel;
		private QlibTitlebarButton closeBtn;
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.Button okBtn;
	}
}