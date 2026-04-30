using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Notepad_Z
{
    public partial class MainForm : Form
    {
        private String path = String.Empty;
        private static Dictionary<string, string> templateAppCodePair =
            new Dictionary<string, string>(); //gets template text and application code
        private static Dictionary<string, string> templateAppNamePair =
            new Dictionary<string, string>(); //gets template text and application name
        private DateTime dateTimeSaved;
        private bool mSubscribed;
        private Timer backupTimer;
        private float ZoomMultiplier { get; set; } = 1;
        private Font TextFont { get; set; }
        private float TextFontSize { get; set; }
        private FontStyle TextFontStyle { get; set; }
        private string LineBreak { get; set; }
        private bool IsDirty { get; set; }
        private string TextBeforeChange { get; set; }
        private bool IsBackedUp { get; set; } = false;
        private string lastBackupContent = null; // store last backed up content to avoid redundant backups

        public MainForm()
        {
            InitializeComponent();
            findAndReplacePopup.mainForm = this;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = "Untitled - Notepad Z";

            LoadConfig(); // load initial config for templates and line breaks

            LoadPreferences();

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
            backupTimer?.Stop();
            backupTimer?.Dispose();

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
            // Use the editor text for state, not the form title.
            IsDirty = textBoxMain.Text != TextBeforeChange;

            // Ensure the form title has a leading star when dirty.
            if (!this.Text.StartsWith("*") && IsDirty)
                this.Text = "*" + this.Text;

            UpdateFormTitle(IsDirty);
            UpdateLineAndColumn();
        }

        private void UpdateFormTitle(bool dirty)
        {
            if (dirty)
            {
                if (!this.Text.StartsWith("*"))
                    this.Text = "*" + this.Text;
            }
            else
            {
                if (this.Text.StartsWith("*"))
                    this.Text = this.Text.Substring(1);
            }
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
                    case Keys.D0: // RESET ZOOM
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
                    case Keys.Back:
                        e.SuppressKeyPress = true;
                        if (textBoxMain.SelectionStart > 0)
                        {
                            SendKeys.Send("+{LEFT}{DEL}");
                        }
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

        // BACK UP
        private void TimerStart()
        {
            backupTimer = new Timer { Interval = 60 * 1000 }; // 1 minute
            backupTimer.Tick += BackupTimer_Tick;
            backupTimer.Start();
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - dateTimeSaved).Minutes >= 5)
            {
                saveBackUp();

                backupTimer.Stop();
                dateTimeSaved = DateTime.Now;
                backupTimer.Start();
            }
            if (IsBackedUp)
            {
                try
                {
                    this.Invoke(
                        (MethodInvoker)(
                            () =>
                                backupStripStatusLabel.Text =
                                    $"Backup saved {(DateTime.Now - dateTimeSaved).Minutes} mins ago."
                        )
                    );
                }
                catch (Exception ex)
                {
                    var errFile = Path.Combine(Environment.CurrentDirectory, "error.txt");
                    File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
                }
            }
        }

        internal void saveBackUp()
        {
            var backupPath = Path.Combine(Environment.CurrentDirectory, "backup");
            var errFile = Path.Combine(Environment.CurrentDirectory, "error.txt");

            try
            {
                // Capture necessary UI state on the UI thread
                var fileName = this.Text ?? string.Empty;
                var content = textBoxMain.Text ?? string.Empty;

                if (IsDirty && !string.IsNullOrEmpty(fileName) && fileName[0] == '*')
                    fileName = fileName.Substring(1);

                // Offload heavy IO and file system work to background thread
                Task.Run(() =>
                {
                    try
                    {
                        Directory.CreateDirectory(backupPath);

                        // Save backup
                        var timestamp = DateTime.Now.ToString("yyyy-MM-dd_hhmmss_tt");
                        var safeFileName = MakeFileNameSafe(fileName);
                        var backupFile = Path.Combine(
                            backupPath,
                            $"{safeFileName}_{timestamp}.txt"
                        );
                        File.WriteAllText(backupFile, content);

                        // Keep only the latest backup for this fileName
                        var filePattern = $"{safeFileName}_*.txt";
                        var files = Directory
                            .GetFiles(backupPath, filePattern)
                            .OrderByDescending(f => File.GetLastWriteTimeUtc(f))
                            .ToArray();

                        foreach (var f in files.Skip(1))
                            TryDelete(f, errFile);

                        // Delete files older than 7 days
                        foreach (var f in Directory.GetFiles(backupPath))
                        {
                            try
                            {
                                if (File.GetLastWriteTimeUtc(f) < DateTime.UtcNow.AddDays(-7))
                                    TryDelete(f, errFile);
                            }
                            catch (Exception ex)
                            {
                                File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
                            }
                        }

                        // Update UI-bound state on the UI thread
                        try
                        {
                            this.Invoke(
                                (MethodInvoker)(
                                    () =>
                                    {
                                        lastBackupContent = content;
                                        IsBackedUp = true;
                                    }
                                )
                            );
                        }
                        catch (Exception ex)
                        {
                            File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
                    }
                });
            }
            catch (Exception ex)
            {
                File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
            }
        }

        private static string MakeFileNameSafe(string name)
        {
            if (string.IsNullOrEmpty(name))
                return "untitled";

            var invalid = Path.GetInvalidFileNameChars();
            foreach (var c in invalid)
                name = name.Replace(c, '_');

            return name;
        }

        private static void TryDelete(string filePath, String errFile)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            catch (Exception ex)
            {
                errFile = Path.Combine(Environment.CurrentDirectory, "error.txt");
                File.AppendAllText(errFile, $"[{DateTime.Now}] {ex}\n\n");
            }
        }

        // FIND AND REPLACE METHODS
        internal void FindAndSelect(
            string wordToFind,
            bool isMatchCase,
            bool isWholeWord,
            bool isSearchDown
        )
        {
            if (string.IsNullOrEmpty(wordToFind))
            {
                MessageBox.Show("Nothing to find.", "Notepad Z");
                return;
            }

            var stringComparison = isMatchCase
                ? StringComparison.CurrentCulture
                : StringComparison.CurrentCultureIgnoreCase;
            var regexOptions = isMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;

            int index = -1;

            if (isWholeWord)
            {
                // Escape input before building regex to avoid accidental metacharacter behavior.
                var escaped = Regex.Escape(wordToFind);
                var rx = new Regex(
                    @"\b" + escaped + @"\b",
                    regexOptions | (isSearchDown ? RegexOptions.None : RegexOptions.RightToLeft)
                );

                var startPos =
                    textBoxMain.SelectionStart + (isSearchDown ? textBoxMain.SelectionLength : -1);
                if (startPos < 0)
                    startPos = 0;

                var match = rx.Match(textBoxMain.Text, isSearchDown ? startPos : 0);
                if (isSearchDown)
                {
                    // find first match after selection
                    foreach (Match m in rx.Matches(textBoxMain.Text))
                    {
                        if (m.Index > textBoxMain.SelectionStart)
                        {
                            index = m.Index;
                            break;
                        }
                    }
                }
                else
                {
                    // last match before selection
                    for (int i = rx.Matches(textBoxMain.Text).Count - 1; i >= 0; i--)
                    {
                        var m = rx.Matches(textBoxMain.Text)[i];
                        if (m.Index < textBoxMain.SelectionStart)
                        {
                            index = m.Index;
                            break;
                        }
                    }
                }
            }
            else
            {
                if (isSearchDown)
                    index = textBoxMain.Text.IndexOf(
                        wordToFind,
                        textBoxMain.SelectionStart + textBoxMain.SelectionLength,
                        stringComparison
                    );
                else
                {
                    int selectionStart = Math.Max(0, textBoxMain.SelectionStart - 1);
                    index = textBoxMain.Text.LastIndexOf(
                        wordToFind,
                        selectionStart,
                        stringComparison
                    );
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

        internal void FindAndReplaceAll(
            string wordToFind,
            string wordToReplace,
            bool isMatchCase,
            bool isWholeWord
        )
        {
            var regexOptions = isMatchCase ? RegexOptions.None : RegexOptions.IgnoreCase;
            var escaped = Regex.Escape(wordToFind);
            var pattern = isWholeWord ? $@"\b{escaped}\b" : escaped;

            int occurrence = Regex.Matches(textBoxMain.Text, pattern, regexOptions).Count;

            // Avoid using clipboard: update the document directly.
            var replacedAll = Regex.Replace(textBoxMain.Text, pattern, wordToReplace, regexOptions);
            textBoxMain.Text = replacedAll;

            MessageBox.Show($"Replaced {occurrence} occurrences.", "Replace All");
            textBoxMain.SelectionStart = textBoxMain.Text.Length;
        }

        internal void findAndReplacePopup_VisibleChanged(object sender, EventArgs e)
        {
            if (findAndReplacePopup.Visible)
            {
                findAndReplacePopup.BringToFront();
            }
            else
                findAndReplacePopup.SendToBack();
        }
    }
}
