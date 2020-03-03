using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace AllFileExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string fpath = "D:\\VersionControl\\LFSTesting";
            var ext = GetAllFileExtenstions(fpath);
            foreach (var e in ext)
            {
                Console.WriteLine(e);
            }
            Console.Title =ext.Length+" Extentions found in " +fpath;

            Console.Read();
        }

        static string[] GetAllFileExtenstions(string directoryPath)
        {

            var filesPathList = Directory.GetFiles(directoryPath,"*.*", SearchOption.AllDirectories);

            List<string> filesNameList = new List<string>();           

            List<string> extensions = new List<string>();           

            //Getting files names
            foreach (var f in filesPathList)
            {
               var arr = f.ToCharArray();
                Array.Reverse(arr);
                List<char> name = new List<char>();
                foreach (var ch in arr)
                {
                    if (ch == '\\')
                        break;
                    else
                        name.Add(ch);
                }
                arr = name.ToArray();
                Array.Reverse(arr);
                string s = new string(arr);
                Regex regex = new Regex(@"(.)*\.(.*)");
                if(regex.IsMatch(s))
                    filesNameList.Add(s);
            }

            //Getting Extensions
            foreach (var s in filesNameList)
            {               
                bool isExtension = false;
                var arr = s.ToCharArray();

                List<char> ext = new List<char>() ;
                foreach(var ch in arr)
                {                   
                    if (ch != '.')
                    {
                        if (!isExtension)
                            continue;
                        else
                            ext.Add(ch);
                    }
                    else if(ch == '.')
                    {
                        isExtension = true;                        
                    }            
                }
                string exName = new string(ext.ToArray());               
                if (extensions.Contains(exName))
                {
                    continue;
                }
                else
                {
                    extensions.Add(exName);
                }
            }
            return extensions.ToArray();
        }
    }
}
