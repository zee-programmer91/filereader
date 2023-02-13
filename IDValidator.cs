using System;

namespace Validator
{
    public class IDChecker
    {
        private int before2010Count = 0;
        private int after2010Count = 0;
        private string pathToFile;
        private string[] listOfIdStrings = new string[]{};

        public string PathToFile
        {
            get {return pathToFile;}
            set {pathToFile = value;}
        }
        public string[] ListOfIdStrings {
            get { return listOfIdStrings;}
            set { listOfIdStrings = value;}
        }

        public IDChecker() {}
    }
}