
using System;
using System.Threading;
using System.Threading.Channels;

//syntax for delegates:
//[modifier] delegate [return_type][delegate_name]([parameter_list]);

namespace DelegatePrac

{
    public class Program
    {

        public delegate void ProgressDelegate(int percent);

        class Downloader {
            public event Action DownloadCompleted;


            public void DownloadFile(string fileName,ProgressDelegate progressCallback)
            {
                Console.WriteLine($"Starting Download:{fileName}");
                for (int i = 0; i < 100; i+=25) {
                    Thread.Sleep(500);
                    progressCallback(i);
                }
                Console.WriteLine( "Download finished");
                DownloadCompleted?.Invoke();

            }
        }

        static void Main(string[] args)
        {
            Downloader d=new Downloader();
            d.DownloadCompleted += NotifyUser;
            d.DownloadCompleted += LogDownload;
            ProgressDelegate prog = percent =>
            {
                Console.WriteLine($"Download progress:{percent}");
            };
            d.DownloadFile("movie.mp4", prog);
            Console.ReadLine();
        }

        static void NotifyUser()
        {
            Console.WriteLine("user notified :download completed");
        }
        static void LogDownload()
        {
            Console.WriteLine("download logged to system");
        }
    }
}







// execution flow from main
// downloader object creation
// event subscription
//  delegation creation
//   download starts
//  progress callback loop
//  DownloadFile → progressCallback → lambda → Console.WriteLine
// DownloadCompleted?.Invoke();
// DownloadCompleted ->  NotifyUser() ->LogDownload()
