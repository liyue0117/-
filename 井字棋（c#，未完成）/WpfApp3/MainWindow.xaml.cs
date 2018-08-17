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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
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
            if (TBox1.Text.Length > 0 && TBox1.Text.Length < 10)//判断玩家输入的文字长度,更为严谨的做法应该是判断字母+数字的长度,以及玩家输入的字符串不符合时应出现提示信息
            {
               //定义在storage类中的静态变量,为了存储玩家名称,成绩等信息
                TBlock2.Text = "Hi " + ". Welcome to the battlefield!Now,lets begin the game!!!Hey,do you want to place a bomb first?";//其实应该直接在前台代码中写好内容,不必在后台再赋值,因多次修改代码所致
                TBlock2.Visibility = Visibility.Visible;//显示提示文本块
                RB1.Visibility = Visibility.Visible;//显示单选按钮,让用户选择是否先手
                RB2.Visibility = Visibility.Visible;//同上
                btm_fight.Visibility = Visibility.Visible;//显示进入游戏界面的按钮
                btm_commit.IsEnabled = false;//禁止玩家再次点击commit按钮
            }

        }

        private void btm_fight_Click(object sender, RoutedEventArgs e)
        {
            bool RButton;
            if (RB1.IsChecked == true)//玩家点击"yes"按钮时,设置静态布尔类型变量RButton的值并进入游戏界面"mainpage"
            {
                RButton = true;

                var mainpage = new Window1();
                this.Hide();
                mainpage.Show();

            }
            else if (RB2.IsChecked == true)//玩家点击"no"按钮后,类同yes
            {
                RButton = false;

                var mainpage = new Window1();
                this.Hide();
                mainpage.Show();

            }
            else//玩家没有点击单选按钮的情形,出现提示信息并不触发进入游戏界面的事件,其实想想是否让程序预先设定好"yes"单选按钮就没有这一步了呢?
            {
                TBcheck.Visibility = Visibility.Visible;
            }

        }
    }
}
