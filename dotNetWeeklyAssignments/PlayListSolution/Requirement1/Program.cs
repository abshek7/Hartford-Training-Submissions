using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter song 1 detail:");
            string[] songDetail1 = Console.ReadLine().Split(',');
            DateTime d = DateTime.ParseExact(songDetail1[5], "dd-MM-yyyy", null);
            Song song1 = new Song(songDetail1[0], songDetail1[1], songDetail1[2], double.Parse(songDetail1[3]), int.Parse(songDetail1[4]), d);

            Console.WriteLine("Enter song 2 detail:");
            string[] songDetail2 = Console.ReadLine().Split(',');
            DateTime d1 = DateTime.ParseExact(songDetail2[5], "dd-MM-yyyy", null);
            Song song2 = new Song(songDetail2[0], songDetail2[1], songDetail2[2], double.Parse(songDetail2[3]), int.Parse(songDetail2[4]), d1);
            Console.WriteLine();
            Console.WriteLine("Song 1:");
            Console.WriteLine(song1);
            Console.WriteLine();
            Console.WriteLine("Song 2:");
            Console.WriteLine(song2);
            Console.WriteLine();
            if (song1.Equals(song2))
                Console.WriteLine("Song 1 is same as Song 2");
            else
                Console.WriteLine("Song 1 and Song 2 are different");
        }
    }
}
