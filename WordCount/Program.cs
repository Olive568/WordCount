using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace DictionaryDemonstration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] dic1 = new string[] {};
            string[] dic2 = new string[] {};
            int ln1count = 0;
            int ln2count = 0;
            Dictionary<string, int> pairs1 = new Dictionary<string, int>();
            Dictionary<string, int> pairs2 = new Dictionary<string, int>();
            string line = "";
            
            using (StreamReader sr = new StreamReader("Jupiter.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    dic1 = line.Split(" ");
                }
            }
            for(int x = 0; x < dic1.Length; x++)
            {
                if (pairs1.ContainsKey(dic1[x]))
                {
                    pairs1[dic1[x]]++;
                }
                else
                {
                    pairs1.Add(dic1[x], 1);
                }
            }
            using (StreamReader sr = new StreamReader("Odin.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    dic2 = line.Split(" ");
                }
            }
            for (int x = 0; x < dic2.Length; x++)
            {
                if (pairs2.ContainsKey(dic2[x]))
                {
                    pairs2[dic2[x]]++;
                }
                else
                {
                    pairs2.Add(dic2[x], 1);
                }
            }
            for (int i = 0; i < dic1.Length; i++)
            {              
                ln1count++;
            }
            for (int i = 0; i < dic2.Length; i++)
            {
                ln2count++;
            }
            var sort1 = pairs1.OrderByDescending(pair => pair.Value);
            var sort2 = pairs2.OrderByDescending(pair => pair.Value);          
            Console.WriteLine("there are " + ln1count + " words");
            using (StreamWriter sw = new StreamWriter("jupitersum.txt"))
            {
                foreach(KeyValuePair<string,int> kvp in sort1)
                {
                    sw.Write(kvp.Key + "\t");
                    sw.Write("-   " + kvp.Value);
                    sw.WriteLine();
                }
                sw.WriteLine("there are " + ln1count + " Lines");
            }
            Console.WriteLine("there are " + ln2count + " words");
            using (StreamWriter sw = new StreamWriter("odinsum.txt"))
            {
                foreach (KeyValuePair<string, int> kvp in sort2)
                {
                    sw.Write(kvp.Key + "\t");
                    sw.Write("-   " + kvp.Value);
                    sw.WriteLine();
                }
                sw.WriteLine("there are " + ln2count + " Lines");
            }
            Console.ReadKey();

        }
    }
}
