using CreatorPDF;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace CreatorPDF
{
    class File
    {
        private static int numOfPages;
        private enum MinMaxPages //Ograniczanie wielkości plików między 100-750 stron - około 1-10 MB
        {
            Min = 100,
            Max = 750
        }
        public static void CreatFile(int n)
        {
            Random rand = new Random();
            numOfPages = rand.Next((int)MinMaxPages.Min, (int)MinMaxPages.Max); //Pseudolosowanie liczby stron z zadanego przedziału
            PdfDocument document = new PdfDocument(); //Tworzenie dokumentu .pdf
            document.Info.Title = "CreatedPdf";
            Page.CreatePages(numOfPages, document); //Tworzenie stron w dokumencie
            string fileName = $"{TargetSource.path}\\{FileName.CreateName(n)}.pdf"; //Tworzenie nazwy pliku
            document.Save(fileName);
        }
    }
}