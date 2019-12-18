﻿using System;
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

        public Listener(string pathToBackup)
        {
            _watcher = new FileSystemWatcher(pathToBackup,"*.txt");
            SetUpWatcher();
            TurnOnWatcher();
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
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnChangeEventHandler(object sender,FileSystemEventArgs args)
        {
            OnWatcherChangeEventRedirector?.Invoke(args);
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnDeleteEventHandler(object sender,FileSystemEventArgs args)
        {
            OnWatcherDeleteEventRedirector?.Invoke(args);
        }

        /// <summary>
        /// Redirects FileWatcherEvents to subscribers
        /// </summary>
        private void OnCreateEventHandler(object sender,FileSystemEventArgs args)
        {
            new Thread(() => OnWatcherCreateEventRedirector?.Invoke(args)).Start();
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
