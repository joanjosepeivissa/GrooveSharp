using GrooveSharpAPI.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace GrooveSharpAPI
{
    public class SubStream : ISubStream
    {
        public string Key { get; internal set; }
        public Uri Url { get; internal set; }
        public TimeSpan Time { get; internal set; }
        public int ServerID { get; internal set; }

        private GrooveSharp grooveSharp = null;

        internal SubStream() { }

        internal static SubStream parse(string data, GrooveSharp grooveSharp)
        {
            IEnumerable<XElement> _elems = Snippet.ToXElementCollection(data);

            SubStream _stream = new SubStream()
            {
                Key = _elems.Where(e => e.Name == "StreamKey").First().Value,
                Url = new Uri(_elems.Where(e => e.Name == "url").First().Value),
                Time = TimeSpan.FromTicks(Convert.ToInt64(_elems.Where(e => e.Name == "uSecs").First().Value + "0")),
                ServerID = Convert.ToInt32(_elems.Where(e => e.Name == "StreamServerID").First().Value)
            };

            _stream.grooveSharp = grooveSharp;

            if (_stream.Url == null)
                return null;

            return _stream;
        }

        public static ISubStream ToISubStream(TimeSpan timeSpan, Uri url)
        {
            throw new NotImplementedException();
        }

        public void MarkAsOver30Seconds()
        {
            RequestData _requestData = new RequestData(Method.markStreamKeyOver30Secs,
                grooveSharp.APIKey, grooveSharp.SessionKey);

            _requestData.AddParameter("streamKey", Key);
            _requestData.AddParameter("streamServerID", ServerID);

            string _response = grooveSharp.getResponse(grooveSharp.getUrl(_requestData), _requestData);
        }

        public override string ToString()
        {
            return Url.ToString();
        }
    }
}
