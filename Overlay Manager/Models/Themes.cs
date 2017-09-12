using System.Collections.Generic;

namespace Overlay_Manager.Models
{
    public class Themes
    {
        public Theme[] themes { get; set; }

        public Themes() {

        }

        public Themes(string commandResult) {
            var lines = commandResult.Split(new[] { '\r', '\n' });

            List<Theme> temp = new List<Theme>();
            string targetPackage = null;
            foreach (var line in lines) {
                if (string.IsNullOrEmpty(line))
                    continue;
                else if (line.StartsWith("---")) {
                    temp.Add(new Theme(targetPackage, Status.STATUS_NO_IDMAP, line.Substring(4, line.Length - 4)));
                }
                else if (line.StartsWith("[ ]")) {
                    temp.Add(new Theme(targetPackage, Status.STATUS_DISABLED, line.Substring(4, line.Length - 4)));
                }
                else if (line.StartsWith("[x]")) {
                    temp.Add(new Theme(targetPackage, Status.STATUS_ENABLED, line.Substring(4, line.Length - 4)));
                } else {
                    targetPackage = line;
                }
            }
            this.themes = temp.ToArray();
        }
    }

    public class Theme
    {
        public string targetPackage { get; set; }
        public Status status { get; set; }
        public string packageName { get; set; }

        public Theme() {

        }

        public Theme(string targetPackage, Status status, string packageName) {
            this.targetPackage = targetPackage;
            this.status = status;
            this.packageName = packageName;
        }
    }

    public enum Status
    {
        STATUS_DISABLED,
        STATUS_ENABLED,
        STATUS_NO_IDMAP
    }
}
