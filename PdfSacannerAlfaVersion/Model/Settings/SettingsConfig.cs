using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfSacannerAlfaVersion.Model.Settings
{
    public class SettingsConfig
    {
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MiddleName { get; set; }
        public string Telephone { get; set; }
        public string Lvl { get; set; }
        public string idpos { get; set; }
        public string dolz { get; set; }
        public string urlavatar { get; set; }
    }

    public class Version
    {
        public string version { get; set; }
        public string[] info { get; set; }
    }

    public class Buffer
    {
        public string nameValue = string.Empty;
        public string dlinaValue = string.Empty;
        public string shirValue = string.Empty;
        public string colValue = string.Empty;
    }

    public class Files
    {
        public string path;
        public int Height;
        public int Width;
        public int col;
        public double zal;
        public int povf;
        public int color = 0;
        public List<string> FailPages;
    }
}
