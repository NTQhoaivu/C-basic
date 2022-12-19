using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace StoreImageTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enviroment = System.Environment.CurrentDirectory;


            Console.WriteLine("Hello, World!");
            string projectDirectory = Directory.GetParent(enviroment).Parent.FullName;
            var path = projectDirectory + "/Images/";
            var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                if (Regex.IsMatch(filename, @"\.jpg$|\.png$|\.gif$"))
                {
                    imageFiles.Add(filename);
                    string s = Path.GetFileName(filename).Substring(0, Path.GetFileName(filename).Length - 3);
                    Console.WriteLine(s);
                }
            }

        }
    }
}