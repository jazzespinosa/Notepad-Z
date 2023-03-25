using Notepad_Z.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Notepad_Z
{
    public partial class FindAndReplaceControl : UserControl
    {
        public mainForm mainForm { get; set; }
        ReplaceControl replaceControl = new ReplaceControl();
        public string WordToFind
        {
            get { return tboxFind.Text; }
            set { tboxFind.Text = value; }
        }
        public bool IsMatchCaseChecked
        {
            get { return checkboxMatchCase.Checked; }
            set { checkboxMatchCase.Checked = value; }
        }
        public bool IsMatchWholeWordChecked
        {
            get { return checkboxMatchWholeWord.Checked; }
            set { checkboxMatchWholeWord.Checked = value; }
        }
        private Point startLocation;

        public FindAndReplaceControl()
        {
            InitializeComponent();
        }


        // MAIN CONTROL EVENTS
        private void FindAndReplaceControl_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.btnFindUp, "Find Previous");
            toolTip.SetToolTip(this.btnFindDown, "Find Next");

        }

        private void FindAndReplaceControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                tboxFind.Focus();
                tboxFind.SelectAll();
            }
        }


        // BUTTON EVENTS
        public void btnCloseControl_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void btnFindUp_Click(object sender, EventArgs e)
        {
            mainForm.FindAndSelect(WordToFind, IsMatchCaseChecked, IsMatchWholeWordChecked, false);
        }

        private void btnFindDown_Click(object sender, EventArgs e)
        {
            mainForm.FindAndSelect(WordToFind, IsMatchCaseChecked, IsMatchWholeWordChecked, true);
        }

        private void toggleExpandCollapse_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleExpandCollapse.Checked == true)
            {
                toggleExpandCollapse.BackgroundImage = Resources.arrow_down;

                panelReplace.SuspendLayout();
                panelReplace.Controls.Clear();
                panelReplace.Controls.Add(replaceControl);
                panelReplace.ResumeLayout();

                replaceControl = (ReplaceControl)panelReplace.Controls[0];
                replaceControl.findAndReplaceControl = this;

                if (mainForm.findAndReplacePopup.Top > mainForm.textBoxMain.Height - mainForm.findAndReplacePopup.Height + 5)
                {
                    mainForm.findAndReplacePopup.Top = mainForm.textBoxMain.Height - mainForm.findAndReplacePopup.Height + 5;
                }
            }
            else
            {
                toggleExpandCollapse.BackgroundImage = Resources.arrow_right;

                panelReplace.SuspendLayout();
                panelReplace.Controls.Clear();
                panelReplace.ResumeLayout();
            }
        }


        // TEXTBOX EVENTS
        private void tboxFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Tab))
            {
                replaceControl.tboxReplace.Focus();
            }
        }

        private void tboxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.Visible)
                {
                    this.Visible = false;
                }
            }
        }

        private void tboxFind_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tboxFind.Text))
            {
                btnFindDown.Enabled = true;
                btnFindDown.BackgroundImage = Resources.search_down;
                btnFindUp.Enabled = true;
                btnFindUp.BackgroundImage = Resources.search_up;

                replaceControl.btnReplaceNext.Enabled = true;
                replaceControl.btnReplaceAll.Enabled = true;
            }
            else
            {
                btnFindDown.Enabled = false;
                btnFindDown.BackgroundImage = Resources.search_down_disabled;
                btnFindUp.Enabled = false;
                btnFindUp.BackgroundImage = Resources.search_up_disabled;

                replaceControl.btnReplaceNext.Enabled = false;
                replaceControl.btnReplaceAll.Enabled = false;
            }

        }


        // FIND CONTROL DRAG MOVEMENT
        private void btnDragFindControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startLocation = e.Location;
            }
        }

        private void btnDragFindControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ny = Math.Min(Math.Max(mainForm.findAndReplacePopup.Top + (e.Y - startLocation.Y), 35), mainForm.textBoxMain.Height - mainForm.findAndReplacePopup.Height + 5);
                mainForm.findAndReplacePopup.Top = ny;
            }
        }
    }
}
