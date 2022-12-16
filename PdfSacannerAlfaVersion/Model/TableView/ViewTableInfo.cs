using PdfSacannerAlfaVersion.Model.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buffer = PdfSacannerAlfaVersion.Model.Settings.Buffer;

namespace PdfSacannerAlfaVersion.Model.TableView
{
    class ViewTableInfo
    {
        public void InfoDisplay(List<Files> infos, DataGridView DB)
        {
            DB.Rows.Clear();
            var color = Color.FromArgb(31, 31, 35);
            for (int i = 0; i < infos.Count; i++)
            {
                if (color == Color.FromArgb(31, 31, 35))
                {
                    string zaliv = infos[i].zal.ToString();
                    string bbb = zaliv.Split(',').First();
                    DB.Rows.Add(infos[i].path, bbb, infos[i].Width, infos[i].Height, infos[i].col);
                    var rowps = DB.Rows.Count - 1;
                    DB.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 35);
                    color = Color.FromArgb(34, 36, 46);

                }
                else
                {
                    string zaliv = infos[i].zal.ToString();
                    string bbb = zaliv.Split(',').First();
                    DB.Rows.Add(infos[i].path, bbb, infos[i].Width, infos[i].Height, infos[i].col);
                    var rowps = DB.Rows.Count - 1;
                    DB.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(34, 36, 46);
                    color = Color.FromArgb(31, 31, 35);
                }
            }

        }

        public void InfoDisplayBuffer(List<Buffer> infos, DataGridView DBbuffer, List<Files> infoSc)
        {
            DBbuffer.Rows.Clear();
            var color = Color.FromArgb(31, 31, 35);
            for (int i = 0; i < infos.Count; i++)
            {
                var isTableSize = Convert.ToInt32(infos[i].dlinaValue) + Convert.ToInt32(infos[i].shirValue);
                var isScannerSize = infoSc[i].Width + infoSc[i].Height;
                var summadec6 = isTableSize - 6;
                var summainc6 = isTableSize + 6;
                int colval = Convert.ToInt32(infos[i].colValue);

                if (infoSc[i].Width > 1300 & infoSc[i].Height > 1300)
                {
                    if (color == Color.FromArgb(31, 31, 35))
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Orange;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 35);
                        color = Color.FromArgb(34, 36, 46);

                    }
                    else
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Orange;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(34, 36, 46);
                        color = Color.FromArgb(31, 31, 35);

                    }

                }

                else if (infoSc[i].Width < 210 & colval > 10 | infoSc[i].Height < 210 & colval > 10)
                {
                    if (color == Color.FromArgb(31, 31, 35))
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Blue;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 35);
                        color = Color.FromArgb(34, 36, 46);

                    }
                    else
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Blue;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(34, 36, 46);
                        color = Color.FromArgb(31, 31, 35);

                    }
                }


                else if (summadec6 > isScannerSize | summainc6 < isScannerSize)
                {
                    if (color == Color.FromArgb(31, 31, 35))
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Red;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 35);
                        color = Color.FromArgb(34, 36, 46);
                    }
                    else
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.Red;
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(34, 36, 46);
                        color = Color.FromArgb(31, 31, 35);
                    }

                }
                else
                {
                    if (color == Color.FromArgb(31, 31, 35))
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.FromArgb(234, 234, 234);
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(31, 31, 35);
                        color = Color.FromArgb(34, 36, 46);
                    }
                    else
                    {
                        DBbuffer.Rows.Add(infos[i].nameValue, infos[i].dlinaValue, infos[i].shirValue, infos[i].colValue);
                        var rowps = DBbuffer.Rows.Count - 1;
                        DBbuffer.Rows[rowps].DefaultCellStyle.ForeColor = Color.FromArgb(234, 234, 234);
                        DBbuffer.Rows[rowps].DefaultCellStyle.BackColor = Color.FromArgb(34, 36, 46);
                        color = Color.FromArgb(31, 31, 35);
                    }
                }
            }

        }

    }
}
