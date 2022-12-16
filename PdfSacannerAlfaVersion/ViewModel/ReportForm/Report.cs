using PdfSacannerAlfaVersion.Model.ReportGoogle;
using PdfSacannerAlfaVersion.ViewModel.Notiflication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfSacannerAlfaVersion.ViewModel.ReportForm
{
    public partial class Report : Form
    {
        private GoogleHelper helper;
        public List<string> zayvki = new List<string>();

        public List<string> track = new List<string>();
        public List<Zayvki> list = new List<Zayvki>();
        public Form curr;
        public Report(Form form)
        {
            InitializeComponent();
            curr = form;
        }

        private void LoginGoogleB_Click(object sender, EventArgs e)
        {
            helper = new GoogleHelper(Properties.Settings.Default.GoogleToken, Properties.Settings.Default.SheetFileName);
            bool success = helper.Start().Result;
            StartReportB.Visible = success;
            
        }

        private void StartReportB_Click(object sender, EventArgs e)
        {
            string dated = $"{dateTimePicker1.Value.ToString("d.MM.yyyy")} {dateTimePicker1.Value.ToString("H:mm")}";
            string datef = $"{dateTimePicker2.Value.ToString("d.MM.yyyy")} {dateTimePicker2.Value.ToString("H:mm")}";
            list.Clear();

            for (int i = 0; i < zayvki.Count; i++)
            {
                list.Add(new Zayvki() { name = zayvki[i].ToString(), track = track[i].ToString() });

            }

            for (int i = 0; i < list.Count; i++)
            {
                var response = this.helper.Get();
                for (int j = 0; j < response.Values.Count; j++)
                {


                    if (response.Values[j].Contains(list[i].name))
                    {
                        this.helper.Set(cellName1: "O" + (j + 1), value: list[i].track);
                        Thread.Sleep(1000);
                        this.helper.SetD(cellName1: "G" + (j + 1), cellName2: "H" + (j + 1), value: dated, value2: datef);
                        Thread.Sleep(1000);
                    }
                    else
                    {


                    }


                }

            }

            this.Alert("Отчет обработан");
        }

        public void Alert(string msg)
        {
            Notif frm = new Notif(curr);
            frm.showAlert(msg);
        }

        private void ChoiceZayvB_Click(object sender, EventArgs e)
        {
            string fp = OpenDialog();
            if (fp == null)
            {
                MessageBox.Show("Вы не выбрали файл");
            }
            else
            {
                zayvki.Clear();
                string[] dannie = File.ReadAllLines(fp);
                for (int i = 0; i < dannie.Length; i++)
                {
                    string slovo = dannie[i];
                    zayvki.Add(slovo);
                }
                if (track.Count != 0 && zayvki.Count != 0)
                {
                    TemplateB.Visible = true;
                }
            }
        }

        public string OpenDialog()  // Открытие проводника
        {
            string fp = null;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.RestoreDirectory = false;
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = Path.GetFullPath(openFileDialog.FileName);
                    fp = filePath;
                }
            }
            //label5.Text = new DirectoryInfo(fp).Name;
            return fp;
        }

        private void ChoiceTrackB_Click(object sender, EventArgs e)
        {
            string fp = OpenDialog();
            if (fp == null)
            {
                MessageBox.Show("Вы не выбрали файл");
            }
            else
            {
                track.Clear();
                string[] dannie = File.ReadAllLines(fp);
                for (int i = 0; i < dannie.Length; i++)
                {
                    string slovo = dannie[i];
                    track.Add(slovo);
                }
                if (track.Count != 0 && zayvki.Count != 0)
                {
                    TemplateB.Visible = true;
                }

            }
        }

        private void TemplateB_Click(object sender, EventArgs e)
        {
            string dated = $"{dateTimePicker1.Value.ToString("d.MM.yyyy")} {dateTimePicker1.Value.ToString("H:mm")}";
            string datef = $"{dateTimePicker2.Value.ToString("d.MM.yyyy")} {dateTimePicker2.Value.ToString("H:mm")}";
            for (int i = 0; i < zayvki.Count; i++)
            {
                list.Add(new Zayvki() { name = zayvki[i].ToString(), track = track[i].ToString() });

            }
            StreamWriter file = new StreamWriter($"dd\\Отчет.txt");
            for (int i = 0; i < list.Count; i++)
            {
                file.Write($"Печатная продукция доставлена на РЦ {dated}\nНомер трека ОТМ: {list[i].track}\n{list[i].name}\n{dated} 	{datef}\n\n");
            }
            file.Close();
            this.Alert("Шаблон готов!");
        }
    }

    public class Zayvki
    {
        public string name;
        public string track;
    }
}
