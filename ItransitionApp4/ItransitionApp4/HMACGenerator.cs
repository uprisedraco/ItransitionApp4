using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace ItransitionApp4
{
    internal class HMACGenerator
    {
        HMac hMac;

        public HMACGenerator(string key)
        {
            hMac = new HMac(new Sha3Digest());
            hMac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
        }

        public string GetHMAC(int option)
        {
            byte[] result = new byte[hMac.GetMacSize()];
            byte[] bytes = Encoding.UTF8.GetBytes(Convert.ToString(option));
            hMac.BlockUpdate(bytes, 0, bytes.Length);
            hMac.DoFinal(result, 0);

            return Convert.ToBase64String(result);
        }
    }
}
