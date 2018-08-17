using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public class btm {
        public int click_num;
    }


    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();//退出程序

        }

        private void Btm0_Click(object sender, RoutedEventArgs e)
        {
           

           
                btm0.Content = "X";//按钮btm0的内容变为"X",打印出"X"字母
               

        }
    }
}
