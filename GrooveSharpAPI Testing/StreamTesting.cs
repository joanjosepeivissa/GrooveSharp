using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrooveSharpAPI;
using System.Collections.Generic;
using System.Linq;
using GrooveSharpAPI.Contract;

namespace GrooveSharpAPI_Testing
{
    [TestClass]
    public class StreamTesting
    {
        [TestMethod]
        public void CanGetStream()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);
            string _songToSearch = "i wont give up - jason  mraz";

            _grooveShark.InitializeSession();
            _grooveShark.Login(Constants.correct_login_username, Constants.correct_login_md5Password);

            ISong _songs = _grooveShark.SearchSong(_songToSearch).First();

            ISubStream _stream = _songs.GetSubscriberStream();

            Assert.IsNotNull(_stream.Url);
        }
    }
}
