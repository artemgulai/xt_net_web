using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_05.MyBackupSystem
{
    sealed class Listener
    {
        private FileSystemWatcher _watcher;
        //private DateTime _writeTime;

        public Listener(string pathToBackup)
        {
            _watcher = new FileSystemWatcher(pathToBackup,"*.txt");
            SetUpWatcher();
            TurnOnWatcher();
        }

        #region Listener controls
        private void SetUpWatcher()
        {
            _watcher.NotifyFilter = NotifyFilters.LastWrite
                                  | NotifyFilters.FileName;

            _watcher.Changed += OnChangeEventHandler;
            _watcher.Deleted += OnDeleteEventHandler;
            _watcher.Created += OnCreateEventHandler;
            _watcher.Renamed += OnRenameEventHandler;

            _watcher.IncludeSubdirectories = true;
        }

        public void TurnOffWatcher()
        {
            if (_watcher != null)
                _watcher.EnableRaisingEvents = false;
        }

        public void TurnOnWatcher()
        {
            if (_watcher != null)
                _watcher.EnableRaisingEvents = true;
        }
        #endregion

        #region _watcher's event handlers
        private void OnChangeEventHandler(object sender,FileSystemEventArgs args)
        {
            Thread.Sleep(100);
            //if ((DateTime.Now - _writeTime).TotalMilliseconds > 250)
                OnWatcherChangeEventRedirector?.Invoke(args);

            //_writeTime = DateTime.Now;
        }

        private void OnDeleteEventHandler(object sender,FileSystemEventArgs args)
        {
            OnWatcherDeleteEventRedirector?.Invoke(args);
        }

        private void OnCreateEventHandler(object sender,FileSystemEventArgs args)
        {
            Thread.Sleep(100);
            OnWatcherCreateEventRedirector?.Invoke(args);
        }

        private void OnRenameEventHandler(object sender,FileSystemEventArgs args)
        {
            OnWatcherDeleteEventRedirector?.Invoke(args);
            OnWatcherCreateEventRedirector?.Invoke(args);
        }
        #endregion

        #region Redirecting events
        // Events, redirecting _watcher's events to BackupSystem
        public event Action<FileSystemEventArgs> OnWatcherChangeEventRedirector;
        public event Action<FileSystemEventArgs> OnWatcherCreateEventRedirector;
        public event Action<FileSystemEventArgs> OnWatcherDeleteEventRedirector;
        #endregion
    }
}
