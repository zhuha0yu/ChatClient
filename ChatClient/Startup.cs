using System;
using System.Net;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ChatClient
{
    public partial class Startup : Form
    {
        private IPEndPoint ipep = null;
        private bool connected=false;
        public delegate int Setupsocket(IPEndPoint IPEP);
        Setupsocket SSocket=null;
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(!connected)
            {
                if (MessageBox.Show("连接尚未完成！重新连接请按重试，退出程序请按取消！", "提示！", MessageBoxButtons.RetryCancel) == DialogResult.Retry)

                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    System.Environment.Exit(0);
                }
            }
            base.OnFormClosing(e);
        }
        public Startup()
        {
            InitializeComponent();
        }
        public void Setdelegate(Setupsocket ssocket1)
        {
            SSocket = ssocket1;
        }

        private void button_connect_Click(object sender, EventArgs e)
        {
            int Portnum = 0;
            IPAddress ip = null;
            try
            {
                Exception Numoutofrange = new Exception();

                Portnum = Convert.ToInt32(textBox_port.Text);
                if (Portnum < 0 || Portnum > 65535)
                    throw Numoutofrange;
            }
            catch (Exception)
            {
                MessageBox.Show("端口号无效！必须是0-65535整数");
                textBox_port.Text = "";
                textBox_port.Focus();
                return;
            }
            string iptemp = textBox1_server_addr.Text;
            Regex ip_rule = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            if (ip_rule.IsMatch(iptemp))
            {
                string[] iptemp1 = iptemp.Split('.');
                byte[] ipaddr = new byte[4];
                for (int i = 0; i < 4; i++)
                {
                    try {
                        ipaddr[i] = Convert.ToByte(iptemp1[i]);
                    }catch(OverflowException)
                    {
                        MessageBox.Show("IP地址错误！");
                        return;
                    }


                }
                ip = new IPAddress(ipaddr);

            }

            else
            {
                MessageBox.Show("IP地址错误！");
                return;
            }
            ipep = new IPEndPoint(ip,Portnum);
            if (SSocket(ipep) == 0)
            {
                connected = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("连接失败，远程主机没有响应！");
            }

        }
    }
}
