using PdfSacannerAlfaVersion.Model.Scanner;
using PdfSacannerAlfaVersion.Model.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfSacannerAlfaVersion.ViewModel.TempScannerBar
{
    public partial class ScannerBar : Form
    {
        public string Path { get; set; }
        public List<Files> filesData { get; set; }
        public ScannerBar(string path)
        {
            InitializeComponent();
            Path = path;
        }

        private void ScannerBar_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            progress();

        }

        public void progress()
        {
            progressBar1.Visible = true;
            progressBar1.BackColor = Color.FromArgb(223, 169, 179);
            progressBar1.ForeColor = Color.FromArgb(211, 29, 62);
            progressBar1.Value = 0;
            progressBar1.Maximum = 0;
            if (Path.Contains(".pdf"))
            {
                ScannerFile scannerFile = new ScannerFile();
                filesData = scannerFile.InfoFiles(Path, progressBar1);
            }
            else
            {
                ScannerFiles scannerFiles = new ScannerFiles();
                filesData = scannerFiles.InfoFiles(Path, progressBar1);
            }
            

    }
    }
}
