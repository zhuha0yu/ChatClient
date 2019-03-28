using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ChatClient
{
   
    public partial class MainWindow : Form
    {
        static BindingList<user> userlist = new BindingList<user>();
        private Socket ClientSocket=null;
        DataTable dt = new DataTable();
        string message = null;
        public MainWindow()
        {
            InitializeComponent();
        }
       
        private void MainWindow_Load(object sender, EventArgs e)
        {
            
                dt.Columns.Add("nickname", typeof(String));
                dt.Columns.Add("id", typeof(String));
                listBox_user.DataSource = dt;
                listBox_user.DisplayMember = "nickname";
                listBox_user.ValueMember = "id";
                dt.Rows.Add("system", "system");
            Startup st1 = new Startup();
            st1.Setdelegate(SetSocket);
            st1.ShowDialog();
            Thread recvmess = new Thread(receivemessage);
            recvmess.Start(ClientSocket);

            userlist.Add(new user("system",ClientSocket.RemoteEndPoint.ToString()));
            

        }
        public int SetSocket(IPEndPoint ipep)
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(ipep);
                
            }
            catch (Exception)
            {               
                return 1;
            }
            Thread recvmess = new Thread(receivemessage);
            recvmess.Start(ClientSocket);
            return 0;


            

        }

        private void button_send_Click(object sender, EventArgs e)
        {
            string receiverid =(string) dt.Rows[listBox_user.SelectedIndex][1];
            string receivernickname = (string)dt.Rows[listBox_user.SelectedIndex][0];
            if(!ClientSocket.Poll(100,SelectMode.SelectWrite))
            {
                textBox_receive.AppendText("发送失败！服务器连接不正常！");
                textBox_receive.AppendText(Environment.NewLine);
                return;

            }
            Thread sendmess = new Thread(sentmessage);
            string type;

            if (receivernickname == "system") type = "System";
            else type = "Message";
            XmlDocument xml = BuildXml(type,textBox_sent.Text,receivernickname);
            sendmess.Start(xml.InnerXml);
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private XmlDocument BuildXml(string type,string message,string receiver)
        {
            XmlDocument xml = new XmlDocument();
            //加入XML的声明段落：<?xmlversion="1.0" encoding="utf-8"?>
            XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
            xml.AppendChild(xmldecl);
            XmlElement root = xml.CreateElement("Message");
            xml.AppendChild(root);
            XmlElement eType = xml.CreateElement("Type");
            eType.InnerText = type;
            
            XmlElement eMessage = xml.CreateElement("Message");
            eMessage.InnerText = message;
            XmlElement eReceiver = xml.CreateElement("Receiver");
            eReceiver.InnerText = receiver;
            XmlElement eTime = xml.CreateElement("Time");
            eTime.InnerText = DateTime.Now.ToString();
            root.AppendChild(eType);
            
            root.AppendChild(eMessage);
            root.AppendChild(eReceiver);
            root.AppendChild(eTime);
            return xml;
        }
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClientSocket.Send(Encoding.Unicode.GetBytes("%%system%%endsession%%system%%"));
            }
            catch
            {

            }
            try
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
            }
            catch
            {

            }
                ClientSocket.Disconnect(false);
            ClientSocket.Close();
            
        }

        private void textBox_sent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button_send.Focus();
                button_send_Click(sender, e);
                textBox_sent.Clear();
            }
        }

        private void button_send_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData!=Keys.Enter)
            {
                textBox_sent.Focus();
                textBox_sent.AppendText(e.KeyCode.ToString().ToLower());
            }
        }
        public void sentmessage(Object mess)
        {

            try
            {
                ClientSocket.Send(Encoding.Unicode.GetBytes((string)mess));
            }
            catch {
                return;
            }

            textBox_receive.Invoke(new EventHandler(
                delegate
                {
                XmlDocument xml = new XmlDocument();
                    xml.LoadXml((string)mess);
                    string receivernickname=xml.SelectSingleNode("/Message/Receiver").InnerText;
                    textBox_receive.AppendText("你 对 " + receivernickname + " 说： " + textBox_sent.Text);
                    textBox_receive.AppendText(Environment.NewLine);
                }));
            textBox_sent.Invoke(new EventHandler(delegate
            {
                textBox_sent.Text = "";
            }));
           
                
        }
        public void receivemessage(Object socket1)
        {
            Socket socket = (Socket)socket1;
            while (true)
            {

                byte[] originalmseeage = new byte[4096];


                if (socket != null && socket.Connected)
                {
                    try
                    {
                        int len = socket.Receive(originalmseeage);

                        if (len >= 0)
                        {
                            message = Encoding.Unicode.GetString(originalmseeage);
                            messageHandle(message);


                        }
                    }
                    catch (Exception)
                    {



                    }
                }
                else return;
            }
        }

        private void messageHandle(string message)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(message);
            XmlNode root = xml.SelectSingleNode("/Message");
            
            string messageType = root.SelectSingleNode("Type").InnerText;
            
            string messageContent = root.SelectSingleNode("Message").InnerText;
            switch(messageType)
            {
                case "NewUser":
                    listBox_user.Invoke(new EventHandler(delegate
                    {
                        dt.Rows.Add(messageContent, "system");
                    }));
                    
                    break;
                case "Message":
                    textBox_receive.Invoke(new EventHandler(delegate
                    {


                        textBox_receive.AppendText(root.SelectSingleNode("Time").InnerText
                            + Environment.NewLine 
                            + root.SelectSingleNode("Sender").InnerText
                            + " : " 
                            + messageContent 
                            );
                        textBox_receive.AppendText(Environment.NewLine);
                    }));
                    break;
            }
            
        }
    }
    public class user
    {
        public string nickname;
        public string id;
        public user(string nick, string i)
        {
            nickname = nick;
            id = i;
        }

    }
    
}
