using MySql.Data.MySqlClient;
using PdfSacannerAlfaVersion.Model.DB;
using PdfSacannerAlfaVersion.Model.Settings;
using PdfSacannerAlfaVersion.View.Main;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using VersionPDF = PdfSacannerAlfaVersion.Model.Settings.Version;
using aLib.Microsoft;

namespace PdfSacannerAlfaVersion
{
    public partial class Login : Form
    {
        WebClient client = new WebClient();
        public bool st = false;
        public string currV;
        public Login()
        {
            InitializeComponent();
            LoadSettingsSerializer();
            Down_Version();
            string path = "v.txt";
            client.DownloadFile("https://drive.google.com/uc?export=download&id=19lR2X2nSbjjiZLWQEtd8xvQMvG-FsWdp", path);
            string[] OB = File.ReadAllLines(@"v.txt");
            File.Delete(@"v.txt");
            if (currV == null  || OB[0] == currV)
            {
                Update_Version(OB);
            }
            else
            {
                this.Alert("Появилось новое обновление!");
            }
            this.FormBorderStyle = FormBorderStyle.None;
            checkBox1.Checked = true;

        }

        public void Alert(string msg)
        {
            Notif frm = new Notif(this);
            frm.showAlert(msg);
        }
        public void Update_Version(string[] v)
        {
            var vers = new VersionPDF();
            vers.version = v[0];
            vers.info = v;
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
                    currV = settings.version;

                }

            }
        }

        private void LoginButt_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                var saveSettingsConf = new SettingsConfig();
                saveSettingsConf.Surname = "Test";
                saveSettingsConf.Name = "Test";
                saveSettingsConf.MiddleName = "Test";
                saveSettingsConf.Telephone = "Test";
                saveSettingsConf.Email = "Test";
                saveSettingsConf.idpos = "Test";
                saveSettingsConf.Login = "Test";
                saveSettingsConf.Password = "Test";
                saveSettingsConf.urlavatar = "Test";
                saveSettingsConf.Lvl = "3";
                saveSettingsConf.dolz = "Test";
                FileInfo fileInfo = new FileInfo("SettingsConfig.xml");
                fileInfo.Delete();
                using (Stream file = new FileStream("SettingsConfig.xml", FileMode.OpenOrCreate))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SettingsConfig));
                    serializer.Serialize(file, saveSettingsConf);
                }

                this.Close();
            }
            else
            {
                string loginUser = LoginBox.Text;
                string passUser = passBox.Text;
                var saveSettingsConf = new SettingsConfig();
                DB dB = new DB();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `accounts` WHERE `login` = @uL AND `pass` = @uP", dB.GetConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                dB.openConnection();

                MySqlDataReader dataReader = command.ExecuteReader();
                if (table.Rows.Count > 0)
                {
                    st = true;
                    MessageBox.Show("Вы вошли");
                    while (dataReader.Read())
                    {
                        saveSettingsConf.Surname = $"{dataReader["surname"]}";
                        saveSettingsConf.Name = $"{dataReader["name"]}";
                        saveSettingsConf.MiddleName = $"{dataReader["middlename"]}";
                        saveSettingsConf.Telephone = $"{dataReader["telephone"]}";
                        saveSettingsConf.Email = $"{dataReader["email"]}";
                        saveSettingsConf.idpos = $"{dataReader["idposition"]}";
                        saveSettingsConf.Login = $"{dataReader["login"]}";
                        saveSettingsConf.Password = $"{dataReader["pass"]}";
                        saveSettingsConf.urlavatar = $"{dataReader["urlavatar"]}";


                    }
                    dB.closeConnection();

                    dB.openConnection();
                    MySqlCommand commandlvl = new MySqlCommand("SELECT * FROM `position` WHERE `id` = @lvl", dB.GetConnection());
                    commandlvl.Parameters.Add("@lvl", MySqlDbType.VarChar).Value = saveSettingsConf.idpos;
                    dataReader = commandlvl.ExecuteReader();
                    while (dataReader.Read())
                    {
                        saveSettingsConf.Lvl = $"{dataReader["rank"]}";
                        saveSettingsConf.dolz = $"{dataReader["name"]}";

                    }
                    dB.closeConnection();
                    FileInfo fileInfo = new FileInfo("SettingsConfig.xml");
                    fileInfo.Delete();
                    using (Stream file = new FileStream("SettingsConfig.xml", FileMode.OpenOrCreate))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(SettingsConfig));
                        serializer.Serialize(file, saveSettingsConf);
                    }

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Неправильные данные");

                }

                this.Close();
            }
           
            
        }

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
                    LoginBox.Text = settings.Login;
                    passBox.Text = settings.Password;

                }

            }

        }


        private void Login_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(388, 500);
            this.MaximumSize = new Size(388,500);
            idT.Text = mm_Encryptions.License.GetUHId();
            this.Close();

        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWhd, int wMsg, int wParam, int lParam);
        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void DLogin_MouseDown(object sender, MouseEventArgs e)
        {
            this.Opacity = 0.5;
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
            this.Opacity = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = idT.Text;
            //mm_Encryptions.License.ActivatedLicense("PdfScanner", mm_Encryptions.AMGCryptUN.ToAUN(id));
            bool ch = mm_Encryptions.License.CheckLic("PdfScanner");
            if(ch == true)
            {
                LoginButt.Enabled = true;
            }
            
        }
    }
}
