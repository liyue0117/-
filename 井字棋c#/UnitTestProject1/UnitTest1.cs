using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 井字棋;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Man_vs_Comp_ManWin()
        {
            Form myFrom = new Form();
            myFrom.type = 3;
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 1;
            var result = myFrom.JudgeWin(1);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Man_vs_Comp_CompWin()
        {
            Form myFrom = new Form();
            myFrom.type = 3;
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 2;
            var result = myFrom.JudgeWin(2);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Man_vs_Man_ing1()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            var result = myFrom.JudgeWin(2);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Man_vs_Man_ing2()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            var result = myFrom.JudgeWin(1);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Man_vs_Man_Man1Win()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 1;
            myFrom.ButtonArray[1, 2] = 2;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 1;
            var result = myFrom.JudgeWin(1);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void Man_vs_Man_Man2Win()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 0;
            myFrom.ButtonArray[0, 2] = 2;
            myFrom.ButtonArray[1, 0] = 0;
            myFrom.ButtonArray[1, 1] = 1;
            myFrom.ButtonArray[1, 2] = 2;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 2;
            var result = myFrom.JudgeWin(2);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void Man_vs_Man_pingju()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 2;
            myFrom.ButtonArray[0, 1] = 2;
            myFrom.ButtonArray[0, 2] = 1;
            myFrom.ButtonArray[1, 0] = 1;
            myFrom.ButtonArray[1, 1] = 1;
            myFrom.ButtonArray[1, 2] = 2;
            myFrom.ButtonArray[2, 0] = 2;
            myFrom.ButtonArray[2, 1] = 2;
            myFrom.ButtonArray[2, 2] = 1;
            var result = myFrom.JudgeWin(2);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void Computer_turn1()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 0;
            myFrom.ButtonArray[0, 1] = 0;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 0;
            myFrom.ButtonArray[1, 1] = 0;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.ComputerTurn();
            Assert.AreEqual(2, myFrom.ButtonArray[0, 0]);
        }
        [TestMethod]
        public void Computer_turn2()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 2;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 1;
            myFrom.ButtonArray[1, 1] = 0;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.ComputerTurn();
            Assert.AreEqual(2, myFrom.ButtonArray[2, 0]);
        }
        [TestMethod]
        public void Computer_turn3()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 2;
            myFrom.ButtonArray[0, 2] = 1;
            myFrom.ButtonArray[1, 0] = 1;
            myFrom.ButtonArray[1, 1] = 0;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 2;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.ComputerTurn();
            Assert.AreEqual(2, myFrom.ButtonArray[2, 2]);
        }
        [TestMethod]
        public void Computer_turn4()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 2;
            myFrom.ButtonArray[0, 2] = 1;
            myFrom.ButtonArray[1, 0] = 1;
            myFrom.ButtonArray[1, 1] = 1;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 2;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 2;
            myFrom.ComputerTurn();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
        }
        [TestMethod]
        public void Computer_turn5()
        {
            Form myFrom = new Form();

            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 2;
            myFrom.ButtonArray[1, 0] = 0;
            myFrom.ButtonArray[1, 1] = 0;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 1;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.ComputerTurn();
            Assert.AreEqual(2, myFrom.ButtonArray[1, 1]);
        }
        [TestMethod]
        public void Turn1()
        {
            Form myFrom = new Form();
            myFrom.Turn(2, 1, 2);
            Assert.AreEqual(2, myFrom.ButtonArray[1, 2]);
        }
        [TestMethod]
        public void Turn2()
        {
            Form myFrom = new Form();
            myFrom.Turn(1, 1, 2);
            Assert.AreEqual(1, myFrom.ButtonArray[1, 2]);
        }
        [TestMethod]
        public void Turn3()
        {
            Form myFrom = new Form();
            myFrom.Turn(1, 2, 2);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
        }
        [TestMethod]
        public void Turn4()
        {
            Form myFrom = new Form();
            myFrom.Turn(2, 0, 1);
            Assert.AreEqual(2, myFrom.ButtonArray[0, 1]);
        }
        [TestMethod]
        public void Turn5()
        {
            Form myFrom = new Form();
            myFrom.Turn(1, 0, 0);
            Assert.AreEqual(1, myFrom.ButtonArray[0, 0]);
        }
        [TestMethod]
        public void Rester1()
        {
            Form myFrom = new Form();
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.Restart();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);

        }
        [TestMethod]
        public void Rester2()
        {
            Form myFrom = new Form();
            myFrom.ButtonArray[0, 0] = 0;
            myFrom.ButtonArray[0, 1] = 0;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 0;
            myFrom.ButtonArray[1, 1] = 0;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.Restart();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);

        }
        [TestMethod]
        public void Rester3()
        {
            Form myFrom = new Form();
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 1;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 2;
            myFrom.Restart();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);

        }
        [TestMethod]
        public void Rester4()
        {
            Form myFrom = new Form();
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 0;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 0;
            myFrom.ButtonArray[2, 1] = 0;
            myFrom.ButtonArray[2, 2] = 0;
            myFrom.Restart();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);

        }
        [TestMethod]
        public void Rester5()
        {
            Form myFrom = new Form();
            myFrom.ButtonArray[0, 0] = 1;
            myFrom.ButtonArray[0, 1] = 1;
            myFrom.ButtonArray[0, 2] = 2;
            myFrom.ButtonArray[1, 0] = 2;
            myFrom.ButtonArray[1, 1] = 2;
            myFrom.ButtonArray[1, 2] = 0;
            myFrom.ButtonArray[2, 0] = 2;
            myFrom.ButtonArray[2, 1] = 2;
            myFrom.ButtonArray[2, 2] = 1;
            myFrom.Restart();
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);
        }
        [TestMethod]
        [DeploymentItem("ManSys.exe")]
        public void ToolStripMenuItem_Restart_Click_Test()
        {
            Form myFrom = new Form();
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            myFrom.ToolStripMenuItem_Restart_Click(sender, e);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[0, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[1, 2]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 0]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 1]);
            Assert.AreEqual(0, myFrom.ButtonArray[2, 2]);

        }
        [TestMethod]
        [DeploymentItem("ManSys.exe")]
        public void 玩家1ToolStripMenuItem_Click_Test()
        {
            Form myFrom = new Form();
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            myFrom.玩家1ToolStripMenuItem_Click(sender, e);
            Assert.AreEqual(1, myFrom.type);
            Assert.AreEqual(true, myFrom.turn);

        }
        [TestMethod]
        [DeploymentItem("ManSys.exe")]
        public void 玩家2ToolStripMenuItem_Click_Test()
        {
            Form myFrom = new Form();
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            myFrom.玩家2ToolStripMenuItem_Click(sender, e);
            Assert.AreEqual(2, myFrom.type);
            Assert.AreEqual(false, myFrom.turn);

        }
        [TestMethod]
        [DeploymentItem("ManSys.exe")]
        public void 人ToolStripMenuItem_Click_Test()
        {
            Form myFrom = new Form();
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            myFrom.人ToolStripMenuItem_Click(sender, e);
            Assert.AreEqual(3, myFrom.type);

        }
        [TestMethod]
        [DeploymentItem("ManSys.exe")]
        public void 电脑ToolStripMenuItem_Click_Test()
        {
            Form myFrom = new Form();
            object sender = null; // TODO: 初始化为适当的值
            EventArgs e = null; // TODO: 初始化为适当的值
            myFrom.电脑ToolStripMenuItem_Click(sender, e);
            Assert.AreEqual(4, myFrom.type);

        }
    }
}
