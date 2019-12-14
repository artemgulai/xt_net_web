using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task_05.FileChangeInfo;
using System.Threading;
using Newtonsoft.Json;

namespace Task_05.MyBackupSystem
{
    sealed class MyBackupSystem
    {
        private string _pathToBackup;
        private Listener _listener;
        private Restorer _restorer;
        private SortedDictionary<string,List<Change>> _changeHistory;
        private FileHandler _fileHandler;

        public MyBackupSystem(string pathToBackup, MyBackupMode mode)
        {
            if (pathToBackup == null)
                throw new ArgumentNullException("pathToBackup");
            _pathToBackup = pathToBackup;

            _listener = new Listener(pathToBackup);

            if (mode == MyBackupMode.Listen)
            {
                _listener.TurnOnWatcher();
                SubscribeListenerEvents();
            }

            if (mode == MyBackupMode.Restore)
            {
                _listener.TurnOffWatcher();
                UnsubscribeListenerEvents();
            }

            _fileHandler = new FileHandler();

            LoadHistory(_pathToBackup);

            _restorer = new Restorer(_changeHistory, _pathToBackup);
        }

        #region Subscribe control
        private void SubscribeListenerEvents()
        {
            _listener.OnWatcherChangeEventRedirector += OnListenerChangeHandler;
            _listener.OnWatcherCreateEventRedirector += OnListenerCreateHandler;
            _listener.OnWatcherDeleteEventRedirector += OnListenerDeleteHandler;
        }

        private void UnsubscribeListenerEvents()
        {
            _listener.OnWatcherChangeEventRedirector -= OnListenerChangeHandler;
            _listener.OnWatcherCreateEventRedirector -= OnListenerCreateHandler;
            _listener.OnWatcherDeleteEventRedirector -= OnListenerDeleteHandler;
        }
        #endregion

        #region History loading and saving
        public static void DeleteHistory(string pathToBackup)
        {
            string pathToHistory = GetPathToHistory(pathToBackup);
            if (File.Exists(pathToHistory))
            {
                File.SetAttributes(pathToHistory,FileAttributes.Normal);
                File.Delete(pathToHistory);
                Console.WriteLine("History has been deleted.");
            }
            Console.WriteLine("History is empty.");
        }
        private static string GetPathToHistory(string pathToBackup)
        {
            return pathToBackup[pathToBackup.Length - 1] == '\\' ? pathToBackup + ".backup.json" : pathToBackup + "\\.backup.json";
        }

        private void LoadHistory(string pathToBackup)
        {
            string pathToHistory = GetPathToHistory(pathToBackup);
            
            if (!File.Exists(pathToHistory))
            {
                Console.WriteLine("Can't find history of changes.");
                Console.WriteLine("Create empty history.");
                _changeHistory = new SortedDictionary<string,List<Change>>();
                InitializeHistory(new DirectoryInfo(pathToBackup));
                return;
            }

            using (FileStream historyFileStream = new FileStream(pathToHistory,FileMode.Open,FileAccess.Read,FileShare.ReadWrite))
            {
                using (StreamReader historyReader = new StreamReader(historyFileStream))
                {
                    string historyContent = historyReader.ReadToEnd();
                    if (string.IsNullOrEmpty(historyContent))
                    {
                        Console.WriteLine("History of changes is empty.");
                        _changeHistory = new SortedDictionary<string,List<Change>>();
                        return;
                    }

                    try
                    {
                        _changeHistory = JsonConvert.DeserializeObject<SortedDictionary<string,List<Change>>>(historyContent);
                        Console.WriteLine("History has been loaded.");
                    }
                    catch (JsonSerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Can't read history of changes.");
                        Console.WriteLine("Create empty history.");
                        _changeHistory = new SortedDictionary<string,List<Change>>();
                    }
                }
            }
        }

        private void InitializeHistory(DirectoryInfo directoryToInit)
        {
            DirectoryInfo[] directories = directoryToInit.GetDirectories();
            foreach (var directory in directories)
            {
                InitializeHistory(directory);
            }

            FileInfo[] files = directoryToInit.GetFiles("*.txt");
            //if (files == null || files.Length == 0)
            //    return;

            foreach (var file in files)
            {
                string content = _fileHandler.GetFileContent(file.FullName);
                byte[] compressedContent = Compression.CompressString(content);
                _changeHistory.Add(file.FullName,new List<Change>{ new Change(file.CreationTime, ChangeType.Exist, compressedContent)});
            }
        }

        public void SaveHistory(string pathToBackup)
        {
            string pathToHistory = GetPathToHistory(pathToBackup);

            if (File.Exists(pathToHistory))
            {
                File.SetAttributes(pathToHistory,FileAttributes.Normal);
            }

            using (FileStream historyFileStream = File.Create(pathToHistory))
            {
                using (StreamWriter historyWriter = new StreamWriter(historyFileStream))
                {
                    historyWriter.Write(JsonConvert.SerializeObject(_changeHistory));
                    Console.WriteLine("History has been saved.");
                }
            }
            File.SetAttributes(pathToHistory,FileAttributes.Hidden);
        }
        #endregion

        #region Listener's events handlers
        private void OnListenerChangeHandler(FileSystemEventArgs e)
        {
            if (!_changeHistory.ContainsKey(e.FullPath))
                _changeHistory.Add(e.FullPath,new List<Change>());

            string content = _fileHandler.GetFileContent(e.FullPath);
            byte[] compressedContent = Compression.CompressString(content);

            Change lastChange = _changeHistory[e.FullPath].LastOrDefault();
            if (lastChange != null && lastChange.ChangeType == ChangeType.Write)
                if (lastChange.Content.SequenceEqual(compressedContent))
                    return;
            _changeHistory[e.FullPath].Add(new Change(DateTime.Now, ChangeType.Write, compressedContent));
        }

        private void OnListenerDeleteHandler(FileSystemEventArgs e)
        {
            if (e is RenamedEventArgs)
            {
                if (!_changeHistory.ContainsKey(((RenamedEventArgs)e).OldFullPath))
                    _changeHistory.Add(((RenamedEventArgs)e).OldFullPath,new List<Change>());

                string oldPath = ((RenamedEventArgs)e).OldFullPath;
                Console.WriteLine(oldPath + " has been deleted.");
                _changeHistory[oldPath].Add(new Change(DateTime.Now,ChangeType.Delete));
            }
            else
            {
                if (!_changeHistory.ContainsKey(e.FullPath))
                    _changeHistory.Add(e.FullPath,new List<Change>());
                Console.WriteLine(e.FullPath + " has been deleted.");
                _changeHistory[e.FullPath].Add(new Change(DateTime.Now,ChangeType.Delete));
            }
        }

        private void OnListenerCreateHandler(FileSystemEventArgs e)
        {
            if (!_changeHistory.ContainsKey(e.FullPath))
                _changeHistory.Add(e.FullPath,new List<Change>());
            string content = _fileHandler.GetFileContent(e.FullPath);
            byte[] compressedContent = Compression.CompressString(content);


            Console.WriteLine(e.FullPath + " has been created.");
            _changeHistory[e.FullPath].Add(new Change(DateTime.Now,ChangeType.Create,compressedContent));
        }
        #endregion

        #region Restoring files from backup
        public void RestoreFiles()
        {
            Console.WriteLine("Enter the date of restoring:");
            DateTime dateTimeOfRestoring;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTimeOfRestoring))
            {
                Console.WriteLine("Incorrect input, try again.");
            }

            _restorer.RestoreFiles(dateTimeOfRestoring);
            Console.WriteLine("Restoring has completed.");
        }
        #endregion
    }
}
