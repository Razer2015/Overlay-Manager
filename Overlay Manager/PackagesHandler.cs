using Overlay_Manager.Models;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Overlay_Manager
{
    class PackagesHandler
    {
        private ADBHandler AdbHandler;
        private ComboBox InstallPackages;
        private ComboBox UninstallPackages;
        private Package[] Packages;

        public PackagesHandler(ADBHandler adbHandler, ComboBox installPackages, ComboBox uninstallPackages) {
            this.AdbHandler = adbHandler;
            this.InstallPackages = installPackages;
            this.UninstallPackages = uninstallPackages;
        }

        public void RefreshData(Package[] packages) {
            this.Packages = packages;
            InstallPackages.Items.Clear();
            UninstallPackages.Items.Clear();
            foreach (var package in packages) {
                InstallPackages.Items.Add(package.packageName);
                UninstallPackages.Items.Add(package.packageName);
            }
        }

        public void Download() {
            if(InstallPackages.SelectedIndex >= 0 && InstallPackages.SelectedIndex < InstallPackages.Items.Count) {
                var packageName = InstallPackages.SelectedItem.ToString();
                var package = this.Packages.FirstOrDefault(x => x.packageName.Equals(packageName));
                try {
                    AdbHandler.DownloadFile(package.remotePath, $"{packageName}.apk");
                    var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    MessageBox.Show($"Path: {System.IO.Path.Combine(path, $"{packageName}.apk")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception e) {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please select a package first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Install(string file, bool reinstall = false) {
            FileAttributes attr = File.GetAttributes(file);
            if ((attr & FileAttributes.Archive) == FileAttributes.Archive) {
                using (ZipArchive zip = ZipFile.Open(file, ZipArchiveMode.Read)) {
                    if (zip.Entries.Any(x => x.Name.Equals("AndroidManifest.xml"))) {
                        try {
                            AdbHandler.InstallApplication(file, reinstall: reinstall);
                            MessageBox.Show($"Installed: {Path.GetFileName(file)}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AdbHandler.RefreshData();
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show($"Not a valid APK, ignoring {file}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Uninstall() {
            if (UninstallPackages.SelectedIndex >= 0 && UninstallPackages.SelectedIndex < UninstallPackages.Items.Count) {
                var packageName = UninstallPackages.SelectedItem.ToString();
                var package = this.Packages.FirstOrDefault(x => x.packageName.Equals(packageName));
                try {
                    AdbHandler.UninstallPackage(packageName);
                    MessageBox.Show($"Package: {packageName} uninstalled succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdbHandler.RefreshData();
                } catch (Exception e) {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please select a package first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
