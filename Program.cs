using System;

namespace filereader
{
   class Program{
      static void Main(string[] args){
         int before2010Count = 0;
         int after2010Count = 0;

         string[] idNumbers = System.IO.File.ReadAllLines(@"C:\Users\bbdnet2866\BBD_Training\C#\filereader\ids.txt");

         foreach (string idNumber in idNumbers){
            // Check if ID is valid
            if (idChecker(idNumber)) {
               Console.WriteLine(createDate(idNumber));
               if (before2010(idNumber)) {
                  before2010Count += 1;
               } else {
                  after2010Count += 1;
               }
            } else {
               Console.WriteLine("ERROR: "+ idNumber);
            }
         }

         string writeText = "Number of people before 2010: "+before2010Count+"\n"+"Number of people after 2010: "+after2010Count;
         System.IO.File.WriteAllText("result.txt", writeText);
      }

      static bool idChecker(string idString) {
         // Check length
         bool isCorrectLength = idString.Length == 13;

         // Check if all characters are digits
         bool isAllNumbers = false;

         foreach (char item in idString){
            isAllNumbers = Char.IsDigit(item);
         }

         // Check if month is correct
         bool isMonthCorrect = false;

         int month = Int32.Parse(idString.Substring(2,2));
         isMonthCorrect = 0 < month && month <= 12;

         // Check if day is correct
         bool isDayCorrect = false;

         int day = Int32.Parse(idString.Substring(4,2));
         isDayCorrect = 0 < day && day <= 31;

         return isCorrectLength && isAllNumbers && isMonthCorrect && isDayCorrect;
      }

      static string createDate(string IdNumber) {
         string year = IdNumber.Substring(0,2);
         string month = IdNumber.Substring(2,2);
         string day = IdNumber.Substring(4,2);

         string dateString = day +"/"+month+"/"+year;

         return dateString;
      }

      static bool before2010(string idString) {
         int year = Int32.Parse(idString.Substring(0,2));

         if (year > 23 || year < 10) {
            return true;
         }
         return false;
      }
   }
}
