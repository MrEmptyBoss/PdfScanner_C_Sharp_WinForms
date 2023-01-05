using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buffer = PdfSacannerAlfaVersion.Model.Settings.Buffer;

namespace PdfSacannerAlfaVersion.Model.Scanner
{

    class ScannerBuffer
    {
        public List<Buffer> InfoBuffer()
        {
            List<Buffer> files = new List<Buffer>();

            string ish = Clipboard.GetText();

            string ots = Regex.Replace(ish, @"\b мм\b|\b шт\b", "\n");

            string[] data = ots.Split('\t', '\r', '\n');

            List<string> spisokmus = new List<string>();


            for (int i = 0; i < data.Length; i++)
            {
                string slovo = data[i];
                if (slovo == "")
                {

                }
                else if (slovo == ".")
                {

                }
                else if (slovo == ".pdf")
                {

                }

                else
                {
                    spisokmus.Add(slovo);
                }
            }

            int filesCount = spisokmus.Count / 4;

            for (int i = 0; i < filesCount; i++)
            {
                Buffer files2 = new Buffer() { nameValue = spisokmus[0 + 0], 
                    dlinaValue = spisokmus[0 + 1],
                    shirValue = spisokmus[0 + 2],
                    colValue = spisokmus[0 + 3] };
                files.Add(files2);
                spisokmus.RemoveRange(0, 4);
            }
            #region ~~Сортировка по алфавиту~~~
            files.Sort(delegate (Buffer name, Buffer name2)
            { return name.nameValue.CompareTo(name2.nameValue); });
            #endregion
            for (int i = 0; i < files.Count; i++)
            {
                string musor1 = files[i].colValue;
                string musor2 = files[i].dlinaValue;
                string musor3 = files[i].shirValue;
                string res1 = Regex.Replace(musor1, @"\D+", "");
                string res2 = Regex.Replace(musor2, @"\D+", "");
                string res3 = Regex.Replace(musor3, @"\D+", "");
                files[i].colValue = res1;
                files[i].dlinaValue = res2;
                files[i].shirValue = res3;

            }

            return files;

        }
    }
}
