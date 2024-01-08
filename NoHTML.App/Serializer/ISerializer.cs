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
        string Serialize<T>(T element) where T : IDOMElement;

        byte[] Serialize<T>(T element, Encoding encoding) where T:IDOMElement => 
            encoding.GetBytes(this.Serialize<T>(element)) ?? Array.Empty<byte>();
    }
}