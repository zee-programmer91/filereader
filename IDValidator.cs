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

        public void EvaluateIdentitities()
        {
            int count = 0;
            foreach (string IdString in listOfIdStrings)
            {
                // Check if ID is valid
                switch (IdStringValid(IdString)) {
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

        public bool IdStringValid(string idString)
        {
            // Check length and all digits
            Regex lengthReg = new Regex("\\d{13}");
            if (!lengthReg.IsMatch(idString))
            {
                return false;
            }

            // Check Date of Birth
            string dateOfBirth;
            try
            {
                dateOfBirth = idString.Substring(0, 6);
            }
            catch (ArgumentOutOfRangeException)
            {
                dateOfBirth = "010101";
            }

            if (!IsValidDate(dateOfBirth))
            {
                return false;
            }

            return true;
        }

        private string createDate(string IdNumber)
        {
            try
            {
                string year = IdNumber.Substring(0, 2);
                year = CreateYear(year);
                string month = IdNumber.Substring(2, 2);
                string day = IdNumber.Substring(4, 2);

                string dateString = day + "/" + month + "/" + year;

                return dateString;
            } catch (ArgumentOutOfRangeException)
            {
                return "01/01/2000";
            }
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
            Dictionary<string, string> months = new Dictionary<string, string>(){
                { "01","January" },{ "02","February" },
                { "03","March" },{ "04","April" },
                { "05","May" },{ "06","June" },
                { "07","July" },{ "08","August" },
                { "09","September" },{ "10","October" },
                { "11","November" },{ "12","December" },
            };

            foreach (string idString in ValidIdentities)
            {
                string dateString = createDate(idString);
                string[] dateStringSplit = dateString.Split("/");
                string day = dateString.Split("/")[0];
                string month = dateString.Split("/")[1];
                string year = dateString.Split("/")[2];

                string gender = "Male";
                string citizenOrPermanent = "citizen";

                string message = "You were born on the "+day+" of " + months[month]+" "+year;
                message += " and you are "+gender+" and a "+citizenOrPermanent+" of South Africa.";

                Console.WriteLine(message);
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
            Regex validDayReg = new Regex("0[1-9]|[12][0-9]|3[01]");

            string year = CreateYear(DateOfBirth);
            if (!validYearReg.Match(year).Success)
            {
                return false;
            }
            
            string month = DateOfBirth.Substring(2, 2);
            if (!validMonthReg.Match(month).Success)
            {
                return false;
            }

            string day = DateOfBirth.Substring(4, 2);
            if (!validDayReg.Match(day).Success)
            {
                return false;
            }

            return true;
        }
    }
}