Grooveshark API

http://developers.grooveshark.com/

https://github.com/vgdagpin/GrooveSharp/blob/master/GrooveSharpAPI/Contract.cs


Sample Code:

     IGrooveSharp _grooveShark = GrooveSharp.Init(
                    key: "xxxxxxx",
                    secret: "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
    
     _grooveShark.InitializeSession()
    
     Console.Write("Enter song title: ");
     string _title = Console.ReadLine();
    
     ISong _searchedSong = SearchSong(_grooveShark, _title);
     IGrooveStream _stream = _searchedSong.GetSubscriberStream();
     
     Process.Start(_stream.Url);
     
    
     private static Song SearchSong(IGrooveSharp grooveSharp, string query)
    {
        Console.WriteLine("Searching: {0}", query);

        var _result = grooveSharp.SearchSong(query);

        Console.WriteLine("Results Found: {0} song/s", _result.Count());

        if (_result.Count() > 0)
        {
            Song _resSong = _result.Where(s => s.IsLowBitrateAvailable).First();

            Console.WriteLine();
            Console.WriteLine("Sample Result: (First)");
            Console.WriteLine();
            Console.WriteLine("ID: {0}", _resSong.SongID);
            Console.WriteLine("SongName: {0}", _resSong.SongName);
            Console.WriteLine("Artist: {0}", _resSong.SongArtist.ArtistName);
            Console.WriteLine("Album: {0}", _resSong.SongAlbum.AlbumName);
            Console.WriteLine();

            return _resSong;
        }

        return null;
    }
=======
GrooveSharp
===========
>>>>>>> 1d1b930693eef0afb8851306208e8fd73259be9f
