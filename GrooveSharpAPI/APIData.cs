using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GrooveSharpAPI
{
    internal class APIData
    {
        public static string SessionData
        {
            get
            {
                string _p = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                _p = Path.Combine(_p, "GSSession");

                if (!Directory.Exists(_p))
                    Directory.CreateDirectory(_p);

                _p = Path.Combine(_p, "session.db");

                if (!File.Exists(_p))
                    File.WriteAllText(_p, "");

                return File.ReadAllText(_p).Trim();
            }
            set
            {
                string _p = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                _p = Path.Combine(_p, "GSSession", "session.db");

                File.WriteAllText(_p, value);
            }
        }
    }
}
