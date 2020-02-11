using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var file_r = new StreamReader(@"C:\Users\{username}\Desktop\file.txt");//replace {username} with yours

            List<string> lines = new List<string>();                    

            string thisline; 
            while((thisline = file_r.ReadLine()) != null)
            {
                lines.Add(thisline);
                Console.WriteLine(thisline);
            }
            List<string> newlines = new List<string>();
            foreach (var line in lines)
            {
                char[] charArray = line.ToArray();
                List<char> newLine = new List<char>();
                foreach (var ch in charArray)
                {
                    newLine.Add(setOffset(ch));               
                }

                newlines.Add(new string(newLine.ToArray()));              
            }
            //replace {username} with yours
            File.WriteAllLines(@"C:\Users\{username}\Desktop\encrypted.txt", newlines.ToArray()); 
            Process.Start(@"C:\Users\Areeb\{username}\encrypted.txt");           
        }             

        static char setOffset(char ch)
        {        
            char[] topRow = new char[] { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            char[] homeRow = new char[] { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' };
            char[] bottomRow = new char[] { 'z', 'x', 'c', 'v', 'b', 'n', 'm' };
            char[] topRowCaps = new char[] { 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
            char[] homeRowCaps = new char[] { 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L' };
            char[] bottomRowCaps = new char[] { 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

            char result;
            int index;
            if (( index = Array.IndexOf(topRow, ch) ) != -1)
            {
                if (( index + 1 ) == topRow.Length)
                {
                    result = topRow[0];
                }
                else
                {
                    result = topRow[index + 1];
                }

            }
            else if (( index = Array.IndexOf(homeRow, ch) ) != -1)
            {
                if (( index + 1 ) == homeRow.Length)
                {
                    result = homeRow[0];
                }
                else
                {
                    result = homeRow[index + 1];
                }

            }
            else if (( index = Array.IndexOf(bottomRow, ch) ) != -1)
            {
                if (( index + 1 ) == bottomRow.Length)
                {
                    result = bottomRow[0];
                }
                else
                {
                    result = bottomRow[index + 1];
                }

            }
            else if (( index = Array.IndexOf(topRowCaps, ch) ) != -1)
            {
                if (( index + 1 ) == topRowCaps.Length)
                {
                    result = topRowCaps[0];
                }
                else
                {
                    result = topRowCaps[index + 1];
                }

            }
            else if (( index = Array.IndexOf(homeRowCaps, ch) ) != -1)
            {
                if (( index + 1 ) == homeRowCaps.Length)
                {
                    result = homeRowCaps[0];
                }
                else
                {
                    result = homeRowCaps[index + 1];
                }

            }
            else if (( index = Array.IndexOf(bottomRowCaps, ch) ) != -1)
            {
                if (( index + 1 ) == bottomRowCaps.Length)
                {
                    result = bottomRowCaps[0];
                }
                else
                {
                    result = bottomRowCaps[index + 1];
                }
            }
            else
            {
                result = ch;
            }
            return result;
        }
    }
}
