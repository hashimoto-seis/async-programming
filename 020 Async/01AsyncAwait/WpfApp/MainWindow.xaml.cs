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

        // 「開始」ボタン
        private async void BStart_Click(object sender, RoutedEventArgs e)
        {
            //前処理
            bStart.IsEnabled = bClose.IsEnabled = false;
            textBox.Text = "処理中";

            //本処理
            await Task.Run(() =>
            {
                Thread.Sleep(5000);     // Heavy work
            });
            //await Task.Run(async () =>
            //{
            //    await Task.Delay(5000);     // Heavy work
            //});

            //後処理
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
