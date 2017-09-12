namespace Overlay_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gBox_settings = new System.Windows.Forms.GroupBox();
            this.cBox_device = new System.Windows.Forms.ComboBox();
            this.lbl_devices = new System.Windows.Forms.Label();
            this.lbl_platform_tools = new System.Windows.Forms.Label();
            this.tBox_platform_tools = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.gBox_installedOverlays = new System.Windows.Forms.GroupBox();
            this.panel_base = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gBox_installPackage = new System.Windows.Forms.GroupBox();
            this.cBox_reinstall = new System.Windows.Forms.CheckBox();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_draganddrop = new System.Windows.Forms.Label();
            this.gBox_uninstallPackage = new System.Windows.Forms.GroupBox();
            this.btn_uninstallPackage = new System.Windows.Forms.Button();
            this.cBox_uninstallPackage = new System.Windows.Forms.ComboBox();
            this.gBox_downloadPackage = new System.Windows.Forms.GroupBox();
            this.btn_downloadPackage = new System.Windows.Forms.Button();
            this.cBox_installedPackages = new System.Windows.Forms.ComboBox();
            this.gBox_settings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gBox_installedOverlays.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gBox_installPackage.SuspendLayout();
            this.gBox_uninstallPackage.SuspendLayout();
            this.gBox_downloadPackage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBox_settings
            // 
            this.gBox_settings.Controls.Add(this.cBox_device);
            this.gBox_settings.Controls.Add(this.lbl_devices);
            this.gBox_settings.Controls.Add(this.lbl_platform_tools);
            this.gBox_settings.Controls.Add(this.tBox_platform_tools);
            this.gBox_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBox_settings.Location = new System.Drawing.Point(0, 24);
            this.gBox_settings.Name = "gBox_settings";
            this.gBox_settings.Size = new System.Drawing.Size(846, 71);
            this.gBox_settings.TabIndex = 0;
            this.gBox_settings.TabStop = false;
            this.gBox_settings.Text = "Settings";
            // 
            // cBox_device
            // 
            this.cBox_device.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cBox_device.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBox_device.FormattingEnabled = true;
            this.cBox_device.Location = new System.Drawing.Point(126, 46);
            this.cBox_device.Name = "cBox_device";
            this.cBox_device.Size = new System.Drawing.Size(713, 21);
            this.cBox_device.TabIndex = 3;
            this.cBox_device.SelectedIndexChanged += new System.EventHandler(this.cBox_device_SelectedIndexChanged);
            // 
            // lbl_devices
            // 
            this.lbl_devices.AutoSize = true;
            this.lbl_devices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_devices.Location = new System.Drawing.Point(6, 49);
            this.lbl_devices.Name = "lbl_devices";
            this.lbl_devices.Size = new System.Drawing.Size(99, 13);
            this.lbl_devices.TabIndex = 2;
            this.lbl_devices.Text = "Connected Device:";
            // 
            // lbl_platform_tools
            // 
            this.lbl_platform_tools.AutoSize = true;
            this.lbl_platform_tools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_platform_tools.Location = new System.Drawing.Point(6, 19);
            this.lbl_platform_tools.Name = "lbl_platform_tools";
            this.lbl_platform_tools.Size = new System.Drawing.Size(108, 13);
            this.lbl_platform_tools.TabIndex = 1;
            this.lbl_platform_tools.Text = "Platform Tools - Path:";
            // 
            // tBox_platform_tools
            // 
            this.tBox_platform_tools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBox_platform_tools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_platform_tools.Location = new System.Drawing.Point(126, 16);
            this.tBox_platform_tools.Name = "tBox_platform_tools";
            this.tBox_platform_tools.Size = new System.Drawing.Size(714, 20);
            this.tBox_platform_tools.TabIndex = 0;
            this.tBox_platform_tools.TextChanged += new System.EventHandler(this.tBox_platform_tools_TextChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(846, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(846, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // gBox_installedOverlays
            // 
            this.gBox_installedOverlays.Controls.Add(this.panel_base);
            this.gBox_installedOverlays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBox_installedOverlays.Location = new System.Drawing.Point(3, 3);
            this.gBox_installedOverlays.Name = "gBox_installedOverlays";
            this.gBox_installedOverlays.Size = new System.Drawing.Size(832, 372);
            this.gBox_installedOverlays.TabIndex = 3;
            this.gBox_installedOverlays.TabStop = false;
            this.gBox_installedOverlays.Text = "Installed Overlays";
            // 
            // panel_base
            // 
            this.panel_base.AutoScroll = true;
            this.panel_base.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_base.Location = new System.Drawing.Point(3, 16);
            this.panel_base.Name = "panel_base";
            this.panel_base.Size = new System.Drawing.Size(826, 353);
            this.panel_base.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 95);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(846, 404);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gBox_installedOverlays);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Overlays";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gBox_installPackage);
            this.tabPage2.Controls.Add(this.gBox_uninstallPackage);
            this.tabPage2.Controls.Add(this.gBox_downloadPackage);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Packages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gBox_installPackage
            // 
            this.gBox_installPackage.Controls.Add(this.cBox_reinstall);
            this.gBox_installPackage.Controls.Add(this.btn_browse);
            this.gBox_installPackage.Controls.Add(this.lbl_draganddrop);
            this.gBox_installPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gBox_installPackage.Location = new System.Drawing.Point(3, 145);
            this.gBox_installPackage.Name = "gBox_installPackage";
            this.gBox_installPackage.Size = new System.Drawing.Size(832, 230);
            this.gBox_installPackage.TabIndex = 1;
            this.gBox_installPackage.TabStop = false;
            this.gBox_installPackage.Text = "Install Package";
            // 
            // cBox_reinstall
            // 
            this.cBox_reinstall.AutoSize = true;
            this.cBox_reinstall.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBox_reinstall.Location = new System.Drawing.Point(3, 39);
            this.cBox_reinstall.Name = "cBox_reinstall";
            this.cBox_reinstall.Size = new System.Drawing.Size(826, 17);
            this.cBox_reinstall.TabIndex = 3;
            this.cBox_reinstall.Text = "Reinstall";
            this.cBox_reinstall.UseVisualStyleBackColor = true;
            // 
            // btn_browse
            // 
            this.btn_browse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browse.Location = new System.Drawing.Point(3, 16);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(826, 23);
            this.btn_browse.TabIndex = 2;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Visible = false;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lbl_draganddrop
            // 
            this.lbl_draganddrop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_draganddrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_draganddrop.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_draganddrop.Location = new System.Drawing.Point(3, 16);
            this.lbl_draganddrop.Name = "lbl_draganddrop";
            this.lbl_draganddrop.Size = new System.Drawing.Size(826, 211);
            this.lbl_draganddrop.TabIndex = 4;
            this.lbl_draganddrop.Text = "Drag and Drop - Here";
            this.lbl_draganddrop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gBox_uninstallPackage
            // 
            this.gBox_uninstallPackage.Controls.Add(this.btn_uninstallPackage);
            this.gBox_uninstallPackage.Controls.Add(this.cBox_uninstallPackage);
            this.gBox_uninstallPackage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_uninstallPackage.Location = new System.Drawing.Point(3, 74);
            this.gBox_uninstallPackage.Name = "gBox_uninstallPackage";
            this.gBox_uninstallPackage.Size = new System.Drawing.Size(832, 71);
            this.gBox_uninstallPackage.TabIndex = 2;
            this.gBox_uninstallPackage.TabStop = false;
            this.gBox_uninstallPackage.Text = "Uninstall Package";
            // 
            // btn_uninstallPackage
            // 
            this.btn_uninstallPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_uninstallPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_uninstallPackage.Location = new System.Drawing.Point(3, 37);
            this.btn_uninstallPackage.Name = "btn_uninstallPackage";
            this.btn_uninstallPackage.Size = new System.Drawing.Size(826, 31);
            this.btn_uninstallPackage.TabIndex = 1;
            this.btn_uninstallPackage.Text = "Uninstall the selected package";
            this.btn_uninstallPackage.UseVisualStyleBackColor = true;
            this.btn_uninstallPackage.Click += new System.EventHandler(this.btn_uninstallPackage_Click);
            // 
            // cBox_uninstallPackage
            // 
            this.cBox_uninstallPackage.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBox_uninstallPackage.FormattingEnabled = true;
            this.cBox_uninstallPackage.Location = new System.Drawing.Point(3, 16);
            this.cBox_uninstallPackage.Name = "cBox_uninstallPackage";
            this.cBox_uninstallPackage.Size = new System.Drawing.Size(826, 21);
            this.cBox_uninstallPackage.TabIndex = 0;
            // 
            // gBox_downloadPackage
            // 
            this.gBox_downloadPackage.Controls.Add(this.btn_downloadPackage);
            this.gBox_downloadPackage.Controls.Add(this.cBox_installedPackages);
            this.gBox_downloadPackage.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBox_downloadPackage.Location = new System.Drawing.Point(3, 3);
            this.gBox_downloadPackage.Name = "gBox_downloadPackage";
            this.gBox_downloadPackage.Size = new System.Drawing.Size(832, 71);
            this.gBox_downloadPackage.TabIndex = 0;
            this.gBox_downloadPackage.TabStop = false;
            this.gBox_downloadPackage.Text = "Download Package";
            // 
            // btn_downloadPackage
            // 
            this.btn_downloadPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_downloadPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_downloadPackage.Location = new System.Drawing.Point(3, 37);
            this.btn_downloadPackage.Name = "btn_downloadPackage";
            this.btn_downloadPackage.Size = new System.Drawing.Size(826, 31);
            this.btn_downloadPackage.TabIndex = 1;
            this.btn_downloadPackage.Text = "Download the selected package";
            this.btn_downloadPackage.UseVisualStyleBackColor = true;
            this.btn_downloadPackage.Click += new System.EventHandler(this.btn_downloadPackage_Click);
            // 
            // cBox_installedPackages
            // 
            this.cBox_installedPackages.Dock = System.Windows.Forms.DockStyle.Top;
            this.cBox_installedPackages.FormattingEnabled = true;
            this.cBox_installedPackages.Location = new System.Drawing.Point(3, 16);
            this.cBox_installedPackages.Name = "cBox_installedPackages";
            this.cBox_installedPackages.Size = new System.Drawing.Size(826, 21);
            this.cBox_installedPackages.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gBox_settings);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Overlay Manager - Alpha - by xfileFIN/Razerman";
            this.gBox_settings.ResumeLayout(false);
            this.gBox_settings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gBox_installedOverlays.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gBox_installPackage.ResumeLayout(false);
            this.gBox_installPackage.PerformLayout();
            this.gBox_uninstallPackage.ResumeLayout(false);
            this.gBox_downloadPackage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBox_settings;
        private System.Windows.Forms.Label lbl_platform_tools;
        private System.Windows.Forms.TextBox tBox_platform_tools;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox cBox_device;
        private System.Windows.Forms.Label lbl_devices;
        private System.Windows.Forms.GroupBox gBox_installedOverlays;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Panel panel_base;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gBox_downloadPackage;
        private System.Windows.Forms.GroupBox gBox_installPackage;
        private System.Windows.Forms.ComboBox cBox_installedPackages;
        private System.Windows.Forms.Button btn_downloadPackage;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.CheckBox cBox_reinstall;
        private System.Windows.Forms.Label lbl_draganddrop;
        private System.Windows.Forms.GroupBox gBox_uninstallPackage;
        private System.Windows.Forms.Button btn_uninstallPackage;
        private System.Windows.Forms.ComboBox cBox_uninstallPackage;
    }
}

