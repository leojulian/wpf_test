using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CancellationTokenSource cancellationSource;
        CancellationToken token;

        Path pipe;
        Path waterFlow;

        public MainWindow()
        {
            InitializeComponent();
            CreatePipe();
            //InitializeWaterFlowAnimation();

            cancellationSource = new CancellationTokenSource();
            token = cancellationSource.Token;
            Button button = new Button
            {
                Content = "Start Animation",
                Width = 150,
                Height = 30,
                Margin = new Thickness(10)
            };

        }

        void test(string a)
        {

        }

        void test(int a)
        {

        }

        string test(char a)
        {
            return "a";
        }

        void CreatePipe()
        {
            pipe = new Path { Stroke = Brushes.Red, StrokeThickness = 2 };

            var pipeGeometry = new PathGeometry();
            var pipeFigure = new PathFigure() { StartPoint = new Point(150, 250) };

            // 添加直线和折线段
            pipeFigure.Segments.Add(new LineSegment(new Point(200, 250), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(250, 200), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(300, 200), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(350, 300), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(400, 300), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(450, 250), true));
            pipeFigure.Segments.Add(new LineSegment(new Point(550, 250), true));

            pipeGeometry.Figures.Add(pipeFigure);
            pipe.Data = pipeGeometry;

            // 创建水流动画路径
            waterFlow = new Path
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 5,
                StrokeDashArray = new DoubleCollection { 10, 5 }
            };

            // 使用相同的几何图形
            waterFlow.Data = pipeGeometry.Clone();

            // 添加到画布
            MainCanvas.Children.Add(pipe);
            MainCanvas.Children.Add(waterFlow);
        }

        private void InitializeWaterFlowAnimation()
        {
            // 创建水流动画
            var waterFlowStoryboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                From = 0,
                To = 15,
                Duration = TimeSpan.FromSeconds(1),
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTarget(animation, waterFlow);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Path.StrokeDashOffset)"));

            waterFlowStoryboard.Children.Add(animation);
            waterFlowStoryboard.Begin(this);
        }
        static readonly object locker = new object();
        private async void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //var ctx = SynchronizationContext.Current;
                await Task.Run(() =>
                {
                    lock (locker)
                    {

                    }
                    Console.WriteLine("In");
                    // 1st. Post
                    //ctx.Post(_ => { InitializeWaterFlowAnimation(); }, null);
                    // 2nd
                    //SynchronizationContext.SetSynchronizationContext(ctx);
                    //ctx.Send(_ => { InitializeWaterFlowAnimation(); }, null);
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(10000);
                    token.ThrowIfCancellationRequested();
                    Console.WriteLine("out");
                }, token);//.GetAwaiter().GetResult();
                          //InitializeWaterFlowAnimation();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.WriteLine("after await");
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            cancellationSource.Cancel();
            foreach (var num in GetInts())
            {
                Console.WriteLine("外部遍历了:{0}", num);
            }
        }

        IEnumerable<int> GetInts()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("内部遍历了:{0}", i);
                yield return i;
            }
        }

        void LockTest()
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            ManualResetEvent manualResetEvent = new ManualResetEvent(false);

            Semaphore semaphore = new Semaphore(1, 1);
            SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

            using (Mutex mutex = new Mutex(false, "Global\\MyMutex"))
            {
                mutex.WaitOne();
                try
                {
                    // 执行临界区代码
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }

            ReaderWriterLockSlim readerWriterLockSlim = new ReaderWriterLockSlim();

            Barrier barrier = new Barrier(2, (b) =>
            {
                Console.WriteLine("所有线程都到达了屏障点");
            });
        }
    }

}
