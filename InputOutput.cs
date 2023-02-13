using System;
using System.IO;

namespace IOclass
{
    public class InputOuputReader
    {
        public static void GetFileContent(string pathToFile, ref string[] listOfIdStrings)
        {
            try
            {
                listOfIdStrings = File.ReadAllLines(pathToFile);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("ERROR: File path '"+pathToFile+"' does not exist");
            }
        }
    }
}