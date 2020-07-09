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
            Console.WriteLine("Ścieżka do miejsca zapisu plików: C:\\CreatedPDFs\n");
            TargetSource.NewFolder(); //Zawiera ścieżkę zapisu plików. Sprawdza, czy folder istnieje - jeśli nie to tworzy
            
            Console.Write("Wprowadź liczbę generowanych plików: ");
            try
            {
                numOfPdfs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nGenerowanie...");
                Template.CreateTemplate(); //Sprawdza, czy istnieje przykładowy dokument - jeśli nie to tworzy
                for (int i = 0; i < numOfPdfs; i++)
                {
                    PdfFile.CreatFile(i); //Wywoływanie metody z klasy PdfFile tworzącej pliki
                }
                Console.Write("\nUtworzone.\n\nKliknij Enter, by zamknąć...");
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