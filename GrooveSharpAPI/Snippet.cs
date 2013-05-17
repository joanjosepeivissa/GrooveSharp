using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class Snippet
    {
        internal static IEnumerable<XElement> ToXElementCollection(string jsonResponse)
        {
            XDocument _doc = JsonConvert.DeserializeXNode(jsonResponse, "response");

            try
            {
                var _elem = _doc.Element("response").Elements()
                    .Where(e => e.Name == "result").First().Elements();

                if (_elem.Count() > 0)
                {
                    return _elem;
                }
                else
                {
                    List<XElement> _elems = new List<XElement>();
                    _elems.Add(_doc.Element("response").Elements()
                        .Where(e => e.Name == "result").First());

                    return _elems.AsEnumerable();
                }
            }
            catch
            {
                throw new Exception("Some error here.. i will give full details soon.. ;)");
            }
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CalculateSHA1(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            SHA1CryptoServiceProvider cryptoTransformSHA1 = new SHA1CryptoServiceProvider();
            return BitConverter.ToString(cryptoTransformSHA1.ComputeHash(buffer)).Replace("-", "");
        }        
    }
}
