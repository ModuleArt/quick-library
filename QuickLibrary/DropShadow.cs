using System;
using System.Windows.Forms;

namespace QuickLibrary
{
    internal class DropShadow
    {
        internal void ApplyShadows(Form form)
        {
            var v = 2;
            NativeMan.DwmSetWindowAttribute(form.Handle, 2, ref v, 4);

            NativeMan.MARGINS margins = new NativeMan.MARGINS()
            {
                Bottom = 1,
                Left = 1,
                Right = 1,
                Top = 1
            };

            NativeMan.DwmExtendFrameIntoClientArea(form.Handle, ref margins);
        }
    }
}