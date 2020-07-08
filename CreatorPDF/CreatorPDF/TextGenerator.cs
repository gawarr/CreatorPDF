using System;
using System.Collections.Generic;
using System.Text;

namespace CreatorPDF
{
    class TextGenerator
    {
        public static string Text()
        {
            Random rand = new Random();
            string text = "";
            for (int i = 0; i < 100; i++)
                text += (char)rand.Next(48, 73);
            return text;
        }
    }
}
