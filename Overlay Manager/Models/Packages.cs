using System;
using System.Collections.Generic;

namespace Overlay_Manager.Models
{
    public class Packages
    {
        public Package[] packages { get; set; }

        public Packages() {

        }

        public Packages(string commandResult) {
            var lines = commandResult.Split(new[] { '\r', '\n' });

            List<Package> temp = new List<Package>();
            foreach (var line in lines) {
                if (string.IsNullOrEmpty(line))
                    continue;
                else if (line.StartsWith("package:")) {
                    var parts = line.Remove(0, 8).Split(new string[] { ".apk=" }, StringSplitOptions.None);
                    temp.Add(new Package($"{parts[0]}.apk", parts[1]));
                }
            }
            this.packages = temp.ToArray();
            Array.Sort(this.packages, (x, y) => String.Compare(x.packageName, y.packageName));
        }
    }

    public class Package {
        public string remotePath { get; set; }
        public string packageName { get; set; }

        public Package() {

        }

        public Package(string remotePath, string packageName) {
            this.remotePath = remotePath;
            this.packageName = packageName;
        }
    }
}
