using System.Windows.Forms;

namespace Notepad_Z
{
    partial class ReplaceControl
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
            this.lblReplace = new System.Windows.Forms.Label();
            this.tboxReplace = new System.Windows.Forms.TextBox();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnReplaceNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblReplace
            // 
            this.lblReplace.AutoSize = true;
            this.lblReplace.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblReplace.Location = new System.Drawing.Point(10, 2);
            this.lblReplace.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplace.Name = "lblReplace";
            this.lblReplace.Size = new System.Drawing.Size(65, 17);
            this.lblReplace.TabIndex = 0;
            this.lblReplace.Text = "Replace : ";
            // 
            // tboxReplace
            // 
            this.tboxReplace.Location = new System.Drawing.Point(70, 0);
            this.tboxReplace.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tboxReplace.Name = "tboxReplace";
            this.tboxReplace.Size = new System.Drawing.Size(135, 23);
            this.tboxReplace.TabIndex = 1;
            this.tboxReplace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tboxReplace_KeyDown);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.BackgroundImage = global::Notepad_Z.Properties.Resources.replace_all;
            this.btnReplaceAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReplaceAll.Enabled = false;
            this.btnReplaceAll.FlatAppearance.BorderSize = 0;
            this.btnReplaceAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplaceAll.Location = new System.Drawing.Point(232, 2);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(20, 20);
            this.btnReplaceAll.TabIndex = 3;
            this.btnReplaceAll.UseVisualStyleBackColor = true;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnReplaceNext
            // 
            this.btnReplaceNext.BackgroundImage = global::Notepad_Z.Properties.Resources.replace;
            this.btnReplaceNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReplaceNext.Enabled = false;
            this.btnReplaceNext.FlatAppearance.BorderSize = 0;
            this.btnReplaceNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReplaceNext.Location = new System.Drawing.Point(209, 2);
            this.btnReplaceNext.Name = "btnReplaceNext";
            this.btnReplaceNext.Size = new System.Drawing.Size(20, 20);
            this.btnReplaceNext.TabIndex = 2;
            this.btnReplaceNext.UseVisualStyleBackColor = true;
            this.btnReplaceNext.Click += new System.EventHandler(this.btnReplaceNext_Click);
            // 
            // ReplaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReplaceAll);
            this.Controls.Add(this.btnReplaceNext);
            this.Controls.Add(this.tboxReplace);
            this.Controls.Add(this.lblReplace);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReplaceControl";
            this.Size = new System.Drawing.Size(280, 24);
            this.Load += new System.EventHandler(this.ReplaceControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReplace;
        public System.Windows.Forms.TextBox tboxReplace;
        public Button btnReplaceNext;
        public Button btnReplaceAll;
    }
}
