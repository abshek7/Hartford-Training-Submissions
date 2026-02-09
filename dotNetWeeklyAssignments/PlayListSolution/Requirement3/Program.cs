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
        SongBO sb = new SongBO();
        Console.WriteLine("Enter the number of Songs:");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split(',');
            double d = double.Parse(s[3]);
            int nd = int.Parse(s[4]);
            DateTime dt = new DateTime();
            dt = DateTime.ParseExact(s[5], "dd-MM-yyyy", null);
            Song s1 = new Song(s[0], s[1], s[2], d, nd, dt);
            ls.Add(s1);
        }
        Console.WriteLine("Enter a search type:\n1.Song Type\n2.Date of Download\n3.Rating");
        int n1 = int.Parse(Console.ReadLine());
        if (n1 >= 1 && n1 <= 3)
        {
            if (n1 == 1)
            {
                Console.WriteLine("Enter the song type:");
                string st = Console.ReadLine();
                List<Song> l = new List<Song>();
                l = sb.FindSong(ls, st);
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Rating", "No of Download", "Date of Download");
                foreach (var item in l)
                {
                    Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.Rating.ToString("0.0"), item.NumberOfDownloads, item.DateDownloaded.ToString("dd-MM-yyyy"));
                }

            }
            else if (n1 == 2)
            {
                Console.WriteLine("Enter the date:");
                string st = Console.ReadLine();
                DateTime dt = new DateTime();
                dt = DateTime.ParseExact(st, "dd-MM-yyyy", null);
                List<Song> l1 = new List<Song>();
                l1 = sb.FindSong(ls, dt);
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Rating", "No of Download", "Date of Download");
                foreach (var item in l1)
                {
                    Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.Rating.ToString("0.0"), item.NumberOfDownloads, item.DateDownloaded.ToString("dd-MM-yyyy"));
                }

            }
            else if (n1 == 3)
            {
                Console.WriteLine("Enter the rating:");
                double r = double.Parse(Console.ReadLine());

                List<Song> l2 = new List<Song>();
                l2 = sb.FindSong(ls, r);
                Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", "Name", "Artist", "Song Type", "Rating", "No of Download", "Date of Download");
                foreach (var item in l2)
                {
                    Console.WriteLine("{0} {1,15} {2,15} {3,15} {4,15} {5,15}", item.Name, item.Artist, item.SongType, item.Rating.ToString("0.0"), item.NumberOfDownloads, item.DateDownloaded.ToString("dd-MM-yyyy"));
                }

            }
        }
        else
            Console.WriteLine("Invalid choice");

    }
}

