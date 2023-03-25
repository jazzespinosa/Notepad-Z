using Notepad_Z.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Timer = System.Timers.Timer;
using System.Windows.Forms;
using System.Timers;
using IronXL;

namespace Notepad_Z
{
    public partial class mainForm : Form
    {
        String path = String.Empty;
        private static Dictionary<string, string> templateAppCodePair = new Dictionary<string, string>();
        private static Dictionary<string, string> templateAppNamePair = new Dictionary<string, string>();
        private static Timer timer;
        DateTime dateTimeSaved;
        private bool mSubscribed;
        private float ZoomMultiplier { get; set; } = 1;
        private Font TextFont { get; set; }
        private float TextFontSize { get; set; }
        private FontStyle TextFontStyle { get; set; }
        private string LineBreak { get; set; }
        private bool IsTextChange { get; set; }
        private string TextBeforeChange { get; set; }
        private bool IsBackedUp { get; set; } = false;

        public mainForm()
        {
            InitializeComponent();
            findAndReplacePopup.mainForm = this;
        }

        // FILE MENU
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsTextChange == true)
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
            if (IsTextChange == true)
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

                IsTextChange = false;
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

                IsTextChange = false;
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

                IsTextChange = false;
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
            if (IsTextChange == true)
            {
                DialogResult = MessageBox.Show("Do you want to save current file?",
                "Notepad Z",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            }
        }


        // EDIT MENU
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


