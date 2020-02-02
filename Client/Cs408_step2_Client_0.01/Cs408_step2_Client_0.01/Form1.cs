using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cs408_step2_Client_0._01
{
    public partial class Form1 : Form
    {
        static Socket mySocket;
        static bool connected = false;
        static bool isGameStarted = false;
        static bool flag1 = false;
        static bool flag2 = false;
        static string consoleMsg = "";
        
        
        delegate void StringArgReturningVoidDelegate(string text);

        public void AppendTextBox(string msg)
        {
            if (this.Console.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(AppendTextBox);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.Console.Text += msg;
            }
        }
        public Form1()
        {
            InitializeComponent();
            Console.Text = "Welcome please enter USERNAME, IPADDRESSS and PORTNUMBER :)";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string UserName = textBox_UserName.Text;
            string ServerIP = textBox_IPAddress.Text;
            int portNum = int.Parse(textBox_PortNum.Text);
            if (connected)
            {
                AppendTextBox("\nYou are already connected");
            }
            else
            {
                if (String.IsNullOrEmpty(textBox_IPAddress.Text) && String.IsNullOrEmpty(textBox_PortNum.Text) && String.IsNullOrEmpty(textBox_UserName.Text))
                {
                    AppendTextBox("\nPlease fill all required spaces to play the game!");
                }
                else
                {
                    try
                    {
                        mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        mySocket.Connect(ServerIP, portNum);
                        
                        AppendTextBox("\nConnection Established! Checking for USERNAME APPROVAL");

                        sendMessage(UserName);

                        string msg = "";
                        ReceiveMessage(ref msg);

                        if (msg == "Try another UserName")
                        {
                            AppendTextBox("\n" + msg);
                            mySocket.Close();
                        }
                        else if(msg == "Game already started")
                        {
                            AppendTextBox("\n" + msg);
                            AppendTextBox("\nTry again later");
                            mySocket.Close();
                        }
                        else if(msg == "UNCORRECT NAME")
                        {
                            AppendTextBox("\nPlease try with another username");
                            mySocket.Close();
                        }
                        else if(msg.Substring(0,6) == "Server")
                        {
                            Thread MainThread = new Thread(new ThreadStart(ClientMain));
                            MainThread.IsBackground = true;
                            AppendTextBox("\n" + msg);
                            connected = true;
                            MainThread.Start();
                        }
                        else
                        {
                            AppendTextBox("\nProblem occured while connecting. Try again.");
                            connected = false;
                        }
                    }
                    catch
                    {
                        AppendTextBox("\nProblem occured while connecting. Try again.");
                        connected = false;
                    }
                }
            }
        }
        public void ClientMain()
        {
            AppendTextBox("\nIn ClientMain");
            AppendTextBox("\n\nWaiting for other players");
            string msg = "";
            string EMPTY = "";
            bool isMessageTaken = true;

            while (connected)
            {
                msg = "";
                EMPTY = "";
                try
                {
                    ReceiveMessage(ref msg);
                }
                catch
                {
                    isMessageTaken = false;
                    AppendTextBox("\nERROR0.02::Problem occured while taking message");
                }

                //AppendTextBox("\n\nDEBUGDEBUG:MSG= " + msg);
                if(!isMessageTaken)
                {

                }
                if (msg == "You Win")
                {
                    AppendTextBox("You win everbody disconnected");
                    connected = false;
                }
                else if (msg == "Gameover")
                {
                    string score = "";
                    ReceiveMessage(ref score);

                    AppendTextBox("\n" + score);



                    AppendTextBox("\n\nDisconnecting...");
                    connected = false;

                }
                else if (msg[0] == 'R')       //round num
                {
                    AppendTextBox(msg);
                }
                else
                {
                    try
                    {
                        if (msg == "Ask")
                        {
                            AppendTextBox("\n\nYOUR TURN\n\nPLEASE ASK");
                            flag2 = true;
                            while (!flag1) { }
                            sendMessage(consoleMsg);
                            consoleMsg = "";
                            flag2 = false;
                            flag1 = false;

                            ReceiveMessage(ref EMPTY);
                            AppendTextBox("\nDEBUG:Server" + EMPTY);
                            EMPTY = "";

                            AppendTextBox("\nPlease write the ANSWER");
                            flag2 = true;
                            while (!flag1) { }
                            sendMessage(consoleMsg);
                            consoleMsg = "";
                            flag1 = false;
                            flag2 = false;


                            string a = "";
                            ReceiveMessage(ref a);      //score msg
                            AppendTextBox("\n" + a);
                            a = "";
                            sendMessage("OK");
                        }
                        else if (msg == "Answer")
                        {
                            AppendTextBox("\n\nPLEASE Wait for question");

                            string Question = "";
                            ReceiveMessage(ref Question);               //receive QUESTION
                            AppendTextBox("\n\nQuestion = " + Question);

                            AppendTextBox("\nPlease write your ANSWER");
                            flag2 = true;
                            while (!flag1) { }
                            sendMessage(consoleMsg);                //SEND USERANSWER
                            flag1 = false;
                            flag2 = false;

                            ReceiveMessage(ref Question);    //RECEIVE correct or incorrect answer
                            AppendTextBox("\n\n" + Question);

                            sendMessage("OK");              //SEND OK

                            ReceiveMessage(ref Question);   //RECEIVE SCORE
                            AppendTextBox("\n" + Question);

                            sendMessage("OK");              //SEND OK
                        }
                        else
                        {
                            AppendTextBox("\nERROR0.03::Problem occured while taking message DDisconnected");
                            connected = false;
                        }
                    }
                    catch
                    {
                        AppendTextBox("\nDisconnected1");
                        connected = false;
                    }
                }
            }
            //try
            //{
            //    string MResult = "";
            //    ReceiveMessage(ref MResult);

            //    AppendTextBox("\n\n MResult = " + MResult);
            //}
            //catch
            //{
            //    AppendTextBox("\nDisconnected2");
            //}
            
    }


        private void ReceiveMessage(ref string msg)
        {
            Byte[] buffer = new Byte[4096];
            mySocket.Receive(buffer);
            msg = Encoding.Default.GetString(buffer);
            string result = "";
            for(int i = 0; i < msg.Length -1; i++)
            {
                if(msg.ElementAt(i) == '\0')
                {
                    break;
                }
                result += msg.ElementAt(i);
            }
            msg = result;
           // AppendTextBox("\nDEBUG: RECEIVE: " + msg);
        }









        private void sendMessage(string msg)
        {
            try
            {
                Byte[] buffer = new Byte[4096];
                buffer = Encoding.Default.GetBytes(msg);

                mySocket.Send(buffer);
               // AppendTextBox("\nDEBUG: SEND: " + msg);
            }
            catch
            {
                AppendTextBox((msg + " could not send in send messaage fnc"));
            }
        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            if (flag2)
            {
                consoleMsg = inputConsole.Text;
                inputConsole.Text = "";
                flag1 = true;
                flag2 = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
            connected = false;
            if(mySocket != null)
            {
                mySocket.Close();
            }
            mySocket = null;
        }
    }

}
