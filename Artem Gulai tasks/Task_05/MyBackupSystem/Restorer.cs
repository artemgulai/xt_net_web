using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_05.FileChangeInfo;

namespace Task_05.MyBackupSystem
{
    sealed class Restorer
    {
        private SortedDictionary<string,List<Change>> _changeHistory;
        private string _pathToBackup;
        public Restorer(SortedDictionary<string,List<Change>> changeHistory, string pathToBackup)
        {
            _changeHistory = changeHistory;
            _pathToBackup = pathToBackup;
        }

        /// <summary>
        /// Delete existing files which are being restored
        /// </summary>
        /// <param name="directoryToRestore"></param>
        private void DeleteRestoringFiles(DirectoryInfo directoryToRestore)
        {
            DirectoryInfo[] subDirectories = directoryToRestore.GetDirectories();
            foreach(var directory in subDirectories)
            {
                DeleteRestoringFiles(directory);
            }

            FileInfo[] filesToDelete = directoryToRestore.GetFiles("*.txt");
            foreach (var fileToDelete in filesToDelete)
            {
                if (_changeHistory.ContainsKey(fileToDelete.FullName))
                {
                    File.Delete(fileToDelete.FullName);
                }
            }
        }

        /// <summary>
        /// Create subdirectories for restored files
        /// </summary>
        /// <param name="fileName"></param>
        private void CreateSubdirectory(string fileName)
        {
            for (int i = fileName.Length - 1; i > 0; i--)
            {
                if (fileName[i] == '\\')
                {
                    string path = fileName.Substring(0,i);
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                }
            }
        }

        /// <summary>
        /// Restore files at specified moment of time
        /// </summary>
        /// <param name="dateTimeOfRestoring">Date and time of restoring</param>
        public void RestoreFiles(DateTime dateTimeOfRestoring)
        {
            DeleteRestoringFiles(new DirectoryInfo(_pathToBackup));
            foreach (var changedFile in _changeHistory)
            {
                List<Change> changes = changedFile.Value;
                Change restorePoint = changes.LastOrDefault(a => a.ChangeTime <= dateTimeOfRestoring);
                // if restore point is null, check whether file existed at the very beginning of the history
                if (restorePoint == null)
                {
                    Change firstChange = changes.First();
                    if (firstChange.ChangeType == ChangeType.Exist && firstChange.ChangeTime <= dateTimeOfRestoring)
                    {
                        byte[] compressedContent = firstChange.Content;
                        string content = Compression.DecompressBytes(compressedContent);
                        CreateSubdirectory(changedFile.Key);
                        using (FileStream file = File.Create(changedFile.Key))
                        {
                            using (StreamWriter writer = new StreamWriter(file))
                            {
                                writer.Write(content);
                                continue;
                            }
                        }
                    }
                }
                // else check whether this change is not deleting
                else if (restorePoint.ChangeType != ChangeType.Delete)
                {
                    byte[] compressedContent = restorePoint.Content;
                    string content = Compression.DecompressBytes(compressedContent);
                    CreateSubdirectory(changedFile.Key);
                    using (FileStream file = File.Create(changedFile.Key))
                    {
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            writer.Write(content);
                            continue;
                        }
                    }
                }
                // do nothing, file was deleted and should not exist at the time of restoring
            }
        }
    }
}
