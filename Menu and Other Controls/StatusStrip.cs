using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad_Z
{
    public partial class MainForm
    {
        /// <summary>
        /// Event to update line and column number in status strip
        /// </summary>
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

    }
}
