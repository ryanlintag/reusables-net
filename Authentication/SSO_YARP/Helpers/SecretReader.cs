using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class SecretReader : ISecretReader
    {
        private readonly IDictionary<string, string> _secrets;
        private readonly string _IV;
        public SecretReader()
        {
            this._secrets = new Dictionary<string, string>();
            this._secrets.Add(new KeyValuePair<string, string>("UKzwmwDZHqE4QK1olkghw", "DlOobCIEmlj7FbIC5ZJwpdnHUU3RHitT"));
            this._secrets.Add(new KeyValuePair<string, string>("D0U6ae7rnL3i6XpGSR4si", "tht1p0AO2pM8JppPiXfhdGWijPvlVEIC"));
            this._secrets.Add(new KeyValuePair<string, string>("10UcOZvq4ek8m0v90yE52", "EJwZdl50Ekg4RwFbXIU2u4NpeM6F6E0b"));
            this._secrets.Add(new KeyValuePair<string, string>("7Ljn7ehJC7DiUzW3NzU9s", "gD5r3zba82GxwOjrW95QgelRYsdMFEp0"));
            this._IV = "npt2VFaKem83DHimsjExlj==";
        }

        public byte[] GenerateIV()
        {
            return Convert.FromBase64String(_IV);
        }

        public byte[] ReadSecret(string key)
        {
            if(_secrets.TryGetValue(key, out var secret))
            {
                return Encoding.UTF8.GetBytes(secret);
            }
            Random rnd = new Random();
            byte[] bytes = new byte[32];
            rnd.NextBytes(bytes);
            return bytes;
        }
    }
}
