using GrooveSharpAPI.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class Country : ICountry
    {
        public Int64 ID { get; internal set; }
        public Int64 CC1 { get; internal set; }
        public Int64 CC2 { get; internal set; }
        public Int64 CC3 { get; internal set; }
        public Int64 CC4 { get; internal set; }
        public Int64 DMA { get; internal set; }
        public Int64 IPR { get; internal set; }

        internal static Country parse(string jsonData)
        {
            IEnumerable<XElement> elements = Snippet.ToXElementCollection(jsonData);

            Country _retVal = new Country()
            {
                ID = Convert.ToInt64(elements.Where(e => e.Name == "ID").First().Value),
                CC1 = Convert.ToInt64(elements.Where(e => e.Name == "CC1").First().Value),
                CC2 = Convert.ToInt64(elements.Where(e => e.Name == "CC2").First().Value),
                CC3 = Convert.ToInt64(elements.Where(e => e.Name == "CC3").First().Value),
                CC4 = Convert.ToInt64(elements.Where(e => e.Name == "CC4").First().Value),
                DMA = Convert.ToInt64(elements.Where(e => e.Name == "DMA").First().Value),
                IPR = Convert.ToInt64(elements.Where(e => e.Name == "IPR").First().Value)
            };

            return _retVal;
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
