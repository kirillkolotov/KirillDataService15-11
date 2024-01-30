using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfClient
{
    public class ValidFirstname : ValidationRule
    {
        public int min { get; set; }
        public int max { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string firstname = value.ToString();
                if (firstname.Length < 2)
                {
                    return new ValidationResult(false, "first name too short");
                }
                if (firstname.Length > 20)
                {
                    return new ValidationResult(false, "first name too long");
                }
                if (!Char.IsLetter(firstname[0]))
                {
                    return new ValidationResult(false, "start with letter");
                }
                for (int i = 0; i < firstname.Length; i++)
                {
                    if (!char.IsLetter(firstname[i]) && !char.IsWhiteSpace(firstname[i]))
                    {
                        return new ValidationResult(false, "only letter or space!");
                    }
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "first name not valid ->" + ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }
    public class ValidUsername : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {

                string username = value.ToString();
                if (username.Length < 2)
                {
                    return new ValidationResult(false, "user name too short");
                }
                if (username.Length > 20)
                {
                    return new ValidationResult(false, "user name too long");
                }
                if (!char.IsLetter(username[0]))
                {
                    return new ValidationResult(false, "start with letter");
                }
                for (int i = 0; i < username.Length; i++)
                {
                    if (!char.IsLetter(username[i]) && !char.IsWhiteSpace(username[i]))
                    {
                        return new ValidationResult(false, "only letter or space!");
                    }
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "user name not valid ->" + ex.Message);
            }
            return ValidationResult.ValidResult;
        }
    }
    public class ValidPassword : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            bool big, small, digit, sym;
            big = small = digit = sym = false;
            string symbol = "#$_~";
            try
            {
                string password = value.ToString();
                if (password.Length < 6)
                {
                    return new ValidationResult(false, "Too short");
                }
                if (password.Length > 12)
                {
                    return new ValidationResult(false, "Too short");
                }
                for (int i = 0; i < password.Length; i++)
                {
                    if (!char.IsLetterOrDigit(password[i]) && symbol.IndexOf(password[i]) == -1)
                        return new ValidationResult(false, "Only letter, digits and symbols: " + symbol);
                    if (Char.IsUpper(password[i])) big = true;
                    if (Char.IsLower(password[i])) small = true;
                    if (Char.IsDigit(password[i])) digit = true;
                    if (symbol.IndexOf(password[i]) != -1) sym = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("a password must contain atleast 1 upper letter 1 lower letter 1 digit and 1 symbol");
            }
            if (big && small && digit && sym)
                return ValidationResult.ValidResult;
            return new ValidationResult(false, "At least one big letter, one small letter, one digit and one symbols: " + symbol);
        }
    }
    public class ValidEmail : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string email = value as string;
                Regex emailRegex = new Regex("([A-Za-z0-9]+[._-])*[A-Za-z0-9]+@[A-Za-z0-9-]+(\\.[A-Z|a-z]{2,})+");
                Match match = emailRegex.Match(email);

                if (!match.Success)
                {
                    return new ValidationResult(false, "not in the right format");
                }

            }
            catch (Exception ex)
            {
                return new ValidationResult(false, ex.Message);
            }

            return ValidationResult.ValidResult;
        }
    }
}
