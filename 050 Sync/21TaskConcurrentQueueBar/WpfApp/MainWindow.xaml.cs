using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Collections.Concurrent;

#nullable disable

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new();
        private readonly ConcurrentQueue<string> mQueue = new();

        public MainWindow()
        {
            InitializeComponent();

            Title = "Queue & Timer";

            bStart.Content = "開始";
            bClose.Content = "閉じる";

            _timer.Interval = new TimeSpan(0, 0, 0, 0, 50); // 50 m sec.
            _timer.Tick += new EventHandler(MyTimerMethod);
        }

        // 「開始」ボタン
        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = false;

            AProgressBar.Value = 0;
            _timer.Start();

            Task.Run(() =>
            {
                string sendData;
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(100);

                    sendData = "percent " + i.ToString();

                    mQueue.Enqueue(sendData);   // Enqueue data
                }
                mQueue.Enqueue("end");   // Enqueue data
            });
        }

        // タイマメソッド
        private void MyTimerMethod(object sender, EventArgs e)
        {
            char[] delimiter = { ' ', ',', ':', '/' };      // delimitters
            string[] split;

            try
            {
                while (mQueue.TryDequeue(out string msg)) // Dequeue data
                {
                    split = msg.Split(delimiter);   // split
                    if (split.Length > 0)           // no data
                    {
                        switch (split[0])
                        {
                            case "percent":
                                AProgressBar.Value = Int32.Parse(split[1]);
                                break;

                            case "end":
                                _timer.Stop();
                                bStart.IsEnabled = bClose.IsEnabled = true;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //表示更新
        private void AProgressBar_ValueChanged(object sender, RoutedEventArgs e)
        {
            ATextBlock.Text = AProgressBar.Value.ToString() + " %";
        }
    }
}
