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

namespace Cs408_step2_deneme_0._01
{
   
    public partial class Form1 : Form
    {
        static Socket serverSocket;
        static List<Client> clientList;
        static Client Asker;
        //static bool isListening = false;
        static bool isTreminating = false;
        static bool isStarted = false;
        static bool accept = true;
        static bool flag1 = false;
        static bool flag2 = false;
        static int gameRound;
        static bool waitPlayers = true;
        static string Question, Answer;     //UserAnswer????
        static bool barier = true;
        static int barrierNum;
        static bool isListening = false;

        static bool waitAsk = true;
        static bool waitAnswer = true;


        delegate void StringArgReturningVoidDelegate(string text);
        public Form1()
        {
            InitializeComponent();
            Console.Text = "Welcome Please enter the PORT NUMBER to start the server";
            //TextBox.CheckForIllegalCrossThreadCalls = false;
        }

        public void AppendTextBox(string msg)
        {
            if(this.Console.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(AppendTextBox);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.Console.Text += msg;
            }
        }

        private void OpenServer_Click(object sender, EventArgs e)
        {
            accept = true;
            waitPlayers = true;
            waitAsk = true;
            waitAnswer = true;
            isStarted = false;
            isTreminating = false;
            try
            {
                if (!isListening)
                {
                    serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    serverSocket.ReceiveTimeout = 10000;        // 
                    isListening = true;
                    clientList = new List<Client>();
                }
                IPEndPoint ipendP = new IPEndPoint(IPAddress.Any, int.Parse(textBox_PortNum.Text));
                serverSocket.Bind(ipendP);
                serverSocket.Listen(20);     //can be more ???????????????????



                Console.AppendText("\nListening...");
                Thread AcceptThread = new Thread(new ThreadStart(Accept));
                AcceptThread.IsBackground = true;
                AcceptThread.Start();
            }
            catch
            {
                AppendTextBox("\nProblem occured... Please try with another Port Number");
            }
        }

        private void CloseServer_Click(object sender, EventArgs e)
        {
            if (clientList != null)
            {
                foreach (Client a in clientList)
                {
                    a.SocketClient.Close();
                }
            }
            clientList = null;
            serverSocket = null;
            isTreminating = true;
            accept = false;
            isStarted = false;
            serverSocket = null;
            isListening = false;
            AppendTextBox("\nServer is closed");
        }


        private void button_StartGame_Click(object sender, EventArgs e)
        {
            barier = true;
            barrierNum = 0;                                                                     //barier initialization
            gameRound = int.Parse(textBox_RoundNo.Text);
            if (clientList.Count > 1 && !String.IsNullOrEmpty(textBox_RoundNo.Text) && !String.IsNullOrWhiteSpace(textBox_RoundNo.Text) && gameRound > 0)
            {
                accept = false;
                sortingPlayers();
                isStarted = true;
            }
            else
            {
                AppendTextBox("\nThere is not enough player Or Please enter Acceptable RoundNo, PLAYER COUNT:" + clientList.Count);
            }
        }

        public void Accept()
        {
            while (!isTreminating)
            {
                
                Client newclient = new Client();
                bool isNameExist = false;
                string msg = "";
                
                try
                {
                    newclient.SocketClient = serverSocket.Accept();
                }
                catch
                {
                    AppendTextBox("\nERROR::A client tried to connect but failed, No1");
                    
                }
                try
                {
                    ReceiveMessage(ref msg, newclient);      //takes name of the user
                }
                catch
                {
                    AppendTextBox("\nUserName cannot be reveived");
                }
                newclient.Name = msg;
                //Byte[] buffer = new Byte[4096];             
                //newclient.SocketClient.Receive(buffer);             //takes name of the user
                //newclient.Name = Encoding.Default.GetString(buffer);

                if (serverSocket == null)
                {
                    Thread.CurrentThread.Abort();
                }
                foreach (Client a in clientList)
                {
                    if (newclient.Name == a.Name)        //if the player name already taken by another player
                    {
                        isNameExist = true;
                    }
                }               
                if(!accept)
                {
                    sendMessage("Game already started", newclient);
                    AppendTextBox("\nA player tried to connect while game is on:" + newclient.Name);
                    newclient.SocketClient.Close();
                }
                else if (String.IsNullOrEmpty(newclient.Name))
                {
                    try
                    {
                        sendMessage("UNCORRECT NAME", newclient);
                    }
                    catch
                    {
                        AppendTextBox("\nError:: A client tried to connect but failed No:2 ");
                        newclient.SocketClient.Close();
                        
                    }
                }
                else if (isNameExist || String.IsNullOrWhiteSpace(newclient.Name))
                {
                    sendMessage("Try another UserName", newclient);
                    newclient.SocketClient.Dispose();
                    newclient.SocketClient.Close();
                }
                else
                {
                    clientList.Add(newclient);
                    AppendTextBox("\nPlayer Connected id = " + newclient.Name);
                    
                    sendMessage("Server: You are connected", newclient);
                    Thread Receive = new Thread(new ThreadStart(ServerMain));
                    Receive.IsBackground = true;
                    Receive.Start();
                }
               
               
            }
        }



