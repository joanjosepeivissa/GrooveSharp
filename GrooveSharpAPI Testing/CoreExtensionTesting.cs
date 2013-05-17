using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GrooveSharpAPI;
using GrooveSharpAPI.Contract;

namespace GrooveSharpAPI_Testing
{
    [TestClass]
    public class CoreExtensionTesting
    {
        [TestMethod]
        public void CanGetUserCountry()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            Assert.IsNotNull(_grooveShark.GrooveCountry);
        }

        [TestMethod]
        public void CanGetPopularSongForToday()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            var _temp = _grooveShark.GetPopularSongsToday();

            Assert.IsTrue(_temp.Count() > 0);
        }

        [TestMethod]
        public void CanGetPopularSongForTheMonth()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);                       

            _grooveShark.InitializeSession();

            var _temp = _grooveShark.GetPopularSongsMonth();

            Assert.IsTrue(_temp.Count() > 0);
        }

        [TestMethod]
        public void CanGetUserPlaylist()
        {
            //
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            _grooveShark.Login(Constants.correct_login_username, Constants.correct_login_md5Password);

            IEnumerable<IPlaylist> _response = _grooveShark.User.GetPlaylists();

            Assert.IsTrue(_response.Count() > 0);
        }

        [TestMethod]
        public void CanGetSongsFromPlaylist()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            _grooveShark.Login(Constants.correct_login_username, Constants.correct_login_md5Password);

            IEnumerable<IPlaylist> _response = _grooveShark.User.GetPlaylists();

            IPlaylist _playlist = _response.FirstOrDefault();

            Assert.IsNotNull(_playlist);

            IEnumerable<ISong> _songsFromThisPlaylist = _playlist.GetSongs();

            Assert.IsTrue(_songsFromThisPlaylist.Count() > 0);
        }

        [TestMethod]
        public void CanGetUserInfo()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            _grooveShark.InitializeSession();

            _grooveShark.Login(Constants.correct_login_username, Constants.correct_login_md5Password);

            IUser _getUser = _grooveShark.User;

            Assert.IsTrue(_getUser.ID != 0);
        }
    }
}
