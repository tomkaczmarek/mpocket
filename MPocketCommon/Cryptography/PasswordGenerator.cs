using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPocketCommon.Cryptography
{
    public class PasswordGenerator : ICommandPassword
    {
        public string Generate()
        {
            StringBuilder builder = new StringBuilder();
            string[] literal = new string[] {"a","b","c","(","@","#","$","e","r","n","g","i","o","7","5","4","3",",",".","/","l","o","i","u","y","@",")" };

            for (int i = 0; i < 8; i++)
            {
                Random r = new Random();
                int j = r.Next(0, literal.Length);
                builder.Append(literal[j]);
            }

            return builder.ToString();
        }
    }
}
