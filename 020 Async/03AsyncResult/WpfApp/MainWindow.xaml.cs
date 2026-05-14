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

            Title = "Result";
            label.Content = "結果";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // 「開始」ボタン
        private async void BStart_Click(object sender, RoutedEventArgs e)
        {
            bStart.IsEnabled = bClose.IsEnabled = false;
            textBox.Text = "処理中";

            var Result = await Task.Run(() => {
                Thread.Sleep(5000);     // Heavy work
                return "本処理完了";
            });

            textBox.Text = Result;
            bStart.IsEnabled = bClose.IsEnabled = true;
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
