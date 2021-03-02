using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QuickLibrary
{
	public class QlibFixedForm : Form
	{
		#region PRIVATE FIELDS

		private bool darkMode = false;
		private bool alternativeAppearance = false;
		private Color customBackColor = Color.White;
		private bool usePadding = true;
		private Button closeBtn = null;

		#endregion

		#region HIDDEN PROPS

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool ControlBox { get { return base.ControlBox; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new FormBorderStyle FormBorderStyle { get { return base.FormBorderStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new AutoScaleMode AutoScaleMode { get { return base.AutoScaleMode; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool HelpButton { get { return base.HelpButton; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoScroll { get { return base.AutoScroll; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size AutoScrollMargin { get { return base.AutoScrollMargin; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Size AutoScrollMinSize { get { return base.AutoScrollMinSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool AutoSize { get { return base.AutoSize; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new AutoSizeMode AutoSizeMode { get { return base.AutoSizeMode; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Image BackgroundImage { get { return base.BackgroundImage; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Font Font { get { return base.Font; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color ForeColor { get { return base.ForeColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor { get { return base.BackColor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new RightToLeft RightToLeft { get { return base.RightToLeft; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool RightToLeftLayout { get { return base.RightToLeftLayout; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new SizeGripStyle SizeGripStyle { get { return base.SizeGripStyle; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new IButtonControl AcceptButton { get { return base.AcceptButton; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new IButtonControl CancelButton { get { return base.CancelButton; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool KeyPreview { get { return base.KeyPreview; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding { get { return base.Padding; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool UseWaitCursor { get { return base.UseWaitCursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new Cursor Cursor { get { return base.Cursor; } set { } }

		[Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
		public new bool CausesValidation { get { return base.CausesValidation; } set { } }

		#endregion

		#region PUBLIC PROPS

		[Category("Qlib props"), Browsable(true), Description("Custom back color")]
		public Color CustomBackColor 
		{
			get { return customBackColor; }
			set 
			{
				customBackColor = value;
				base.BackColor = value;
			}
		}

		[Category("Qlib props"), Browsable(true), Description("Custom back color")]
		public bool CustomBack { get; set; } = false;

		[Category("Qlib props"), Browsable(true), Description("Draggable form")]
		public bool Draggable { get; set; } = false;

		[Category("Qlib props"), Browsable(true), Description("Title label")]
		public Label TitleLabel { get; set; } = null;

		[Category("Qlib props"), Browsable(true), Description("Close button")]
		public Button CloseButton 
		{ 
			get { return closeBtn; }
			set { SetCloseButton(value); }
		}

		[Category("Qlib props"), Browsable(true), Description("Dark mode")]
		public bool DarkMode
		{
			get { return darkMode; }
			set { SetDarkMode(value, alternativeAppearance); }
		}

		[Category("Qlib props"), Browsable(true), Description("Alternative appearance")]

		public bool AlternativeAppearance
		{
			get { return alternativeAppearance; }
			set { SetDarkMode(darkMode, value); }
		}

		[Category("Qlib props"), Browsable(true), Description("Use padding")]
		public bool UsePadding
		{
			get { return usePadding; }
			set 
			{
				usePadding = value;
				if (value)
				{
					base.Padding = new Padding(10);
				}
				else
				{
					base.Padding = new Padding(0);
				}
			}
		}

		#endregion

		#region CONSTRUCTOR

		public QlibFixedForm()
		{
			base.FormBorderStyle = FormBorderStyle.None;
			base.AutoScaleMode = AutoScaleMode.Dpi;
			base.HelpButton = false;
			base.AutoScroll = false;
			base.AutoScrollMargin = Size.Empty;
			base.AutoScrollMinSize = Size.Empty;
			base.AutoSize = false;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.BackgroundImage = null;
			base.BackgroundImageLayout = ImageLayout.Tile;
			base.Font = ThemeMan.DefaultFont;
			base.KeyPreview = true;
			base.CancelButton = null;
			base.AcceptButton = null;
			base.SizeGripStyle = SizeGripStyle.Hide;
			base.RightToLeft = RightToLeft.No;
			base.RightToLeftLayout = false;
			base.Padding = new Padding(10);
			base.UseWaitCursor = false;
			base.Cursor = Cursors.Default;
			base.BackColor = ThemeMan.LightBackColor;
			base.ForeColor = Color.Black;
			base.CausesValidation = false;

			TextChanged += QlibFixedForm_TextChanged;
		}

		#endregion

		#region PRIVATE BODY

		protected override void OnLoad(EventArgs e)
		{
			SetDarkMode(DarkMode, AlternativeAppearance);
			base.OnLoad(e);
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			(new DropShadow()).ApplyShadows(this);
			base.OnHandleCreated(e);
		}

		private void QlibFixedForm_TextChanged(object sender, EventArgs e)
		{
			if (TitleLabel != null) 
			{
				TitleLabel.Text = Text;
			}
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

			if (e.Button == MouseButtons.Left && Draggable)
			{
				GoDrag();
			}
		}

		private void GoDrag()
		{
			NativeMan.DragWindow(Handle);
		}

		private void SetCloseButton(Button btn)
		{
			if (btn == null)
			{
				closeBtn = null;
			}
			else
			{
				if (closeBtn == null)
				{
					closeBtn = btn;
					closeBtn.Click += CloseBtn_Click;
				}
				else
				{
					closeBtn.Click -= CloseBtn_Click;
					closeBtn = btn;
				}
			}
		}

		private void CloseBtn_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void SetDarkMode(bool dark, bool alternative)
		{
			HandleCreated += new EventHandler(ThemeMan.formHandleCreated);

			darkMode = dark;
			alternativeAppearance = alternative;

			if (dark)
			{
				base.ForeColor = Color.White;

				if (CustomBack)
				{
					base.BackColor = customBackColor;
				}
				else if (alternative)
				{
					base.BackColor = ThemeMan.DarkMainColor;
				}
				else
				{
					base.BackColor = ThemeMan.DarkBackColor;
				}
			}
			else
			{
				base.ForeColor = Color.Black;

				if (CustomBack)
				{
					base.BackColor = customBackColor;
				}
				else if (alternative)
				{
					base.BackColor = ThemeMan.LightMainColor;
				}
				else
				{
					base.BackColor = ThemeMan.LightBackColor;
				}
			}
		}

		#endregion
	}
}
