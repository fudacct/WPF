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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World!");
            MessageBox.Show("Hello WPF!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameText.Text))
            {
                MessageBox.Show("请输入姓名！");
            }
            else
            {
                MessageBox.Show("您输入的姓名是：" + NameText.Text);
                OutPutText.Text = "您输入的姓名是：" + NameText.Text;
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (NameText.IsEnabled)
                NameText.IsEnabled = false;
            else
                NameText.IsEnabled = true;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (gridBackground.ImageSource == null)
            {
                gridBackground.ImageSource = new BitmapImage(new Uri("C:\\Users\\Administrator\\Desktop\\bg2.gif"));
            }
            else
                gridBackground.ImageSource = null;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        proceBar.Dispatcher.Invoke(() => this.proceBar.Value = i);
                        tb.Dispatcher.Invoke(() => tb.Text = i + "%");
                        Thread.Sleep(300);
                        if (i == 100)
                        {
                            Thread.Sleep(1000);
                            i = 0;
                        }
                    }
                }
                catch (Exception)
                {
                }
                
            }));
            thread.Start();
        }
    }
}
