using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrooveSharpAPI;
using System.Collections.Generic;
using GrooveSharpAPI.Contract;

namespace GrooveSharpAPI_Testing
{
    [TestClass]
    public class GrooveSharpTesting
    {
        [TestMethod]
        public void CanConnectToServer()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            Assert.IsNotNull(_grooveShark.PingServer());
        }        

        [TestMethod]
        public void CanGetSessionKey()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            string _sessionKey = _grooveShark.InitializeSession();

            Assert.AreEqual(32, _sessionKey.Length);
        }

        [TestMethod]
        public void CanGetJsonResponseVIAEvent()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.OnRequestRespondedEvent += (json) =>
                {
                    Assert.IsNotNull(json);
                };
        }

        [TestMethod]
        public void CanLogin()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            bool _response = _grooveShark.Login(Constants.correct_login_username, Constants.correct_login_md5Password);

            Assert.IsTrue(_response);
        }

        [TestMethod]
        public void CanLogout()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        [ExpectedException(typeof(GrooveException))]
        public void LoginFailIfWrongCredentials()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            bool _response = _grooveShark.Login(Constants.wrong_login_username, Constants.wrong_login_md5Password);

            Assert.IsFalse(_response);
        }
    }
}
