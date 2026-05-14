using System.Windows;
using System.ComponentModel;
using System.Threading;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker? BW;

        public MainWindow()
        {
            InitializeComponent();

            Title = "BackgroundWorker";

            bStart.Content = "開始";
            bClose.Content = "閉じる";

            BW = new BackgroundWorker();
            //BW.DoWork += new DoWorkEventHandler(OnDoWork);
            //BW.ProgressChanged += new ProgressChangedEventHandler(OnProgressChanged);
            //BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(OnRunWorkerCompleted);
            BW.DoWork += OnDoWork;
            BW.ProgressChanged += OnProgressChanged;
            BW.RunWorkerCompleted += OnRunWorkerCompleted;
            BW.WorkerReportsProgress = true;
        }

        // 「開始」ボタン
        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = false;
            BW?.RunWorkerAsync(); // Background Worker開始
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Background Worker
        private void OnDoWork(object? sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                BW?.ReportProgress(i + 1);
            }
        }

        // Progress
        private void OnProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            AProgressBar.Value = e.ProgressPercentage;
        }

        //表示更新
        private void AProgressBar_ValueChanged(object sender, RoutedEventArgs e)
        {
            ATextBlock.Text = AProgressBar.Value.ToString() + " %";
        }

        // WorkerCompleted
        private void OnRunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = true;
        }
    }
}
