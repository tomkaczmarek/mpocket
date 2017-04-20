using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MPocketCommon.Cryptography
{
    public interface ICryptography
    {
        string Encrypt(string text);
        bool IsMatch(string p1, string p2);
    }
}