        public void ServerMain()
        {
            int TimeOutReceive = clientList.Count() * 10000;
            if(TimeOutReceive >30000)
            {
                TimeOutReceive = 30000;
            }
            AppendTextBox("\nIn ServerMain");
            Client myClient = clientList[clientList.Count() - 1];
            myClient.Connected = true;
            int RoundCount = 1;
            waitAnswer = true;
            waitAsk = true;


            while (!isTreminating && myClient.Connected)         //wait players????
            {

                while (isStarted&& myClient.Connected)
                {
                    
                    if (clientList.Count == 1)            // if there is just 1 player left
                    {
                        // SEN KAZANDIN
                        AppendTextBox("\nJust 1 player left Winner = " + clientList[0].Name);
                        try
                        {
                            sendMessage("You Win", myClient);
                        }
                        catch
                        {
                            AppendTextBox("\nERROR::MSG:'You Win' couldnt send to " + myClient.Name);
                        }
                        myClient.Connected = false;
                        isTreminating = true;
                        isStarted = false;

                    }
                    else if (clientList.Count < 1)         //if there is no one to play
                    {
                        // Oyuncu kalmadı 
                        AppendTextBox("\n\nThere is no player to play");
                        isStarted = false;
                        accept = true;
                        isTreminating = true;
                    }
                    else
                    {
                        try
                        {
                            string EMPTY = "";

                            sendMessage("Round " + RoundCount.ToString(), myClient);


                            for (int i = 0; i != clientList.Count() && isStarted; i++)
                            {
                                
                                if (myClient.isMyTurn)
                                {
                                    myClient.isMyTurn = false;
                                }
                                if (clientList.ElementAt(i) == myClient)
                                {
                                    myClient.isMyTurn = true;
                                    Asker = myClient;
                                }

                                if (myClient.isMyTurn)           //Asker
                                {
                                    //waitAnswer = true;
                                    sendMessage("Ask", myClient);
                                    AppendTextBox("\nAsk = " + myClient.Name);

                                    ReceiveMessage(ref Question, myClient);
                                    AppendTextBox("\n\nQuestion = " + Question);

                                    sendMessage("Ok", myClient);

                                    ReceiveMessage(ref Answer, myClient);
                                    AppendTextBox("\nAnswer = " + Answer);



                                    waitAsk = false;
                                    while (waitAnswer) { }
                                    waitAnswer = true;

                                }
                                else                             //Answerer
                                {
                                    waitAsk = true;
                                    sendMessage("Answer", myClient);
                                    while (waitAsk) { }

                                    sendMessage(Question, myClient);            //SEND QUESTION

                                    ReceiveMessage(ref myClient.Answer, myClient);      //RECEIVE USERANSWER

                                    if (Asker.Connected)
                                    {
                                        if (myClient.Answer == Answer)
                                        {
                                            myClient.Score++;
                                            sendMessage("Correct", myClient);               //SEND CORRECT

                                            AppendTextBox("\n Correct::" + myClient.Name);
                                        }
                                        else
                                        {
                                            sendMessage("Incorrect", myClient);
                                            AppendTextBox("\nIncorrect::" + myClient.Name);
                                        }
                                    }
                                    else
                                    {
                                        sendMessage("Preparing for next round", myClient);
                                    }
                                    waitAnswer = false;
                                    ReceiveMessage(ref EMPTY, myClient);            //RECEIVE OK
                                    EMPTY = "";
                                }
                                string scores = "";
                                foreach(Client a in clientList)
                                {
                                    scores = scores + "\n" + a.Name + " = " + a.Score;
                                }
                                sendMessage(scores, myClient); //SEND SCORE
                                //waitAnswer = true;
                                //waitAsk = true;
                                ReceiveMessage(ref EMPTY, myClient);                //RECEIVE OK
                                AppendTextBox("\nSERVER:" + EMPTY);
                                RoundCount++;
                            }

                        }
                        catch
                        {
                            if(myClient.isMyTurn)
                            {
                                myClient.Connected = false;
                                Question = "Akser disconnected please write OK for next turn";
                                waitAsk = false;
                            }
                            else if(clientList.Count() == 2)
                            {
                                waitAnswer = false;
                            }
                            
                            AppendTextBox("A Player Disconnected PlayerNAme:" + myClient.Name);
                            myClient.Connected = false;
                            isTreminating = true;

                        }
                        if (gameRound < RoundCount)
                        {
                            isStarted = false;
                            isTreminating = true;
                            try
                            {
                                sendMessage("Gameover", myClient);




                                Client Winner = clientList[0];

                                foreach (Client a in clientList)
                                {
                                    if (Winner.Score < a.Score)
                                    {
                                        Winner = a;
                                    }
                                }

                                int Score = Winner.Score;
                                int winnerCount = 0;
                                foreach (Client a in clientList)
                                {
                                    if (a.Score == Score)
                                    {
                                        winnerCount++;
                                    }
                                }


                                if (winnerCount > 1)
                                {
                                    if (myClient.Score == Score)
                                    {
                                        sendMessage("You Win with tie Your score is " + myClient.Score, myClient);
                                    }
                                    else
                                    {
                                        sendMessage("You LOST Your score is " + myClient.Score, myClient);
                                    }
                                }
                                else
                                {
                                    if (myClient.Score == Score)
                                    {
                                        sendMessage("You WIN Your score is " + myClient.Score, myClient);
                                    }
                                    else
                                    {
                                        sendMessage("You LOST Your score is " + myClient.Score, myClient);
                                    }
                                }
                               

                                Barrier barrier = new Barrier(clientList.Count);
                                barrier.SignalAndWait();
                            }
                            catch
                            {
                                AppendTextBox("\nDEBUG:0.04 PROBLEM IN GAMEOVER");
                            }
                            myClient.Connected = false;
                            isTreminating = true;
                        }
                    }
                }
            }
            isTreminating = true;
            myClient.Connected = false;
            isStarted = false;
            accept = true;

            myClient.SocketClient.Close();


            if (clientList != null)
            {
                clientList.Remove(myClient);
            }
            //disconnect
        }

