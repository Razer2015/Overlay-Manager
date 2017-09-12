using Overlay_Manager.Models;
using SharpAdbClient;
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
        private AdbServer server = new AdbServer();
        public List<DeviceData> devices;
        public DeviceData device;
        private DeviceMonitor monitor;
        private ComboBox cBox_devices;
        private Themes myThemes;
        private Packages myPackages;
        public ThemesHandler themesHandler;
        public PackagesHandler packagesHandler;
        public string ADBPath;

        public ADBHandler(string platformTools, Panel panel_base, ComboBox cBox_device, ComboBox packagesCbox) {
            cBox_devices = cBox_device;
            ADBPath = Path.Combine(platformTools, "adb.exe");
            var result = server.StartServer(Path.Combine(platformTools, "adb.exe"), restartServerIfNewer: false);

            monitor = new DeviceMonitor(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)));
            monitor.DeviceConnected += this.OnDeviceConnected;
            monitor.DeviceDisconnected += this.OnDeviceDisconnected;
            monitor.Start();

            GetDevices(cBox_devices);

            themesHandler = new ThemesHandler(this, panel_base);
            packagesHandler = new PackagesHandler(this, packagesCbox);
        }


        public void GetThemes() {
            this.myThemes = new Themes(this.SendCommand("cmd overlay list --user 0"));
            this.themesHandler.RefreshData(this.myThemes.themes);
        }

        public void GetPackages() {
            this.myPackages = new Packages(this.SendCommand("pm list packages -f"));
            this.packagesHandler.RefreshData(this.myPackages.packages);
        }

        #region Adb Calls
        public void GetDevices(ComboBox cBox_device) {
            devices = AdbClient.Instance.GetDevices();

            cBox_device.Items.Clear();
            foreach (var device in this.devices) {
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

            String command = $@"/C {adbPath} -s {this.device.Serial} install{((reinstall) ? " -r" : "")} {Path.GetFileName(packagePath)}";
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

        public void DownloadFile(string remoteFilePath, string output) {
            //var device = AdbClient.Instance.GetDevices().First();

            using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), this.device))
            using (Stream stream = File.OpenWrite(output)) {
                service.Pull(remoteFilePath, stream, null, CancellationToken.None);
            }
        }

        public void UploadFile(string input, string remotePath, int permissions) {
            //var device = AdbClient.Instance.GetDevices().First();

            using (SyncService service = new SyncService(new AdbSocket(new IPEndPoint(IPAddress.Loopback, AdbClient.AdbServerPort)), this.device))
            using (Stream stream = File.OpenRead(input)) {
                service.Push(stream, remotePath, permissions, DateTime.Now, null, CancellationToken.None);
            }
        }

        public string SendCommand(string command) {
            //var device = AdbClient.Instance.GetDevices().First();
            var receiver = new ConsoleOutputReceiver();

            AdbClient.Instance.ExecuteRemoteCommand(command, this.device, receiver);

            Debug.WriteLine("The device responded:");
            Debug.WriteLine(receiver.ToString());
            return (receiver.ToString());
        }
        #endregion

        #region Adb Events
        void OnDeviceConnected(object sender, DeviceDataEventArgs e) {
            if (cBox_devices.InvokeRequired) {
                cBox_devices.Invoke(new Action(() => GetDevices(cBox_devices)));
            } else {
                GetDevices(cBox_devices);
            }
            Debug.WriteLine($"The device {e.Device.Name} has connected to this PC");
        }
        void OnDeviceDisconnected(object sender, DeviceDataEventArgs e) {
            if (cBox_devices.InvokeRequired) {
                cBox_devices.Invoke(new Action(() => GetDevices(cBox_devices)));
            } else {
                GetDevices(cBox_devices);
            }
            Debug.WriteLine($"The device {e.Device.Name} has disconnected from this PC");
        }
        #endregion
    }
}
