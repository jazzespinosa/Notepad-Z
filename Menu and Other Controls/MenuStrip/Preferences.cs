using Notepad_Z.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad_Z
{
    /// <summary>
    /// Events for Preferences MenuStrip items
    /// </summary>
    public partial class MainForm
    {
        private void LoadPreferences()
        {
            mainMenuStrip.Items.Insert(3, new ToolStripLabel { Text = "Template", Name = "templateToolStripLabel" });
            mainMenuStrip.Items.Insert(3, new ToolStripSeparator { Name = "separatorToolStripItem", Margin = new Padding(0, 0, 5, 0) });

            templateToolStripComboBox.Visible = Settings.Default.enableTemplate;
            enableTemplateToolStripMenuItem.Checked = Settings.Default.enableTemplate;

            lineBreakToolStripMenuItem.Visible = Settings.Default.enableLineBreak;
            enableLineBreakToolStripMenuItem.Checked = Settings.Default.enableLineBreak;

            if (templateToolStripComboBox.Visible)
            {
                ShowToolsInMenuStrip("templateToolStripLabel");
                ShowToolsInMenuStrip("separatorToolStripItem");
            }
            else
            {
                DestroyToolsInMenuStrip("templateToolStripLabel");
            }
            if (!templateToolStripComboBox.Visible && !lineBreakToolStripMenuItem.Visible)
            {
                DestroyToolsInMenuStrip("separatorToolStripItem");
            }

            textBoxMain.WordWrap = Settings.Default.wordWrap;
            wordWrapToolStripMenuItem.Checked = Settings.Default.wordWrap;

            statusStrip.Visible = Settings.Default.statusBar;
            statusBarToolStripMenuItem.Checked = Settings.Default.statusBar;

        }

        private void enableTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableTemplateToolStripMenuItem.Checked = !enableTemplateToolStripMenuItem.Checked;
            Settings.Default.enableTemplate = enableTemplateToolStripMenuItem.Checked;
            Settings.Default.Save();

            templateToolStripComboBox.Visible = enableTemplateToolStripMenuItem.Checked;
            if (templateToolStripComboBox.Visible)
            {
                ShowToolsInMenuStrip("templateToolStripLabel");
                ShowToolsInMenuStrip("separatorToolStripItem");
            }
            else
            {
                DestroyToolsInMenuStrip("templateToolStripLabel");
            }

            if (!templateToolStripComboBox.Visible && !lineBreakToolStripMenuItem.Visible)
            {
                DestroyToolsInMenuStrip("separatorToolStripItem");
            }
            prefStripMenuItem.ShowDropDown();
        }

        private void enableLineBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableLineBreakToolStripMenuItem.Checked = !enableLineBreakToolStripMenuItem.Checked;
            Settings.Default.enableLineBreak = enableLineBreakToolStripMenuItem.Checked;
            Settings.Default.Save();

            lineBreakToolStripMenuItem.Visible = enableLineBreakToolStripMenuItem.Checked;
            if (lineBreakToolStripMenuItem.Visible)
            {
                ShowToolsInMenuStrip("separatorToolStripItem");
            }

            if (!templateToolStripComboBox.Visible && !lineBreakToolStripMenuItem.Visible)
            {
                DestroyToolsInMenuStrip("separatorToolStripItem");
            }
            prefStripMenuItem.ShowDropDown();
        }

        private void ShowToolsInMenuStrip(string toolStripName)
        {
            if (toolStripName == "templateToolStripLabel")
            {
                var toolStripItem = mainMenuStrip.Items.OfType<ToolStripLabel>().FirstOrDefault(t => t.Name == toolStripName);
                if (toolStripItem != null)
                {
                    toolStripItem.Visible = true;
                }
            }
            else if (toolStripName == "separatorToolStripItem")
            {
                var toolStripItem = mainMenuStrip.Items.OfType<ToolStripSeparator>().FirstOrDefault(t => t.Name == toolStripName);
                if (toolStripItem != null)
                {
                    toolStripItem.Visible = true;
                }
            }
        }

        private void DestroyToolsInMenuStrip(string toolStripName)
        {
            if (toolStripName == "templateToolStripLabel")
            {
                var toolStripItem = mainMenuStrip.Items.OfType<ToolStripLabel>().FirstOrDefault(t => t.Name == toolStripName);
                if (toolStripItem != null)
                {
                    toolStripItem.Visible = false;
                }
            }
            else if (toolStripName == "separatorToolStripItem")
            {
                var toolStripItem = mainMenuStrip.Items.OfType<ToolStripSeparator>().FirstOrDefault(t => t.Name == toolStripName);
                if (toolStripItem != null)
                {
                    toolStripItem.Visible = false;
                }
            }
        }
    }
}
