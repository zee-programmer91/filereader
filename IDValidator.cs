using System;

namespace Validator
{
    public class IDChecker
    {
        private readonly int EvalutedYear;
        private int OldYears = 0;
        private int NewYears = 0;
        private string pathToFile;
        private string[] listOfIdStrings = new string[] { };

        public string PathToFile
        {
            get { return pathToFile; }
            set { pathToFile = value; }
        }
        public string[] ListOfIdStrings
        {
            get { return listOfIdStrings; }
            set { listOfIdStrings = value; }
        }

        public IDChecker(int evalutedYear)
        {
            EvalutedYear = evalutedYear;
        }

        public void IdentifiedAsOldID()
        {
            OldYears++;
        }

        public void IdentifiedAsNewID()
        {
            NewYears++;
        }

        public int ReturnSumOfOldIdentities()
        {
            return OldYears;
        }

        public int ReturnSumOfNewIdentities()
        {
            return NewYears;
        }
    }
}