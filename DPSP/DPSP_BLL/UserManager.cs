using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSP_BLL
{
    public class UserManager
    {

        public static string CreateHash(string password)
        {
            return PasswordSecurity.PasswordStorage.CreateHash(password);
        }

        public static bool VerifyPassword(string password, string goodHash)
        {
            return PasswordSecurity.PasswordStorage.VerifyPassword(password, goodHash);
        }

        public static string GetHash(string formatedPassword)
        {
            return PasswordSecurity.PasswordStorage.GetHash(formatedPassword);
        }

        public static string GetSalt(string formatedPassword)
        {
            return PasswordSecurity.PasswordStorage.GetSalt(formatedPassword);
        }
    }
}
