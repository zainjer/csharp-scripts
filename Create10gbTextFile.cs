using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            List<string> m = new List<string>();            
            for (int i = 0; i < 10000000; i++)
            {
                m.Add(i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i + " " + i);
            }
            var arr = m.ToArray();
            m.Clear();
            for (int i = 0; i <= 10; i++)
            {
                System.IO.File.AppendAllLines("D:/x.txt", arr);
                Console.WriteLine("Step " + i + " Done");
            }
            Console.WriteLine("Created file @  D:/x.txt");
            Console.Read();
        }
    }
}
