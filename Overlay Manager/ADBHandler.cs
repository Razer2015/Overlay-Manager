using Overlay_Manager.Models;
using SharpAdbClient;
using SharpAdbClient.DeviceCommands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Overlay_Manager
{
    class ADBHandler
    {
        private AdbServer Server = new AdbServer();
        public List<DeviceData> Devices;
        public DeviceData Device;
        private DeviceMonitor Monitor;
        private ComboBox CBox_devices;
        private Themes MyThemes;
        private Packages MyPackages;
        public ThemesHandler ThemesHandler;
        public PackagesHandler PackagesHandler;
        public string ADBPath;

        public ADBHandler(string platformTools, Panel panel_base, ComboBox cBox_device, ComboBox installPackages, ComboBox uninstallPackages) {
            CBox_devices = cBox_device;
            ADBPath = Path.Combine(platformTools, "adb.exe");
            var result = Server.StartServer(Path.Combine(platformTools, "adb.exe"), restartServerIfNewer: false);

            Monitor = new DeviceMonitor(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
            Monitor.DeviceConnected += this.OnDeviceConnected;
            Monitor.DeviceDisconnected += this.OnDeviceDisconnected;
            Monitor.Start();

            GetDevices(CBox_devices);

            ThemesHandler = new ThemesHandler(this, panel_base);
            PackagesHandler = new PackagesHandler(this, installPackages, uninstallPackages);
        }

        public void RefreshData() {
            this.GetThemes();
            this.GetPackages();
        }

        public void GetThemes() {
            this.MyThemes = new Themes(this.SendCommand("cmd overlay list --user 0"));
            this.ThemesHandler.RefreshData(this.MyThemes.themes);
        }

        public void GetPackages() {
            this.MyPackages = new Packages(this.SendCommand("pm list packages -f"));
            this.PackagesHandler.RefreshData(this.MyPackages.packages);
        }

        #region Adb Calls
        public void GetDevices(ComboBox cBox_device) {
            Devices = AdbClient.Instance.GetDevices();

            cBox_device.Items.Clear();
            foreach (var device in this.Devices) {
                cBox_device.Items.Add($"{device.Name} - {device.Model} - {device.Serial}");
                Debug.WriteLine(device.Name);
            }
        }

        public void InstallApplication(string packagePath, bool reinstall = false) {
            //var device = AdbClient.Instance.GetDevices().First();
            //PackageManager manager = new PackageManager(this.device);
            //manager.InstallPackage(packagePath, reinstall: reinstall);

            //UploadFile(packagePath, $"data/local/tmp/{Path.GetFileName(packagePath)}", 644);
            //manager.InstallRemotePackage($"data/local/tmp/{Path.GetFileName(packagePath)}", reinstall: reinstall);

            var adbPath = $"\"{ADBPath}\"";
            bool fileCreated = false;
            if (!File.Exists(Path.GetFileName(packagePath))) {
                File.Copy(packagePath, Path.GetFileName(packagePath));
                fileCreated = true;
            }

            String command = $@"/C {adbPath} -s {this.Device.Serial} install{((reinstall) ? " -r" : "")} {Path.GetFileName(packagePath)}";
            ProcessStartInfo cmdsi = new ProcessStartInfo("cmd.exe");
            cmdsi.UseShellExecute = false;
            cmdsi.RedirectStandardError = true;
            cmdsi.Arguments = command;
            cmdsi.WindowStyle = ProcessWindowStyle.Hidden;
            Process cmd = Process.Start(cmdsi);
            cmd.StartInfo.CreateNoWindow = true;
            cmd.WaitForExit();

            if (fileCreated)
                File.Delete(Path.GetFileName(packagePath));

            string output = cmd.StandardError.ReadToEnd();
            if (output.Contains("Success"))
                return;
            else {
                throw new Exception(output);
            }
        }

        public void UninstallPackage(string packageName) {
            PackageManager manager = new PackageManager(this.Device);
            manager.UninstallPackage(packageName);
        }

        public void DownloadFile(string remoteFilePath, string output) {
            //var device = AdbClient.Instance.GetDevices().First();

            using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), this.Device))
            using (Stream stream = File.OpenWrite(output)) {
                service.Pull(remoteFilePath, stream, null, CancellationToken.None);
            }
        }

        public void UploadFile(string input, string remotePath, int permissions) {
            //var device = AdbClient.Instance.GetDevices().First();

            using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), this.Device))
            using (Stream stream = File.OpenRead(input)) {
                service.Push(stream, remotePath, permissions, DateTime.Now, null, CancellationToken.None);
            }
        }

        public string SendCommand(string command) {
            //var device = AdbClient.Instance.GetDevices().First();
            var receiver = new ConsoleOutputReceiver();

            AdbClient.Instance.ExecuteRemoteCommand(command, this.Device, receiver);

            Debug.WriteLine("The device responded:");
            Debug.WriteLine(receiver.ToString());
            return (receiver.ToString());
        }
        #endregion

        #region Adb Events
        void OnDeviceConnected(object sender, DeviceDataEventArgs e) {
            if (CBox_devices.InvokeRequired) {
                CBox_devices.Invoke(new Action(() => GetDevices(CBox_devices)));
            } else {
                GetDevices(CBox_devices);
            }
            Debug.WriteLine($"The device {e.Device.Name} has connected to this PC");
        }
        void OnDeviceDisconnected(object sender, DeviceDataEventArgs e) {
            if (CBox_devices.InvokeRequired) {
                CBox_devices.Invoke(new Action(() => GetDevices(CBox_devices)));
            } else {
                GetDevices(CBox_devices);
            }
            Debug.WriteLine($"The device {e.Device.Name} has disconnected from this PC");
        }
        #endregion
    }
}
