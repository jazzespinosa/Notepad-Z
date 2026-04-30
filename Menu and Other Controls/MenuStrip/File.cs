using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for File MenuStrip items
    /// </summary>
    public partial class MainForm
    {
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDirty == true)
            {
                exitPrompt();

                if (DialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    textBoxMain.Text = String.Empty;
                    path = String.Empty;
                    this.Text = "Untitled - Notepad Z";
                }
                else if (DialogResult == DialogResult.No)
                {
                    textBoxMain.Text = String.Empty;
                    path = String.Empty;
                    this.Text = "Untitled - Notepad Z";
                }
            }
            else
            {
                textBoxMain.Text = String.Empty;
                path = String.Empty;
                this.Text = "Untitled - Notepad Z";
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string initialPath = Environment.CurrentDirectory;
            ProcessStartInfo newProcess = new ProcessStartInfo();
            newProcess.FileName = initialPath + @"\Notepad Z.exe";
            Process.Start(newProcess);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsDirty == true)
            {
                exitPrompt();

                if (DialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (DialogResult == DialogResult.No)
                {
                }
                else
                {
                    return;
                }
            }
            if (mainOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxMain.Text = String.Empty;
                textBoxMain.Text = File.ReadAllText(path = mainOpenFileDialog.FileName);

                this.Text = mainOpenFileDialog.FileName.Substring(mainOpenFileDialog.FileName.LastIndexOf('\\') + 1);

                IsDirty = false;
                TextBeforeChange = textBoxMain.Text;
            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(path = mainSaveFileDialog.FileName, textBoxMain.Text);

                string newFile = mainSaveFileDialog.FileName;
                this.Text = newFile.Substring(newFile.LastIndexOf('\\') + 1);

                IsDirty = false;
                TextBeforeChange = textBoxMain.Text;

                saveBackUp();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(path))
            {
                File.WriteAllText(path, textBoxMain.Text);

                this.Text = path.Substring(path.LastIndexOf('\\') + 1);

                IsDirty = false;
                TextBeforeChange = textBoxMain.Text;

                saveBackUp();
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void exitPrompt()
        {
            if (IsDirty == true)
            {
                DialogResult = MessageBox.Show("Do you want to save current file?",
                "Notepad Z",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            }
        }

    }
}
