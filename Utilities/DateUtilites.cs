using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_project.Utilities
{
    internal class DateUtilites
    {
        public static uint CalculateAge(DateTime date)
        {
            DateTime now = DateTime.Now;
            uint age = (uint)(now.Year - date.Year);
            if (now.Month < date.Month || (now.Month == date.Month && now.Day < date.Day))
            {
                age--;
            }
            return age;
        }

        public static string GetWesternZodiac(DateTime dateOfBirth)
        {
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;

            int[] endDates = { 20, 19, 20, 20, 20, 21, 22, 22, 22, 22, 21, 21 };
            string[] zodiacSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini",
                             "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };

            if (day < endDates[month - 1])
                return zodiacSigns[month - 1];
            else
                return zodiacSigns[month % 12];
        }

        public static string GetChineseZodiac(DateTime dateOfBirth)
        {
            string[] chineseZodiacSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake",
                                            "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return chineseZodiacSigns[(dateOfBirth.Year - 4) % 12];
        }


        public static bool IsBirthday(DateTime dateOfBirth)
        {
            DateTime now = DateTime.Now;
            return now.Month == dateOfBirth.Month && now.Day == dateOfBirth.Day;
        }
    }
}
