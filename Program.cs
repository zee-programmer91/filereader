using System;
using IOclass;
using Validator;

namespace filereader
{
   class Program{
      static void Main(string[] args){
            const string pathToFile = @"C:\Users\bbdnet2866\BBD_Training\C#\filereader\ids.txt";
            const string pathToWriteFileTo = "result.txt";
            const int evaluatedYear = 2010;

            IDChecker checker = new IDChecker(evaluatedYear);

            checker.ListOfIdStrings = InputOuputReader.GetFileContent(pathToFile);

            checker.EvaluateIdentitities();

            string writeText = "Number of people before "+ evaluatedYear + ": " + checker.ReturnSumOfOldIdentities() + "\n" + "Number of people after 2010: " + checker.ReturnSumOfNewIdentities();
            System.IO.File.WriteAllText("result.txt", writeText);

            checker.DecodeIdentities();
            InputOuputReader.WriteToFile(pathToWriteFileTo, writeText);
      }
   }
}
