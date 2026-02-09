using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class PlayList
{
    string _name;
    List<Song> _songList;

    public List<Song> SongList
    {
        get { return _songList; }
        set { _songList = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public PlayList()
    {

    }
    public PlayList(string _name, List<Song> _songList)
    {
        Name = _name;
        SongList = _songList;
    }
    public void AddSongToPlaylist(Song song)
    {
        SongList.Add(song);
    }
    public bool RemoveSongFromPlaylist(String name)
    {
        foreach (Song s in SongList)
        {
            if (s.Name == name)
                return SongList.Remove(s);
        }
        return false;
    }

    public void DisplaySongs()
    {
        if (SongList.Count == 0)
            Console.WriteLine("No song to show");
        else
        {
            Console.WriteLine("Songs in " + Name);
            Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}",
                "Name", "Artist", "Song Type", "Rating", "No of Download", "Date Downloaded");
            foreach (Song s in SongList)
                Console.WriteLine(s);
        }
    }
}
