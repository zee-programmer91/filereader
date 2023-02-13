using System;
using IOclass;
using Validator;

namespace filereader
{
   class Program{
      static void Main(string[] args){
         string pathToFile = @"C:\Users\bbdnet2866\BBD_Training\C#\filereader\ids.txt";
         
         IDChecker checker = new IDChecker(2010);

         checker.ListOfIdStrings = InputOuputReader.GetFileContent(pathToFile);

         checker.EvaluateIdentidities();

         string writeText = "Number of people before 2010: "+ checker.ReturnSumOfOldIdentities()+ "\n"+"Number of people after 2010: "+checker.ReturnSumOfNewIdentities();
         System.IO.File.WriteAllText("result.txt", writeText);
         
         checker.DecodeIdentities();
      }
   }
}
