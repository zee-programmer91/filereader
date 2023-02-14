using InputOutput;
using Validator;

namespace filereader
{
    public delegate void ValidateIDs();
    class Program{
      static void Main(){
            const string pathToFile = @"C:\Users\bbdnet2866\BBD_Training\C#\filereader\ids.txt";
            const string pathToWriteFileTo = "result.txt";
            const int evaluatedYear = 2010;

            IDChecker checker = new IDChecker(evaluatedYear)
            {
                ListOfIdStrings = InputOuputReader.GetFileContent(pathToFile)
            };

            ValidateIDs IdValidator = new ValidateIDs(checker.DecodeValidIdentities);

            checker.EvaluateIdentitities();

            string writeText = "Number of people before "+ evaluatedYear + ": " + checker.ReturnSumOfOldIdentities() + "\n" + "Number of people after 2010: " + checker.ReturnSumOfNewIdentities();
            System.IO.File.WriteAllText("result.txt", writeText);

            IdValidator();
            InputOuputReader.WriteToFile(pathToWriteFileTo, writeText);
      }
   }
}
