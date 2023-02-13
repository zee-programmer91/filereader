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
                string[] idNumbers = File.ReadAllLines(pathToFile);
                return idNumbers;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File path '"+pathToFile+"' does not exist");
                return new string[0];
            }
        }
    }
}