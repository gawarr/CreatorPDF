using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CreatorPDF
{
    class TargetSource
    {
        public static string path = "C:\\CreatedPDFs";
        public static void NewFolder()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
