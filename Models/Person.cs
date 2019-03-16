using System;

namespace Lab2.Models
{
    class Person
    {
        #region read & write binding properties
        internal string Name { get; private set; }
        internal string Surname { get; private set; }
        internal string Email { get; private set; }
        internal DateTime DateOfBirth { get; private set; }

        #endregion
        #region read only binding properties
        internal bool IsAdult => DateOfBirthday.IsAdult(DateOfBirth);

        internal bool IsBirthday => DateOfBirthday.IsBirthday(DateOfBirth);

        internal AstrologicalSign AstrologicalSign => GetAstrSignOfBirthday(DateOfBirth);

        internal ZodiacSign ZodiacSign => GetZodSignOfBirthday(DateOfBirth);
        #endregion

        #region ctors
        internal Person(string name, string surname, string email, DateTime dateOfBirth) : this(name, surname, email)
        {
            if (!DateOfBirthday.DateOfBirthIsTrue(dateOfBirth))
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth));
            }
            DateOfBirth = dateOfBirth;
        }

        internal Person(string name, string surname, string email) : this(name, surname)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (!EmailValidator.IsValidFormat(email))
            {
                throw new ArgumentException("the email is badly fomatted");
            }
            Email = email;
        }

        internal Person(string name, string surname, DateTime dateOfBirth) : this(name, surname)
        {
            DateOfBirth = dateOfBirth;
        }

        internal Person(string name, string surname)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
        }
        #endregion

        static AstrologicalSign GetAstrSignOfBirthday(DateTime birthDate)
        {
            int astrologicalSignOfBirthday = 0;
            int monthOfBirthday = birthDate.Month;

            switch (monthOfBirthday)
            {
                case 04:
                    {
                        if (birthDate.Day < 21)
                            astrologicalSignOfBirthday = 0;
                        else astrologicalSignOfBirthday = 1;
                        break;
                    }
                case 05:
                    {
                        if (birthDate.Day < 21)
                            astrologicalSignOfBirthday = 1;
                        else astrologicalSignOfBirthday = 2;
                        break;
                    }
                case 06:
                    {
                        if (birthDate.Day < 22)
                            astrologicalSignOfBirthday = 2;
                        else astrologicalSignOfBirthday = 3;
                        break;
                    }
                case 07:
                    {
                        if (birthDate.Day < 23)
                            astrologicalSignOfBirthday = 3;
                        else astrologicalSignOfBirthday = 4;
                        break;
                    }
                case 08:
                    {
                        if (birthDate.Day < 24)
                            astrologicalSignOfBirthday = 4;
                        else astrologicalSignOfBirthday = 5;
                        break;
                    }
                case 09:
                    {
                        if (birthDate.Day < 24)
                            astrologicalSignOfBirthday = 5;
                        else astrologicalSignOfBirthday = 6;
                        break;
                    }
                case 10:
                    {
                        if (birthDate.Day < 24)
                            astrologicalSignOfBirthday = 6;
                        else astrologicalSignOfBirthday = 7;
                        break;
                    }
                case 11:
                    {
                        if (birthDate.Day < 23)
                            astrologicalSignOfBirthday = 7;
                        else astrologicalSignOfBirthday = 8;
                        break;
                    }
                case 12:
                    {
                        if (birthDate.Day < 23)
                            astrologicalSignOfBirthday = 8;
                        else astrologicalSignOfBirthday = 9;
                        break;
                    }
                case 01:
                    {
                        if (birthDate.Day < 20)
                            astrologicalSignOfBirthday = 9;
                        else astrologicalSignOfBirthday = 10;
                        break;
                    }
                case 02:
                    {
                        if (birthDate.Day < 20)
                            astrologicalSignOfBirthday = 10;
                        else astrologicalSignOfBirthday = 11;
                        break;
                    }
                case 03:
                    {
                        if (birthDate.Day < 21)
                            astrologicalSignOfBirthday = 11;
                        else astrologicalSignOfBirthday = 0;
                        break;
                    }


            }

            return (AstrologicalSign)astrologicalSignOfBirthday;
        }

        static ZodiacSign GetZodSignOfBirthday(DateTime birthDate)
        {
            const int firstSignOfZodiac = 4;
            int chinaCycleYear = (birthDate.Year - firstSignOfZodiac) % 12;
            return (ZodiacSign)chinaCycleYear;
        }
    }
}