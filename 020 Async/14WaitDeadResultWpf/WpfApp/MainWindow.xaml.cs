using System.Windows;
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

            Title = "deadlock";
            label.Content = "結果";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // async Task
        private async Task<string> AwaitTask()
        {
            await Task.Delay(100);
            return "本処理完了";
        }

        // 「開始」ボタン
        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            //前処理
            bStart.IsEnabled = bClose.IsEnabled = false;
            textBox.Text = "処理中";

            //本処理
            var t = AwaitTask();
            var str = t.Result;     // デッドロック
            //var str = AwaitTask().Result; // デッドロック

            //後処理
            textBox.Text = str;
            bStart.IsEnabled = bClose.IsEnabled = true;
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
