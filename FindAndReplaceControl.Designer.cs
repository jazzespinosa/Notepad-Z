namespace Notepad_Z
{
    partial class FindAndReplaceControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFind = new System.Windows.Forms.Label();
            this.tboxFind = new System.Windows.Forms.TextBox();
            this.panelFind = new System.Windows.Forms.Panel();
            this.toggleExpandCollapse = new System.Windows.Forms.CheckBox();
            this.btnFindUp = new System.Windows.Forms.Button();
            this.btnCloseControl = new System.Windows.Forms.Button();
            this.btnFindDown = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panelReplace = new System.Windows.Forms.Panel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.btnDragFindControl = new System.Windows.Forms.Button();
            this.checkboxMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.checkboxMatchCase = new System.Windows.Forms.CheckBox();
            this.panelFind.SuspendLayout();
            this.flowLayoutPanel.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFind
            // 
            this.lblFind.AutoSize = true;
            this.lblFind.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFind.Location = new System.Drawing.Point(32, 4);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(39, 17);
            this.lblFind.TabIndex = 1;
            this.lblFind.Text = "Find :";
            // 
            // tboxFind
            // 
            this.tboxFind.Location = new System.Drawing.Point(70, 2);
            this.tboxFind.Name = "tboxFind";
            this.tboxFind.Size = new System.Drawing.Size(135, 23);
            this.tboxFind.TabIndex = 101;
            this.tboxFind.TextChanged += new System.EventHandler(this.tboxFind_TextChanged);
            this.tboxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxFind_KeyDown);
            this.tboxFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxFind_KeyPress);
            // 
            // panelFind
            // 
            this.panelFind.Controls.Add(this.toggleExpandCollapse);
            this.panelFind.Controls.Add(this.btnFindUp);
            this.panelFind.Controls.Add(this.btnCloseControl);
            this.panelFind.Controls.Add(this.tboxFind);
            this.panelFind.Controls.Add(this.lblFind);
            this.panelFind.Controls.Add(this.btnFindDown);
            this.panelFind.Location = new System.Drawing.Point(0, 0);
            this.panelFind.Margin = new System.Windows.Forms.Padding(0);
            this.panelFind.Name = "panelFind";
            this.panelFind.Size = new System.Drawing.Size(280, 27);
            this.panelFind.TabIndex = 6;
            // 
            // toggleExpandCollapse
            // 
            this.toggleExpandCollapse.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleExpandCollapse.AutoSize = true;
            this.toggleExpandCollapse.BackgroundImage = global::Notepad_Z.Properties.Resources.arrow_right;
            this.toggleExpandCollapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toggleExpandCollapse.FlatAppearance.BorderSize = 0;
            this.toggleExpandCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleExpandCollapse.Location = new System.Drawing.Point(4, 4);
            this.toggleExpandCollapse.MinimumSize = new System.Drawing.Size(16, 16);
            this.toggleExpandCollapse.Name = "toggleExpandCollapse";
            this.toggleExpandCollapse.Size = new System.Drawing.Size(16, 16);
            this.toggleExpandCollapse.TabIndex = 0;
            this.toggleExpandCollapse.TabStop = false;
            this.toggleExpandCollapse.UseVisualStyleBackColor = true;
            this.toggleExpandCollapse.CheckedChanged += new System.EventHandler(this.toggleExpandCollapse_CheckedChanged);
            // 
            // btnFindUp
            // 
            this.btnFindUp.BackgroundImage = global::Notepad_Z.Properties.Resources.search_up_disabled;
            this.btnFindUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindUp.Enabled = false;
            this.btnFindUp.FlatAppearance.BorderSize = 0;
            this.btnFindUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindUp.Location = new System.Drawing.Point(209, 2);
            this.btnFindUp.Name = "btnFindUp";
            this.btnFindUp.Size = new System.Drawing.Size(20, 20);
            this.btnFindUp.TabIndex = 4;
            this.btnFindUp.UseVisualStyleBackColor = true;
            this.btnFindUp.Click += new System.EventHandler(this.btnFindUp_Click);
            // 
            // btnCloseControl
            // 
            this.btnCloseControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseControl.BackgroundImage = global::Notepad_Z.Properties.Resources.close;
            this.btnCloseControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCloseControl.FlatAppearance.BorderSize = 0;
            this.btnCloseControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseControl.Location = new System.Drawing.Point(260, 0);
            this.btnCloseControl.Name = "btnCloseControl";
            this.btnCloseControl.Size = new System.Drawing.Size(20, 20);
            this.btnCloseControl.TabIndex = 3;
            this.btnCloseControl.UseVisualStyleBackColor = true;
            this.btnCloseControl.Click += new System.EventHandler(this.btnCloseControl_Click);
            // 
            // btnFindDown
            // 
            this.btnFindDown.BackgroundImage = global::Notepad_Z.Properties.Resources.search_down_disabled;
            this.btnFindDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindDown.Enabled = false;
            this.btnFindDown.FlatAppearance.BorderSize = 0;
            this.btnFindDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindDown.Location = new System.Drawing.Point(232, 2);
            this.btnFindDown.Name = "btnFindDown";
            this.btnFindDown.Size = new System.Drawing.Size(20, 20);
            this.btnFindDown.TabIndex = 5;
            this.btnFindDown.UseVisualStyleBackColor = true;
            this.btnFindDown.Click += new System.EventHandler(this.btnFindDown_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoSize = true;
            this.flowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel.Controls.Add(this.panelFind);
            this.flowLayoutPanel.Controls.Add(this.panelReplace);
            this.flowLayoutPanel.Controls.Add(this.panelSettings);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(280, 49);
            this.flowLayoutPanel.TabIndex = 7;
            // 
            // panelReplace
            // 
            this.panelReplace.AutoSize = true;
            this.panelReplace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelReplace.Location = new System.Drawing.Point(0, 27);
            this.panelReplace.Margin = new System.Windows.Forms.Padding(0);
            this.panelReplace.Name = "panelReplace";
            this.panelReplace.Size = new System.Drawing.Size(0, 0);
            this.panelReplace.TabIndex = 7;
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.btnDragFindControl);
            this.panelSettings.Controls.Add(this.checkboxMatchWholeWord);
            this.panelSettings.Controls.Add(this.checkboxMatchCase);
            this.panelSettings.Location = new System.Drawing.Point(0, 27);
            this.panelSettings.Margin = new System.Windows.Forms.Padding(0);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(280, 22);
            this.panelSettings.TabIndex = 8;
            // 
            // btnDragFindControl
            // 
            this.btnDragFindControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDragFindControl.BackgroundImage = global::Notepad_Z.Properties.Resources.corner_drag;
            this.btnDragFindControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDragFindControl.FlatAppearance.BorderSize = 0;
            this.btnDragFindControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDragFindControl.Location = new System.Drawing.Point(0, 6);
            this.btnDragFindControl.Margin = new System.Windows.Forms.Padding(0);
            this.btnDragFindControl.Name = "btnDragFindControl";
            this.btnDragFindControl.Size = new System.Drawing.Size(15, 15);
            this.btnDragFindControl.TabIndex = 2;
            this.btnDragFindControl.UseVisualStyleBackColor = true;
            this.btnDragFindControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDragFindControl_MouseDown);
            this.btnDragFindControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDragFindControl_MouseMove);
            // 
            // checkboxMatchWholeWord
            // 
            this.checkboxMatchWholeWord.AutoSize = true;
            this.checkboxMatchWholeWord.Location = new System.Drawing.Point(137, 3);
            this.checkboxMatchWholeWord.Name = "checkboxMatchWholeWord";
            this.checkboxMatchWholeWord.Size = new System.Drawing.Size(129, 19);
            this.checkboxMatchWholeWord.TabIndex = 1;
            this.checkboxMatchWholeWord.Text = "Match Whole Word";
            this.checkboxMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // checkboxMatchCase
            // 
            this.checkboxMatchCase.AutoSize = true;
            this.checkboxMatchCase.Location = new System.Drawing.Point(40, 3);
            this.checkboxMatchCase.Name = "checkboxMatchCase";
            this.checkboxMatchCase.Size = new System.Drawing.Size(88, 19);
            this.checkboxMatchCase.TabIndex = 0;
            this.checkboxMatchCase.Text = "Match Case";
            this.checkboxMatchCase.UseVisualStyleBackColor = true;
            // 
            // FindAndReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.flowLayoutPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FindAndReplaceControl";
            this.Size = new System.Drawing.Size(280, 49);
            this.Load += new System.EventHandler(this.FindAndReplaceControl_Load);
            this.VisibleChanged += new System.EventHandler(this.FindAndReplaceControl_VisibleChanged);
            this.panelFind.ResumeLayout(false);
            this.panelFind.PerformLayout();
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFind;
        private System.Windows.Forms.Button btnCloseControl;
        private System.Windows.Forms.Button btnFindUp;
        private System.Windows.Forms.Button btnFindDown;
        private System.Windows.Forms.Panel panelFind;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel panelReplace;
        private System.Windows.Forms.Panel panelSettings;
        public System.Windows.Forms.CheckBox toggleExpandCollapse;
        public System.Windows.Forms.TextBox tboxFind;
        public System.Windows.Forms.CheckBox checkboxMatchCase;
        public System.Windows.Forms.CheckBox checkboxMatchWholeWord;
        public System.Windows.Forms.Button btnDragFindControl;
    }
}
