using CreatorPDF;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.IO;

namespace CreatorPDF
{
    class LaunchProgram
    {
        private static int numOfPdfs; //Liczba plików
        public static void Launch()
        {
            Console.WriteLine("Ścieżka do miejsca zapisu: C:\\CreatedPDFs\n");
            TargetSource.NewFolder(); //Zawiera ścieżkę zapisu plików. Sprawdza czy folder istnieje, jeśli nie to tworzymy.
            Console.Write("Liczba generowanych plików: ");
            try
            {
                numOfPdfs = Convert.ToInt32(Console.ReadLine());
                //File[] file = new File[numOfPdfs]; //Tworzenie tablicy obiektów (plików)
                for (int i = 0; i < numOfPdfs; i++)
                {
                    File.CreatFile(i); //Wywoływanie metody z klasy File tworzącej pliki
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
    }
}