using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_U201513807
{
    public partial class startpage : Form
    {
        public startpage()
        {
            InitializeComponent();
            label2.Visible = false;
            RB1.Visible = false;
            RB2.Visible = false;
            button2.Visible = false;//隐藏下半部分内容
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text.Length < 10)//判断玩家输入的文字长度
                storage.name = textBox1.Text;   //存储玩家昵称
                label2.Text = "Hi," + storage.name + "！请选择谁先落子。";
                label2.Visible=true;//显示提示文本块
                RB1.Visible=true;//显示单选按钮,让用户选择谁先落子
                RB2.Visible=true;//同上
                button2.Visible=true;//显示进入确认按钮
                button1.Enabled = false;//禁止玩家再次点击commit按钮

            }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (RB1.Checked == true)//玩家选择电脑先落子时,设置RButton的值为false并进入游戏主界面mainpage
            {
                bool RButton = false;
                var frm = new mainpage();
                frm.ShowDialog();   //禁止用户修改初始信息 
            }
            else if (RB2.Checked == true)//玩家选择自己先落子时,设置Rbutton为true并进入游戏主界面mainpage
            {
                bool RButton = true;
                var frm = new mainpage();
                frm.ShowDialog();   
            }
            else//玩家未点选时，显示警告
            {
                MessageBox.Show("请选择谁先落子！","警告");   
            }

        }

        private void startpage_Load(object sender, EventArgs e)
        {

        }
    }

    internal class storage     //定义storage类，用于存储玩家信息
    {
        internal static string name;    //昵称
    }
}
