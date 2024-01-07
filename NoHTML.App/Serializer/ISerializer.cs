using NoHTML.SharpPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoHTML.App.Core
{
    public interface ISerializer
    {
        string Serialize(IDOMElement element);

        byte[] Serialize(IDOMElement element, Encoding encoding) => encoding.GetBytes(this.Serialize(element)) ?? Array.Empty<byte>();
    }
}
