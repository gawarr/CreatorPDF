using CreatorPDF;
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
            LaunchProgram.Launch();//Metoda tworzenia odpowiedniej ilości plików
        }
    }
}