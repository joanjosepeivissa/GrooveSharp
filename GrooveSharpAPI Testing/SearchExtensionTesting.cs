using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GrooveSharpAPI;
using System.Collections.Generic;
using GrooveSharpAPI.Contract;


namespace GrooveSharpAPI_Testing
{
    [TestClass]
    public class SearchExtensionTesting
    {
        [TestMethod]
        public void CanSearchSongs()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);
            string _songToSearch = "i wont give up - jason  mraz";

            _grooveShark.InitializeSession();

            IEnumerable<ISong> _songs = _grooveShark.SearchSong(_songToSearch);

            Assert.IsTrue(_songs.Count() > 0);
        }

        [TestMethod]
        public void CanSearchAlbum()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            string _albumName = "Camino Palmero";

            _grooveShark.InitializeSession();

            IEnumerable<IAlbum> _result = _grooveShark.SearchAlbum(_albumName);

            Assert.IsTrue(_result.Count() > 0);
        }

        [TestMethod]
        public void CanGetSongsFromAlbum()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            string _albumName = "Camino Palmero";

            _grooveShark.InitializeSession();

            IEnumerable<IAlbum> _result = _grooveShark.SearchAlbum(_albumName);

            IEnumerable<ISong> _albumSongs = _result.First().GetSongs();

            Assert.IsTrue(_albumSongs.Count() > 0);
        }

        [TestMethod]
        public void CanSearchPlaylists()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            string _playlist = "Acoustic";

            _grooveShark.InitializeSession();

            IEnumerable<IPlaylist> _data = _grooveShark.SearchPlaylist(_playlist);

            Assert.IsTrue(_data.Count() > 0);
        }

        [TestMethod]
        public void CanSearchArtist()
        {
            IGrooveSharp _grooveShark = GrooveSharp.Init(Constants.apiKey, Constants.apiSecret);

            string _artist = "The Calling";

            _grooveShark.InitializeSession();

            IEnumerable<IArtist> _data = _grooveShark.SearchArtist(_artist);

            Assert.IsTrue(_data.Count() > 0);
        }

        [TestMethod]
        public void CanGetSongInformationFromListOfIDs()
        {
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void CanGetSongInformation()
        {
            Assert.IsTrue(false);
        }
    }
}
