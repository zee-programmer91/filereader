using System;
using System.Collections.Generic;
using System.IO;

namespace IOclass
{
    public class InputOuputReader
    {
        public static List<string> GetFileContent(string pathToFile)
        {
            List<string> FileContents= new List<string>();
            try
            {
                foreach (string item in File.ReadAllLines(pathToFile))
                {
                    FileContents.Add(item);
                }
                return FileContents;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File path '"+pathToFile+"' does not exist");
                return new List<string>();
            }
        }
    }
}