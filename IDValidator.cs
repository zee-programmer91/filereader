using System;

namespace Validator
{
    public class IDChecker
    {
        private readonly int EvalutedYear;
        private int OldYears = 0;
        private int NewYears = 0;
        private string[] listOfIdStrings = new string[] { };

        public string[] ListOfIdStrings
        {
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

        public void EvaluateIdentidities()
        {
            foreach (string IdStrings in listOfIdStrings)
            {
                // Check if ID is valid
                if (idChecker(IdStrings))
                {
                    Console.WriteLine(createDate(IdStrings));
                    if (before2010(IdStrings))
                    {
                        IdentifiedAsOldID();
                    }
                    else
                    {
                        IdentifiedAsNewID();
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + IdStrings);
                }
            }
        }

        static bool idChecker(string idString)
        {
            // Check length
            bool isCorrectLength = idString.Length == 13;

            // Check if all characters are digits
            bool isAllNumbers = false;

            foreach (char item in idString)
            {
                isAllNumbers = Char.IsDigit(item);
            }

            // Check if month is correct
            bool isMonthCorrect = false;

            int month = Int32.Parse(idString.Substring(2, 2));
            isMonthCorrect = 0 < month && month <= 12;

            // Check if day is correct
            bool isDayCorrect = false;

            int day = Int32.Parse(idString.Substring(4, 2));
            isDayCorrect = 0 < day && day <= 31;

            return isCorrectLength && isAllNumbers && isMonthCorrect && isDayCorrect;
        }

        static string createDate(string IdNumber)
        {
            string year = IdNumber.Substring(0, 2);
            string month = IdNumber.Substring(2, 2);
            string day = IdNumber.Substring(4, 2);

            string dateString = day + "/" + month + "/" + year;

            return dateString;
        }

        static bool before2010(string idString)
        {
            int year = Int32.Parse(idString.Substring(0, 2));

            if (year > 23 || year < 10)
            {
                return true;
            }
            return false;
        }
    }
}