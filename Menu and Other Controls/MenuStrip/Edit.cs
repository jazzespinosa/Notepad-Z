using System;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for Edit MenuStrip items
    /// </summary>
    public partial class MainForm
    {
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetText(TextDataFormat.Text) == "") pasteToolStripMenuItem.Enabled = false;
            else pasteToolStripMenuItem.Enabled = true;

            if (textBoxMain.SelectionLength > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
            }

            if (textBoxMain.SelectionLength == textBoxMain.Text.Length) selectAllToolStripMenuItem.Enabled = false;
            else selectAllToolStripMenuItem.Enabled = true;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.Undo();

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.Cut();

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.Copy();

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.Paste();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.SelectedText = String.Empty;

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFindAndReplaceControl(false);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFindAndReplaceControl(true);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => textBoxMain.SelectAll();

        private void OpenFindAndReplaceControl(bool isFindAndReplace)
        {
            findAndReplacePopup.toggleExpandCollapse.Checked = isFindAndReplace;
            findAndReplacePopup.Visible = true;

            findAndReplacePopup.Focus();
        }

    }
}
