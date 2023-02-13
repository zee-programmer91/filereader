using System;

namespace Validator
{
    public class IDChecker
    {
        private int before2010Count = 0;
        private int after2010Count = 0;
        private string pathToFile;
        
        public string PathToFile
        {
            get {return pathToFile;}
            set {pathToFile = value;}
        }
        private string[] ListOfIdStrings { get; set; }

        public IDChecker() {}
    }
}