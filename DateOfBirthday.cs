using System;

namespace Lab2
{
    static class DateOfBirthday
    {
        
        internal static bool IsBirthday(DateTime birthDate)
        {
            if (DateOfBirthIsTrue(birthDate) == false)
            {
                throw new ArgumentException("not valid birthDate");
            }
            return DateTime.Today.Day == birthDate.Day && DateTime.Today.Month == birthDate.Month;
           
        }
        internal static bool IsAdult(DateTime birthDate)
        {
           return DateOfBirthIsAdult(birthDate);
           
        }


        internal static int CalcAge(DateTime birthDate)
        {
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month > birthDate.Month && DateTime.Now.Day < birthDate.Day))
                return DateTime.Now.Year - birthDate.Year;
            else return DateTime.Now.Year - birthDate.Year;
        }
        internal static int CalcMonth(DateTime birthDate)
        {
            return DateTime.Now.Month - birthDate.Month;
        }
        internal static int CalcDay(DateTime birthDate)
        {
            return DateTime.Now.Day - birthDate.Day;
        }

        internal static bool DateOfBirthIsTrue(DateTime birthDate)
        {
            return AgeIsTrue(CalcAge(birthDate), CalcMonth(birthDate), CalcDay(birthDate));
        }

        internal static bool DateOfBirthIsAdult(DateTime birthDate)
        {
            return AgeIsAdult(CalcAge(birthDate), CalcMonth(birthDate), CalcDay(birthDate));
        }

        private static bool AgeIsTrue(int age, int month, int day)
        {
            return age > 0 && age < 135 || (age == 0 && (month > 0 || month == 0 && (day > 0 || day == 0))) || (age == 0 && (month > 0 && (day < 0 || day == 0)));

        }
        private static bool AgeIsAdult(int age, int month, int day)
        {
            return age > 18 && age <= 135 || (age == 18 && (month > 0 || month == 0 && (day > 0 || day == 0))) || (age == 18 && (month > 0 && (day < 0 || day==0)));
        }

    }
} 