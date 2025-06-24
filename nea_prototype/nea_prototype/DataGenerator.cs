using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public class DataGenerator
    {
        public string Generate(string dictFilePath, int length, Random random)
        {
            string[] dict = File.ReadAllLines(dictFilePath);
            string text = "";
            do
            {
                text += dict[random.Next(0, dict.Length)] + " ";
            }while (text.Length < length);

            return text.Substring(0,length).Trim();
        }
    }
}
