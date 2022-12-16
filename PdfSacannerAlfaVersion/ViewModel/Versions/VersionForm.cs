using PdfSacannerAlfaVersion.ViewModel.Notiflication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using VersionPDF = PdfSacannerAlfaVersion.Model.Settings.Version;

namespace PdfSacannerAlfaVersion.ViewModel.Versions
{
    public partial class VersionForm : Form
    {
        public Form curr;
        WebClient client = new WebClient();
        public string version;
        public string[] info;
        public string[] last;
        public VersionForm(Form form)
        {
            InitializeComponent();
            curr = form;
            Down_Version();
            label1.Text = $"Текущая версия: {version}";
            label2.Text = $"Что нового в обновлении {version}";
            listBox1.Items.Clear();
            for (int i = 2; i < info.Length; i++ )
            {
                listBox1.Items.Add(info[i]);
            } 
        }
        public void Alert(string msg)
        {
            Notif frm = new Notif(this);
            frm.showAlert(msg);
        }

        private void PrBtn_Click(object sender, EventArgs e)
        {
            string path = "v.txt";
            client.DownloadFile("https://drive.google.com/uc?export=download&id=19lR2X2nSbjjiZLWQEtd8xvQMvG-FsWdp", path);
            string[] OB = File.ReadAllLines(@"v.txt");
            File.Delete(@"v.txt");

            if (version == null || OB[0] == version)
            {
                this.Alert("У вас установлена последняя версия обновления!");
            }
            else
            {
                last = OB;
                this.Alert("Появилось новое обновление!");
                DPObtn.Visible = true;
                listBox1.Items.Clear();
                for (int i = 2; i < OB.Length; i++)
                {
                    listBox1.Items.Add(OB[i]);
                }
                label2.Text = $"Что нового в обновлении {OB[0]}";

            }
        }

        public void Update_Version(string v, string[] inf)
        {
            var vers = new VersionPDF();
            vers.version = v;
            vers.info = inf;
            FileInfo fileInfo = new FileInfo("VersionConfig.xml");
            fileInfo.Delete();
            using (Stream file = new FileStream("VersionConfig.xml", FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(VersionPDF));
                serializer.Serialize(file, vers);
            }

        }

        public void Down_Version()
        {
            if (!File.Exists("VersionConfig.xml"))
                return;
            else
            {
                using (Stream stream = new FileStream("VersionConfig.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(VersionPDF));
                    VersionPDF settings = (VersionPDF)serializer.Deserialize(stream);
                    version = settings.version;
                    info = settings.info;

                }

            }
        }

        private void DPObtn_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
            Update_Version(last[0], last);
            string paths = @"updater\alfa.rar";
            client.DownloadFile(last[1], paths);
            Process.Start("Updater.exe");
            }).Start();
        }
    }
}
