using Demo2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Demo2.Controllers
{
    public class HomeController : Controller
    {

        List<WavFile> allFiles = new List<WavFile>();

        public HomeController()
        {
            readFromFileList();
        }


        public ActionResult Index(List<WavFile> files, string submitButton)
        {

            var wavId = -1;

            //if (id != null)
            {
                //wavId = id.Value;
                //Console.WriteLine(id.Value);

                switch (submitButton)
                {
                    case "Encrypt":
                        for (int i = 0; i < files.Count; i++)
                        {
                            if (files[i].isChecked)
                            {
                                allFiles[i].encrypt();
                                allFiles[i].serverPath = allFiles[i].name.Replace("Models/Audio/", "http://127.0.0.1:8000/");
                                allFiles[i].isChecked = false;
                                Console.WriteLine(allFiles[i].serverPath);
                            }
                        }
                        writeToFileList();
                        return (View(allFiles));
                    case "Decrypt":
                        for (int i = 0; i < files.Count; i++)
                        {
                            if (files[i].isChecked)
                            {
                                allFiles[i].decrypt();
                                allFiles[i].serverPath = allFiles[i].serverPath.Replace("http://127.0.0.1:8000/", "Models/Audio/");
                                allFiles[i].isChecked = false;
                                Console.WriteLine(allFiles[i].serverPath);
                            }
                        }
                        writeToFileList();
                        return (View(allFiles));
                    case "Delete":
                        for (int i = 0; i < files.Count; i++)
                        {
                            if (files[i].isChecked)
                            {
                                System.IO.File.Delete(allFiles[i].name);
                                allFiles.RemoveAt(i);
                                
                            }
                        }

                        for (int j = 0; j < allFiles.Count; j++)
                        {
                            allFiles[j].wavId = j;
                        }

                        writeToFileList();
                        readFromFileList();
                        return (View(allFiles));
                    default:
                        // If they've submitted the form without a submitButton, 
                        // just return the view again.
                        return (View(allFiles));
                }
            }


        }


        public void writeToFileList()
        {
            using (var file = new StreamWriter("Models/AllFiles.txt", false))
            {
                foreach (WavFile f in allFiles)
                {
                    //Console.WriteLine(f.name + ", " + f.encryptionStatus + ", " + f.wavId.ToString());
                    file.WriteLineAsync(f.name + ", " + f.encryptionStatus + ", " + f.wavId.ToString() + ", " + f.serverPath + ", " + f.isChecked);
                }
            }

        }


        public void readFromFileList()
        {
            allFiles.Clear();
            string fileName = "Models/AllFiles.txt";
            List<string> allLines = new List<string>();
            string[] parts;
            Regex regex = new Regex(", ");
            int wavId;
            bool isChecked;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    parts = regex.Split(line);
                    wavId = int.Parse(parts[2]);
                    isChecked = bool.Parse(parts[4]);
                    allFiles.Add(new WavFile(parts[0], parts[1], wavId, parts[3], isChecked));
                }
            }


        }



    }
}

