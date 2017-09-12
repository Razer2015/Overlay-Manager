using Overlay_Manager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Overlay_Manager
{
    class ThemesHandler
    {
        private ADBHandler adbHandler;
        private Panel parentPanel;

        public ThemesHandler(ADBHandler adbHandler, Panel parentPanel) {
            this.adbHandler = adbHandler;
            this.parentPanel = parentPanel;
        }

        public void RefreshData(Theme[] themes) {
            var results = themes.GroupBy(x => x.targetPackage);
            parentPanel.Controls.Clear();
            foreach (var target in results) {
                parentPanel.Controls.Add(CreateNewTarget(target.ToArray()));
                parentPanel.Controls[parentPanel.Controls.Count - 1].BringToFront();
            }
        }

        private Panel CreateNewTarget(Theme[] themes) {
            System.Windows.Forms.Panel panel_target;
            System.Windows.Forms.CheckedListBox cLB_target;
            System.Windows.Forms.Label lbl_target;
            cLB_target = new System.Windows.Forms.CheckedListBox();
            panel_target = new System.Windows.Forms.Panel();
            lbl_target = new System.Windows.Forms.Label();

            // 
            // lbl_target_android
            // 
            lbl_target.AutoSize = false;
            lbl_target.Dock = System.Windows.Forms.DockStyle.Top;
            lbl_target.Location = new System.Drawing.Point(0, 0);
            lbl_target.Name = $"lbl_target_{themes[0].targetPackage}";
            lbl_target.Size = new System.Drawing.Size(821, 13);
            lbl_target.TabIndex = 0;
            lbl_target.Text = $"{themes[0].targetPackage}";
            // 
            // cLB_target_android
            // 
            cLB_target.Dock = System.Windows.Forms.DockStyle.Fill;
            cLB_target.FormattingEnabled = true;
            cLB_target.CheckOnClick = true;
            cLB_target.SelectionMode = SelectionMode.One;
            foreach (var theme in themes) {
                cLB_target.Items.Add(theme.packageName);
                cLB_target.SetItemCheckState(cLB_target.Items.Count - 1, CheckState.Unchecked);
                cLB_target.SetItemCheckState(cLB_target.Items.Count - 1, (CheckState)((int)theme.status));
            }
            cLB_target.Location = new System.Drawing.Point(0, lbl_target.Height);
            cLB_target.Name = $"cLB_target_{themes[0].targetPackage}";
            cLB_target.Size = new System.Drawing.Size(821, (cLB_target.Items.Count * 13));
            cLB_target.TabIndex = 1;
            cLB_target.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cLB_target_ItemCheck);

            //cLB_target.Size = new System.Drawing.Size(821, neededHeight);
            var totalHeight_cLB = ((cLB_target.GetItemHeight(0) + 2) * cLB_target.Items.Count) + (cLB_target.Margin.Top + cLB_target.Margin.Bottom);
            var totalHeight_lbl = (lbl_target.Height) + (lbl_target.Margin.Top + lbl_target.Margin.Bottom);

            // 
            // panel_target_android
            // 
            panel_target.Controls.Add(cLB_target);
            panel_target.Controls.Add(lbl_target);
            panel_target.Dock = System.Windows.Forms.DockStyle.Top;
            panel_target.Location = new System.Drawing.Point(0, 0); //new System.Drawing.Point(3, 16);
            panel_target.Name = $"panel_target_{themes[0].targetPackage}";
            panel_target.Size = new System.Drawing.Size(821, (totalHeight_cLB + totalHeight_lbl) /*neededHeight + lbl_target.Height*/);
            panel_target.TabIndex = 2;

            return (panel_target);
        }

        private void cLB_target_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Indeterminate)
                return;
            if (e.CurrentValue == CheckState.Indeterminate) {
                e.NewValue = CheckState.Indeterminate;
                return;
            }

            if(e.NewValue == CheckState.Checked) {
                adbHandler.SendCommand($"cmd overlay enable --user 0 {((CheckedListBox)sender).Items[e.Index].ToString()}");
                adbHandler.GetThemes();
            }
            else if (e.NewValue == CheckState.Unchecked) {
                adbHandler.SendCommand($"cmd overlay disable --user 0 {((CheckedListBox)sender).Items[e.Index].ToString()}");
                adbHandler.GetThemes();
            }
        }
    }
}
