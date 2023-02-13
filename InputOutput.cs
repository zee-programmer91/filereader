using System;
using System.IO;

namespace IOclass
{
    public class InputOuputReader
    {
        public static string[] GetFileContent(string pathToFile)
        {
            try
            {
                return File.ReadAllLines(pathToFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File path '"+pathToFile+"' does not exist");
                return new string[0];
            }
        }
    }
}