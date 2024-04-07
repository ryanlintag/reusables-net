using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public interface ISecretReader
    {
        byte[] ReadSecret(string key);
        byte[] GenerateIV();
    }
}
