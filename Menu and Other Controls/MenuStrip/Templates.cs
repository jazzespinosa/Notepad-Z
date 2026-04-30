using Notepad_Z.Properties;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for Templates MenuStrip items
    /// </summary>
    public partial class MainForm
    {
        private void templateToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTemplateFromComboBox();
            templateToolStripComboBox.SelectedItem = null;
        }

        private void lineBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(LineBreak))
            {
                textBoxMain.Paste(LineBreak);
            }
        }

        private void LoadConfig()
        {
            string initialPath = Environment.CurrentDirectory;
            string templateFilePath = initialPath + @"\config\templates.xlsx";
            string lineBreakFilePath = initialPath + @"\config\linebreak.txt";
            string configFolder = initialPath + @"\config";

            if (Directory.Exists(configFolder) == false)
            {
                MessageBox.Show("Config folder does not exist.");
                lineBreakToolStripMenuItem.Enabled = false;
                templateToolStripComboBox.Enabled = false;

                foreach (var item in mainMenuStrip.Items)
                {
                    if (item is ToolStripLabel)
                    {
                        DestroyToolsInMenuStrip("templateToolStripLabel");
                        //ToolStripLabel toolStripLabel = (ToolStripLabel)item;

                        //if (toolStripLabel.Name.Equals("templateToolStripLabel"))
                        //    toolStripLabel.Enabled = false;
                    }
                }

                Settings.Default.enableTemplate = false;
                Settings.Default.enableLineBreak = false;
                Settings.Default.Save();

                return;
            }

            if (File.Exists(templateFilePath))
                LoadTemplatesAtStart(templateFilePath);
            else
            {
                if (templateToolStripComboBox.Visible == true)
                {
                    MessageBox.Show("Templates file does not exist.");

                    Settings.Default.enableTemplate = false;
                    Settings.Default.Save();
                }
            }

            if (File.Exists(lineBreakFilePath) == true)
                LoadLineBreakAtStart(lineBreakFilePath);
            else
            {
                Settings.Default.enableLineBreak = false;
                Settings.Default.Save();
            }
        }

        private void LoadTemplateFromSnippet()
        {
            int caretPosition = textBoxMain.SelectionStart;
            string lastChars = "";
            string stringAfterNewline = "";

            if (caretPosition <= 15) lastChars = textBoxMain.Text.Substring(0, caretPosition);
            else lastChars = textBoxMain.Text.Substring(caretPosition - 15, 15);

            int pos = lastChars.LastIndexOf("\r\n");

            if (pos >= 0) stringAfterNewline = lastChars.Substring(pos + 2);
            else stringAfterNewline = lastChars;

            string[] stringsInSpace = stringAfterNewline.Split(' ');
            string lastString = stringsInSpace.LastOrDefault();

            int stringCount = lastString.Length;
            DisplayTemplate(templateAppCodePair, lastString, stringCount, "");
        }

        private void LoadTemplateFromComboBox()
        {
            string templateTitle = templateToolStripComboBox.Text;
            DisplayTemplate(templateAppNamePair, templateTitle, 0, "\r\n");
        }

        private void DisplayTemplate(Dictionary<string, string> dict, string keyInput, int stringCount, string newLine)
        {
            int caretPosition = textBoxMain.SelectionStart;
            if (dict.ContainsKey(keyInput))
            {
                string template = dict[keyInput];

                textBoxMain.SelectionStart = caretPosition - stringCount;
                textBoxMain.SelectionLength = stringCount;
                textBoxMain.Paste(template + newLine);

                textBoxMain.Focus();
            }
        }

        private void LoadTemplatesAtStart(string templateFilePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            try
            {
                using (ExcelPackage package = new ExcelPackage(templateFilePath))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
                    int totalRows = workSheet.Dimension.End.Row;

                    int colTemplateTitle = 1;
                    int colTemplateText = 2;
                    int colTemplateCode = 3;

                    for (int i = 1; i <= totalRows; i++)
                    {
                        string templateTitle = workSheet.Cells[i, colTemplateTitle].Value.ToString();
                        string templateText = workSheet.Cells[i, colTemplateText].Value.ToString();
                        string templateCode = workSheet.Cells[i, colTemplateCode].Value.ToString();
                        templateText = templateText.Replace("\n", "\r\n");

                        if (templateCode != "")
                            templateAppCodePair.Add(templateCode, templateText);

                        if (templateTitle != "")
                        {
                            templateToolStripComboBox.Items.Add(templateTitle);
                            templateAppNamePair.Add(templateTitle, templateText);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void LoadLineBreakAtStart(string lineBreakFilePath)
        {
            LineBreak = File.ReadAllText(lineBreakFilePath);
            if (string.IsNullOrEmpty(LineBreak))
            {
                lineBreakToolStripMenuItem.Enabled = false;
            }
        }

    }
}
