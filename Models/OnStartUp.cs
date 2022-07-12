using System;
using System.Collections.Generic;
using System.IO;

namespace Demo2.Models
{
    public class OnStartUp
    {
        public List<WavFile> allFiles { get; set; } 
        public void Init()
        {
           

            Console.WriteLine("started!");

            // walk through files and add to list
            string[] fileList = Directory.GetFiles("Models/Audio", "*.wav"); //add pattern for .wav files only 

            int count = 0;

            using (var file = new StreamWriter("Models/AllFiles.txt", append: false))
            {
                foreach (string f in fileList)
                {
                    //string server = f.Replace("Models/Audio/", "http://127.0.0.1:8000/");
                    file.WriteLineAsync(f + ", Decrypted, " + count + ", " + f + ", false");
                    count++;
                }
            }

        }
        
    }
}
