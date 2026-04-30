using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for TextBox Context Menu
    /// </summary>
    public partial class MainForm
    {
        private void textBoxMainContexMenuStrip_Opened(object sender, EventArgs e)
        {
            if (Clipboard.GetText(TextDataFormat.Text) == "") pasteContextMenuItem.Enabled = false;
            else pasteContextMenuItem.Enabled = true;

            if (textBoxMain.SelectionLength > 0)
            {
                cutContextMenuItem.Enabled = true;
                copyContextMenuItem.Enabled = true;
                deleteContextMenuItem.Enabled = true;
                checkFolderPathContextMenuItem.Enabled = true;
            }
            else
            {
                cutContextMenuItem.Enabled = false;
                copyContextMenuItem.Enabled = false;
                deleteContextMenuItem.Enabled = false;
                checkFolderPathContextMenuItem.Enabled = false;
            }

            if (textBoxMain.SelectionLength == textBoxMain.Text.Length) selectAllContextMenuItem.Enabled = false;
            else selectAllContextMenuItem.Enabled = true;
        }

        private void undoContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.Undo();

        private void copyContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.Copy();

        private void cutContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.Cut();

        private void pasteContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.Paste();

        private void deleteContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.SelectedText = String.Empty;

        private void selectAllContextMenuItem_Click(object sender, EventArgs e) => textBoxMain.SelectAll();

        private void checkFolderPathContextMenuItem_Click(object sender, EventArgs e)
        {
            string selectedText = textBoxMain.SelectedText.Trim();
            if (CheckIfDirectoryExists(selectedText) == true)
            {
                OpenSelectedFolderPath(selectedText);
            }
        }

        private void checkFolderPermissionsContextMenuItem_Click(object sender, EventArgs e)
        {
            string selectedText = textBoxMain.SelectedText.Trim();
            string appDirectory = Environment.CurrentDirectory + @"\Fil-Group-Lister.exe";

            if (CheckIfDirectoryExists(selectedText) == true)
            {
                OpenFileGroupLister(selectedText, appDirectory);
            }
        }

        private void checkPathAndPermissionsContextMenuItem_Click(object sender, EventArgs e)
        {
            string selectedText = textBoxMain.SelectedText.Trim();
            string appDirectory = Environment.CurrentDirectory + @"\Fil-Group-Lister.exe";
            if (CheckIfDirectoryExists(selectedText) == true)
            {
                OpenSelectedFolderPath(selectedText);
                OpenFileGroupLister(selectedText, appDirectory);
            }
        }

        private bool CheckIfDirectoryExists(string selectedText)
        {
            bool output;
            if (Directory.Exists(selectedText) == false)
            {
                MessageBox.Show($"Path \"{selectedText}\" does not exist", "Error");
                output = false;
            }
            else output = true;
            return output;
        }

        private void OpenSelectedFolderPath(string selectedText)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = selectedText,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void OpenFileGroupLister(string selectedText, string appDirectory)
        {
            if (File.Exists(appDirectory) == true)
            {
                try
                {
                    ProcessStartInfo newProcess = new ProcessStartInfo
                    {
                        Arguments = selectedText,
                        FileName = appDirectory
                    };
                    Process.Start(newProcess);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
            else MessageBox.Show("Application Fil Group Lister missing", "Error");
        }

    }
}
