using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Models
{
    public class Student
    {
        public string name { get; set; }

        public Student()
        {
           
            try
            {

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = ("/usr/bin/python3");
               
                start.Arguments = ("/Users/pimladatanti/Projects/Demo2/Demo2/Models/app.py");
                
                start.UseShellExecute = false;

                start.RedirectStandardOutput = true;

                using (Process process = Process.Start(start))
                {
                   
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        
                        name = result;

                    }
                }
            }
            catch (Exception ex)
            {
                Trace.Write(ex.Message);
            }
           
        }



    }
}
