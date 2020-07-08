using CreatorPDF;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace CreatorPDF
{
    class Page
    {
        public static void CreatePages(int numOfPages, PdfDocument document) //Tworzenie stron w dokumencie
        {
            int numOfRows = 100;
            PdfPage[] page = new PdfPage[numOfPages]; //Tworzenie tablicy obiektów (stron)
            for (int i = 0; i < numOfPages; i++) // Wypełnianie stron pseudo losowymi znakami
            {
                page[i] = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page[i]);
                XFont font = new XFont("Verdana", 12, XFontStyle.Bold);
                for (int j = 0; j < numOfRows; j++)
                {
                    gfx.DrawString(TextGenerator.Text(), font, XBrushes.Black,
                       new XRect(0, j * 10, page[i].Width, page[i].Height),
                       XStringFormats.TopCenter); //Generowanie pseudo losowego tekstu przy użyciu klasy TextGeneration
                }
            }
        }
    }
}
