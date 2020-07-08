using System;
using System.Collections.Generic;
using System.Text;

namespace CreatorPDF
{
    class FileName
    {
        public enum RandValues //Ograniczanie losowania w nazwie
        {
            TTStart = 0, //co do typu i okresu
            TTStop = 3,
            NStart = 100000, //co do numeru kienta
            NStop = 999999
        }
        public static string CreateName(int n) //Generowanie pseudo losowej nazwy na podstawie wzorca
        {
            DateTime data = DateTime.UtcNow.ToLocalTime();
            Random rand = new Random();
            string type = "";
            int term = 0;
            switch (rand.Next((int)RandValues.TTStart, (int)RandValues.TTStop)) //Losowanie typu
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
            switch (rand.Next((int)RandValues.TTStart, (int)RandValues.TTStop)) //Losowanie okresu
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
            /*Wzorzec nazwy faktury
                FV - 000007 - 20 - 05 - 4 - 137518.pdf
                Typ - Numer - rok - miesiąc - okres - numerKlienta
                (FV / KF / FZ / KZ - inkrementowanyNumer - YY - MM - 1 / 2 / 3 / 4 - numerKlienta)
            */
            return type + "-" + n.ToString().PadLeft(6, '0') +
                "-" + data.ToString("yy") + "-" + data.ToString("MM") +
                "-" + term + "-" + rand.Next((int)RandValues.NStart, (int)RandValues.NStop);
        }
    }
}
