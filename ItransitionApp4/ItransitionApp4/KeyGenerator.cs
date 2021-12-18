using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ItransitionApp4
{
    internal class KeyGenerator
    {
        string key;

        public KeyGenerator(int lenght)
        {
            byte[] keyBytes = new byte[lenght];
            RandomNumberGenerator.Create().GetBytes(keyBytes);
            key = Convert.ToBase64String(keyBytes);
        }

        public string GetKey()
        {
            return key;
        }
    }
}
