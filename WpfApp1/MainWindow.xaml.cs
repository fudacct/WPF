using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //Img = new BitmapImage(new Uri("/WpfApp1;component/Images/earth.gif", UriKind.Relative));
        }

        public ImageSource Img
        {
            get { return (ImageSource)GetValue(ImgProperty); }
            set { SetValue(ImgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Img.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgProperty =
            DependencyProperty.Register("Img", typeof(ImageSource), typeof(MainWindow), new PropertyMetadata(null));

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
                //可获得当前执行的exe的文件名。
                string str1 = Process.GetCurrentProcess().MainModule.FileName;
                //获取和设置当前目录(即该进程从中启动的目录)的完全限定路径。 备注 按照定义，如果该进程在本地或网络驱动器的根目录中启动，则此属性的值为驱动器名称后跟一个尾部反斜杠(如“C:\”)。如果该进程在子目录中启动，则此属性的值为不带尾部反斜杠的驱动器和子目录路径(如“C:\mySubDirectory”)。
                string str2 = Environment.CurrentDirectory;
                //获取应用程序的当前工作目录。
                string str3 = Directory.GetCurrentDirectory();
                //获取基目录，它由程序集冲突解决程序用来探测程序集。
                string str4 = AppDomain.CurrentDomain.BaseDirectory;
                //获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称。
                //string str5 = Application.StartupPath;
                ////获取启动了应用程序的可执行文件的路径，包括可执行文件的名称。
                //string str6 = Application.ExecutablePath;
                //获取或设置包含该应用程序的目录的名称。
                string str7 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                //正确的写法 授权和（1）结合起来。 
                Uri uri = new Uri("pack://application:,,,/xx;pic/bg2.gif", UriKind.Absolute);
                string currentDirectory = System.Environment.CurrentDirectory;
                System.IO.Path.GetDirectoryName(str7);
                gridBackground.ImageSource = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(str7))) + "//pic//bg.gif"));
                //gridBackground1.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(str7))) + "//pic//bg.gif"));
            }
            else
            {
                //string str7 = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                //gridBackground1.Source = new BitmapImage(new Uri(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(str7))) + "//pic//bg2.gif"));
                gridBackground.ImageSource = null;
                //gridBackground1.Source = null;
            }
                
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
