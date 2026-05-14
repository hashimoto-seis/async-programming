using System;
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

            Title = "Exception";
            label.Content = "結果";

            bStart.Content = "開始";
            bClose.Content = "閉じる";
        }

        // 「開始」ボタン
        private async void BStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bStart.IsEnabled = bClose.IsEnabled = false;
                textBox.Text = "Task開始.";

                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    throw new FormatException("test.");
                });
                textBox.Text = "Task終了.";
            }
            catch (FormatException ex)
            {
                textBox.Text = "例外発生.";
                MessageBox.Show(ex.Message, ex.GetType().Name,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                bStart.IsEnabled = bClose.IsEnabled = true;
            }
        }

        // 「閉じる」ボタン
        private void BClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
