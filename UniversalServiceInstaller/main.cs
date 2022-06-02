using System.Diagnostics;
using System.Reflection;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.ServiceProcess;
using System.Security.Principal;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Threading;
namespace UniversalServiceInstaller
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            CheckStatus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("explorer","https://github.com/Xottabich0/DiscordHWRich");
        }
        static bool IsElevated => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        public bool serviceExists(string ServiceName)
        {
            return ServiceController.GetServices().Any(serviceController => serviceController.ServiceName.Equals(ServiceName));
        }
        public void CheckStatus()
        {
            if (!IsElevated)
            {
                rights.Visible = true;
                button1.Enabled = false;
                button2.Enabled = false;
            }
            if (serviceExists("DiscordStatus"))
            {
                Installed.Visible = true;
                Uninstalled.Visible = false;
                button1.Enabled = false;
            }
            else
            {
                Installed.Visible = false;
                Uninstalled.Visible = true;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string Path = @"c:\dhwrich\";
            bool exists = System.IO.Directory.Exists(Path);
            if (!exists)
                System.IO.Directory.CreateDirectory(Path);
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://upload.efster.space/Release.zip", "c:\\dhwrich\\dhw.zip");
            if (!File.Exists("c:\\dhwrich\\b.exe"))
            {
                ZipFile.ExtractToDirectory(@"c:\dhwrich\dhw.zip", Path);
            }
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
			    CreateNoWindow = true
            };
            processStartInfo.FileName = "sc";
            processStartInfo.Arguments = "create DiscordStatus binpath=C:\\dhwrich\\b.exe start=auto";
            process.StartInfo = processStartInfo;
            process.Start();
            processStartInfo.FileName = "sc";
            processStartInfo.Arguments = "start DiscordStatus";
            process.Start();
            MessageBox.Show("Installed!");
            CheckStatus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };
            processStartInfo.FileName = "sc";
            processStartInfo.Arguments = "stop DiscordStatus";
            process.StartInfo = processStartInfo;
            process.Start();
            Thread.Sleep(100);
            processStartInfo.FileName = "sc";
            processStartInfo.Arguments = "delete DiscordStatus";
            process.Start();
            MessageBox.Show("Deleted!");
            CheckStatus();
        }
    }
}