        private void sortingPlayers()
        {
            Client temp;
            List<Client> result = new List<Client>();

            while(clientList.Count() >0)
            {
                temp = clientList[0];
                foreach(Client a in clientList)
                {
                    if(String.Compare(a.Name, temp.Name) < 0)
                    {
                        temp = a;
                    }
                }
                result.Add(temp);
                clientList.Remove(temp);
            }

            for(int i = 0; i < result.Count(); i++)
            {
                clientList.Add(result[i]);
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void ReceiveMessage(ref string msg, Client client)
        {
            Byte[] buffer = new Byte[4096];
            client.SocketClient.Receive(buffer);
            msg = Encoding.Default.GetString(buffer);
            string result = "";
            for (int i = 0; i < msg.Length - 1; i++)
            {
                if(msg.ElementAt(i) == '\0')
                {
                    break;
                }
                result += msg.ElementAt(i);

            }
            msg = result;
            //AppendTextBox("\nDEBUG: RECEIVE: " + msg + "," + client.Name);
        }

        

        private void sendMessage(string msg, Client client)
        {
                Byte[] buffer = new Byte[4096];
                buffer = Encoding.Default.GetBytes(msg);

                client.SocketClient.Send(buffer);
           // AppendTextBox("\nDEBUG: SEND: " + msg+","+client.Name);
        }


        //private void sendDynamicMessage(ref string msg, Client client)
        //{
        //    int length = msg.Length;
        //    for(; length >0; length-=32)
        //    {
        //        try
        //        {
        //            Byte[] buffer = new Byte[64];
        //            string temp = msg.Substring()
        //        }
        //    }
        //}

    }

    public class Client
    {
        public string Name;
        public Socket SocketClient;
        public int Score = 0;
        public bool Connected = false;
        public bool isMyTurn = false;
        public string Answer;
    }
}
