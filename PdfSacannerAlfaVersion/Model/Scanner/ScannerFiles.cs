using Apitron.PDF.Rasterizer;
using Apitron.PDF.Rasterizer.Configuration;
using iTextSharp.text.pdf;
using PdfSacannerAlfaVersion.Model.Settings;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PdfSacannerAlfaVersion.Model.Scanner
{
    class ScannerFiles
    {
        public List<Files> InfoFiles(string path, ProgressBar progressBar1)
        {
            List<Files> listInfo = new List<Files>();
            List<double> listProcPages = new List<double>();
            List<string> listFailPages = new List<string>();
            int prog = 0;

            if (path == null)
            {
                return listInfo;
            }
        
            string[] fileEntries = Directory.GetFiles(path);

            progressBar1.Maximum = fileEntries.Length;
            foreach (string fileNames in fileEntries)
            {

                PdfReader pdfReaderr = null;
                try
                {
                    PdfReader pdfReader = new PdfReader(fileNames);
                    pdfReaderr = pdfReader;
                    int numberOfPages = pdfReaderr.NumberOfPages;
                    Spire.Pdf.PdfDocument doc = new Spire.Pdf.PdfDocument();
                    doc.LoadFromFile(fileNames);
                    PdfPageBase page = doc.Pages[0];
                    float pointwidth = page.Size.Width;
                    float pointheight = page.Size.Height;
                    var point = 0.3527;
                    int height = Convert.ToInt32(Math.Round(pointheight * point));
                    int width = Convert.ToInt32(Math.Round(pointwidth * point));
                    var namef = Path.GetFileName(fileNames);
                    pdfReader.Close();
                    //Start Fill Block
                    FileStream fs = new FileStream(fileNames, FileMode.Open);
                    Document document = new Document(fs);
                    RenderingSettings settings = new RenderingSettings();
                    for (int i = 0; i < document.Pages.Count; i++)
                    {

                        Page currentPage = document.Pages[i];
                        using (Bitmap bitmap = currentPage.Render(((int)currentPage.Width / 2), ((int)currentPage.Height / 2), settings))
                        {
                            //bitmap.Save(string.Format("images/" + namef + "{0}.tif", i), ImageFormat.Tiff);
                            List<pixels> pixels = CountPixels(bitmap, Color.FromArgb(255, 255, 255, 255));
                            listProcPages.Add(Math.Round(obr(pixels[0].white_pixels, pixels[0].Pixels), 0));
                            if (listProcPages.Last() < 0.01)
                            {
                                string failPage = namef + " -  " + listProcPages.Count + " страница повреждена";
                                listFailPages.Add(failPage);
                            }
                        }

                    }

                    double tempZal = 0;
                    double resultZal;
                    for (int i = 0; i < document.Pages.Count; i++)
                    {
                        tempZal = tempZal + listProcPages[i];
                    }

                    resultZal = tempZal / document.Pages.Count;

                    //End Fill Block
                    var info = new Files { path = namef, zal = resultZal, Height = height, Width = width, col = numberOfPages, color = 0, FailPages = listFailPages };
                    listInfo.Add(info);
                    listProcPages.Clear();
                    fs.Close();
                }

                catch (iTextSharp.text.exceptions.InvalidPdfException)
                {
                    var nameff = Path.GetFileName(fileNames);
                    var info = new Files { path = nameff, Height = 0, Width = 0, col = 0, povf = 0, color = 1 };
                    listInfo.Add(info);
                    MessageBox.Show("Файл поврежден: " + nameff);
                    listInfo[0].povf++;

                }

                prog++;
                progressBar1.Value = prog;

            };
            return listInfo;
        }

        class pixels
        {
            public double white_pixels;
            public double Pixels;
        }

        //Start Find Pixels
        private List<pixels> CountPixels(Bitmap bm, Color target_color)
        {
            List<pixels> pixels = new List<pixels>();
            // Loop through the pixels.
            int matches = 0;

            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    if (bm.GetPixel(x, y) == target_color)
                    {
                        matches++;
                    }
                }
            }
            var col = bm.Height * bm.Width;
            var info = new pixels { white_pixels = matches, Pixels = col };
            pixels.Add(info);

            return pixels;

        }

        //End Find Pixels


        // Start Calculate zalivka
        public double obr(double white, double pixels)
        {

            double formula = (white * 100.0) / pixels;
            double result = 100.0 - formula;
            if (result < 99.9 & result > 0.1)
            {
                var result2 = result - 0.35;
                return result2;

            }
            else
                return result;

        }

    }
}
