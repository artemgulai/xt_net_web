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
        private Queue<FileSystemEventArgs> _changeQueue;
        private Queue<FileSystemEventArgs> _createQueue;
        private Queue<FileSystemEventArgs> _deleteQueue;
        private Thread _th;

        public Listener(string pathToBackup)
        {
            _watcher = new FileSystemWatcher(pathToBackup,"*.txt");
            SetUpWatcher();
            TurnOnWatcher();
            _changeQueue = new Queue<FileSystemEventArgs>();
            _createQueue = new Queue<FileSystemEventArgs>();
            _deleteQueue = new Queue<FileSystemEventArgs>();

            _th = new Thread(() => EmptyQueues());
            _th.IsBackground = true;
            _th.Start();
        }

        #region Listener controls
        /// <summary>
        /// Set up FileSystemWatcher
        /// </summary>
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

        /// <summary>
        /// Turn off FileSystemWatcher fire on events
        /// </summary>
        public void TurnOffWatcher()
        {
            if (_watcher != null)
                _watcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Turn on FileSystemWatcher fire on events
        /// </summary>
        public void TurnOnWatcher()
        {
            if (_watcher != null)
                _watcher.EnableRaisingEvents = true;
        }
        #endregion

        #region _watcher's event handlers

        /// <summary>
        /// Process event queues
        /// </summary>
        private void EmptyQueues()
        {
            while (true)
            {
                if (_createQueue.Count != 0)
                {
                    OnWatcherCreateEventRedirector?.Invoke(_createQueue.Dequeue());
                }

                if (_changeQueue.Count != 0)
                {
                    OnWatcherChangeEventRedirector?.Invoke(_changeQueue.Dequeue());
                }

                if (_deleteQueue.Count != 0)
                {
                    OnWatcherDeleteEventRedirector?.Invoke(_deleteQueue.Dequeue());
                }
            }
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnChangeEventHandler(object sender,FileSystemEventArgs args)
        {
            _changeQueue.Enqueue(args);
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnDeleteEventHandler(object sender,FileSystemEventArgs args)
        {
            _deleteQueue.Enqueue(args);
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnCreateEventHandler(object sender,FileSystemEventArgs args)
        {
            _createQueue.Enqueue(args);
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnRenameEventHandler(object sender,FileSystemEventArgs args)
        {
            OnWatcherDeleteEventRedirector?.Invoke(args);
            OnWatcherCreateEventRedirector?.Invoke(args);
        }
        #endregion

        #region Redirecting events
        // Events redirecting _watcher's events to BackupSystem
        public event Action<FileSystemEventArgs> OnWatcherChangeEventRedirector;
        public event Action<FileSystemEventArgs> OnWatcherCreateEventRedirector;
        public event Action<FileSystemEventArgs> OnWatcherDeleteEventRedirector;
        #endregion
    }
}
