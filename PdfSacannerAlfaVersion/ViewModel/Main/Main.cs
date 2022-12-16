using PdfSacannerAlfaVersion.Model.Scanner;
using PdfSacannerAlfaVersion.Model.Settings;
using PdfSacannerAlfaVersion.ViewModel.MainScanner;
using PdfSacannerAlfaVersion.ViewModel.Notiflication;
using PdfSacannerAlfaVersion.ViewModel.ReportForm;
using PdfSacannerAlfaVersion.ViewModel.TempScannerBar;
using PdfSacannerAlfaVersion.ViewModel.Versions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Buffer = PdfSacannerAlfaVersion.Model.Settings.Buffer;

namespace PdfSacannerAlfaVersion.View.Main
{
    public partial class Main : Form
    {
        private Form currentChildForm;
        public List<Files> files = new List<Files>();
        public int lvl { get; set; }
        public string urlavatar { get; set; }

        private void LoadSettingsSerializer()
        {
            if (!File.Exists("SettingsConfig.xml"))
                return;
            else
            {
                using (Stream stream = new FileStream("SettingsConfig.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsConfig));
                    SettingsConfig settings = (SettingsConfig)serializer.Deserialize(stream);
                    lvl = Convert.ToInt32(settings.Lvl);
                    

                }

            }
        }

        public Main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            LoadSettingsSerializer();
            this.Load += new EventHandler(Main_Load);
            //Image image = GetImageFromPicPath(urlavatar);
            //avatar.BackgroundImage = image;
            //avatar.BackgroundImageLayout = ImageLayout.Stretch;

        }
        //public static Image GetImageFromPicPath(string strUrl)
        //{
        //    using (WebResponse wrFileResponse = WebRequest.Create(strUrl).GetResponse())
        //    using (Stream objWebStream = wrFileResponse.GetResponseStream())
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        objWebStream.CopyTo(ms, 8192);
        //        return System.Drawing.Image.FromStream(ms);
        //    }
        //}
      

        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWhd, int wMsg, int wParam, int lParam);
        private void borderPanel_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            this.Opacity = 1;
        }

        private void btnsver_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60);
                this.Opacity = this.Opacity - 0.5;
            }
            WindowState = FormWindowState.Minimized;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60);
                this.Opacity = this.Opacity + 0.5;
            }
        }

        private void btnrazv_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;

            else
                WindowState = FormWindowState.Normal;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region ~~~Проверка на кэш~~~
        public void CheckFiles()
        {
            string directoryPath = Path.GetTempPath();
            string folder = "Apitron\\";
            string dir = directoryPath + folder;
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
                MessageBox.Show("Кэш очищен!");
            }
            else
            {
                MessageBox.Show("Нету кэша!");
            }
            
        }
        #endregion

        #region ~~~Открытие проводника~~~
        public string OpenDialog()  // Открытие проводника
        {
            string fp = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = false;
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Folder Selection.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string folderPath = Path.GetDirectoryName(openFileDialog.FileName);
                    fp = folderPath;
                }
            }
         
            return fp;
        }

        public string OpenFile()  // Открытие проводника
        {
            string fp = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;
                    fp = fileName;
                }
            }

            return fp;
        }
        #endregion
        private void OpenFolderScanBt_Click(object sender, EventArgs e)
        {
            ScannerBuffer scannerBuffer = new ScannerBuffer();
            List<Buffer> filesBuffer = scannerBuffer.InfoBuffer();
            string pt = OpenDialog();
            if (pt == null)
            {
                MessageBox.Show("Вы не указали папку!");
            }
            else
            {
                ScannerBar scannerBar = new ScannerBar(pt);
                OpenChildForm(scannerBar);
                this.files = scannerBar.filesData;
                OpenChildFormMain(new NewMainScanner(filesBuffer, files, pt, this));
            }
        }


        #region ~~~Scanner Bar~~~
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesk.Controls.Add(childForm);
            PanelDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            childForm.Close();
        }
        #endregion

        #region ~~~Переход формы на сканнирование файлов~~~
        private void OpenChildFormMain(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesk.Controls.Add(childForm);
            PanelDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region ~~~Переход формы на отчет~~~
        private void OpenChildFormReport(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesk.Controls.Add(childForm);
            PanelDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        #region ~~~Переход формы на Обновление~~~
        private void OpenChildFormProgram(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelDesk.Controls.Add(childForm);
            PanelDesk.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(1595,706);
        }

        private void ReportB_Click(object sender, EventArgs e)
        {
            Report report = new Report(this);
            OpenChildFormReport(report);
        }

        public void Alert(string msg)
        {
            Notif frm = new Notif(this);
            frm.showAlert(msg);
        }
        private void OrderListButt_Click(object sender, EventArgs e)
        {
            this.Alert("Скоро будет)");
        }

        private void PrBtn_Click(object sender, EventArgs e)
        {
            VersionForm Vers = new VersionForm(this);
            OpenChildFormProgram(Vers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckFiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScannerBuffer scannerBuffer = new ScannerBuffer();
            List<Buffer> filesBuffer = scannerBuffer.InfoBuffer();
            string pt = OpenFile();
            if (pt == null)
            {
                MessageBox.Show("Вы не указали папку!");
            }
            else
            {
                ScannerBar scannerBar = new ScannerBar(pt);
                OpenChildForm(scannerBar);
                this.files = scannerBar.filesData;
                OpenChildFormMain(new NewMainScanner(filesBuffer, files, pt, this));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(CodeBox.Text == "oHVic3wD1pSFqYu6RiXCpXPY9waNBhNQ34EhfvaetqLHOMkfGtVh2S")
            {
                OpenFolderScanBt.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                OpenFolderScanBt.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/mrempty");
        }
    }
}
