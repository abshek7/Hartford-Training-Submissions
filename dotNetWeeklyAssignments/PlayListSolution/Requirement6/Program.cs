using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        List<Song> ls = new List<Song>();
        Console.WriteLine("Enter the number of songs");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split(',');
            double d = double.Parse(s[4]);
            int nd = int.Parse(s[5]);
            DateTime dt = new DateTime();
            dt = DateTime.ParseExact(s[3], "dd-MM-yyyy", null);
            Song s1 = new Song(s[0], s[1], s[2], dt, d, nd);
            ls.Add(s1);
        }
        Dictionary<string, int> sd = new Dictionary<string, int>();
        sd = Song.CalculateTypeCount(ls);
        string a = Song.PredictState(sd);
        Console.WriteLine("The user is feeling " + a);
    }
}

