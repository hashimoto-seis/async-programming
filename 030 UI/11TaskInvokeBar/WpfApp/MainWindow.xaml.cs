using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Title = "Task & Invoke";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // 「開始」ボタン
        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = false;

            AProgressBar.Value = 0;
            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        AProgressBar.Value += 1;
                        if (AProgressBar.Value == 100)
                            bStart.IsEnabled = bClose.IsEnabled = true;
                    });
                }
            });
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


