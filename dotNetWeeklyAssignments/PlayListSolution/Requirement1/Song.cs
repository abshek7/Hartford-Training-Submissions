using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Song
{

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }



    private string _artist;

    public string Artist
    {
        get { return _artist; }
        set { _artist = value; }
    }
    private string _songType;

    public string SongType
    {
        get { return _songType; }
        set { _songType = value; }
    }



    private double _rating;

    public double Rating
    {
        get { return _rating; }
        set { _rating = value; }
    }



    private int _numberOfDownloads;

    public int NumberOfDownloads
    {
        get { return _numberOfDownloads; }
        set { _numberOfDownloads = value; }
    }
    private DateTime _dateDownloaded;

    public DateTime DateDownloaded
    {
        get { return _dateDownloaded; }
        set { _dateDownloaded = value; }
    }
    public Song()
    {

    }
    public Song(string _name, string _artist, string _songType, double _rating, int _numberOfDownloads, DateTime _dateDownloaded)
    {
        Name = _name;
        Artist = _artist;
        SongType = _songType;
        Rating = _rating;
        NumberOfDownloads = _numberOfDownloads;
        DateDownloaded = _dateDownloaded;
    }

    public override string ToString()
    {
        return "Name:" + Name +
               "\nArtist:" + Artist +
               "\nSong Type:" + SongType +
               "\nRating:" + Rating.ToString("0.0") +
               "\nNumber of Downloads" + NumberOfDownloads +
                "\nDate Downloaded:" + DateDownloaded.ToString("dd-MM-yyyy");
    }

    public override bool Equals(Object obj)
    {
        Song s = obj as Song;
        return Name.Equals(s.Name) && Artist.Equals(s.Artist) && SongType.Equals(s.SongType);

    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Artist.GetHashCode() ^ SongType.GetHashCode();
    }


}

