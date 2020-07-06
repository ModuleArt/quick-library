﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibFixedForm : Form
	{
		public bool draggable = false;

		[Browsable(false), Obsolete("Don't use this! (FormBorderStyle = None)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum FormBorderStyle { };

		[Browsable(false), Obsolete("Don't use this! (AutoScaleMode = Dpi)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScaleMode { };

		[Browsable(false), Obsolete("Don't use this! (HelpButton = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum HelpButton { };
		[Browsable(false), Obsolete("Don't use this! (AutoScroll = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScroll { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMargin = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMargin { };

		[Browsable(false), Obsolete("Don't use this! (AutoScrollMinSize = [0, 0])", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoScrollMinSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSize = false)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSize { };

		[Browsable(false), Obsolete("Don't use this! (AutoSizeMode = GrowAndShrink)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum AutoSizeMode { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImage = None)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImage { };

		[Browsable(false), Obsolete("Don't use this! (BackgroundImageLayout = Tile)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum BackgroundImageLayout { };

		[Browsable(false), Obsolete("Don't use this! (Font = ThemeManager.DefaultFont)", true), EditorBrowsable(EditorBrowsableState.Never)]
		public new enum Font { };

		protected override CreateParams CreateParams
		{
			get
			{
				const int CS_DROPSHADOW = 0x20000;
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}

		public QlibFixedForm() 
		{
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.HelpButton = false;
			base.AutoScroll = false;
			base.AutoScrollMargin = new System.Drawing.Size(0, 0);
			base.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			base.AutoSize = false;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.Font = ThemeManager.DefaultFont;
		}

		public void SetDraggableControls(List<Control> controls)
		{
			foreach (Control control in controls)
			{
				control.MouseDown += Control_MouseDown;
			}
		}

		private void Control_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				GoDrag();
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (draggable && e.Button == MouseButtons.Left)
			{
				GoDrag();
			}
		}

		private void GoDrag()
		{
			Cursor.Current = Cursors.SizeAll;
			NativeMethodsManager.ReleaseCapture();
			NativeMethodsManager.SendMessage(Handle, 0xA1, 0x2, 0);
		}
	}
}
