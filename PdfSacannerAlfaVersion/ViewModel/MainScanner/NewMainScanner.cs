using PdfSacannerAlfaVersion.Model.Settings;
using PdfSacannerAlfaVersion.Model.TableView;
using PdfSacannerAlfaVersion.ViewModel.Notiflication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buffer = PdfSacannerAlfaVersion.Model.Settings.Buffer;

namespace PdfSacannerAlfaVersion.ViewModel.MainScanner
{
    public partial class NewMainScanner : Form
    {
        public List<Buffer> filesBuffer { get; set; }
        public List<Files> files { get; set; }
        public List<Files> filesotsr { get; set; }
        public Form curr;

        public string path { get; set; }
        public NewMainScanner(List<Buffer> FilesBuffer, List<Files> Files, string Pt, Form form)
        {
            InitializeComponent();
            filesBuffer = FilesBuffer;
            files = Files;
            path = Pt;
            filesotsr = Files;
            curr = form;
            this.Alert("Сканирование завершено!");
        }
        public void Alert(string msg)
        {
            Notif frm = new Notif(curr);
            frm.showAlert(msg);
        }

        private void NewMainScanner_Load(object sender, EventArgs e)
        {
            NumberOrder.Text = new DirectoryInfo(path).Name;
            CollFilles.Text = files.Count.ToString();
            listBox1.Items.Clear();
            for (int i = 0; i < files[0].FailPages.Count; i++)
            {
                listBox1.Items.Add(files[0].FailPages[i]);
            }
            //otsr();
            InfoTable();
        }
        public void InfoTable()
        {
            DataGridView DBbuffer = InfoTableBuffer;
            DataGridView DBfiles = TablePdfScanner;
            ViewTableInfo viewTable = new ViewTableInfo();
            viewTable.InfoDisplay(files, DBfiles);
            viewTable.InfoDisplayBuffer(filesBuffer, DBbuffer, files);

        }


        private void InfoTableBuffer_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                ((DataGridView)sender).SelectedCells[0].Selected = false;
            }
            catch { }
        }
    }
}
