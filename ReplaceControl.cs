using System;
using System.Windows.Forms;

namespace Notepad_Z
{
    public partial class ReplaceControl : UserControl
    {
        public FindAndReplaceControl findAndReplaceControl { get; set; }

        public ReplaceControl()
        {
            InitializeComponent();
        }

        private void ReplaceControl_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.btnReplaceNext, "Replace Next");
            toolTip.SetToolTip(this.btnReplaceAll, "Replace All");
        }

        public void btnReplaceNext_Click(object sender, EventArgs e)
        {
            string wordToFind = findAndReplaceControl.tboxFind.Text;
            string wordToReplace = tboxReplace.Text;
            bool isMatchCase = findAndReplaceControl.checkboxMatchCase.Checked;
            bool isWholeWord = findAndReplaceControl.checkboxMatchWholeWord.Checked;
            var stringComparison = isMatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase;
            bool isSearchDown = true;

            mainForm mainForm = this.ParentForm as mainForm;

            if (mainForm.textBoxMain.SelectedText.Equals(wordToFind, stringComparison))
            {
                mainForm.textBoxMain.SelectedText = wordToReplace;
            }

            if (mainForm != null)
            {
                mainForm.FindAndSelect(wordToFind, isMatchCase, isWholeWord, isSearchDown);
            }
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            string wordToFind = findAndReplaceControl.tboxFind.Text;
            string wordToReplace = tboxReplace.Text;
            bool isMatchCase = findAndReplaceControl.checkboxMatchCase.Checked;
            bool isWholeWord = findAndReplaceControl.checkboxMatchWholeWord.Checked;

            mainForm mainForm = this.ParentForm as mainForm;
            mainForm.FindAndReplaceAll(wordToFind, wordToReplace, isMatchCase, isWholeWord);
        }

        private void tboxReplace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (findAndReplaceControl.Visible)
                {
                    findAndReplaceControl.Visible = false;
                }
            }
        }
    }
}
