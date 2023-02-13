using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            string firstSixNumbers = idString.Substring(0, 6);
            Console.WriteLine("> "+CreateYear(firstSixNumbers) + " " + IsValidDate(firstSixNumbers));

            string nextFourNumbers = idString.Substring(6, 4);

            string nextThreeNumbers = "";
            try
            {
                nextThreeNumbers = idString.Substring(10, 3);
            } catch (Exception e)
            {
                return false;
            }

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
            year = CreateYear(year);
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
                string firstSixNumbers = idString.Substring(0, 6);
                bool isValid = IsValidDate(firstSixNumbers);
                //Console.WriteLine(CreateYear(firstSixNumbers) +" "+isValid);

                string nextFourNumbers = idString.Substring(6, 4);
                string nextThreeNumbers = idString.Substring(10, 3);

                Console.WriteLine(firstSixNumbers);
                Console.WriteLine(nextFourNumbers);
                Console.WriteLine(nextThreeNumbers);
                Console.WriteLine();
            }
        }

        public string CreateYear(string DateOfBirth)
        {
            int startYear = 24;
            string twenty = "20";
            string nineteen = "19";

            try
            {
                string year = DateOfBirth.Substring(0, 2);

                switch (Int32.Parse(year) > startYear)
                {
                    case true:
                        return nineteen + year;
                    case false:
                        return twenty + year;
                }
                return year;
            } catch(Exception) {
                return "";
            }
        }

        public bool IsValidDate(string DateOfBirth)
        {
            Regex validYearReg = new Regex("19|20");
            Regex validMonthReg = new Regex("0[1-9]|1[0-2]");

            string year = CreateYear(DateOfBirth);
            Match matchYear = validYearReg.Match(year);
            
            string month = DateOfBirth.Substring(2, 2);
            Match matchMonh = validMonthReg.Match(month);

            string day = DateOfBirth.Substring(4, 2);

            return matchMonh.Success;
        }
    }
}