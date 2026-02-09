using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Enter the Play list name:");
        String name = Console.ReadLine();
        PlayList playList = new PlayList(name, new List<Song>());
        int choice;
        do
        {
            Console.WriteLine("1.Add Song\n2.Remove Song\n3.Display\n4.Exit\nEnter your choice:");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of Songs:");
                    int n = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= n; i++)
                    {
                        Console.WriteLine("Enter song " + i + " detail:");
                        Song mySong = Song.CreateSong(Console.ReadLine());
                        playList.AddSongToPlaylist(mySong);
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter the name of the song to be deleted:");
                    string songName = Console.ReadLine();
                    if (playList.RemoveSongFromPlaylist(songName))
                        Console.WriteLine("Song successfully deleted");
                    else
                        Console.WriteLine("Song not found in the Play List");
                    break;
                case 3:
                    playList.DisplaySongs();
                    break;
            }
        } while (choice != 4);
    }
}