using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GrooveSharpAPI.Contract
{
    public class GrooveException : Exception
    {
        public int ErrorCode { get; private set; }

        public GrooveException(string message)
            : base(message)
        {

        }

        public GrooveException(XElement element)
            : base(element.Element("message").Value)
        {
            ErrorCode = Convert.ToInt32(element.Element("code").Value);
        }
    }
}
