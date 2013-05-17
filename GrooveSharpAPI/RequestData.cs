using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrooveSharpAPI
{
    internal class RequestData
    {
        /// <summary>
        /// Gets the type of method of the request.
        /// </summary>
        public string method { get; set; }

        /// <summary>
        /// Gets the parameters of the request.
        /// </summary>
        public Dictionary<string, object> parameters { get; set; }

        /// <summary>
        /// Gets the header of the request.
        /// </summary>
        public Dictionary<string, object> header { get; set; }

        public RequestData(Method method)
        {
            this.method = method.ToString();
            this.parameters = new Dictionary<string, object>();
            this.header = new Dictionary<string, object>();
        }

        public RequestData(string method)
        {
            this.method = method;
            this.parameters = new Dictionary<string, object>();
            this.header = new Dictionary<string, object>();
        }

        public RequestData(Method method, string wsKey)
        {
            this.method = method.ToString();
            this.parameters = new Dictionary<string, object>();

            Dictionary<string, object> _header = new Dictionary<string, object>();
            _header.Add("wsKey", wsKey);

            this.header = _header;
        }

        public RequestData(Method method, string wsKey, string sessionID)
        {
            this.method = method.ToString();
            this.parameters = new Dictionary<string, object>();

            Dictionary<string, object> _header = new Dictionary<string, object>();
            _header.Add("wsKey", wsKey);
            _header.Add("sessionID", sessionID);

            this.header = _header;
        }

        public RequestData(Method method, string wsKey, string sessionID, IPAddress ip)
        {
            this.method = method.ToString();
            this.parameters = new Dictionary<string, object>();

            Dictionary<string, object> _header = new Dictionary<string, object>();
            _header.Add("wsKey", wsKey);
            _header.Add("sessionID", sessionID);
            _header.Add("ip", ip.ToString());

            this.header = _header;
        }

        public RequestData(Method method, string wsKey, IPAddress ip)
        {
            this.method = method.ToString();
            this.parameters = new Dictionary<string, object>();

            Dictionary<string, object> _header = new Dictionary<string, object>();
            _header.Add("wsKey", wsKey);
            _header.Add("ip", ip.ToString());

            this.header = _header;
        }

        /// <summary>
        /// Adds a parameter to the request object.
        /// </summary>
        /// <param name="paramName">The key name of the parameter</param>
        /// <param name="value">The value of the parameter</param>
        public void AddParameter(string paramName, object value)
        {
            Dictionary<string, object> _params = parameters.ToDictionary(a => a.Key, b => b.Value);

            _params.Add(paramName, value);

            parameters = _params;
        }

        public void AddHeader(string paramName, object value)
        {
            Dictionary<string, object> _header = header.ToDictionary(a => a.Key, b => b.Value);

            _header.Add(paramName, value);

            header = _header;
        }

        public string GetJsonData()
        {
            return JsonConvert.SerializeObject(this);
        }

        public byte[] GetByteArrayData()
        {
            return Encoding.ASCII.GetBytes(GetJsonData());
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
