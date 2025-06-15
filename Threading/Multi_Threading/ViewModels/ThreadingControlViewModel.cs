using Multi_Threading.Abstractions;
using Multi_Threading.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Multi_Threading.ViewModels
{
    public class ThreadingControlViewModel : BaseViewModel, IDisplayControl
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private bool _isRunning = false;

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }
        public ICommand PauseCommand { get; set; }
        public ICommand ResumeCommand { get; set; }

        public ThreadingControlViewModel()
        {
            GenerateCancellationToken();
            StartCommand = new RelayCommand(() => { TaskStart(); }, null);
            StopCommand = new RelayCommand(() => { TaskStop(); }, null);
            PauseCommand = new RelayCommand(() => { TaskPause(); }, null);
            ResumeCommand = new RelayCommand(() => { TaskResume(); }, null);
        }

        private int _CurrentValue;
        public int CurrentValue
        {
            get { return _CurrentValue; }
            set
            {
                _CurrentValue = value;
                OnPropertyChanged();
            }
        }

        public string Tittle => "Threading Control Demo";

        private void TaskStart()
        {
            if (_isRunning)
                return;

            _isRunning = true;

            Task.Run(() =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    CurrentValue++;
                    Thread.Sleep(100);
                    if (CurrentValue == 200)
                        CurrentValue = 0;
                }

            }, _cancellationToken).ContinueWith(r => { _isRunning = false; });
        }

        private void TaskStop()
        {
            _cancellationTokenSource.Cancel();
            CurrentValue = 0;
        }

        private void TaskPause()
        {
            _cancellationTokenSource.Cancel();
        }

        private void TaskResume()
        {
            GenerateCancellationToken();
            TaskStart();
        }

        void GenerateCancellationToken()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
        }
    }
}
