using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BankManagementSystem.Helpers
{
    public static class ArgumentValidation
    {
        public const string motif = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
        public static bool ValidateEmail(string emailId)
        {
            if (emailId == null || emailId == "")
                return false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailId);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool IsPhoneNbr(string number)
        {
            if (number != null) 
                return Regex.IsMatch(number, motif);
            else 
                return false;
        }
    }
}
