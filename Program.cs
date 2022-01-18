using System;
using System.IO;
using System.Collections.Generic;

namespace C__Reduce_Dictonary
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = $"./output/{DateTime.Now.ToString("MMdd HH.mm.ss")}.txt";
            string[] dictionary = File.ReadAllLines("./dictionary.txt");
            List <string> newDictionary = new List <string>();
            Random getRandom = new Random();
            int nexRand;
            int one_out_of = 100;
            double delta;

            Console.Write("Selecting ramdom lines, 25% ...");

            for(int i=0; i<dictionary.Length; i++)
            {
                nexRand = getRandom.Next(one_out_of);

                if(nexRand < 1)
                {
                    newDictionary.Add(dictionary[i]);
                }
            }

            double newCount = Convert.ToDouble(newDictionary.Count);
            double oldCount = Convert.ToDouble(dictionary.Length);
            delta = Math.Round((newCount/oldCount) * 100, 2);
            File.WriteAllLines(path, newDictionary.ToArray());

            Console.Clear();
            Console.Write($@"
            New dictionary created. 
            New length : [{newDictionary.Count}].
            % Of Old Dict : {delta} %
");
            Console.ReadKey();
        }
    }
}
