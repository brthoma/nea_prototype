using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace nea_prototype
{
    public interface IClassifier
    {
        double Classify(string text);
    }

    public class Printable : IClassifier
    {
        public double Classify(string text)
        {
            int printable = 0;
            foreach (char c in text)
            {
                if (! (char.IsWhiteSpace(c) || char.IsControl(c)) ) printable++;
            }
            double proportion = (printable / text.Length);
            return proportion;
        }
    }
    public class FreqAnalysis : IClassifier
    {
        private Dictionary<double, double> Γ = new Dictionary<double, double> 
        { 
            { 0.5, 1.772453851 }, 
            { 1, 1 }, 
            { 1.5, 0.8862269255 }, 
            { 2, 1 }, 
            { 2.5, 1.329340388 }, 
            { 3, 2 }, 
            { 3.5, 3.32335097 }, 
            { 4, 6 }, 
            { 4.5, 11.6317284 }, 
            { 5, 24 }, 
            { 5.5, 52.34277778 }, 
            { 6, 120 }, 
            { 6.5, 287.8852778 }, 
            { 7, 720 }, 
            { 7.5, 1871.254306 }, 
            { 8, 5040 }, 
            { 8.5, 14034.40729 }, 
            { 9, 40320 }, 
            { 9.5, 119292.462 }, 
            { 10, 362880 }, 
            { 10.5, 1133278.389 }, 
            { 11, 3628800 }, 
            { 11.5, 11899423.08 }, 
            { 12, 39916800 }, 
            { 12.5, 136843365.5 }, 
            { 13, 479001600 } 
        };
        private double lowIncGammaFnct;
        private double ChiSquared(double[] fo, double[] fe, int v = 26 - 1)
        {
            double chiSquared = 0;
            for (int i = 0; i < fo.Length; i++)
            {
                chiSquared += Math.Pow( fo[i] - fe[i], 2) / fe[i];
            }
            //Console.WriteLine("Chi: " + chiSquared);
            
            return 1 - CDF(v, chiSquared);
        }
        private double CDF(int degFreedom, double chiSquared) //Cumulative Distribution Function -> this is the integral of the Probablility Density Function of the chi squared distribution
        {
            //Console.WriteLine("Gamma: " + Γ[(double)degFreedom / 2]);
            return ɣ((double)degFreedom / 2, chiSquared / 2) / Γ[(double)degFreedom / 2];
        }
        private double ɣ(double s, double x, int n = 10000000)
        {
            double h = x / n;
            double result = 0;
            for (int i = 1; i < n; i++)
            {
                result += Math.Pow(i * h, s - 1) * Math.Pow(Math.E, -i * h);
            }
            result *= 2;
            result += n * h * Math.Pow(Math.E, -h);
            result *= h / 2;
            //Console.WriteLine("Lower: " + result);
            return result;
        }
        //public (double[], double[]) CombineClasses(double[] fo, double[] fe)
        //{
        //    List<double[]> cols = new List<double[]>();
        //    for (int i = 0; i < fo.Length; i++)
        //    {
        //        cols.Add(new double[] { fo[i], fe[i] });
        //    }
        //    while (fe.Min() < 5)
        //    {
                
        //    }
        //}
        public double Classify(string text)
        {
            int n = text.Count(c => "abcdefghijklmnopqrstuvwxyz".Contains(char.ToLower(c)));
            double[] expectedDistribution = { 0.0804, 0.0148, 0.0334, 0.0382, 0.1249, 0.0240, 0.0187, 0.0505, 0.0757, 0.0016, 0.0054, 0.0407, 0.0251, 0.0723, 0.0764, 0.0214, 0.0012, 0.0628, 0.0651, 0.0928, 0.0273, 0.0105, 0.0168, 0.0023, 0.0166, 0.0009 };
            double[] expectedFreqs = new double[26];
            for (int i = 0; i < expectedFreqs.Length; i++) expectedFreqs[i] = expectedDistribution[i] * n;
            double[] observedFreqs = new double[26];
            for (int i = 0; i < 26; i++)
            {
                observedFreqs[i] = text.Count(c => char.ToLower(c) == (char)('a' + i));
            }
            int degFreedom = 25;
            return ChiSquared(observedFreqs, expectedFreqs, degFreedom);
            //return 1 - CDF(degFreedom, 14.61);
        }
    }
}
