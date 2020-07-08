using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace CretorPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Console.Write("Liczba generowanych plików: ");
            try
            {
                int numOfPdfs = Convert.ToInt32(Console.ReadLine()); //Liczba plików

                for (int i = 1, n = 100000; i <= numOfPdfs; i++, n++)
                {
                    CreatePdf(n);
                }
                Console.Write("\nUtworzone\n\nKliknij Enter, by zamknąć...");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("\nKliknij Enter, by zamknąć...");
                Console.ReadLine();
            }
        }
        static void CreatePdf(int n) //Tworzenie pliku
        {
            Random rand = new Random();
            int numOfPages = rand.Next(80, 750); //Ograniczanie wielkości plików między 1-10MB - 80-750 stron
            int numOfRows = 100;

            PdfDocument document = new PdfDocument(); //Tworzenie pliku PDF
            document.Info.Title = "CreatedPdf";
            PdfPage[] page = new PdfPage[numOfPages];
            for (int i = 0; i < numOfPages; i++) // Wypełnianie stron pseudo losowymi znakami
            {
                page[i] = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page[i]);
                XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
                for (int j = 0; j < numOfRows; j++)
                {
                    gfx.DrawString(TextGenerator(), font, XBrushes.Black,
                       new XRect(0, j * 10, page[i].Width, page[i].Height),
                       XStringFormats.TopCenter);
                }
            }
            string fileName = ".\\created\\" + FileName(n) + ".pdf";
            document.Save(fileName);
        }
        static string TextGenerator() //Generowanie pseudo losowego tekstu
        {
            Random rand = new Random();
            string text = "";

            for (int i = 0; i < 100; i++)
                text += (char)rand.Next(48, 73);

            return text;
        }
        static string FileName(int n) //Generowanie pseudo losowej nazwy na podstawie wzorca
        {
            DateTime data = DateTime.UtcNow.ToLocalTime();
            Random rand = new Random();
            string type = "";
            string year = data.ToString("yyyy");
            string month = data.ToString("MM");
            int term = 0;
            int numOfClient = rand.Next(100000, 999999);

            switch (rand.Next(0, 3))
            {
                case 0:
                    type = "FV";
                    break;
                case 1:
                    type = "KF";
                    break;
                case 2:
                    type = "FZ";
                    break;
                case 3:
                    type = "KZ";
                    break;
            }
            switch (rand.Next(0, 3))
            {
                case 0:
                    term = 1;
                    break;
                case 1:
                    term = 2;
                    break;
                case 2:
                    term = 3;
                    break;
                case 3:
                    term = 4;
                    break;
            }
            string result = type + "-" + n + "-" + year + "-" + month + "-" + term + "-" + numOfClient;

            return result;
        }
    }
}
