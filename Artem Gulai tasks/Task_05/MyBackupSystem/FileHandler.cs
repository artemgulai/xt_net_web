using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.MyBackupSystem
{
    sealed class FileHandler
    {
        public string GetFileContent(string path)
        {
            // a crutch for waiting until the file is available
            //while (true)
            //{
            //    try
            //    {
            //        using (FileStream readFileStream = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.Read))
            //        {}
            //        break;
            //    } 
            //    catch (IOException)
            //    {}
            //}

            using (FileStream readFileStream = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
            {
                using (StreamReader read = new StreamReader(readFileStream, true))
                {
                    string content = read.ReadToEnd();
                    return content;
                }
            }
        }
    }
}
