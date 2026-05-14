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

            Title = "async/await";
            label.Content = "結果";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // async, Heavy work
        private static void SleepMethod()
        {
            Thread.Sleep(5000);
        }

        // 「開始」ボタン
        private async void BStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = false;
            textBox.Text = "処理中";

            await Task.Run(SleepMethod);

            textBox.Text = "本処理完了";
            bStart.IsEnabled = bClose.IsEnabled = true;
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
