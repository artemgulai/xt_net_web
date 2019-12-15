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

        public MyBackupSystem(string pathToBackup)
        {
            if (pathToBackup == null)
                throw new ArgumentNullException("pathToBackup");
            _pathToBackup = pathToBackup;

            _fileHandler = new FileHandler();

            LoadHistory(_pathToBackup);
        }

        #region Mode selection
        public void SetMode(MyBackupMode mode)
        {
            if (mode == MyBackupMode.Listen)
            {
                ListenerMode();
                return;
            }
            if (mode == MyBackupMode.Restore)
            {
                RestorerMode();
                return;
            }
            if (mode == MyBackupMode.DeleteHistory)
            {
                DeleteHistory(_pathToBackup);
                return;
            }
            throw new ArgumentException("Wrong mode");
        }

        /// <summary>
        /// Configure MyBackupSystem to listen for changes
        /// </summary>
        private void ListenerMode()
        {
            if (_listener == null)
            {
                _listener = new Listener(_pathToBackup);
            }
            _listener.TurnOnWatcher();
            SubscribeListenerEvents();
        }

        /// <summary>
        /// Configure MyBackupSystem to restore files
        /// </summary>
        private void RestorerMode()
        {
            if (_restorer == null)
            {
                _restorer = new Restorer(_changeHistory,_pathToBackup);
            }
            
            if (_listener != null)
            {
                _listener.TurnOffWatcher();
                UnsubscribeListenerEvents();
            }
            RestoreFiles();
        }
        #endregion

        #region Subscribe control
        /// <summary>
        /// Subscribe to _listener's events
        /// </summary>
        private void SubscribeListenerEvents()
        {
            _listener.OnWatcherChangeEventRedirector += OnListenerChangeHandler;
            _listener.OnWatcherCreateEventRedirector += OnListenerCreateHandler;
            _listener.OnWatcherDeleteEventRedirector += OnListenerDeleteHandler;
        }

        /// <summary>
        /// Unsibcribe from _listener's events
        /// </summary>
        private void UnsubscribeListenerEvents()
        {
            _listener.OnWatcherChangeEventRedirector -= OnListenerChangeHandler;
            _listener.OnWatcherCreateEventRedirector -= OnListenerCreateHandler;
            _listener.OnWatcherDeleteEventRedirector -= OnListenerDeleteHandler;
        }
        #endregion

        #region History loading and saving
        /// <summary>
        /// Delete file containing history of changes
        /// </summary>
        /// <param name="pathToBackup">Path to backed up directory</param>
        private void DeleteHistory(string pathToBackup)
        {
            string pathToHistory = GetPathToHistory(pathToBackup);
            if (File.Exists(pathToHistory))
            {
                File.SetAttributes(pathToHistory,FileAttributes.Normal);
                File.Delete(pathToHistory);
                Console.WriteLine("History has been deleted.");
            }
            else
            {
                Console.WriteLine("History is empty.");
            }
        }

        /// <summary>
        /// Generate path to file with history of changes
        /// </summary>
        /// <param name="pathToBackup">Path to backed up directory</param>
        /// <returns>Path to file containing history of changes</returns>
        private static string GetPathToHistory(string pathToBackup)
        {
            return pathToBackup[pathToBackup.Length - 1] == '\\' ? pathToBackup + ".backup.json" : pathToBackup + "\\.backup.json";
        }

        /// <summary>
        /// Read JSON from file and deserialize to _changeHistory object.
        /// </summary>
        /// <param name="pathToBackup">Path to backed up directory.</param>
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

            string history = _fileHandler.GetFileContent(pathToHistory);

            if (string.IsNullOrEmpty(history))
            {
                Console.WriteLine("History of changes is empty.");
                _changeHistory = new SortedDictionary<string,List<Change>>();
                return;
            }

            try
            {
                _changeHistory = JsonConvert.DeserializeObject<SortedDictionary<string,List<Change>>>(history);
                Console.WriteLine("History has been loaded.");
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Can't read history of changes.");
                Console.WriteLine("Create empty history.");
                _changeHistory = new SortedDictionary<string,List<Change>>();
                InitializeHistory(new DirectoryInfo(pathToBackup));
            }
        }

        /// <summary>
        ///  History of changes initialization with existing files
        /// </summary>
        /// <param name="directoryToInit">Directory containing files</param>
        private void InitializeHistory(DirectoryInfo directoryToInit)
        {
            DirectoryInfo[] directories = directoryToInit.GetDirectories();
            foreach (var directory in directories)
            {
                if (directory.Attributes.HasFlag(FileAttributes.Hidden))
                    continue;
                InitializeHistory(directory);
            }

            FileInfo[] files = directoryToInit.GetFiles("*.txt");

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
        /// <summary>
        /// Process file changing
        /// </summary>
        /// <param name="e">Description of an event from FileSystemWatcher</param>
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

        /// <summary>
        /// Process file deleting and renaming
        /// </summary>
        /// <param name="e">Description of an event from FileSystemWatcher</param>
        private void OnListenerDeleteHandler(FileSystemEventArgs e)
        {
            RenamedEventArgs eRename = e as RenamedEventArgs;
            if (eRename != null)
            {
                if (!_changeHistory.ContainsKey(eRename.OldFullPath))
                    _changeHistory.Add(eRename.OldFullPath,new List<Change>());

                string oldPath = eRename.OldFullPath;
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

        /// <summary>
        /// Process file creation and renaming
        /// </summary>
        /// <param name="e">Description of an event from FileSystemWatcher</param>
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
        /// <summary>
        /// Restore files from history
        /// </summary>
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
