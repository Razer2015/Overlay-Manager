using Overlay_Manager.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Overlay_Manager
{
    class PackagesHandler
    {
        private ADBHandler adbHandler;
        private ComboBox parentComboBox;
        private Package[] packages;

        public PackagesHandler(ADBHandler adbHandler, ComboBox parentComboBox) {
            this.adbHandler = adbHandler;
            this.parentComboBox = parentComboBox;
        }

        public void RefreshData(Package[] packages) {
            this.packages = packages;
            parentComboBox.Items.Clear();
            foreach (var package in packages) {
                parentComboBox.Items.Add(package.packageName);
            }
        }

        public void Download() {
            if(parentComboBox.SelectedIndex >= 0 && parentComboBox.SelectedIndex < parentComboBox.Items.Count) {
                var packageName = parentComboBox.SelectedItem.ToString();
                var package = this.packages.FirstOrDefault(x => x.packageName.Equals(packageName));
                try {
                    adbHandler.DownloadFile(package.remotePath, $"{packageName}.apk");
                    var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    MessageBox.Show($"Path: {System.IO.Path.Combine(path, $"{packageName}.apk")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception e) {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please select a package first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
