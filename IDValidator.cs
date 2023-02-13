using System;
using System.Collections.Generic;

namespace Validator
{
    public class IDChecker
    {
        private readonly int EvalutedYear;
        private int OldYears = 0;
        private int NewYears = 0;
        private List<string> listOfIdStrings = new List<string>();
        private List<string> ValidIdentities = new List<string>();

        public List<string> ListOfIdStrings
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
            int count = 0;
            foreach (string IdString in listOfIdStrings)
            {
                // Check if ID is valid
                switch (idChecker(IdString)) {
                    case true:
                        Console.WriteLine(createDate(IdString));
                        ValidIdentities.Add(IdString);

                        switch (before2010(IdString))
                        {
                            case true:
                                IdentifiedAsOldID();
                                break;
                            case false:
                                IdentifiedAsOldID();
                                break;
                        }
                        break;
                    case false:
                        Console.WriteLine("ERROR: " + IdString);
                        break;
                }
                count++;
            }
        }

        private bool idChecker(string idString)
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

        private string createDate(string IdNumber)
        {
            string year = IdNumber.Substring(0, 2);
            string month = IdNumber.Substring(2, 2);
            string day = IdNumber.Substring(4, 2);

            string dateString = day + "/" + month + "/" + year;

            return dateString;
        }

        private bool before2010(string idString)
        {
            int year = Int32.Parse(idString.Substring(0, 2));

            if (year > 23 || year < 10)
            {
                return true;
            }
            return false;
        }

        public void DecodeIdentities()
        {
            foreach (string idString in ValidIdentities)
            {
                Console.WriteLine(idString);
            }
        }
    }
}