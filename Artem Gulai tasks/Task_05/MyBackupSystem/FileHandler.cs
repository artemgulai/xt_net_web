using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05.MyBackupSystem
{
    internal sealed class FileHandler
    {
        /// <summary>
        /// Reading content of a text file
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>Content of the text file</returns>
        public string GetFileContent(string path)
        {
            int numberOfTries = 0;
            while (true)
            {
                try
                {
                    using (FileStream readFileStream = new FileStream(path,FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
                    {
                        using (StreamReader read = new StreamReader(readFileStream,true))
                        {
                            string content = read.ReadToEnd();
                            return content;
                        }
                    }
                }
                catch (IOException ex) 
                {
                    if (numberOfTries++ == 10)
                        throw new IOException(ex.Message,ex.InnerException);
                }
            }
        }
    }
}
