using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Overlay_Manager
{
    public partial class Form1 : Form
    {
        private string PlatformTools_path { get; set; }
        private ADBHandler AdbHandler;
        private bool Initialized = false;

        public Form1() {
            InitializeComponent();

            this.gBox_installPackage.AllowDrop = true;
            this.gBox_installPackage.DragEnter += new DragEventHandler(GroupBox_DragEnter);
            this.gBox_installPackage.DragDrop += new DragEventHandler(GroupBox_DragDrop);

            Initialize();
        }

        private bool Initialize() {
            if (AdbHandler != null)
                return (true);

            this.PlatformTools_path = Properties.Settings.Default.platform_tools;
            if (string.IsNullOrEmpty(this.PlatformTools_path)) {
                this.PlatformTools_path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", ""), "platform-tools");
            }

            AdbHandler = new ADBHandler(this.PlatformTools_path, this.panel_base, this.cBox_device, this.cBox_installedPackages, this.cBox_uninstallPackage);

            if (cBox_device.Items.Count > 0)
                cBox_device.SelectedIndex = 0;

            tBox_platform_tools.Text = this.PlatformTools_path;

            if (!File.Exists(Path.Combine(this.PlatformTools_path, "adb.exe")))
                return (false);

            return (true);
        }

        #region Events
        private void tBox_platform_tools_TextChanged(object sender, EventArgs e) {
            if (!File.Exists(Path.Combine(tBox_platform_tools.Text, "adb.exe")))
                return;

            Properties.Settings.Default["platform_tools"] = tBox_platform_tools.Text;
            Properties.Settings.Default.Save();

            if (!Initialized)
                Initialize();
        }

        private void cBox_device_SelectedIndexChanged(object sender, EventArgs e) {
            if (cBox_device.Items.Count <= 0 || AdbHandler == null)
                return;

            if (cBox_device.SelectedIndex >= 0 && cBox_device.SelectedIndex < AdbHandler.Devices.Count) {
                AdbHandler.Device = AdbHandler.Devices[cBox_device.SelectedIndex];
                Debug.WriteLine($"Selected device: {AdbHandler.Device.Name}");

                //this.SendCommand("pm list users"); //TODO: Give support for multiple users

                AdbHandler.GetThemes();
                AdbHandler.GetPackages();
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
            AdbHandler.RefreshData();
        }

        void GroupBox_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void GroupBox_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) {
                Debug.WriteLine(file);

                AdbHandler.PackagesHandler.Install(file, reinstall: cBox_reinstall.Checked);
            }
        }

        private void btn_browse_Click(object sender, EventArgs e) {

        }

        private void btn_downloadPackage_Click(object sender, EventArgs e) {
            AdbHandler.PackagesHandler.Download();
        }

        private void btn_uninstallPackage_Click(object sender, EventArgs e) {
            AdbHandler.PackagesHandler.Uninstall();
        }
        #endregion
    }
}
