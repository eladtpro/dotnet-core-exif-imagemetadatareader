using ImageMetadata.MediaMetadata;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ImageMetadata.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] images = new string[] {
                @"C:\Users\eladt\OneDrive - Microsoft\Customers\Mekorot\Media\DJI_0046.JPG"
                //@"C:\Users\eladt\OneDrive - Microsoft\Customers\Mekorot\Media\image001.jpg"
            };

            foreach (string path in args)
            {
                using FileStream stream = new(path, FileMode.Open, FileAccess.Read);
                JObject exif = MetadataReader.Read(stream);
                Console.WriteLine(exif);
            }

            Console.Read();
            //ImageMetadata md 
        }
    }
}
