using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void STartOhne(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                Thread.Sleep(100);
            }
        }

        private void StartTS(object sender, RoutedEventArgs e)
        {
            Task.Run(() => 
            {
                for (int i = 0; i < 100; i++)
                {
                    //pb1.Value = i;
                    pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Thread.Sleep(100);
                }

            });
        }

        private void StartTS2(object sender, RoutedEventArgs e)
        {
            var ts = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    //pb1.Value = i;
                    //pb1.Dispatcher.Invoke(() => pb1.Value = i);
                    Task.Factory.StartNew(() => pb1.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                    Thread.Sleep(100);
                }

            });
        }

        private async void StartAsync(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pb1.Value = i;
                await Task.Delay(100);
            }
        }
    }
}
