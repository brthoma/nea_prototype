using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ROT47 rot47 = new ROT47();
            //StrInt key = new StrInt(47);
            //StrInt negKey = new StrInt(-47);
            //string encrypted = rot47.Encrypt("~ABCabcXYZxyz123890!.,;()~", key);
            //Console.WriteLine(encrypted);
            //Console.WriteLine(rot47.Encrypt(encrypted, negKey));

            //XOR xor = new XOR();
            //StrInt key = new StrInt("HELLO");
            //string encrypted = xor.Encrypt("~ABCabcXYZxyz123890!.,; ()~", key);
            //Console.WriteLine(encrypted);
            //Console.WriteLine(xor.Decrypt(encrypted, key));

            FreqAnalysis freqAnalysis = new FreqAnalysis();
            Console.WriteLine(freqAnalysis.Classify(""));

            Console.ReadKey();

        }
    }
}
