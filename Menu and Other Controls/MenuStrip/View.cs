using Notepad_Z.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for View MenuStrip items
    /// </summary>
    public partial class MainForm
    {
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
            textBoxMain.WordWrap = wordWrapToolStripMenuItem.Checked;
            textBoxMain.ScrollBars = wordWrapToolStripMenuItem.Checked ? ScrollBars.Vertical : ScrollBars.Both;
            wordWrapStripStatusLabel.Text = wordWrapToolStripMenuItem.Checked ? "WW: ON" : "WW: OFF";

            Settings.Default.wordWrap = wordWrapToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBarToolStripMenuItem.Checked = !statusBarToolStripMenuItem.Checked;
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;

            Settings.Default.statusBar = statusBarToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainFontDialog.Font = TextFont;

            if (mainFontDialog.ShowDialog() == DialogResult.OK)
            {
                //textBoxMain.Font = new Font(mainFontDialog.Font, mainFontDialog.Font.Style);
                textBoxMain.ForeColor = mainFontDialog.Color;

                TextFont = mainFontDialog.Font;
                TextFontSize = mainFontDialog.Font.Size;
                TextFontStyle = mainFontDialog.Font.Style;

                UpdateFontAndZoomContent();
            }
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomMultiplier += (float)0.1;
            validateZoom();
            UpdateFontAndZoomContent();
            UpdateZoomStatusLabel();
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomMultiplier -= (float)0.1;
            validateZoom();
            UpdateFontAndZoomContent();
            UpdateZoomStatusLabel();
        }

        private void resetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZoomMultiplier = 1;
            UpdateFontAndZoomContent();
            UpdateZoomStatusLabel();
        }

        /// <summary>
        /// Subscribes or unsubscribes the mouse wheel event handler for the main text box.
        /// </summary>
        /// <remarks>If the subscription is enabled, the method ensures that the event handler is added
        /// only once.  If disabled, the event handler is removed.</remarks>
        /// <param name="enabled">A value indicating whether to enable or disable the subscription.  Pass <see langword="true"/> to subscribe
        /// to the mouse wheel event; otherwise, <see langword="false"/>.</param>
        private void Subscribe(bool enabled)
        {
            if (!enabled) textBoxMain.MouseWheel -= MyMouseWheel;
            else if (!mSubscribed) textBoxMain.MouseWheel += MyMouseWheel;

            mSubscribed = enabled;
        }

        private void MyMouseWheel(object sender, MouseEventArgs e)
        {
            int mousedeltaval = e.Delta / 120;
            float x = (float)mousedeltaval / 10;
            ZoomMultiplier += x;

            validateZoom();
            UpdateFontAndZoomContent();
            UpdateZoomStatusLabel();
        }

        private void validateZoom()
        {
            if (ZoomMultiplier <= 0.1)
            {
                ZoomMultiplier = (float)0.1;
            }
            else if (ZoomMultiplier >= 5)
            {
                ZoomMultiplier = (float)5;
            }
        }

        private void UpdateZoomStatusLabel()
        {
            zoomStripStatusLabel.Text = $"{Math.Round(ZoomMultiplier * 100, 0, MidpointRounding.ToEven)} %";
        }

        private void UpdateFontAndZoomContent()
        {
            textBoxMain.Font = new Font(TextFont.FontFamily, (TextFontSize * ZoomMultiplier), TextFontStyle);
        }

    }
}
