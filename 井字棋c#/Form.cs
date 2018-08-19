using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace 井字棋
{
    public partial class Form : System.Windows.Forms.Form
    {
        //模式表示（1 人VS人且玩家1先攻,2 人VS人且玩家2先攻,3 人VS电脑且人先攻,4 人VS电脑且电脑先攻）
        int type = 0;//取1,2,3,4值
        //表示两种类型的棋子，ture表示玩家1的棋子，false表示玩家2的棋子
        bool turn = true;
        //初始化按钮数组，0-未按下，1-“X”（玩家），2-"O"（电脑）
        int[,] ButtonArray = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public Form()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //首先得选择游戏模式
            if (type == 0)
            {
                MessageBox.Show("请先选择游戏模式！", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #region 获取被点击按钮及其Name、X、Y坐标
            Button ClickedButton = (Button)sender;
            string ClickedButtonName = ClickedButton.Name;
            //根据按钮的名字来分析出当前所点击处是哪一行那一列的格子
            int ClickedButtonX = Convert.ToInt32(ClickedButtonName.Substring(6, 1));
            int ClickedButtonY = Convert.ToInt32(ClickedButtonName.Substring(7, 1));
            #endregion
            //若为人机模式
            if(type==3||type==4)Turn(1, ClickedButtonX, ClickedButtonY);
            //人和人对战模式
            else if (turn==true)
            {
                Turn(1, ClickedButtonX, ClickedButtonY);
            }
            else if (turn == false)
            {
                Turn(2, ClickedButtonX, ClickedButtonY);
            }
            turn = !turn;//换棋子
        }

        private int JudgeWin(int Player)
        {
            int Result = 0;

            #region 进行判断
            //判断第一横排
            if (ButtonArray[0, 0] == Player && ButtonArray[0, 1] == Player && ButtonArray[0, 2] == Player) Result = Player;

            //判断第二横排
            else if (ButtonArray[1, 0] == Player && ButtonArray[1, 1] == Player && ButtonArray[1, 2] == Player) Result = Player;

            //判断第三横排
            else if (ButtonArray[2, 0] == Player && ButtonArray[2, 1] == Player && ButtonArray[2, 2] == Player) Result = Player;

            //判断第一纵排
            else if (ButtonArray[0, 0] == Player && ButtonArray[1, 0] == Player && ButtonArray[2, 0] == Player) Result = Player;

            //判断第二纵排
            else if (ButtonArray[0, 1] == Player && ButtonArray[1, 1] == Player && ButtonArray[2, 1] == Player) Result = Player;

            //判断第三纵排
            else if (ButtonArray[0, 2] == Player && ButtonArray[1, 2] == Player && ButtonArray[2, 2] == Player) Result = Player;

            //判断左上到右下
            else if (ButtonArray[0, 0] == Player && ButtonArray[1, 1] == Player && ButtonArray[2, 2] == Player) Result = Player;

            //判断右上到左下
            else if (ButtonArray[0, 2] == Player && ButtonArray[1, 1] == Player && ButtonArray[2, 0] == Player) Result = Player;
            #endregion

            #region 报出结果
            if (Result == 1)//棋子 在数组中表示值为1的一方胜利
            {
                if (type == 3 || type == 4)
                {
                    MessageBox.Show("玩家获胜"); SaveResult("人机对战，玩家获胜\r\n");//人机模式
                }//人机模式
                else
                {
                    MessageBox.Show("玩家1获胜"); SaveResult("人人对战，玩家1获胜\r\n");//人对战人
                }
                    Restart();
                return 1;
            }
            if (Result == 2)//棋子 在数组中表示值为2的一方胜利
            {
                if (type == 3 || type == 4)
                {
                    MessageBox.Show("电脑获胜"); SaveResult("人机对战，电脑获胜\r\n");//人机模式
                }
                else
                {
                    MessageBox.Show("玩家2获胜"); SaveResult("人人对战，玩家2获胜\r\n");//人对战人
                }
                    Restart();
                return 2;
            }
            #endregion
            //判断是否下满棋盘
            #region 格子已满，打成平局
            bool full = true;
            foreach (int item in ButtonArray)
            {
                if (item == 0) full = false;//在数组中站位值为0，说明此处没有棋子
            }
            if (full)
            {
                MessageBox.Show("平局");
                SaveResult("平局\r\n");
                Restart();
            }
            #endregion
            //如果没有获胜的结果，返回0
            return 0;
        }

        private void ComputerTurn()
        {
            #region 调用寻找缺口的函数
            //寻找电脑的缺口
            int Result = FindBreach(1);

            //未找到电脑的缺口，寻找玩家的缺口
            if (Result == 0) Result = FindBreach(2);
            #endregion
            //找是否有条件更好的四个角落位置
            if (Result == 0) Result = FindBreach2(1);

            #region 未找到玩家的缺口，随便寻找四角是否被占
            if (Result == 0)
                if (ButtonArray[0, 0] == 0) Turn(2, 0, 0);
                else if (ButtonArray[0, 2] == 0) Turn(2, 0, 2);
                else if (ButtonArray[2, 0] == 0) Turn(2, 2, 0);
                else if (ButtonArray[2, 2] == 0) Turn(2, 2, 2);
                //寻找中心是否被占
                else if (ButtonArray[1, 1] == 0) Turn(2, 1, 1);
                //寻找是否有空位
                else if (ButtonArray[0, 1] == 0) Turn(2, 0, 1);
                else if (ButtonArray[1, 0] == 0) Turn(2, 1, 0);
                else if (ButtonArray[1, 2] == 0) Turn(2, 1, 2);
                else if (ButtonArray[2, 1] == 0) Turn(2, 2, 1);
            #endregion
        }

        /// <summary>
        /// 寻找缺口，寻找是否有一条线上已经有两个同样的棋子，并补上第三个，用于防止对方连成一条线或者使自己连成一条线
        /// </summary>
        /// <param name="Player">玩家为1，电脑为2</param>
        /// <returns></returns>
        private int FindBreach(int Player)
        {
            int Result = 0, Opponent = 0;

            #region 分配自己和对手的Player值
            if (Player == 1) Opponent = 2;
            else Opponent = 1;
            #endregion

            #region 判断并执行缺口
            //判断第一横排
            if (ButtonArray[0, 0] + ButtonArray[0, 1] + ButtonArray[0, 2] == 2 * Opponent &&
                ButtonArray[0, 0] != Player && ButtonArray[0, 1] != Player && ButtonArray[0, 2] != Player)
            {
                //寻找该排是否有空位
                if (ButtonArray[0, 0] == 0)
                {
                    Turn(2, 0, 0);
                    Result = 1;
                }
                else if (ButtonArray[0, 1] == 0)
                {
                    Turn(2, 0, 1);
                    Result = 1;
                }
                else if (ButtonArray[0, 2] == 0)
                {
                    Turn(2, 0, 2);
                    Result = 1;
                }
            }

            //判断第二横排
            else if (ButtonArray[1, 0] + ButtonArray[1, 1] + ButtonArray[1, 2] == 2 * Opponent &&
                     ButtonArray[1, 0] != Player && ButtonArray[1, 1] != Player && ButtonArray[1, 2] != Player)
            {
                if (ButtonArray[1, 0] == 0)
                {
                    Turn(2, 1, 0);
                    Result = 1;
                }
                else if (ButtonArray[1, 1] == 0)
                {
                    Turn(2, 1, 1);
                    Result = 1;
                }
                else if (ButtonArray[1, 2] == 0)
                {
                    Turn(2, 1, 2);
                    Result = 1;
                }
            }

            //判断第三横排
            else if (ButtonArray[2, 0] + ButtonArray[2, 1] + ButtonArray[2, 2] == 2 * Opponent &&
                     ButtonArray[2, 0] != Player && ButtonArray[2, 1] != Player && ButtonArray[2, 2] != Player)
            {
                if (ButtonArray[2, 0] == 0)
                {
                    Turn(2, 2, 0);
                    Result = 1;
                }
                else if (ButtonArray[2, 1] == 0)
                {
                    Turn(2, 2, 1);
                    Result = 1;
                }
                else if (ButtonArray[2, 2] == 0)
                {
                    Turn(2, 2, 2);
                    Result = 1;
                }
            }

            //判断第一纵排
            else if (ButtonArray[0, 0] + ButtonArray[1, 0] + ButtonArray[2, 0] == 2 * Opponent &&
                     ButtonArray[0, 0] != Player && ButtonArray[1, 0] != Player && ButtonArray[2, 0] != Player)
            {
                if (ButtonArray[0, 0] == 0)
                {
                    Turn(2, 0, 0);
                    Result = 1;
                }
                else if (ButtonArray[1, 0] == 0)
                {
                    Turn(2, 1, 0);
                    Result = 1;
                }
                else if (ButtonArray[2, 0] == 0)
                {
                    Turn(2, 2, 0);
                    Result = 1;
                }
            }

            //判断第二纵排
            else if (ButtonArray[0, 1] + ButtonArray[1, 1] + ButtonArray[2, 1] == 2 * Opponent &&
                     ButtonArray[0, 1] != Player && ButtonArray[1, 1] != Player && ButtonArray[2, 1] != Player)
            {
                if (ButtonArray[0, 1] == 0)
                {
                    Turn(2, 0, 1);
                    Result = 1;
                }
                else if (ButtonArray[1, 1] == 0)
                {
                    Turn(2, 1, 1);
                    Result = 1;
                }
                else if (ButtonArray[2, 1] == 0)
                {
                    Turn(2, 2, 1);
                    Result = 1;
                }
            }

            //判断第三纵排
            else if (ButtonArray[0, 2] + ButtonArray[1, 2] + ButtonArray[2, 2] == 2 * Opponent &&
                     ButtonArray[0, 2] != Player && ButtonArray[1, 2] != Player && ButtonArray[2, 2] != Player)
            {
                if (ButtonArray[0, 2] == 0)
                {
                    Turn(2, 0, 2);
                    Result = 1;
                }
                else if (ButtonArray[1, 2] == 0)
                {
                    Turn(2, 1, 2);
                    Result = 1;
                }
                else if (ButtonArray[2, 2] == 0)
                {
                    Turn(2, 2, 2);
                    Result = 1;
                }
            }

            //判断左上到右下
            else if (ButtonArray[0, 0] + ButtonArray[1, 1] + ButtonArray[2, 2] == 2 * Opponent &&
                     ButtonArray[0, 0] != Player && ButtonArray[1, 1] != Player && ButtonArray[2, 2] != Player)
            {
                if (ButtonArray[0, 0] == 0)
                {
                    Turn(2, 0, 0);
                    Result = 1;
                }
                else if (ButtonArray[1, 1] == 0)
                {
                    Turn(2, 1, 1);
                    Result = 1;
                }
                else if (ButtonArray[2, 2] == 0)
                {
                    Turn(2, 2, 2);
                    Result = 1;
                }
            }

            //判断右上到左下
            else if (ButtonArray[0, 2] + ButtonArray[1, 1] + ButtonArray[2, 0] == 2 * Opponent &&
                     ButtonArray[0, 2] != Player && ButtonArray[1, 1] != Player && ButtonArray[2, 0] != Player)
            {
                if (ButtonArray[0, 2] == 0)
                {
                    Turn(2, 0, 2);
                    Result = 1;
                }
                else if (ButtonArray[1, 1] == 0)
                {
                    Turn(2, 1, 1);
                    Result = 1;
                }
                else if (ButtonArray[2, 0] == 0)
                {
                    Turn(2, 2, 0);
                    Result = 1;
                }
            }
            #endregion

            return Result;
        }

        //判断是否有 创造两个一排的良好机会
        private int FindBreach2(int Player)
        {
            int Result = 0, Opponent = 0;

            #region 分配自己和对手的Player值
            if (Player == 1) Opponent = 2;
            else Opponent = 1;
            #endregion
            //判断第一横排
            if (ButtonArray[0, 0] + ButtonArray[0, 1] + ButtonArray[0, 2] == Opponent&&
                ButtonArray[0, 0] != Player && ButtonArray[0, 1] != Player && ButtonArray[0, 2] != Player)
                if(ButtonArray[0, 0] == Opponent)
                {
                    Turn(2, 0, 2);
                    return Result = 1;
                }
                else if(ButtonArray[0, 2] == Opponent)
                {
                    Turn(2, 0, 0);
                    return Result = 1;
                }
            //判断第三横排
            if (ButtonArray[2, 0] + ButtonArray[2, 1] + ButtonArray[2, 2] == Opponent &&
                ButtonArray[2, 0] != Player && ButtonArray[2, 1] != Player && ButtonArray[2, 2] != Player)
                if (ButtonArray[2, 0] == Opponent)
                {
                    Turn(2, 2, 2);
                    return Result = 1;
                }
                else if (ButtonArray[2, 2] == Opponent)
                {
                    Turn(2, 2, 0);
                    return Result = 1;
                }
            //判断第一纵排
            if (ButtonArray[0, 0] + ButtonArray[1, 0] + ButtonArray[2, 0] == Opponent &&
                ButtonArray[0, 0] != Player && ButtonArray[1, 0] != Player && ButtonArray[2, 0] != Player)
                if (ButtonArray[0, 0] == Opponent)
                {
                    Turn(2, 2, 0);
                    return Result = 1;
                }
                else if (ButtonArray[2, 0] == Opponent)
                {
                    Turn(2, 0, 0);
                    return Result = 1;
                }
            //判断第三纵排
            if (ButtonArray[0, 2] + ButtonArray[1, 2] + ButtonArray[2, 2] ==  Opponent &&
                ButtonArray[0, 2] != Player && ButtonArray[1, 2] != Player && ButtonArray[2, 2] != Player)
                if (ButtonArray[0, 2] == Opponent)
                {
                    Turn(2, 2, 2);
                    return Result = 1;
                }
                else if (ButtonArray[2, 2] == Opponent)
                {
                    Turn(2, 0, 2);
                    return Result = 1;
                }
            //判断左上到右下
            if (ButtonArray[0, 0] + ButtonArray[1, 1] + ButtonArray[2, 2] ==  Opponent &&
                ButtonArray[0, 0] != Player && ButtonArray[1, 1] != Player && ButtonArray[2, 2] != Player)
                if (ButtonArray[0, 0] == Opponent)
                {
                    Turn(2, 2, 2);
                    return Result = 1;
                }
                else if (ButtonArray[2, 2] == Opponent)
                {
                    Turn(2, 0, 0);
                    return Result = 1;
                }
            //判断右上到左下
            if (ButtonArray[0, 2] + ButtonArray[1, 1] + ButtonArray[2, 0] ==  Opponent &&
                ButtonArray[0, 2] != Player && ButtonArray[1, 1] != Player && ButtonArray[2, 0] != Player)
                if (ButtonArray[0, 2] == Opponent)
                {
                    Turn(2, 2, 0);
                    return Result = 1;
                }
                else if (ButtonArray[2, 0] == Opponent)
                {
                    Turn(2, 0, 2);
                    return Result = 1;
                }
            return Result;
        }

        /// <summary>
        /// 输入玩家、X和Y坐标进行回合处理
        /// </summary>
        /// <param name="Player">玩家为1，电脑为2</param>
        /// <param name="X">X坐标</param>
        /// <param name="Y">Y坐标</param>
        private void Turn(int Player, int X, int Y)
        {
            string Graph;
            if (Player == 1) Graph = "X";
            else Graph = "O";

            //修改对应按钮数组中对应位置
            ButtonArray[X, Y] = Player;

            //将被点击按钮上的文字改为“X”
            ((Button)Controls.Find("Button" + X + Y, true)[0]).Text = Graph;

            //将被点击按钮禁用
            ((Button)Controls.Find("Button" + X + Y, true)[0]).Enabled = false;

            //判断是否获胜
            if (JudgeWin(Player) == 0)
                if (Player == 1&&(type==3||type==4)) ComputerTurn();//人机模式自动让机器下棋
        }
        //恢复初始情况
        private void Restart()
        {
            #region 将按钮数组还原
            for (int x = 0; x <= 2; x++)
                for (int y = 0; y <= 2; y++)
                    ButtonArray[x, y] = 0;
            #endregion

            #region 将按钮控件还原
            Button00.Text = "";
            Button00.Enabled = true;
            Button01.Text = "";
            Button01.Enabled = true;
            Button02.Text = "";
            Button02.Enabled = true;
            Button10.Text = "";
            Button10.Enabled = true;
            Button11.Text = "";
            Button11.Enabled = true;
            Button12.Text = "";
            Button12.Enabled = true;
            Button20.Text = "";
            Button20.Enabled = true;
            Button21.Text = "";
            Button21.Enabled = true;
            Button22.Text = "";
            Button22.Enabled = true;
            #endregion
            //模式选项还原
            模式ToolStripMenuItem.Enabled = true;
            type = 0;
        }

        //重新开始
        private void ToolStripMenuItem_Restart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        //以下为 模式选择时的初始化
        private void 玩家1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 1;//1 人VS人且玩家1先攻
            模式ToolStripMenuItem.Enabled = false;
            turn = true;
        }

        private void 玩家2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 2;//2 人VS人且玩家2先攻
            模式ToolStripMenuItem.Enabled = false;
            turn = false;
        }

        private void 人ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 3;//3 人VS电脑且人先攻
            模式ToolStripMenuItem.Enabled = false;
        }

        private void 电脑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 4;//4 人VS电脑且电脑先攻
            模式ToolStripMenuItem.Enabled = false;
            //ComputerTurn();//简单固定位置起步

            //电脑随机下第一颗棋子
            Random ro = new Random();
            int x = ro.Next(1, 10);
            switch (x)
            {
                case 1: Turn(2, 0, 0); break;
                case 2: Turn(2, 0, 1); break;
                case 3: Turn(2, 0, 2); break;
                case 4: Turn(2, 1, 0); break;
                case 5: Turn(2, 1, 1); break;
                case 6: Turn(2, 1, 2); break;
                case 7: Turn(2, 2, 0); break;
                case 8: Turn(2, 2, 1); break;
                case 9: Turn(2, 2, 2); break;
                default:MessageBox.Show("Error!", "信息提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);break;
            }
        }
        private void SaveResult(string p)
        {
            FileStream fs = new FileStream(@"C:\Users\lrk\Desktop\#\jingziqi\井字棋c#\结果.txt", FileMode.Append);
            //获得字节数组
            byte[] data = new UTF8Encoding().GetBytes(p);
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }
    }
}
