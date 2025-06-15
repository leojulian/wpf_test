using Multi_Threading.Abstractions;
using Multi_Threading.Commands;
using Multi_Threading.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Multi_Threading.ViewModels
{
    internal class MultiThreadsHandleViewModel : BaseViewModel, IDisplayControl
    {
        public string Tittle => "Muti-Threads control demo";

        public ICommand StartCommand { get; private set; }

        public ObservableCollection<TaskPlanItem> Tasks { get; private set; }

        private ManualResetEvent _manualResetEvent; // 1. Wait 4 thread, need waitone 4 times, but need reset manully after each thread finished
        private AutoResetEvent _autoResetEvent; // Or 2. Wait 4 thread, need waitone 4 times
        private CountdownEvent _countdownEvent; // Or 3. Wait all threads finished, then main thread go on
        private SemaphoreSlim _semaphoreSlim; // Or 4, initial 4, let the 4 threads run first, then the main thread, after threads finished, main thread will continue.
        
        private bool _isRunning = false;

        public MultiThreadsHandleViewModel()
        {
            GenerateTaskPlanItem();

            StartCommand = new RelayCommand(() => Start(), () => !_isRunning);
            _manualResetEvent = new ManualResetEvent(false);
            _autoResetEvent = new AutoResetEvent(false);
            _countdownEvent = new CountdownEvent(4);
            _semaphoreSlim = new SemaphoreSlim(4);
        }

        void GenerateTaskPlanItem()
        {
            Tasks = new ObservableCollection<TaskPlanItem>();
            for (int i = 0; i < 5; i++)
            {
                TaskPlanItem taskPlanItem = new TaskPlanItem() { MaxValue = 30 + i * 10, CurrentValue = 0 };
                Tasks.Add(taskPlanItem);
            }
        }

        private void Start()
        {
            _isRunning = true;
            //_manualResetEvent.Reset();
            Task.Run(() =>
            {
                //_manualResetEvent.WaitOne();
                //_autoResetEvent.WaitOne();
                //_countdownEvent.Wait();
                Run(Tasks[0]);
            }).ContinueWith(r =>
            {
                Console.WriteLine($"Finished!--- {_countdownEvent.CurrentCount}");
                _isRunning = false;
                Tasks[0].CurrentValue = 0;
            });

            for(int i = 1; i < Tasks.Count; i++ )
            {
                TaskPlanItem taskPlanItem = Tasks[i];
                Task.Run(() =>
                {
                    Run(taskPlanItem);
                }).ContinueWith(r => taskPlanItem.CurrentValue = 0); ;
            }
        }

        private void Run(TaskPlanItem taskPlanItem)
        {
            _semaphoreSlim.Wait(10* 1000);
            while (taskPlanItem.CurrentValue < taskPlanItem.MaxValue)
            {
                taskPlanItem.CurrentValue++;
                Thread.Sleep(100);
            }

            //_manualResetEvent.Set();
            //_autoResetEvent.Set();
            //if (_countdownEvent.CurrentCount > 0)
            //    _countdownEvent.Signal(1);
        }
    }
}
