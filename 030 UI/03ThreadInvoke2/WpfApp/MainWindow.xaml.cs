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
            UpdateUI("処理中", false);

            // スレッドを生成/開始
            Thread thread = new Thread(ThreadSub);
            thread.Start();
        }

        // UI更新
        private void UpdateUI(String msg, bool FEnable)
        {
            textBox.Text = msg;
            bStart.IsEnabled = bClose.IsEnabled = FEnable;
        }

        // スレッドメソッド
        private void ThreadSub()
        {
            //本処理
            Thread.Sleep(5000);

            //結果表示
            textBox.Dispatcher.Invoke(
                UpdateUI, new object[] { "本処理完了", true });
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
