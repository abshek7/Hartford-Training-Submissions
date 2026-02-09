using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Song
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

    public Song(string name, string artist, string songType, DateTime dateDownloaded, double rating, int numberOfDownloads)
    {
        Name = name;
        Artist = artist;
        SongType = songType;
        Rating = rating;
        NumberOfDownloads = numberOfDownloads;
        DateDownloaded = dateDownloaded;
    }
    public Song()
    {

    }
    public static Dictionary<string, int> CalculateTypeCount(List<Song> list)
    {
        Dictionary<string, int> sd1 = new Dictionary<string, int>();
        foreach (var item in list)
        {
            int c = 0;

            foreach (var item1 in list)
            {
                if (item.SongType == item1.SongType)
                {
                    c++;
                }
            }
            if (!sd1.ContainsKey(item.SongType))
                sd1.Add(item.SongType, c);
        }
        return sd1;
    }
    public static string PredictState(Dictionary<string, int> perTypeCount)
    {
        string s = "";
        string ss = "";
        int max = 0;
        foreach (var item in perTypeCount)
        {
            if (item.Value > max)
            {
                s = item.Key;
                max = item.Value;
            }
        }
        if (s == "Emotional")
            ss = "depressed";
        else if (s == "Celebration")
            ss = "happy";
        else if (s == "Motivational")
            ss = "energetic";
        return ss;
    }

}


