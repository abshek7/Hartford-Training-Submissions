using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Song
{
    string _name;
    string _artist;
    string _songType;
    double _rating;
    int _numberOfDownloads;
    DateTime _dateDownloaded;

    public DateTime DateDownloaded
    {
        get { return _dateDownloaded; }
        set { _dateDownloaded = value; }
    }
    public int NumberOfDownloads
    {
        get { return _numberOfDownloads; }
        set { _numberOfDownloads = value; }
    }
    public double Rating
    {
        get { return _rating; }
        set { _rating = value; }
    }
    public string SongType
    {
        get { return _songType; }
        set { _songType = value; }
    }
    public string Artist
    {
        get { return _artist; }
        set { _artist = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
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
        return String.Format("{0} {1,15} {2,15} {3,15} {4,15} {5,15}",
            Name, Artist, SongType, Rating, NumberOfDownloads, DateDownloaded.ToString("dd-MM-yyyy"));
    }
    public override bool Equals(object obj)
    {
        Song s = obj as Song;
        return (Name.ToLower().Equals(s.Name.ToLower()) &&
            Artist.ToLower().Equals(s.Artist.ToLower()) &&
            SongType.ToLower().Equals(s.SongType.ToLower()));
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode() ^ Artist.GetHashCode() ^ SongType.GetHashCode();
    }
    public static Song CreateSong(string song)
    {
        string[] split = song.Split(',');
        DateTime d = DateTime.ParseExact(split[5], "dd-MM-yyyy", null);
        return new Song(split[0], split[1], split[2], double.Parse(split[3]), int.Parse(split[4]), d);
    }
}