        // VIEW MENU
        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                textBoxMain.WordWrap = false;
                textBoxMain.ScrollBars = ScrollBars.Both;
                wordWrapToolStripMenuItem.Checked = false;
                wordWrapStripStatusLabel.Text = "WW: OFF";
            }
            else
            {
                textBoxMain.WordWrap = true;
                textBoxMain.ScrollBars = ScrollBars.Vertical;
                wordWrapToolStripMenuItem.Checked = true;
                wordWrapStripStatusLabel.Text = "WW: ON";
            }
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked == true)
            {
                statusStrip.Visible = false;
                statusBarToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip.Visible = true;
                statusBarToolStripMenuItem.Checked = true;
            }
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


        // TEMPLATES MENU
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


        // PREFERENCES MENU
        private void enableTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableTemplateToolStripMenuItem.Checked == true) enableTemplateToolStripMenuItem.Checked = false;
            else enableTemplateToolStripMenuItem.Checked = true;

            Settings.Default.enableTemplate = enableTemplateToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void enableLineBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (enableLineBreakToolStripMenuItem.Checked == true) enableLineBreakToolStripMenuItem.Checked = false;
            else enableLineBreakToolStripMenuItem.Checked = true;

            Settings.Default.enableLineBreak = enableLineBreakToolStripMenuItem.Checked;
            Settings.Default.Save();
        }


        // MAIN FORM EVENTS
        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled - Notepad Z";

            templateToolStripComboBox.Visible = Settings.Default.enableTemplate;
            enableTemplateToolStripMenuItem.Checked = Settings.Default.enableTemplate;

            lineBreakToolStripMenuItem.Visible = Settings.Default.enableLineBreak;
            enableLineBreakToolStripMenuItem.Checked = Settings.Default.enableLineBreak;

            if (templateToolStripComboBox.Visible == true)
            {
                mainMenuStrip.Items.Insert(3, new ToolStripLabel { Text = "Template", Name = "templateToolStripLabel" });
            }

            if (templateToolStripComboBox.Visible == true || lineBreakToolStripMenuItem.Visible == true)
            {
                LoadConfig();
                mainMenuStrip.Items.Insert(3, new ToolStripSeparator { Name = "separatorToolStripItem", Margin = new Padding(0, 0, 5, 0) });
            }

            dateTimeSaved = DateTime.Now;
            TimerStart();

            textBoxMain.BringToFront();
            statusStrip.ShowItemToolTips = true;

            TextFont = textBoxMain.Font;
            TextFontSize = TextFont.Size;
            TextFontStyle = TextFont.Style;
            TextBeforeChange = "";
            UpdateLineAndColumn();

            textBoxMain.ContextMenuStrip = textBoxMainContextMenuStrip;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxMain.Text))
            {
                exitPrompt();

                if (DialogResult == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                else if (DialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            textBoxMain.Focus();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (findAndReplacePopup.Top > textBoxMain.Height - findAndReplacePopup.Height + 5)
            {
                findAndReplacePopup.Top = textBoxMain.Height - findAndReplacePopup.Height + 5;
            }
        }


        // TEXTBOX EVENTS
        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            IsTextChange = true;

            if (this.Text[0] == '*' && textBoxMain.Text == TextBeforeChange)
            {
                this.Text = this.Text.Remove(0, 1);
                IsTextChange = false;
            }
            else if (this.Text[0] != '*')
            {
                this.Text = $"*{this.Text}";
                IsTextChange = true;
            }

            UpdateLineAndColumn();
        }

        private void textBoxMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                Subscribe(true);

                if (e.Shift && e.KeyCode == Keys.N)
                {
                    newWindowToolStripMenuItem_Click(sender, e);
                    return;
                }

                switch (e.KeyCode)
                {
                    case Keys.A: // SELECT ALL
                        e.SuppressKeyPress = true;
                        textBoxMain.SelectAll();
                        break;
                    case Keys.C: // COPY
                        e.SuppressKeyPress = true;
                        copyToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.X: // CUT
                        e.SuppressKeyPress = true;
                        cutToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.V: // PASTE
                        e.SuppressKeyPress = true;
                        pasteToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.N: // NEW FILE
                        e.SuppressKeyPress = true;
                        newToolStripMenuItem_Click(sender, e);
                        Subscribe(false);
                        break;
                    case Keys.O: // OPEN
                        e.SuppressKeyPress = true;
                        openToolStripMenuItem_Click(sender, e);
                        Subscribe(false);
                        break;
                    case Keys.S: // SAVE
                        e.SuppressKeyPress = true;
                        saveToolStripMenuItem_Click(sender, e);
                        Subscribe(false);
                        break;
                    case Keys.Z: // UNDO
                        e.SuppressKeyPress = true;
                        undoToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.F: // FIND
                        e.SuppressKeyPress = true;
                        OpenFindAndReplaceControl(false);
                        break;
                    case Keys.H: // REPLACE
                        e.SuppressKeyPress = true;
                        OpenFindAndReplaceControl(true);
                        break;
                    case Keys.Add: // ZOOM IN
                    case Keys.Oemplus:
                        e.SuppressKeyPress = true;
                        zoomInToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.Subtract: // ZOOM OUT
                    case Keys.OemMinus:
                        e.SuppressKeyPress = true;
                        zoomOutToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.D0:  // RESET ZOOM
                    case Keys.NumPad0:
                        e.SuppressKeyPress = true;
                        resetZoomToolStripMenuItem_Click(sender, e);
                        break;
                    case Keys.Left:
                        e.SuppressKeyPress = false;
                        break;
                    case Keys.Right:
                        e.SuppressKeyPress = false;
                        break;
                    case Keys.Delete:
                        e.SuppressKeyPress = false;
                        break;
                    default:
                        e.SuppressKeyPress = true;
                        break;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                LoadTemplateFromSnippet();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (findAndReplacePopup.Visible)
                {
                    findAndReplacePopup.Visible = false;
                }

                textBoxMain.Select(textBoxMain.SelectionStart, 0);
            }

            UpdateLineAndColumn();
        }

        private void textBoxMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                Subscribe(false);
            }

            UpdateLineAndColumn();
        }

        private void textBoxMain_Leave(object sender, EventArgs e)
        {
            Subscribe(false);
        }

        private void textBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateLineAndColumn();
        }


        // TEMPLATES METHODS
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
                        ToolStripLabel toolStripLabel = (ToolStripLabel)item;

                        if (toolStripLabel.Name.Equals("templateToolStripLabel"))
                            toolStripLabel.Enabled = false;
                    }
                }

                Settings.Default.enableTemplate = false;
                Settings.Default.enableLineBreak = false;
                Settings.Default.Save();

                return;
            }

            if (File.Exists(templateFilePath))
            {
                LoadTemplatesAtStart(templateFilePath);
            }
            else
            {
                if (templateToolStripComboBox.Visible == true)
                {
                    MessageBox.Show("Templates file does not exist.");

                    Settings.Default.enableTemplate = false;
                    Settings.Default.Save();
                }
            }
            if (File.Exists(lineBreakFilePath) == true) LoadLineBreakAtStart(lineBreakFilePath);
            else
            {
                Settings.Default.enableLineBreak = false;
                Settings.Default.Save();
            }
        }

        private void LoadTemplatesAtStart(string templateFilePath)
        {
            try
            {
                WorkBook workBook = WorkBook.Load(templateFilePath);
                WorkSheet workSheet = workBook.GetWorkSheet("Sheet1");

                for (int i = 1; i < 100; i++)
                {
                    var range = workSheet[$"A{i}:C{i}"].ToList();
                    string templateTitle = (string)range[0].Value;
                    string templateText = (string)range[1].Value;
                    string templateCode = (string)range[2].Value;
                    templateText = templateText.Replace("\n", "\r\n"); //RTB uses \n only

                    if (templateCode != "")
                        templateAppCodePair.Add(templateCode, templateText);

                    if (templateTitle != "")
                    {
                        templateToolStripComboBox.Items.Add(templateTitle);
                        templateAppNamePair.Add(templateTitle, templateText);
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


        // BACK UP
        private void TimerStart()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);

            timer.Start();
        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            if ((DateTime.Now - dateTimeSaved).Minutes >= 5)
            {
                saveBackUp();

                timer.Stop();
                dateTimeSaved = DateTime.Now;
                timer.Start();
            }
            if (IsBackedUp)
            {
                try
                {
                    this.Invoke((MethodInvoker)(() => backupStripStatusLabel.Text = $"Backup saved {(DateTime.Now - dateTimeSaved).Minutes} mins ago."));

                }
                catch (Exception ex)
                {
                    string errPath = Environment.CurrentDirectory;
                    File.AppendAllText($@"{errPath}\error.txt", $"[{DateTime.Now}]\n\r{ex.Message}\n\r\n\r");
                    //throw;
                }
            }
        }

        private void saveBackUp()
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
                {

                    string fileName = this.Text;
                    if (IsTextChange == true && fileName[0] == '*')
                    {
                        fileName = fileName.Remove(0, 1);
                    }

                    string backupPath = Environment.CurrentDirectory + @"\backup";
                    if (!Directory.Exists(backupPath))
                        Directory.CreateDirectory(backupPath);

                    // SAVE BACK UP & DELETE DUPLICATE
                    var fileList = Directory.GetFiles(backupPath, $@"*{fileName}*.txt")
                        .Where(file => file.StartsWith($@"{backupPath}\{fileName}_"));

                    File.WriteAllText($@"{backupPath}\{fileName}_{DateTime.Now:yyyy'-'MM'-'dd hhmmss tt}.txt", textBoxMain.Text);

                    foreach (var file in fileList)
                    {
                        File.Delete(file);
                    }

                    // DELETE FILES > 7 DAYS
                    var directory = new DirectoryInfo(backupPath);
                    var dirFiles = directory.GetFiles().Where(file => file.LastWriteTime < DateTime.Now.AddDays(-7));
                    foreach (var item in dirFiles)
                    {
                        File.Delete($@"{backupPath}\{item}");
                    }

                    IsBackedUp = true;
                }));

            }
            catch (Exception ex)
            {
                string errPath = Environment.CurrentDirectory;
                File.AppendAllText($@"{errPath}\error.txt", $"[{DateTime.Now}]\n\r{ex.Message}\n\r\n\r");
                //throw;
            }
        }


        // FIND AND REPLACE METHODS
        public void FindAndSelect(string wordToFind, bool isMatchCase, bool isWholeWord, bool isSearchDown)
        {
            int index = 0;

            var stringComparison = isMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
            var regexOptions = isMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;

            if (isSearchDown == true)
            {
                if (isWholeWord == true)
                {
                    var matches = Regex.Matches(textBoxMain.Text, $@"\b{wordToFind}\b", regexOptions);
                    if (matches.Count > 0)
                    {
                        foreach (Match item in matches)
                        {
                            if (item.Index > textBoxMain.SelectionStart)
                            {
                                index = item.Index;
                                break;
                            }
                            else
                                index = -1;
                        }
                    }
                    else
                        index = -1;

                }
                else
                    index = textBoxMain.Text.IndexOf(wordToFind, textBoxMain.SelectionStart + textBoxMain.SelectionLength, stringComparison);
            }
            else
            {
                if (isWholeWord == true)
                {
                    var matches = Regex.Matches(textBoxMain.Text, $@"\b{wordToFind}\b", regexOptions | RegexOptions.RightToLeft);
                    if (matches.Count > 0)
                    {
                        foreach (Match item in matches)
                        {
                            if (item.Index < textBoxMain.SelectionStart)
                            {
                                index = item.Index;
                                break;
                            }
                            else
                                index = -1;
                        }
                    }
                    else
                        index = -1;
                }
                else
                {
                    int selectionStart = textBoxMain.SelectionStart - 1;
                    if (selectionStart <= 0)
                    {
                        selectionStart = 0;
                    }
                    index = textBoxMain.Text.LastIndexOf(wordToFind, selectionStart, stringComparison);
                }
            }

            if (index == -1)
            {
                MessageBox.Show($"Cannot find \"{wordToFind}\".", "Notepad Z");
                textBoxMain.Focus();
                return;
            }

            textBoxMain.Focus();
            textBoxMain.SelectionStart = index;
            textBoxMain.ScrollToCaret();
            textBoxMain.SelectionLength = wordToFind.Length;
        }

        public void FindAndReplaceAll(string wordToFind, string wordToReplace, bool isMatchCase, bool isWholeWord)
        {
            var regexOptions = isMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
            var pattern = isWholeWord ? $@"\b{wordToFind}\b" : wordToFind;

            var replacedAll = Regex.Replace(textBoxMain.Text, pattern, wordToReplace, regexOptions);

            int occurence = Regex.Matches(textBoxMain.Text, pattern, regexOptions).Count;

            textBoxMain.SelectAll();
            textBoxMain.Paste(replacedAll);

            MessageBox.Show($"Replaced {occurence} occurences.", "Replace All");
            textBoxMain.SelectionStart = textBoxMain.Text.Length;
        }

        private void findAndReplacePopup_VisibleChanged(object sender, EventArgs e)
        {
            if (findAndReplacePopup.Visible)
            {
                findAndReplacePopup.BringToFront();
            }
            else
                findAndReplacePopup.SendToBack();
        }


        // STATUS STRIP 
        private void UpdateLineAndColumn()
        {
            caretPosStripStatusLabel.Text = $"Ln {caretLine()}, Col {caretColumn()}";
        }

        private int caretLine()
        {
            return textBoxMain.GetLineFromCharIndex(textBoxMain.SelectionStart) + 1;
        }

        private int caretColumn()
        {
            return textBoxMain.SelectionStart - textBoxMain.GetFirstCharIndexOfCurrentLine() + 1;
        }


        // CONTEXT MENU STRIP
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












        // TRIAL

        // adding email???
        // adding right click check directory

    }
}
