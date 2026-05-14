using System;
using System.Windows;
using System.Threading;

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

            Title = "Thread & Invoke";
            label.Content = "結果";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // 「開始」ボタン
        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            //前処理
            bStart.IsEnabled = bClose.IsEnabled = false;
            textBox.Text = "処理中";

            // スレッドを生成/開始
            Thread thread = new Thread(ThreadSub);
            thread.Start();
        }

        // スレッドメソッド
        private void ThreadSub()
        {
            //本処理
            Thread.Sleep(5000);

            //後処理
            textBox.Dispatcher.Invoke(new Action(() =>
            {
                textBox.Text = "本処理完了";
                bStart.IsEnabled = bClose.IsEnabled = true;
            }));
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
