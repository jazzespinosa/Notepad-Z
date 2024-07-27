using System.Windows.Forms;

namespace Notepad_Z
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.lineBreakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableLineBreakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mainSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mainFontDialog = new System.Windows.Forms.FontDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.backupStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.separator1StripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.separator2StripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.wordWrapStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.caretPosStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.textBoxMainContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.undoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorContext1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorContext2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatorContext3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkFolderPathContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkFolderPermissionsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPathAndPermissionsContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAndReplacePopup = new Notepad_Z.FindAndReplaceControl();
            this.mainMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.textBoxMainContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenuStrip.GripMargin = new System.Windows.Forms.Padding(0);
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.templateToolStripComboBox,
            this.lineBreakToolStripMenuItem,
            this.prefStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(458, 27);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.newWindowToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 23);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newToolStripMenuItem.Text = "&New                     Ctrl+N";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.newWindowToolStripMenuItem.Text = "New &Window     Ctrl+W";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.openToolStripMenuItem.Text = "&Open...                Ctrl+O";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(195, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveToolStripMenuItem.Text = "&Save                     Ctrl+S";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem4,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 23);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.undoToolStripMenuItem.Text = "&Undo                    Ctrl+Z";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(194, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.cutToolStripMenuItem.Text = "Cu&t                       Ctrl+X";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.copyToolStripMenuItem.Text = "&Copy                    Ctrl+C";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.pasteToolStripMenuItem.Text = "&Paste                    Ctrl+V";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.deleteToolStripMenuItem.Text = "De&lete                        Del";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(194, 6);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.findToolStripMenuItem.Text = "&Find                     Ctrl+F";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.replaceToolStripMenuItem.Text = "&Replace               Ctrl+H";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All             Ctrl+A";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Checked = true;
            this.viewToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordWrapToolStripMenuItem,
            this.statusBarToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 23);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.wordWrapToolStripMenuItem.Text = "&Word Wrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.statusBarToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.fontToolStripMenuItem.Text = "&Font...";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.resetZoomToolStripMenuItem});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.zoomToolStripMenuItem.Text = "&Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom &In             Ctrl+Plus";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom &Out      Ctrl+Minus";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.resetZoomToolStripMenuItem.Text = "&Reset Zoom            Ctrl+0";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetZoomToolStripMenuItem_Click);
            // 
            // templateToolStripComboBox
            // 
            this.templateToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.templateToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.templateToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.templateToolStripComboBox.Name = "templateToolStripComboBox";
            this.templateToolStripComboBox.Size = new System.Drawing.Size(140, 23);
            this.templateToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.templateToolStripComboBox_SelectedIndexChanged);
            // 
            // lineBreakToolStripMenuItem
            // 
            this.lineBreakToolStripMenuItem.Name = "lineBreakToolStripMenuItem";
            this.lineBreakToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.lineBreakToolStripMenuItem.Text = "Line &Break";
            this.lineBreakToolStripMenuItem.Click += new System.EventHandler(this.lineBreakToolStripMenuItem_Click);
            // 
            // prefStripMenuItem
            // 
            this.prefStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.prefStripMenuItem.AutoSize = false;
            this.prefStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.prefStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.prefStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableTemplateToolStripMenuItem,
            this.enableLineBreakToolStripMenuItem});
            this.prefStripMenuItem.Image = global::Notepad_Z.Properties.Resources.preferences;
            this.prefStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.prefStripMenuItem.Name = "prefStripMenuItem";
            this.prefStripMenuItem.Padding = new System.Windows.Forms.Padding(0);
            this.prefStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.prefStripMenuItem.Size = new System.Drawing.Size(17, 17);
            // 
            // enableTemplateToolStripMenuItem
            // 
            this.enableTemplateToolStripMenuItem.AutoToolTip = true;
            this.enableTemplateToolStripMenuItem.Checked = true;
            this.enableTemplateToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableTemplateToolStripMenuItem.Name = "enableTemplateToolStripMenuItem";
            this.enableTemplateToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.enableTemplateToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.enableTemplateToolStripMenuItem.Text = "Templates";
            this.enableTemplateToolStripMenuItem.ToolTipText = "Check to enable Templates";
            this.enableTemplateToolStripMenuItem.Click += new System.EventHandler(this.enableTemplateToolStripMenuItem_Click);
            // 
            // enableLineBreakToolStripMenuItem
            // 
            this.enableLineBreakToolStripMenuItem.AutoToolTip = true;
            this.enableLineBreakToolStripMenuItem.Checked = true;
            this.enableLineBreakToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableLineBreakToolStripMenuItem.Name = "enableLineBreakToolStripMenuItem";
            this.enableLineBreakToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.enableLineBreakToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.enableLineBreakToolStripMenuItem.Text = "Line Break";
            this.enableLineBreakToolStripMenuItem.ToolTipText = "Check to enable Line Break";
            this.enableLineBreakToolStripMenuItem.Click += new System.EventHandler(this.enableLineBreakToolStripMenuItem_Click);
            // 
            // mainSaveFileDialog
            // 
            this.mainSaveFileDialog.CheckPathExists = false;
            this.mainSaveFileDialog.DefaultExt = "txt";
            this.mainSaveFileDialog.Filter = "Text Documents|*txt|All files|*.*";
            // 
            // mainFontDialog
            // 
            this.mainFontDialog.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.mainFontDialog.FontMustExist = true;
            this.mainFontDialog.ShowColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupStripStatusLabel,
            this.separator1StripStatusLabel,
            this.zoomStripStatusLabel,
            this.separator2StripStatusLabel,
            this.wordWrapStripStatusLabel,
            this.caretPosStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 505);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(458, 25);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 5;
            // 
            // backupStripStatusLabel
            // 
            this.backupStripStatusLabel.AutoToolTip = true;
            this.backupStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.backupStripStatusLabel.Name = "backupStripStatusLabel";
            this.backupStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backupStripStatusLabel.Size = new System.Drawing.Size(121, 20);
            this.backupStripStatusLabel.Text = "Back up not yet saved.";
            this.backupStripStatusLabel.ToolTipText = "Back up status";
            // 
            // separator1StripStatusLabel
            // 
            this.separator1StripStatusLabel.AutoSize = false;
            this.separator1StripStatusLabel.Enabled = false;
            this.separator1StripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.separator1StripStatusLabel.Name = "separator1StripStatusLabel";
            this.separator1StripStatusLabel.Size = new System.Drawing.Size(13, 20);
            this.separator1StripStatusLabel.Text = "|";
            // 
            // zoomStripStatusLabel
            // 
            this.zoomStripStatusLabel.AutoToolTip = true;
            this.zoomStripStatusLabel.Name = "zoomStripStatusLabel";
            this.zoomStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.zoomStripStatusLabel.Size = new System.Drawing.Size(38, 20);
            this.zoomStripStatusLabel.Text = "100 %";
            this.zoomStripStatusLabel.ToolTipText = "Zoom";
            // 
            // separator2StripStatusLabel
            // 
            this.separator2StripStatusLabel.AutoSize = false;
            this.separator2StripStatusLabel.Enabled = false;
            this.separator2StripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.separator2StripStatusLabel.Name = "separator2StripStatusLabel";
            this.separator2StripStatusLabel.Size = new System.Drawing.Size(13, 20);
            this.separator2StripStatusLabel.Text = "|";
            // 
            // wordWrapStripStatusLabel
            // 
            this.wordWrapStripStatusLabel.AutoToolTip = true;
            this.wordWrapStripStatusLabel.Name = "wordWrapStripStatusLabel";
            this.wordWrapStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.wordWrapStripStatusLabel.Size = new System.Drawing.Size(56, 20);
            this.wordWrapStripStatusLabel.Text = "WW: OFF";
            this.wordWrapStripStatusLabel.ToolTipText = "Word Wrap";
            // 
            // caretPosStripStatusLabel
            // 
            this.caretPosStripStatusLabel.Name = "caretPosStripStatusLabel";
            this.caretPosStripStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.caretPosStripStatusLabel.Size = new System.Drawing.Size(202, 20);
            this.caretPosStripStatusLabel.Spring = true;
            this.caretPosStripStatusLabel.Text = "Ln 0, Col 0";
            this.caretPosStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxMain
            // 
            this.textBoxMain.AcceptsTab = true;
            this.textBoxMain.BackColor = System.Drawing.Color.White;
            this.textBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMain.Font = new System.Drawing.Font("Consolas", 11.25F);
            this.textBoxMain.Location = new System.Drawing.Point(0, 27);
            this.textBoxMain.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxMain.MaxLength = 2000000000;
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMain.Size = new System.Drawing.Size(458, 478);
            this.textBoxMain.TabIndex = 8;
            this.textBoxMain.WordWrap = false;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBoxMain_TextChanged);
            this.textBoxMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxMain_KeyDown);
            this.textBoxMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMain_KeyUp);
            this.textBoxMain.Leave += new System.EventHandler(this.textBoxMain_Leave);
            this.textBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBoxMain_MouseDown);
            // 
            // textBoxMainContextMenuStrip
            // 
            this.textBoxMainContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoContextMenuItem,
            this.separatorContext1,
            this.cutContextMenuItem,
            this.copyContextMenuItem,
            this.pasteContextMenuItem,
            this.deleteContextMenuItem,
            this.separatorContext2,
            this.selectAllContextMenuItem,
            this.separatorContext3,
            this.checkFolderPathContextMenuItem,
            this.checkFolderPermissionsContextMenuItem,
            this.checkPathAndPermissionsContextMenuItem});
            this.textBoxMainContextMenuStrip.Name = "contextMenuStrip";
            this.textBoxMainContextMenuStrip.ShowImageMargin = false;
            this.textBoxMainContextMenuStrip.Size = new System.Drawing.Size(199, 220);
            this.textBoxMainContextMenuStrip.Opened += new System.EventHandler(this.textBoxMainContexMenuStrip_Opened);
            // 
            // undoContextMenuItem
            // 
            this.undoContextMenuItem.Name = "undoContextMenuItem";
            this.undoContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.undoContextMenuItem.Text = "Undo";
            this.undoContextMenuItem.Click += new System.EventHandler(this.undoContextMenuItem_Click);
            // 
            // separatorContext1
            // 
            this.separatorContext1.Name = "separatorContext1";
            this.separatorContext1.Size = new System.Drawing.Size(195, 6);
            // 
            // cutContextMenuItem
            // 
            this.cutContextMenuItem.Name = "cutContextMenuItem";
            this.cutContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.cutContextMenuItem.Text = "Cut";
            this.cutContextMenuItem.Click += new System.EventHandler(this.cutContextMenuItem_Click);
            // 
            // copyContextMenuItem
            // 
            this.copyContextMenuItem.Name = "copyContextMenuItem";
            this.copyContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.copyContextMenuItem.Text = "Copy";
            this.copyContextMenuItem.Click += new System.EventHandler(this.copyContextMenuItem_Click);
            // 
            // pasteContextMenuItem
            // 
            this.pasteContextMenuItem.Name = "pasteContextMenuItem";
            this.pasteContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.pasteContextMenuItem.Text = "Paste";
            this.pasteContextMenuItem.Click += new System.EventHandler(this.pasteContextMenuItem_Click);
            // 
            // deleteContextMenuItem
            // 
            this.deleteContextMenuItem.Name = "deleteContextMenuItem";
            this.deleteContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.deleteContextMenuItem.Text = "Delete";
            this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
            // 
            // separatorContext2
            // 
            this.separatorContext2.Name = "separatorContext2";
            this.separatorContext2.Size = new System.Drawing.Size(195, 6);
            // 
            // selectAllContextMenuItem
            // 
            this.selectAllContextMenuItem.Name = "selectAllContextMenuItem";
            this.selectAllContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.selectAllContextMenuItem.Text = "Select All";
            this.selectAllContextMenuItem.Click += new System.EventHandler(this.selectAllContextMenuItem_Click);
            // 
            // separatorContext3
            // 
            this.separatorContext3.Name = "separatorContext3";
            this.separatorContext3.Size = new System.Drawing.Size(195, 6);
            // 
            // checkFolderPathContextMenuItem
            // 
            this.checkFolderPathContextMenuItem.Name = "checkFolderPathContextMenuItem";
            this.checkFolderPathContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.checkFolderPathContextMenuItem.Text = "Check Folder Path";
            this.checkFolderPathContextMenuItem.Click += new System.EventHandler(this.checkFolderPathContextMenuItem_Click);
            // 
            // checkFolderPermissionsContextMenuItem
            // 
            this.checkFolderPermissionsContextMenuItem.Name = "checkFolderPermissionsContextMenuItem";
            this.checkFolderPermissionsContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.checkFolderPermissionsContextMenuItem.Text = "Check Folder Permissions";
            this.checkFolderPermissionsContextMenuItem.Click += new System.EventHandler(this.checkFolderPermissionsContextMenuItem_Click);
            // 
            // checkPathAndPermissionsContextMenuItem
            // 
            this.checkPathAndPermissionsContextMenuItem.Name = "checkPathAndPermissionsContextMenuItem";
            this.checkPathAndPermissionsContextMenuItem.Size = new System.Drawing.Size(198, 22);
            this.checkPathAndPermissionsContextMenuItem.Text = "Check Path and Permissions";
            this.checkPathAndPermissionsContextMenuItem.Click += new System.EventHandler(this.checkPathAndPermissionsContextMenuItem_Click);
            // 
            // findAndReplacePopup
            // 
            this.findAndReplacePopup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findAndReplacePopup.AutoSize = true;
            this.findAndReplacePopup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.findAndReplacePopup.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.findAndReplacePopup.BackColor = System.Drawing.Color.AliceBlue;
            this.findAndReplacePopup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findAndReplacePopup.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.findAndReplacePopup.IsMatchCaseChecked = false;
            this.findAndReplacePopup.IsMatchWholeWordChecked = false;
            this.findAndReplacePopup.Location = new System.Drawing.Point(157, 30);
            this.findAndReplacePopup.mainForm = null;
            this.findAndReplacePopup.Margin = new System.Windows.Forms.Padding(0);
            this.findAndReplacePopup.Name = "findAndReplacePopup";
            this.findAndReplacePopup.Size = new System.Drawing.Size(282, 51);
            this.findAndReplacePopup.TabIndex = 3;
            this.findAndReplacePopup.TabStop = false;
            this.findAndReplacePopup.Visible = false;
            this.findAndReplacePopup.WordToFind = "";
            this.findAndReplacePopup.VisibleChanged += new System.EventHandler(this.findAndReplacePopup_VisibleChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 530);
            this.Controls.Add(this.findAndReplacePopup);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.MinimumSize = new System.Drawing.Size(340, 350);
            this.Name = "mainForm";
            this.Text = "Notepad Z";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.textBoxMainContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog mainOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog mainSaveFileDialog;
        private System.Windows.Forms.FontDialog mainFontDialog;
        private System.Windows.Forms.ToolStripComboBox templateToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem lineBreakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        public FindAndReplaceControl findAndReplacePopup;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel zoomStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel backupStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel separator1StripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel separator2StripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel wordWrapStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel caretPosStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        public System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.ToolStripMenuItem prefStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableTemplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableLineBreakToolStripMenuItem;
        private ToolStripMenuItem zoomToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private ContextMenuStrip textBoxMainContextMenuStrip;
        private ToolStripMenuItem undoContextMenuItem;
        private ToolStripMenuItem cutContextMenuItem;
        private ToolStripSeparator separatorContext1;
        private ToolStripMenuItem copyContextMenuItem;
        private ToolStripMenuItem pasteContextMenuItem;
        private ToolStripMenuItem deleteContextMenuItem;
        private ToolStripSeparator separatorContext2;
        private ToolStripMenuItem selectAllContextMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator separatorContext3;
        private ToolStripMenuItem checkFolderPathContextMenuItem;
        private ToolStripMenuItem checkFolderPermissionsContextMenuItem;
        private ToolStripMenuItem checkPathAndPermissionsContextMenuItem;
    }
}

