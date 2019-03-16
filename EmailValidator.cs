using System.Text.RegularExpressions;

namespace Lab2
{
    static class EmailValidator
    {
        public static bool IsValidFormat(string email)
        {
            
            string pattern = @"^([0-9a-zA-Z]" + 
                             @"([\+\-_\.][0-9a-zA-Z]+)*" + 
                             @")+" +
                             @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";

            return Regex.IsMatch(email, pattern);
        }
    }
}