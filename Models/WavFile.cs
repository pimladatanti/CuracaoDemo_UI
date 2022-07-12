using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IronPython.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Demo2.Models
{
	public class WavFile
	{
        public string name { get; set; }
        public string displayName { get; set; }
        public string directory { get; set; }
        public string encryptionStatus { get; set; }
        public int wavId { get; set; }
        public string serverPath { get; set; }
        public bool isChecked { get; set; }

        Microsoft.Scripting.Hosting.ScriptEngine engine = Python.CreateEngine();

        public WavFile() { }

        public WavFile(string name, string encryptionStatus, int wavId, string serverPath, bool isChecked)
        {
            this.name = name;
            this.encryptionStatus = encryptionStatus;
            this.wavId = wavId;
            //string server = name.Replace("Models/Audio/", "http://127.0.0.1:8000/");
            this.serverPath = serverPath;
            this.directory = name.Substring(0, 12);
            this.displayName = name.Substring(13);
            this.isChecked = isChecked;


        }


            //var engine = Python.CreateEngine();
            //var searchPaths = engine.GetSearchPaths();
            //searchPaths.Add(@"/usr/local/lib/python3.9/site-packages");
            //searchPaths.Add(@"/Library/Frameworks/Python.framework/Versions/3.9/lib/")
            //engine.SetSearchPaths(searchPaths);
            //var scope = engine.CreateScope();

        public void encrypt()
        {
            try
            {
                //var engine = Python.CreateEngine();
                //var searchPaths = engine.GetSearchPaths();
                //searchPaths.Add(@"/usr/local/lib/python3.9/site-packages");
                //searchPaths.Add(@"/Library/Frameworks/Python.framework/Versions/3.9/lib/")
                //engine.SetSearchPaths(searchPaths);
                var scope = engine.CreateScope();
                //engine.ExecuteFile("/Users/pimladatanti/Projects/curacaoWebAppTest/curacaoWebAppTest/Models/FileMonitorDaemon.py", scope);
                //dynamic FileMonitorDaemon = scope.GetVariable("FileMonitorDaemon");
                //dynamic fileMonitor = FileMonitorDaemon();
                //var monitor = fileMonitor.monitor_changes();

                engine.ExecuteFile("/Users/pimladatanti/Projects/Demo2/Demo2/Models/DirectoryManager.py", scope);
                dynamic DirectoryManager = scope.GetVariable("DirectoryManager");
                dynamic manager = DirectoryManager();
                var result = manager.encrypt();
                encryptionStatus = result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public void decrypt()
        {
            try
            { 
                var scope = engine.CreateScope();
               
                engine.ExecuteFile("/Users/pimladatanti/Projects/Demo2/Demo2/Models/DirectoryManager.py", scope);
                dynamic DirectoryManager = scope.GetVariable("DirectoryManager");
                dynamic manager = DirectoryManager();
                var result = manager.decrypt();
                encryptionStatus = result;
  

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

       
    }
}

  




