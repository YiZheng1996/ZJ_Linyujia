using System;
using System.Drawing;
using System.Windows.Forms;

namespace RWTEST.UI.Valve
{
    public partial class JYNYTest : Form
    {
        public JYNYTest()
        {
            InitializeComponent();
        }
        private VarHelper varval;
        public VarHelper VarVal
        {
            get
            { return varval; }

            set
            { varval = value; }
        }
        private void JYNYTest_Load(object sender, EventArgs e)
        {
            //ucJYNYTest jy = new ucJYNYTest();
            rbnJYDZ.Checked = true;
        }
        private void btnStartJYtest_Click(object sender, EventArgs e)
        {
            try
            {

                string newLine = Environment.NewLine + Environment.NewLine;
                decimal jydzVol = nudJYDZVol.Value;
                decimal jydzTime = nudJYDZtime.Value;
                decimal jydzLow = nudJYDZlow.Value;

                string tips = "请先确认绝缘电阻试验参数：" + newLine;
                tips += "绝缘电压(DC)：" + jydzVol.ToString() + newLine;
                tips += "绝缘测试时间(s)：" + jydzTime.ToString() + newLine;
                tips += "绝缘电阻下限(Ω）：" + jydzLow.ToString() + newLine;


                if (MessageBox.Show(tips, "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                //TH9320.TH9320_JueYuanTest(serialPortTH9320, jydzVol.ToString(), jydzTime, jydzLow);


                lblJYDZrst.Text = "";
                lblJYDZState.Text = "";

                rbnJYNY.Enabled = false;
                btnStartJYtest.Enabled = false;

                lblJYDZState.BackColor = SystemColors.Control;
                timerJY.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("绝缘电阻测试出错，" + ex.Message, "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStopJYtest_Click(object sender, EventArgs e)
        {
            //TH9320.TH9320_TestStop(serialPortTH9320);
            timerJY.Stop();
            rbnJYNY.Enabled = true;
            btnStartJYtest.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)  //绝缘
        {
            DiLed12.Switch = varval.AllShow.ArrayKG[11];//试验中
            DiLed13.Switch = varval.AllShow.ArrayKG[12];  //失败
            DiLed14.Switch = varval.AllShow.ArrayKG[13];//成功


            if (varval.AllShow.ArrayKG[11] == true)
            {
                lblJYDZState.Text = "正在测试……";
                lblJYDZState.BackColor = Color.Green;

            }

            if (varval.AllShow.ArrayKG[12])
            {
                lblJYDZState.Text = "测试完成";
                lblJYDZState.BackColor = SystemColors.Control;

                lblJYDZrst.Text = "测试失败";
                timerJY.Stop();
                rbnJYNY.Enabled = true;
                btnStartJYtest.Enabled = true;

            }

            if (varval.AllShow.ArrayKG[13])
            {
                lblJYDZState.Text = "测试完成";
                lblJYDZState.BackColor = SystemColors.Control;

                lblJYDZrst.Text = "测试通过";

                timerJY.Stop();
                rbnJYNY.Enabled = true;
                btnStartJYtest.Enabled = true;

            }
        }

        private void btnNYStart_Click(object sender, EventArgs e)
        {
            try
            {
                string newLine = Environment.NewLine + Environment.NewLine;
                decimal jynyVol = nudNYVol.Value;
                decimal jynyTime = nudNYtime.Value;
                decimal jynyUP = nudNYLDLUP.Value;

                string tips = "请先确认绝缘耐压试验参数：" + newLine;
                tips += "绝缘电压(AC)：" + jynyVol.ToString() + newLine;
                tips += "绝缘测试时间(s)：" + jynyTime.ToString() + newLine;
                tips += "绝缘电阻下限(mA)：" + jynyUP.ToString() + newLine;


                if (MessageBox.Show(tips, "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                //TH9320.TH9320_NaiYaTest(serialPortTH9320, jynyVol.ToString(), jynyTime.ToString(), jynyUP.ToString());


                lblNYrst.Text = "";
                lblNYstate.Text = "";

                rbnJYDZ.Enabled = false;
                btnNYStart.Enabled = false;

                lblNYstate.BackColor = SystemColors.Control;
                timerNY.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("绝缘电阻测试出错，" + ex.Message, "提示：", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNYstop_Click(object sender, EventArgs e)
        {
            //TH9320.TH9320_TestStop(serialPortTH9320);

            timerNY.Stop();

            rbnJYDZ.Enabled = true;
            btnNYStart.Enabled = true;

        }

        private void timerNY_Tick(object sender, EventArgs e)  //耐压
        {
            DiLed12.Switch = varval.AllShow.ArrayKG[11];//试验中
            DiLed13.Switch = varval.AllShow.ArrayKG[12];  //失败
            DiLed14.Switch = varval.AllShow.ArrayKG[13];//成功

            if (varval.AllShow.ArrayKG[11])
            {
                lblNYstate.Text = "正在测试……";
                lblNYstate.BackColor = Color.Green;
            }
            if (varval.AllShow.ArrayKG[12])
            {
                lblNYstate.Text = "测试完成";
                lblNYstate.BackColor = SystemColors.Control;

                lblNYrst.Text = "测试失败";
                timerNY.Stop();

                rbnJYDZ.Enabled = true;
                btnNYStart.Enabled = true;
            }

            if (varval.AllShow.ArrayKG[13])
            {
                lblNYstate.Text = "测试完成";
                lblNYstate.BackColor = SystemColors.Control;

                lblNYrst.Text = "测试通过";

                timerNY.Stop();
                rbnJYDZ.Enabled = true;
                btnNYStart.Enabled = true;

            }
        }

        private void rbnJYDZ_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnJYDZ.Checked)
            {
                grpJYDZ.Enabled = true;
                grpNY.Enabled = false;
            }
            else if (rbnJYNY.Checked)
            {
                grpNY.Enabled = true;
                grpJYDZ.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPortTH9320.Close();
            this.Close();
        }




    }
}
