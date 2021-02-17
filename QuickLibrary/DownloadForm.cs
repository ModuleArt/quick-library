using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace QuickLibrary
{
    public partial class DownloadForm : QlibFixedForm
    {
        private string fileName;
        private WebClient wc;

        private string downloading;
        private string readyToInstall;
        private string failed;

        public DownloadForm(string url, bool darkMode, string updating, string downloading, string readyToInstall, string failed, string install)
        {
            if (darkMode)
            {
                HandleCreated += new EventHandler(ThemeMan.formHandleCreated);
            }

            fileName = Path.Combine(GetDownloadFolderPath(), System.IO.Path.GetFileName(url));
            this.downloading = downloading;
            this.readyToInstall = readyToInstall;
            this.failed = failed;

            InitializeComponent();
            (new DropShadow()).ApplyShadows(this);
            SetDraggableControls(new List<Control>() { titleLabel, statusLabel });

            titleLabel.Text = updating;
            statusLabel.Text = downloading;
            updateButton.Text = install;
            cancelButton.Text = NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCANCEL);

            infoTooltip.SetToolTip(closeBtn, NativeMan.GetMessageBoxText(NativeMan.DialogBoxCommandID.IDCLOSE) + " | Alt+F4");

            DarkMode = darkMode;
            closeBtn.DarkMode = darkMode;
            progressBar1.DarkMode = darkMode;
            if (darkMode)
            {
                cancelButton.BackColor = ThemeMan.DarkSecondColor;
                updateButton.BackColor = ThemeMan.DarkSecondColor;  
            }

            wc = new WebClient();

            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;

            wc.DownloadFileAsync(new Uri(url), fileName);
        }

        private string GetDownloadFolderPath()
        {
            try
            {
                return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            }
            catch
            {
                return "";
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            statusLabel.Text = string.Format(downloading + " {0}% ({1} / {2})", e.ProgressPercentage, BytesToSize(e.BytesReceived), BytesToSize(e.TotalBytesToReceive));
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled)
            {
                statusLabel.Text = failed;
            }
            else
            {
                updateButton.Visible = true;
                statusLabel.Text = readyToInstall;
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            Process.Start(fileName);
            Close();
            Owner.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            wc.CancelAsync();
        }

        private void DownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wc.CancelAsync();
        }

        private string BytesToSize(double len)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return String.Format("{0:0.#} {1}", len, sizes[order]);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
