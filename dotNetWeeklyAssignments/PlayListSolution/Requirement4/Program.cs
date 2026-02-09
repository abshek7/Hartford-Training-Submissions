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
        Console.WriteLine("Enter the number of the songs:");
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
        Console.WriteLine("Enter a type to sort:\n1.Sort by name\n2.Sort by Rating\n3.Sort by Popularity");
        int n1 = int.Parse(Console.ReadLine());
        if (n1 == 1)
        {
            // Song sg = new Song();
            ls.Sort();
            Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Date of Download", "Rating", "No of Downloads");
            foreach (var item in ls)
            {
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.DateDownloaded.ToString("dd-MM-yyyy"), item.Rating.ToString("0.0"), item.NumberOfDownloads);

            }
        }
        else if (n1 == 2)
        {
            RatingComparer rc = new RatingComparer();
            ls.Sort(rc);
            Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Date of Download", "Rating", "No of Downloads");
            foreach (var item in ls)
            {
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.DateDownloaded.ToString("dd-MM-yyyy"), item.Rating.ToString("0.0"), item.NumberOfDownloads);

            }
        }
        else if (n1 == 3)
        {
            PopularityComparer pc = new PopularityComparer();
            ls.Sort(pc);
            Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Date of Download", "Rating", "No of Downloads");
            foreach (var item in ls)
            {
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.DateDownloaded.ToString("dd-MM-yyyy"), item.Rating.ToString("0.0"), item.NumberOfDownloads);

            }
        }
    }
}

