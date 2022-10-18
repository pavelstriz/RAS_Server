using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Diagnostics;
namespace TcpServer
{

    public partial class MainForm : Form
    {
        public class StateObject
        {
            // Size of receive buffer.  
            public const int BufferSize = 1024;

            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];

            // Received data string.
            public StringBuilder sb = new StringBuilder();

            // Client socket.
            public Socket workSocket = null;
        }
        private Blacklist blacklist;
        public MainForm(Blacklist _blacklist)
        {
            InitializeComponent();

            blacklist = _blacklist;

        }
        License lcs;

        private string pKey;
        String salt = String.Empty;
        String hashedpassword;

        //TcpListener listener;
        TcpClient client;

        private int clientID;
        private string usedMac;

        public SqlConnection sqlClients0 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients1 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients2 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients3 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients4 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients5 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients6 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlBlackList = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");



        public List<Socket> activeSockets = new List<Socket>();
        List<string>[] clientList = new List<string>[Constants.maximumClients];
        public List<string> activeClientsList = new List<string>();

        public struct activeClientsParameters
        {
            public Socket clientSocket;
            public String clientIp;
            public String clientPort;
        }

        public activeClientsParameters[] clientsParam = new activeClientsParameters[Constants.maximumClients];


        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (ucLa.txtPublicKey.TextLength > 0)
            {
                lcs = new License();

                salt = lcs.CreateSalt(10);
                hashedpassword = lcs.GenerateSHA256Hash(ucLa.txtPublicKey.Text, salt);

                pKey = salt;
                ucLa.txtVerKey.Text = hashedpassword;
            }
            else
            {
                ucLa.txtVerKey.Text = String.Empty;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //VerifyLicenseTask();
            //LoadLicensesToCB();
            //LicenseCheckTask(TimeSpan.FromSeconds(10), ct);
        }
        public DateTime serverTime = DateTime.Today;
        public DateTime startT;
        public DateTime expT;
        //public DateTime activatedT;
        TimeSpan daysLeft;
        string _daysLeft;



        public string verSn;
        public string verRegK;
        public string verVerK;
        public string mac;

        public string lSerialN;
        public string lRegK;
        public string lVerK;
        public string licenseResult;
        public string onlineMac;
        private void VerifyLicense(Socket clienT)
        {

            /* POROVNAT OVĚŘOVACÍ KOD KLIENTA NA SERVERU
             * POKUD BUDE KOD I MAC ADRESA SOUHLASIT
             * ODESLANI KLIENTOVI SIGNAL + DATUM A ČAS EXPIRACE POUŽITÍ LICENCE
             
             */

            SqlCommand checkLicenseId = new SqlCommand("SELECT COUNT(*) FROM " + Constants.tableActiveLicenses + "", sqlClients0);
            sqlClients0.Open();
            //checkLicenseId.Parameters.AddWithValue("@orderNumber", UC_Priority1.orderSelectedIdStored1); /////////CHYBA
            int UserIdExist = (int)checkLicenseId.ExecuteScalar();
            sqlClients0.Close();

            //MSG IKONA_TRUE
            //MessageBox.Show(UserIdExist.ToString());
            //UPRAVIT ZÁZNAM
            if (UserIdExist <= 0) //POKUD NEEXISTUJE ZÁZNAM
            {
                if (activeSockets.Count > 0)
                {
                    licenseStatus = "Deactivated"; //(NAPSAT DO INVOKU)
                    txtLStatus.Invoke(new MethodInvoker(() =>
                    {
                        txtLStatus.Text = licenseStatus;
                        txtDaysLeft.Text = "";

                    }));
                }
            }
            else
            {

                sqlClients2.Open();
                String query2 = "SELECT mac, sN, pK, vK, startT, expT, activatedT FROM " + Constants.tableActiveLicenses + "";

                SqlCommand cmd2 = new SqlCommand(query2, sqlClients2);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    //MessageBox.Show(dr3["macAddress"].ToString());
                    mac = dr2["mac"].ToString();

                    lSerialN = dr2["sN"].ToString();
                    lRegK = dr2["pK"].ToString();
                    lVerK = dr2["vK"].ToString();

                    startT = DateTime.Parse(dr2["startT"].ToString());
                    expT = DateTime.Parse(dr2["expT"].ToString());
                    lActivatedT = dr2["activatedT"].ToString();

                    daysLeft = expT.Subtract(serverTime);

                    _daysLeft = daysLeft.ToString(@"dd");
                    _daysLeft = _daysLeft.TrimStart('0');
                    _daysLeft = (Int32.Parse(_daysLeft)).ToString();

                    if (ucLv.btnDeactivateLicense.Text == "Activate") // POKUD JE LICENCE VYPNUTÁ V LICENSEVIEW
                    {
                        cSerialN = "Disabled";
                        cRegK = "Disabled";
                        cVerK = "Disabled";
                    }
                    
                    //POROVNÁNÍ PROMĚNÝCH 2 SQL TABULEK
                    if (cMac.Equals(mac) && cSerialN.Equals(lSerialN) && cRegK.Equals(lRegK) && cVerK.Equals(lVerK))
                    {
                        /*
                        MessageBox.Show(cMac + "\n" + mac);
                        MessageBox.Show(cSerialN + "\n" + lSerialN);
                        MessageBox.Show(cRegK + "\n" + lRegK);
                        MessageBox.Show(cVerK + "\n" + lVerK);*/

                        Console.WriteLine("Verified.");


                        licenseResult = "<licenseVerified>";
                        SendCommand(clienT, licenseResult);
                        sqlClients3.Open();
                        String query3 = "UPDATE " + Constants.tableL_OnlineClients + " SET licenseStatus=@licenseStatus, daysLeft=@daysLeft WHERE macAddress=@macAddress";
                        SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);

                        cmd3.Parameters.AddWithValue("@licenseStatus", "Activated");
                        //MessageBox.Show(_daysLeft);
                        cmd3.Parameters.AddWithValue("@daysLeft", _daysLeft);
                        cmd3.Parameters.AddWithValue("@macAddress", cMac);//rdpName.Text);

                        cmd3.ExecuteNonQuery();
                        sqlClients3.Close();

                        if (txtMAC.Text == cMac)
                        {

                            txtLStatus.Invoke(new MethodInvoker(() =>
                            {
                                txtLStatus.Text = "Activated";
                                txtDaysLeft.Text = _daysLeft;
                                //SendCommand(clientSocket, licenseResult);

                            }));
                        }
                        break;
                    }
                    else
                    {
                        //Console.WriteLine(cSerialN + cRegK + cVerK + cMac);
                        Console.WriteLine("Deactivated.");
                        //SendCommand(clientSocket, "<licenseNotVerified>");
                        licenseResult = "<licenseNotVerified>";
                        SendCommand(clienT, licenseResult);
                        sqlClients3.Open();
                        String query3 = "UPDATE " + Constants.tableL_OnlineClients + " SET licenseStatus=@licenseStatus, daysLeft=@daysLeft WHERE macAddress=@macAddress";
                        SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);

                        cmd3.Parameters.AddWithValue("@licenseStatus", "Deactivated");
                        cmd3.Parameters.AddWithValue("@daysLeft", "");
                        cmd3.Parameters.AddWithValue("@macAddress", cMac);//rdpName.Text);

                        cmd3.ExecuteNonQuery();
                        sqlClients3.Close();

                        if (txtMAC.Text == cMac)
                        {

                            txtLStatus.Invoke(new MethodInvoker(() =>
                            {
                                txtLStatus.Text = "Deactivated";
                                txtDaysLeft.Text = "";
                                //SendCommand(clientSocket, licenseResult);

                            }));
                        }
                    }

                }

                sqlClients2.Close();


            }

            //foreach (Socket soc in activeSockets)
            //{
            //Console.WriteLine("test");
            //SendCommand(clientSocket, licenseResult);
            //}
        }
        private void button3_Click(object sender, EventArgs e)
        {

            // Set the monitor timout to "never".

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ucLa.Visible = false;
            ucLm.Visible = true;
        }
        private void LicenseExpirationTask()
        {
            try
            {
                sqlClients0.Open();
                String query2 = "SELECT mac, sN, startT, expT FROM " + Constants.tableActiveLicenses + "";

                SqlCommand cmd2 = new SqlCommand(query2, sqlClients0);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                while (dr2.Read())
                {
                    mac = dr2["mac"].ToString();
                    verSn = dr2["sN"].ToString();
                    startT = DateTime.Parse(dr2["startT"].ToString());
                    expT = DateTime.Parse(dr2["expT"].ToString());


                    if (serverTime >= expT)
                    {
                        sqlClients1.Open();
                        String query1 = "UPDATE " + Constants.tableL_OnlineClients + " SET licenseStatus=@licenseStatus, uSN = @uSN, uPK = @uPK, uVK = @uVK WHERE macAddress=@macAddress";
                        SqlCommand cmd1 = new SqlCommand(query1, sqlClients1);

                        cmd1.Parameters.AddWithValue("@licenseStatus", "Deactivated");
                        cmd1.Parameters.AddWithValue("@uSN", String.Empty);
                        cmd1.Parameters.AddWithValue("@uPK", String.Empty);
                        cmd1.Parameters.AddWithValue("@uVK", String.Empty);
                        cmd1.Parameters.AddWithValue("@macAddress", mac);



                        cmd1.ExecuteNonQuery();
                        sqlClients1.Close();
                        if (txtMAC.Text == onlineMac)
                        {
                            txtLStatus.Invoke(new MethodInvoker(() =>
                            {
                                txtLStatus.Text = "Deactivated";
                                txtDaysLeft.Text = String.Empty;

                            }));
                        }

                        sqlClients2.Open();
                        String query3 = "DELETE FROM " + Constants.tableActiveLicenses + " WHERE mac = '" + mac + "' AND sN = '" + verSn + "'";
                        SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
                        cmd3.ExecuteNonQuery();
                        sqlClients2.Close();



                        sqlClients2.Open();
                        String query4 = "UPDATE " + Constants.tableL_AR + " SET active=@active WHERE sN=@sN";
                        SqlCommand cmd4 = new SqlCommand(query4, sqlClients2);

                        cmd4.Parameters.AddWithValue("@active", false);
                        cmd4.Parameters.AddWithValue("@sN", verSn);//rdpName.Text);

                        cmd4.ExecuteNonQuery();
                        sqlClients2.Close();

                        LoadLicensesToCB();
                        //MOVE TO EXPIRED LICENSES

                        /*
                        sqlClients3.Open();
                        String query5 = "UPDATE " + Constants.tableExpiredLicenses + " SET active=@active WHERE sN=@sN";
                        SqlCommand cmd5 = new SqlCommand(query5, sqlClients2);

                        cmd5.Parameters.AddWithValue("@active", false);

                        cmd5.ExecuteNonQuery();
                        sqlClients3.Close();

                        */

                        //UPDATE TABLE PK TO FALSE 

                        //Console.WriteLine("expiredd");



                    }

                    else
                    {

                    }
                }
                sqlClients0.Close();

                //LoadLicensesToCB();
                //VerifyLicense();
                //VerifyLicenseTask();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
        public async Task LicenseCheckTask(TimeSpan interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                //await FooAsync();
                LicenseExpirationTask();
                await Task.Delay(interval, cancellationToken);

            }
        }

        public void LoadLicensesToCB()
        {


            ucLa.comboLicenseId.Items.Clear();

            sqlClients1.Open();
            String query2 = "SELECT sN FROM " + Constants.tableL_AR + " WHERE active='" + false + "'";

            SqlCommand cmd2 = new SqlCommand(query2, sqlClients1);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                ucLa.comboLicenseId.Items.Add(dr2["sN"].ToString());
            }
            sqlClients1.Close();

            if (ucLa.comboLicenseId.Items.Count > 0)
                ucLa.comboLicenseId.SelectedIndex = 0;

        }
        CancellationTokenSource cancelTask;
        CancellationToken ct;
        public static UC_LicenseMain1 ucLm;
        public static UC_LicenseView1 ucLv;
        public static UC_LicenseAdd1 ucLa;
        public static UC_TaskScheduler1 ucLts;
        UC_RemoteCommand1 ucRc;


        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                if (activeClients.Items.Count == 0)
                {
                    btnDisconnectClient.Enabled = false;
                    btnBlockClient.Enabled = false;

                }
                txtConsole.ReadOnly = true;
                //txtClientIp.Text = String.Empty;
                txtId.Text = String.Empty;
                txtMachineName.Text = String.Empty;
                txtUserName.Text = String.Empty;
                txtUserIp.Text = String.Empty;
                txtMAC.Text = String.Empty;
                txtLStatus.Text = String.Empty;
                pbShowLInfo.Visible = false;
                txtDaysLeft.Text = String.Empty;
                txtUpTime.Text = String.Empty;

                //LoadLicensesToCB();
                //ucLa.comboLicenseId.SelectedIndex = 0;
                GetLocalIPAddress();

                //Overrides
                GraphicOverrides.SetDoubleBuffered(tableLayoutPanel1);


                /*ucLm = new UC_LicenseMain1(this);
                ucLm.Dock = DockStyle.Fill;
                tabPage2.Controls.Add(ucLm);
                */
                ucLm = new UC_LicenseMain1(this);
                ucLm.Dock = DockStyle.Fill;
                //ucLm.Visible = true;
                tabPage2.Controls.Add(ucLm);

                ucLa = new UC_LicenseAdd1(this);
                ucLa.Dock = DockStyle.Fill;
                //ucLa.Visible = false;
                tabPage2.Controls.Add(ucLa);

                ucLv = new UC_LicenseView1(this);
                ucLv.Dock = DockStyle.Fill;
                //ucLv.Visible = false;
                tabPage2.Controls.Add(ucLv);

                ucLts = new UC_TaskScheduler1(this);
                ucLts.Dock = DockStyle.Fill;
                //ucLv.Visible = false;
                tabPage5.Controls.Add(ucLts);



                ucLm.Visible = true;
                ucLa.Visible = false;
                ucLv.Visible = false;
                ucLts.Visible = true;


                ucRc = new UC_RemoteCommand1(this);
                ucRc.Dock = DockStyle.Fill;
                tabPage1.Controls.Add(ucRc);
                //tabControl1.TabPages.Add(tabPage5);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void UpdateLicenseParameter()
        {
            sqlClients1.Open();

            string querystr = "UPDATE " + Constants.tableL_AR + " SET active=@active WHERE sN=@sN";
            SqlCommand cmd1 = new SqlCommand(querystr, sqlClients1);

            cmd1.Parameters.AddWithValue("@active", true);
            cmd1.Parameters.AddWithValue("@sN", ucLa.comboLicenseId.SelectedItem.ToString());//rdpName.Text);
            cmd1.ExecuteNonQuery();
            sqlClients1.Close();

            LoadLicensesToCB();

            ucLa.txtPublicKey.Text = String.Empty;
            ucLa.txtVerKey.Text = String.Empty;
            //txtLStatus.Text = "Activated";
            //clientList[clientIndex].RemoveAt(5);
            //clientList[clientIndex].Add("Activated");
        }
        // Incoming data from the client. 


        const int portNo = 5500;
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            sqlClients3.Open();
            String query3 = "DELETE FROM " + Constants.tableL_OnlineClients + "";
            SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);
            cmd3.ExecuteNonQuery();
            sqlClients3.Close();


            btnServerStart.Enabled = false;
            btnServerStop.Enabled = true;
            if (IsListening == false)
            {
                IsListening = true;


                thread = new Thread(StartListening);
                thread.IsBackground = true;
                thread.Start();

                //tcpListenerReadWrite.Start();
                Console.WriteLine("Starting TCPServer...");
                Console.WriteLine("Server listening on port: {0}", portNo.ToString());
                txtConsole.AppendText(DateTime.Now + ":  Starting TCPServer..." + Environment.NewLine);
                txtConsole.AppendText(DateTime.Now + ":  Server listening on port: " + portNo.ToString() + Environment.NewLine);

                //listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);


                cancelTask = new CancellationTokenSource();
                ct = cancelTask.Token;
                ct.Register(() => Console.WriteLine("Stopping License Check task"));
                LicenseCheckTask(TimeSpan.FromSeconds(Constants.licenseCheckAfter), ct);
            }
        }
        Socket serverSocket;
        private void btnServerStop_Click(object sender, EventArgs e)
        {
            //SendCommand(clientSocket, "<licenseNoteVerified>");

            btnServerStart.Enabled = true;
            btnServerStop.Enabled = false;
            try
            {
                if (IsListening == true)
                {
                    IsListening = false;


                    Console.WriteLine("Stopping TCPServer...");
                    txtConsole.AppendText(DateTime.Now + ":  Stopping TCPServer..." + Environment.NewLine);
                    //thread.Abort();
                    StopListening();

                    cancelTask.Cancel();

                    Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
                    Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());
                    //Console.WriteLine("Active elements in activeClients: " + clientList[].Count.ToString());
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public bool IsListening;
        public void StopListening()
        {

            Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
            Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());
            int i = 1;
            foreach (Socket soc in activeSockets)
            {

                txtConsole.Invoke(new MethodInvoker(() =>
                {
                    txtConsole.AppendText(DateTime.Now + ":  Client " + ((IPEndPoint)(soc.RemoteEndPoint)).Address + " has disconnected." + "(" + upTimes[i] + ")" + Environment.NewLine);
                    i++;
                }));
                //soc.Shutdown(SocketShutdown.Both);
                soc.Close();
            }

            foreach (String s in activeClientsList)
            {

                activeClients.Invoke(new MethodInvoker(() =>
                {

                    activeClients.Items.Remove(s);

                }));

            }

            serverSocket.Close();

            activeSockets.Clear();
            
            activeClientsList.Clear();

        }

        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private static ManualResetEvent commandInfoDone = new ManualResetEvent(false);

        IPAddress ipAddress;

        public string IPADDRESS;
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    IPADDRESS = ip.ToString(); ;
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void StartListening()
        {
            ipAddress = IPAddress.Parse(IPADDRESS); //IPADDRESS

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5500);

            serverSocket = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

            try
            {
                serverSocket.Bind(localEndPoint);
                serverSocket.Listen(1);

                IsListening = true;
                while (IsListening == true)
                {
                    // Set the event to nonsignaled state.  
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.  
                    //Console.WriteLine("Waiting for a connection...");
                    serverSocket.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        serverSocket);
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        String clientInfo;
        String clientMessage;
        Socket clientSocket;

        public void AcceptCallback(IAsyncResult ar)
        {

            // Signal the main thread to continue.  
            allDone.Set();
            BlackListChecker();

            if (IsListening == false) return;
            // Get the socket that handles the client request.


            serverSocket = (Socket)ar.AsyncState;
            clientSocket = serverSocket.EndAccept(ar);

            string cIp = ((IPEndPoint)(clientSocket.RemoteEndPoint)).Address.ToString();
            string cPort = ((IPEndPoint)(clientSocket.RemoteEndPoint)).Port.ToString();
            IPEndPoint remoteIpEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;

            //Blacklist
            if (blockedIps.Contains(cIp))
            {
                //SendCommand(activeSockets[activeClients.SelectedIndex], "</ras -disconnect -c>");
                txtConsole.Invoke(new MethodInvoker(() =>
                {
                    txtConsole.AppendText(DateTime.Now + ":  Client " + cIp + " connection attempt failed. (blacklisted)" + Environment.NewLine);
                }));

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

                return;
            }

            activeSockets.Add(clientSocket);
            clientsParam[activeSockets.Count - 1].clientSocket = clientSocket;


            Console.WriteLine("Server: Client:" + remoteIpEndPoint.Address + " has connected.");



            txtConsole.Invoke(new MethodInvoker(() =>
            {

                txtConsole.AppendText(DateTime.Now + ":  Client " + remoteIpEndPoint.Address.ToString() + " has connected." + Environment.NewLine);

                 
                clientsParam[activeSockets.Count - 1].clientIp = remoteIpEndPoint.Address.ToString(); 
                clientsParam[activeSockets.Count - 1].clientPort = remoteIpEndPoint.Port.ToString(); 

                activeClientsList.Add(remoteIpEndPoint.Address.ToString() + " (" + remoteIpEndPoint.Port + ")");
                activeClients.Items.Add(remoteIpEndPoint.Address.ToString() + " (" + remoteIpEndPoint.Port + ")");

                if (activeClients.Items.Count > 0)
                {
                    btnDisconnectClient.Enabled = true;
                    btnBlockClient.Enabled = true;

                }
                //activeClients.SetSelected(activeClients.FindString(remoteIpEndPoint.Address.ToString() + " (" + remoteIpEndPoint.Port + ")"), false);
            }));

            /*txtRemoteCommandConsole.Invoke(new MethodInvoker(() =>
            {
                ClientList.Add(remoteIpEndPoint.Address.ToString() + " (" + remoteIpEndPoint.Port + ")");


            }));
            */

            remoteIpEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = clientSocket;


            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                   new AsyncCallback(ReadClientInfo), state);


            clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadMessageCallback), state);

            //if(isBlacklisted == true)
            /* {
                 sqlClients4.Open();
                 String query4 = "DELETE FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";
                 SqlCommand cmd4 = new SqlCommand(query4, sqlClients4);
                 cmd4.Parameters.AddWithValue("@socketId", cPort);
                 cmd4.ExecuteNonQuery();
                 sqlClients4.Close();

                 RemoveActiveClient(cIp, cPort);

                 activeClientsList.Remove(cIp + " (" + cPort + ")");
                 activeSockets.Remove(handler);
                 //MessageBox.Show("Client is blacklisted");
                 return;
             }*/


        }



        class Clients
        {
            public int cId { get; set; }
            public string cMachine { get; set; }
            public string cAccount { get; set; }
            public string cIp { get; set; }
        }
        Clients[] ClientData;


        int[] seconds = new int[Constants.maximumClients];
        string[] upTimes = new string[Constants.maximumClients];
        TimeSpan[] timespans = new TimeSpan[Constants.maximumClients];

        public int timerIndex;
        private void Timers_Tick(object sender, EventArgs e)
        {


            System.Windows.Forms.Timer tt = sender as System.Windows.Forms.Timer;

            for (timerIndex = 0; timerIndex < Constants.maximumClients; timerIndex++)
            {
                if ((int)tt.Tag == timerIndex)
                {

                    seconds[timerIndex]++;
                    timespans[timerIndex] = TimeSpan.FromSeconds(seconds[timerIndex]);
                    upTimes[timerIndex] = timespans[timerIndex].ToString(@"hh\:mm\:ss");//\:fff");
                                                                                        //txtUpTime.Text = upTimes[i];
                                                                                        //textBox2.Text = second[i].ToString();
                    try
                    {
                        sqlClients2.Open();
                        String query2 = "UPDATE " + Constants.tableL_OnlineClients + " SET upTime=@upTime WHERE id=@id";
                        SqlCommand cmd2 = new SqlCommand(query2, sqlClients2);

                        cmd2.Parameters.AddWithValue("@upTime", upTimes[timerIndex]);
                        cmd2.Parameters.AddWithValue("@id", timerIndex);

                        cmd2.ExecuteNonQuery();
                        sqlClients2.Close();

                        /*if(activeClients.SelectedIndex == Int32.Parse(selectedID))
                        {
                            txtUpTime.Text = upTimes[activeClients.SelectedIndex].ToString();
                        }*/
                    }
                    catch { }
                }
                else
                {

                }

            }
            txtUpTime.Text = upTimes[activeClients.SelectedIndex + 1];


            int _tag = (int)tt.Tag;




        }
        public bool isBlacklisted;
        public string blockedIp;
        public string[] blockedIps;
        public void BlackListChecker()
        {
            blockedIp = String.Empty;
            blockedIps = new string[Constants.maximumClients];

            sqlBlackList.Open();
            String query2 = "SELECT ipAddress FROM " + Constants.tableL_BlockClients + "";

            SqlCommand cmd2 = new SqlCommand(query2, sqlBlackList);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            int i = 0;
            while (dr2.Read())
            {
                
                blockedIps[i] = dr2["ipAddress"].ToString();
                i++; //blockedIps[i] DAT NAHORU

                blockedIp = (string)dr2["ipAddress"];

                //MessageBox.Show(blockedIps[i].ToString());
            }
            
            sqlBlackList.Close();
        }
        bool clientRecon;
        System.Windows.Forms.Timer t;
        List<System.Windows.Forms.Timer> listOfTimers = new List<System.Windows.Forms.Timer>();
        public void ReadClientInfo(IAsyncResult ar)
        {

            MainForm forme = new MainForm(null);
            Socket handler;
            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            handler = state.workSocket;

            string cPort = ((IPEndPoint)(handler.RemoteEndPoint)).Port.ToString();

            try
            {
                String content = String.Empty;

                // Read data from the client socket.

                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {

                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    clientInfo = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);

                    Console.WriteLine("Total bytes from socket: {0}. \n", clientInfo);// Data:\n{1}", content.Length, clientInfo);



                    GetStreamClientInfo(cPort);

                    //BlackListChecker();

                    /*if (isBlacklisted == true)
                    { }
                    else
                    {*/


                    LoadActiveClients();

                    this.Invoke(new MethodInvoker(() =>
                    {
                        clientRecon = true;
                        //seconds[activeClients.SelectedIndex] = 0;
                        t = new System.Windows.Forms.Timer();
                        t.Interval = 1000;
                        //t.Tag = (int)listOfTimers.Count + 1; //1st timer will have tag 1, 2nd 2,...
                        t.Tag = activeClients.Items.Count; //1st timer will have tag 1, 2nd 2,...
                        t.Tick += new EventHandler(Timers_Tick);

                        listOfTimers.Add(t);
                        //start timer:

                        seconds[activeClients.Items.Count] = 0;
                        timespans[activeClients.Items.Count] = TimeSpan.FromSeconds(seconds[activeClientId]);
                        upTimes[activeClients.Items.Count] = String.Empty; //00:00:00

                        listOfTimers[activeClients.Items.Count - 1].Start();


                    }));
                    Console.WriteLine(activeSockets.Count.ToString());

                    //}
                }
                else
                {
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadClientInfo), state);

                }
            }
            catch
            {
                //RemoveActiveClient(cIp, cPort);

            }

        }
        public int ID = 0;
        //DateTime _startT;
        //DateTime _expT;
        //TimeSpan daysLeft;
        //static string _daysLeft;

        string userSerialN;
        string userRegK;
        string userVerK;
        string licenseStatus;

        string machineName;
        string userName;
        string ipAddress2;
        string macAddress;
        private void GetStreamClientInfo(string socketId)
        {
            string[] lines = clientInfo.Split( //po každém enteru vytvoří novou string proměnou
                                new string[] { "\r\n", "\r", "\n" },
                                StringSplitOptions.None
                    );
            string machI = lines[1];
            string[] machineInfo = machI.Split( //Rozdělí nazev počítače a uživatele ze stringu
                        new string[] { "\u005c" },
                        StringSplitOptions.None
            );

            machineName = machineInfo[0];
            userName = machineInfo[1];
            ipAddress2 = lines[0];
            macAddress = lines[2];

            //licenseStatus = lines[3]; //Activated/Deactivated

            //KONTROLA UŽIVATEL MÁ AKTIVOVANOU LICENCI
            userSerialN = lines[4];
            userRegK = lines[5];
            userVerK = lines[6];
            ////


            var list = Enumerable
            .Range(0, macAddress.Length / 2)
            .Select(i => macAddress.Substring(i * 2, 2));
            macAddress = string.Join(":", list);
            //ID = activeClients.Items.Count + 1;
            ID++;


            sqlClients1.Open();
            string query1 = "INSERT INTO " + Constants.tableL_OnlineClients + " (id, machineName, userName, ipAddress, macAddress, socketId, uSN, UPK, UVK)" +
            " VALUES (@id, @machineName, @userName, @ipAddress, @macAddress, @socketId, @uSN, @UPK, @UVK)";// @daysLeft)";

            SqlCommand cmd1 = new SqlCommand(query1, sqlClients1);
            //cmd1.Parameters.AddWithValue("@id", rdpName.Text);


            cmd1.Parameters.AddWithValue("@id", activeClients.Items.Count);

            cmd1.Parameters.AddWithValue("@machineName", machineName);
            cmd1.Parameters.AddWithValue("@userName", userName);
            cmd1.Parameters.AddWithValue("@ipAddress", ipAddress2);
            cmd1.Parameters.AddWithValue("@macAddress", macAddress);
            //cmd1.Parameters.AddWithValue("@upTime", DateTime.Now);//upTimes[activeClients.Items.Count].ToString());
            //cmd1.Parameters.AddWithValue("@licenseStatus", licenseStatus);
            cmd1.Parameters.AddWithValue("@socketId", socketId);
            cmd1.Parameters.AddWithValue("@uSN", userSerialN);
            cmd1.Parameters.AddWithValue("@UPK", userRegK);
            cmd1.Parameters.AddWithValue("@UVK", userVerK);
            //cmd1.Parameters.AddWithValue("@daysLeft", _daysLeft);
            //cmd1.Parameters.AddWithValue("@daysLeft", DateTime.Parse(ucLa.dateExp.Value.ToShortDateString()));
            cmd1.ExecuteNonQuery();

            sqlClients1.Close();

            //LoadActiveClients();

            if (activeClients.Items.Count == 1)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    activeClients.SelectedIndex = 0;

                }));


                txtId.Invoke(new MethodInvoker(() =>
                {
                    txtId.Text = (activeClients.Items.Count).ToString();//(activeClients.SelectedIndex + 1).ToString();

                }));

                txtUserName.Invoke(new MethodInvoker(() =>
                {
                    txtUserName.Text = userName;

                }));
                txtUserIp.Invoke(new MethodInvoker(() =>
                {
                    txtUserIp.Text = lines[0].ToString();

                }));
                txtMachineName.Invoke(new MethodInvoker(() =>
                {
                    txtMachineName.Text = machineName;

                }));
                txtMAC.Invoke(new MethodInvoker(() =>
                {
                    txtMAC.Text = macAddress;

                }));
                txtLStatus.Invoke(new MethodInvoker(() =>
                {

                    //txtLStatus.Text = licenseStatus; //////////////FROM HERE: TO VerifyLicenseTask
                    //if (licenseStatus == "Activated")
                    //    txtDaysLeft.Text = _daysLeft;

                }));



            }
        }



        //SEND COMMAND FROM SERVER TO THE CLIENT
        byte[] bytesToSend;
        public void SendCommand(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            bytesToSend = Encoding.UTF8.GetBytes(data);

            // Begin sending the data toi the remote device.  
            client.BeginSend(bytesToSend, 0, bytesToSend.Length, 0,
                new AsyncCallback(SendCallback), client);


        }
        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);

                // Signal that all bytes have been sent.  
                //sendMessageDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine("error");
                Console.WriteLine(e.ToString());
            }
        }
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendMessageDone =
            new ManualResetEvent(false);
        private static ManualResetEvent verifyDone =
            new ManualResetEvent(false);
        private static ManualResetEvent clientInfoDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);



        //READ MESSAGE SENT FROM CLIENT TO THE SERVER


        string lActivatedT;

        string cIp;
        string cPort;
        string clientMessageFormat;
        Socket handler;

        string cSerialN;
        string cRegK;
        string cVerK;
        string cMac;


        int activeClientId;
        public void ReadMessageCallback(IAsyncResult ar)
        {
            MainForm forme = new MainForm(null);


            StateObject state = (StateObject)ar.AsyncState;
            handler = state.workSocket;

            if (IsListening == false || clientRecon == false) return; // || handler != null)

            cIp = ((IPEndPoint)(handler.RemoteEndPoint)).Address.ToString();
            cPort = ((IPEndPoint)(handler.RemoteEndPoint)).Port.ToString();

            try
            {

                String content = String.Empty;



                // Read data from the client socket.
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {

                    // There  might be more data, so store the data received so far.  
                    state.sb.Append(Encoding.UTF8.GetString(state.buffer, 0, bytesRead));
                    clientMessage = Encoding.UTF8.GetString(state.buffer, 0, bytesRead);


                    // Check for end-of-file tag. If it is not there, read
                    // more data.  
                    content = state.sb.ToString();


                    // All the data has been read from the
                    // client. Display it on the console.  
                    Console.WriteLine("Total bytes from client: {0}. \n", content.Length);//Data:\n{1}", content.Length, clientMessage);
                    Console.WriteLine("Total bytes from client: {0}. \n", clientMessage.Length);



                    if (clientMessage.Contains("<MESSAGE>"))
                    {
                        clientMessageFormat = clientMessage.Remove(clientMessage.Length - 9, 9); //REMOVES TAG <TAG>
                        txtConsole.Invoke(new MethodInvoker(() =>
                        {

                            txtConsole.AppendText(DateTime.Now + ":  " + cIp + ": " + clientMessageFormat.ToString() + Environment.NewLine);

                        }));

                    }
                    else if (clientMessage.Contains("<verifyLicense-10s>"))
                    {
                        clientMessageFormat = clientMessage.Remove(clientMessage.Length - 19, 19); //REMOVES TAG <TAG>
                        string[] lines2 = clientMessageFormat.Split( //po každém enteru vytvoří novou string proměnou
                                new string[] { "\r\n", "\r", "\n" },
                                StringSplitOptions.None
                        );
                        try
                        {
                            this.Invoke(new MethodInvoker(() =>
                            {
                                /*
                                int clientIndex = 0;
                                
                                userSerialN[clientIndex] = lines[0]; 
                                userRegK[clientIndex] = lines[1];
                                userVerK[clientIndex] = lines[2];
                                clientIndex++; 
                                 */
                                cSerialN = lines2[0]; //userSerial[], userRegK[], userVerK[]!!!!!!!!!!!!!!!!!!!!!!!!
                                cRegK = lines2[1];
                                cVerK = lines2[2];
                                cMac = lines2[3];

                                var list2 = Enumerable
                                .Range(0, cMac.Length / 2)
                                .Select(i => cMac.Substring(i * 2, 2));
                                cMac = string.Join(":", list2);

                                Console.WriteLine(lSerialN + lRegK + lVerK + mac);
                                Console.WriteLine(cSerialN + cRegK + cVerK + cMac);

                                sqlClients5.Open();
                                String query0 = "UPDATE " + Constants.tableL_OnlineClients + " SET uSN=@uSN, uPK = @uPK, uVK = @uVK WHERE macAddress=@macAddress";
                                SqlCommand cmd2 = new SqlCommand(query0, sqlClients5);

                                //cmd2.Parameters.AddWithValue("@licenseStatus", "Activated");
                                cmd2.Parameters.AddWithValue("@uSN", cSerialN);
                                cmd2.Parameters.AddWithValue("@uPK", cRegK);
                                cmd2.Parameters.AddWithValue("@uVK", cVerK);
                                cmd2.Parameters.AddWithValue("@macAddress", cMac);

                                cmd2.ExecuteNonQuery();
                                sqlClients5.Close();


                                //licenseResult = String.Empty;


                                VerifyLicense(handler);//********************************************************************************************




                            }));
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message);
                        }

                    }
                    else if (clientMessage.Contains("<LICENSE2>"))
                    {
                        clientMessageFormat = clientMessage.Remove(clientMessage.Length - 9, 9);
                        string[] lines3 = clientMessageFormat.Split( //po každém enteru vytvoří novou string proměnou
                                new string[] { "\r\n", "\r", "\n" },
                                StringSplitOptions.None
                        );

                        string cOnceSerialN = lines3[0]; //userSerial[], userRegK[], userVerK[]!!!!!!!!!!!!!!!!!!!!!!!!
                        string cOnceRegK = lines3[1];
                        string cOnceVerK = lines3[2];
                        lActivatedT = DateTime.Today.ToShortDateString();

                        sqlClients6.Open();
                        String query6 = "UPDATE " + Constants.tableActiveLicenses + " SET activatedT=@activatedT WHERE sN=@sN";
                        SqlCommand cmd6 = new SqlCommand(query6, sqlClients6);

                        cmd6.Parameters.AddWithValue("@activatedT", lActivatedT);
                        cmd6.Parameters.AddWithValue("@sN", lSerialN);

                        cmd6.ExecuteNonQuery();
                        sqlClients6.Close();

                        //ucLv.txtActDate.Text = lActivatedT;

                        /*userSerialN = lines[0];
                        userRegK = lines[1];
                        userVerK = lines[2];
                        lActivatedT = DateTime.Today.ToShortDateString();

                        this.Invoke(new MethodInvoker(() =>
                        {
                            //VerifyLicenseTask();

                            //UPDATE ACTIVATION TIME (ONLY ONCE)
                            sqlClients1.Open();
                            String query = "UPDATE " + Constants.tableActiveLicenses + " SET activatedT=@activatedT WHERE sN=@sN";
                            SqlCommand cmd = new SqlCommand(query, sqlClients1);

                            cmd.Parameters.AddWithValue("@activatedT", lActivatedT);
                            cmd.Parameters.AddWithValue("@sN", lSerialN);

                            cmd.ExecuteNonQuery();
                            sqlClients1.Close();

                            sqlClients0.Open();
                            String query2 = "UPDATE " + Constants.tableL_OnlineClients + " SET uSN=@uSN, uPK = @uPK, uVK = @uVK WHERE macAddress=@macAddress";
                            SqlCommand cmd2 = new SqlCommand(query2, sqlClients0);

                            //cmd2.Parameters.AddWithValue("@licenseStatus", "Activated");
                            cmd2.Parameters.AddWithValue("@uSN", userSerialN);
                            cmd2.Parameters.AddWithValue("@uPK", userRegK);
                            cmd2.Parameters.AddWithValue("@uVK", userVerK);
                            cmd2.Parameters.AddWithValue("@macAddress", onlineMac);

                            cmd2.ExecuteNonQuery();
                            sqlClients0.Close();*/

                        /*
                        sqlClients1.Open();
                        String query3 = "SELECT licenseStatus, daysLeft FROM " + Constants.tableL_OnlineClients + "";

                        SqlCommand cmd3 = new SqlCommand(query3, sqlClients1);
                        SqlDataReader dr3 = cmd3.ExecuteReader();

                        while (dr3.Read())
                        {
                            txtLStatus.Text = dr3["licenseStatus"].ToString();
                            txtDaysLeft.Text = dr3["daysLeft"].ToString();

                        }
                        sqlClients1.Close();


                    }));*/




                    }
                    // Not all data received. Get more.  



                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, //PRO VÍCE ZPRÁV S <MESSAGE>
                        new AsyncCallback(ReadMessageCallback), state);
                }
                else
                {
                    //DISCONNECT CLIENT BUTTON
                    sqlClients3.Open();
                    String query3 = "SELECT id FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";

                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);
                    cmd3.Parameters.AddWithValue("@socketId", cPort);

                    SqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        activeClientId = Int32.Parse(dr3["id"].ToString());


                        this.Invoke(new MethodInvoker(() =>
                        {
                            if (listOfTimers[activeClientId - 1].Tag.ToString() == activeClientId.ToString())
                            {


                                if (activeClients.Items.Count > activeClientId)
                                {
                                    for (int i = activeClientId; i < activeClients.Items.Count; i++)
                                    {
                                        //MessageBox.Show(i.ToString());

                                        seconds[i] = seconds[i + 1];
                                        upTimes[i] = upTimes[i + 1];
                                        //Array.Copy(seconds, i, seconds, i, seconds.Length - 1); // length - 1 změnit na FOR i
                                        //Array.Copy(upTimes, i, upTimes, i, upTimes.Length - 1);


                                        //AŽ BUDE CYKLOS V POSLEDNI FAZI SPUSTIT 3 ŘADKY DOLE (PODMÍNKOU)

                                        if (i == activeClients.Items.Count - 1)
                                        {
                                            //MessageBox.Show("testíík" + i.ToString());

                                            seconds[i + 1] = 0;
                                            timespans[i + 1] = TimeSpan.FromSeconds(seconds[activeClientId]);
                                            upTimes[i + 1] = String.Empty; //00:00:00
                                            //////

                                            listOfTimers[i].Stop(); //{0, 1, 2} // i - 1
                                            listOfTimers.RemoveAt(i);
                                        }

                                    }

                                }
                                else
                                {
                                    seconds[activeClientId] = 0;
                                    timespans[activeClientId] = TimeSpan.FromSeconds(seconds[activeClientId]);
                                    upTimes[activeClientId] = String.Empty; //00:00:00

                                    listOfTimers[activeClientId - 1].Stop();
                                    listOfTimers.RemoveAt(activeClientId - 1);
                                }

                                Console.WriteLine("Timers count: " + listOfTimers.Count);
                            }
                        }));


                    }
                    sqlClients3.Close();



                    sqlClients4.Open();
                    String query4 = "DELETE FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";
                    SqlCommand cmd4 = new SqlCommand(query4, sqlClients4);
                    cmd4.Parameters.AddWithValue("@socketId", cPort);
                    cmd4.ExecuteNonQuery();
                    sqlClients4.Close();



                    RemoveActiveClient(cIp, cPort);
                    activeClientsList.Remove(cIp + " (" + cPort + ")");
                    activeSockets.Remove(handler);



                    Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
                    Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());
                    LoadActiveClients();

                }
            }
            catch (Exception ex)
            {
                //CLOSE CLIENT APPLICATION

                sqlClients3.Open();
                String query3 = "SELECT id FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";

                SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);
                cmd3.Parameters.AddWithValue("@socketId", cPort);

                SqlDataReader dr3 = cmd3.ExecuteReader();

                while (dr3.Read())
                {
                    activeClientId = Int32.Parse(dr3["id"].ToString());

                    this.Invoke(new MethodInvoker(() =>
                    {

                        if (listOfTimers[activeClientId - 1].Tag.ToString() == activeClientId.ToString())
                        {


                            if (activeClients.Items.Count > activeClientId)
                            {
                                for (int i = activeClientId; i < activeClients.Items.Count; i++)
                                {
                                    //MessageBox.Show(i.ToString());

                                    seconds[i] = seconds[i + 1];
                                    upTimes[i] = upTimes[i + 1];


                                    if (i == activeClients.Items.Count - 1)
                                    {
                                        //MessageBox.Show("testíík" + i.ToString());

                                        seconds[i + 1] = 0;
                                        timespans[i + 1] = TimeSpan.FromSeconds(seconds[activeClientId]);
                                        upTimes[i + 1] = String.Empty; //00:00:00
                                                                       //////

                                        listOfTimers[i].Stop(); //{0, 1, 2} // i - 1
                                        listOfTimers.RemoveAt(i);
                                    }

                                }

                            }
                            else
                            {
                                seconds[activeClientId] = 0;
                                timespans[activeClientId] = TimeSpan.FromSeconds(seconds[activeClientId]);
                                upTimes[activeClientId] = String.Empty; //00:00:00

                                listOfTimers[activeClientId - 1].Stop();
                                listOfTimers.RemoveAt(activeClientId - 1);
                            }

                            Console.WriteLine("Timers count: " + listOfTimers.Count);
                        }
                    }));


                }
                sqlClients3.Close();



                sqlClients4.Open();
                String query4 = "DELETE FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";
                SqlCommand cmd4 = new SqlCommand(query4, sqlClients4);
                cmd4.Parameters.AddWithValue("@socketId", cPort);
                cmd4.ExecuteNonQuery();
                sqlClients4.Close();



                RemoveActiveClient(cIp, cPort);



                activeClientsList.Remove(cIp + " (" + cPort + ")");
                activeSockets.Remove(handler);



                Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
                Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());
                LoadActiveClients();

                //Console.WriteLine(ex.Message);
            }

        }
        public void RemoveActiveClient(String ip, String port)
        {
            txtConsole.Invoke(new MethodInvoker(() =>
            {

                txtConsole.AppendText(DateTime.Now + ":  Client " + ip + " has disconnected." + "(" + txtUpTime.Text + ")" + Environment.NewLine);


            }));


            this.Invoke(new MethodInvoker(() =>
            {

                activeClients.Items.Remove(ip + " (" + port + ")");
            }));
            Console.WriteLine("Server: Client " + ip + " has disconnected." + "(" + txtUpTime.Text + ")");



        }



        private void LoadActiveClients()
        {
            sqlClients1.Open();

            String query = "SELECT * FROM " + Constants.tableL_OnlineClients + "";


            SqlCommand cmd2 = new SqlCommand(query, sqlClients1);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            int index = 0;



            foreach (Socket soc in activeSockets)
            {
                index++;
                string socIp = ((IPEndPoint)(soc.RemoteEndPoint)).Address.ToString();
                string socPort = ((IPEndPoint)(soc.RemoteEndPoint)).Port.ToString();

                sqlClients2.Open();
                String query4 = "UPDATE " + Constants.tableL_OnlineClients + " SET id=@id WHERE socketId=@socketId";
                SqlCommand cmd4 = new SqlCommand(query4, sqlClients2);

                cmd4.Parameters.AddWithValue("@id", index);
                cmd4.Parameters.AddWithValue("@socketId", socPort);

                cmd4.ExecuteNonQuery();
                sqlClients2.Close();
                // }
            }
            sqlClients1.Close();

        }

        public string selectedID;
        public string selectedIDMachine;
        public string selectedIDUserName;
        public string selectedIDIP;
        public string selectedIDMAC;
        public string selectedIDLStatus;
        public string selectedIDUptime;
        public string selectedIDDaysLeft;
        public string selectedIDExpiration;
        public string selectedIDSocket;
        public string selectedIDActivationT;

        private void activeClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeClients.Items.Count > 0 && ucLv.btnDeactivateLicense.Text == "Deactivate")
            {
                ucLv.btnLinkLicense.Enabled = true;
            }
            else if (activeClients.Items.Count == 0 && ucLv.btnLinkLicense.Text == "Link")
            {
                ucLv.btnLinkLicense.Enabled = false;
            }
            clientIndex = activeClients.SelectedIndex + 1;
            showLicenseInfo = false;
            ttLicenseInfo.Active = false;
            pbShowLInfo.BackgroundImage = eyeLInfo_Gray_hidden;

            try
            {


                if (activeClients.SelectedItem == null || clientList == null) // 
                {
                    txtId.Text = String.Empty;
                    txtMachineName.Text = String.Empty;
                    txtUserName.Text = String.Empty;
                    txtUserIp.Text = String.Empty;
                    txtMAC.Text = String.Empty;
                    txtLStatus.Text = String.Empty;
                    txtDaysLeft.Text = String.Empty;
                    selectedIDExpiration = String.Empty;
                    selectedIDActivationT = String.Empty;
                    txtUpTime.Text = "00:00:00";


                    return;
                }
                else
                {


                    sqlClients1.Open();
                    String query = "SELECT * FROM " + Constants.tableL_OnlineClients + " WHERE id = '" + clientIndex + "'";

                    SqlCommand cmd2 = new SqlCommand(query, sqlClients1);
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    while (dr2.Read())
                    {

                        selectedID = dr2["id"].ToString();
                        selectedIDMachine = dr2["machineName"].ToString();
                        selectedIDUserName = dr2["userName"].ToString();
                        selectedIDIP = dr2["ipAddress"].ToString();
                        selectedIDMAC = dr2["macAddress"].ToString();
                        selectedIDUptime = dr2["upTime"].ToString();
                        selectedIDSocket = dr2["socketId"].ToString();
                        selectedIDDaysLeft = dr2["daysLeft"].ToString();
                        selectedIDLStatus = dr2["licenseStatus"].ToString();



                    }
                    sqlClients1.Close();

                    sqlClients1.Open();
                    String query3 = "SELECT sN, startT, expT, activatedT FROM " + Constants.tableActiveLicenses + " WHERE mac = '" + selectedIDMAC + "'";

                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients1);
                    SqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {

                        lSerialN = dr3["sN"].ToString();
                        lActivatedT = dr3["activatedT"].ToString();
                        selectedIDActivationT = dr3["activatedT"].ToString();
                        startT = DateTime.Parse(dr3["startT"].ToString());
                        expT = DateTime.Parse(dr3["expT"].ToString());
                        Console.WriteLine(lSerialN);

                        daysLeft = expT.Subtract(serverTime);

                        _daysLeft = daysLeft.ToString(@"dd");
                        _daysLeft = _daysLeft.TrimStart('0');
                        _daysLeft = (Int32.Parse(_daysLeft)).ToString();
                    }
                    sqlClients1.Close();

                    txtId.Text = selectedID;//clientIndex.ToString();
                    txtMachineName.Text = selectedIDMachine;
                    txtUserName.Text = selectedIDUserName;
                    txtUserIp.Text = selectedIDIP;
                    txtMAC.Text = selectedIDMAC;

                    ucLa.txtClientIp.Text = selectedIDIP;
                    txtLStatus.Text = selectedIDLStatus;
                    UC_LicenseView1.selectedSn = lSerialN;


                    if (selectedIDLStatus == "Activated")
                    {
                        txtDaysLeft.Text = _daysLeft;
                    }
                    else
                    {
                        selectedIDLStatus = "Deactivated";
                        txtDaysLeft.Text = String.Empty;
                    }



                    txtUpTime.Text = upTimes[activeClients.SelectedIndex + 1];

                }

            }
            catch
            {

            }

        }

        Thread thread;

        private void CommandToClient(Socket client, String data)
        {
            if (client != null)
            {
                try
                {
                    // Convert the string data to byte data using ASCII encoding.  

                    byte[] bytesToSend = Encoding.UTF8.GetBytes(data);

                    // Begin sending the data to the remote device.  


                    client.Send(bytesToSend);
                    //int bytesSent = client.EndSend(ar);
                    Console.WriteLine("Sent {0} bytes to client. (shutdown)", bytesToSend.Length);


                    // Begin sending the data toi the remote device.  
                    //client.BeginSend(byteData, 0, byteData.Length, 0,
                    //    new AsyncCallback(VerifyCallback), client);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Connection to the client timed out.");
                }
            }

        }


        private int clientIndex;





        private void txtLStatus_TextChanged(object sender, EventArgs e)
        {
            if (this.txtLStatus.Text == "Activated")
            {
                pbShowLInfo.Visible = true;
            }
            else
            {
                pbShowLInfo.Visible = false;
            }
        }
        //PRO KAŽDÝ OBRÁZEK VYTVOŘIT SPECIÁLNÍ PROMĚNOU K MENŠÍMU VYUŽITÍ RAM
        Image eyeLInfo_Gray = Properties.Resources.eyeLicenseInfo_Show2_2_gray3;
        Image eyeLInfo_Gray_hidden = Properties.Resources.eyeLicenseInfo_Show2_2_gray3_hidden;
        Image eyeLInfo_DarkGray = Properties.Resources.eyeLicenseInfo_Show2_2_darkgray1;
        Image eyeLInfo_DarkGray_hidden = Properties.Resources.eyeLicenseInfo_Show2_2_darkgray1_hidden;
        private void pbShowLInfo_MouseEnter(object sender, EventArgs e)
        {
            //Image myimage = new Bitmap(@"D:\Images\myImage1.jpg");
            //pbShowLInfo.BackgroundImage = Properties.Resources.eyeLicenseInfo_Show2_2_darkgray1;
            //if(pbShowLInfo.BackgroundImage == eyeLInfo_Gray_hidden)

            if (showLicenseInfo == false)
                pbShowLInfo.BackgroundImage = eyeLInfo_DarkGray_hidden;
            else if (showLicenseInfo == true)
                pbShowLInfo.BackgroundImage = eyeLInfo_DarkGray;
        }

        private void pbShowLInfo_MouseLeave(object sender, EventArgs e)
        {
            //pbShowLInfo.BackgroundImage = Properties.Resources.eyeLicenseInfo_Show2_2_gray3;

            if (showLicenseInfo == false)
                pbShowLInfo.BackgroundImage = eyeLInfo_Gray_hidden;
            else if (showLicenseInfo == true)
                pbShowLInfo.BackgroundImage = eyeLInfo_DarkGray;
        }
        private bool showLicenseInfo = false;


        private void pbShowLInfo_MouseDown(object sender, MouseEventArgs e)
        {
            if (pbShowLInfo.BackgroundImage == eyeLInfo_DarkGray_hidden)
            {
                showLicenseInfo = true;
                pbShowLInfo.BackgroundImage = eyeLInfo_DarkGray;

                ttLicenseInfo.AutoPopDelay = 30000;
                ttLicenseInfo.InitialDelay = 100;
                ttLicenseInfo.ReshowDelay = 100;

                ttLicenseInfo.SetToolTip(pbShowLInfo, "Serial number: " + lSerialN + "\nActivation date: " + lActivatedT + "\nExpiration date: " + expT.ToShortDateString());

                ttLicenseInfo.Active = true;

            }
            else if (pbShowLInfo.BackgroundImage == eyeLInfo_DarkGray)
            {
                pbShowLInfo.BackgroundImage = eyeLInfo_DarkGray_hidden;
                showLicenseInfo = false;
                ttLicenseInfo.Active = false;
            }
        }

        private void btnDisconnectClient_Click(object sender, EventArgs e)
        {
            if (activeClients.SelectedIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to disconnect this client?", "Disconnect", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    SendCommand(activeSockets[activeClients.SelectedIndex], "</ras -disconnect -c>"); //Pouze vybraný klient
                                                                                                      //sendMessageDone.WaitOne();

                    sqlClients3.Open();
                    //String query = "SELECT COUNT(*) FROM " + Constants.tableL_OnlineClients + "";
                    String query3 = "SELECT id FROM " + Constants.tableL_OnlineClients + " WHERE socketId = @socketId";

                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);
                    cmd3.Parameters.AddWithValue("@socketId", selectedIDSocket);

                    SqlDataReader dr3 = cmd3.ExecuteReader();

                    while (dr3.Read())
                    {
                        activeClientId = Int32.Parse(dr3["id"].ToString());
                    }

                    //Array.Clear(seconds, activeClientId, activeClientId);
                    //seconds[activeClientId] = 0;
                    //upTimes[activeClientId] = "00:00:00";
                    if ((int)t.Tag == activeClientId)
                    {
                        listOfTimers[activeClientId - 1].Stop();
                        Console.WriteLine("Id je: " + activeClientId);

                    }
                    sqlClients3.Close();



                    sqlClients4.Open();
                    String query4 = "DELETE FROM " + Constants.tableL_OnlineClients + " WHERE id = @id";
                    SqlCommand cmd4 = new SqlCommand(query4, sqlClients4);
                    cmd4.Parameters.AddWithValue("@id", selectedID);
                    cmd4.ExecuteNonQuery();
                    sqlClients4.Close();



                    Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
                    Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());

                    clientRecon = false;
                    //activeSockets.RemoveAt(activeClients.SelectedIndex);
                    activeSockets[activeClients.SelectedIndex].Close();
                    activeSockets.RemoveAt(activeClients.SelectedIndex);
                    //foreach(Socket soc in active)

                    activeClientsList.RemoveAt(activeClients.SelectedIndex);

                    activeClients.Invoke(new MethodInvoker(() =>
                    {
                        activeClients.Items.Remove(activeClients.SelectedItem);

                        if (activeClients.Items.Count == 0)
                        {
                            btnDisconnectClient.Enabled = false;
                            btnBlockClient.Enabled = false;

                        }
                    }));



                    txtConsole.Invoke(new MethodInvoker(() =>
                    {
                        txtConsole.AppendText(DateTime.Now + ":  Client " + selectedIDIP + " has been kicked by the server." + Environment.NewLine);

                    }));



                    Console.WriteLine("Active sockets: " + activeSockets.Count.ToString());
                    Console.WriteLine("Active elements in activeClients: " + activeClientsList.Count.ToString());
                    LoadActiveClients();
                    //activeClientsList.Clear();

                    //soc.Shutdown(SocketShutdown.Both);
                    //soc.Close();
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }
            else { }
        }
        private void btnLinkLicense_Click(object sender, EventArgs e)
        {
            //EVERY CLICK BOOL CHANGES

            if (UC_LicenseView1.isLinked == false)
            {

                lActivatedT = DateTime.Today.ToShortDateString();
                DialogResult dialogResult = MessageBox.Show("Do you want to link this client?", "Activate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {

                    //LINK CLIENT
                    //btnLinkLicense.Text = "Unlink";
                    sqlClients2.Open();
                    String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET mac=@mac, activatedT=@activatedT WHERE sN=@sN";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
                    cmd3.Parameters.AddWithValue("@mac", selectedIDMAC);
                    cmd3.Parameters.AddWithValue("@activatedT", lActivatedT);
                    cmd3.Parameters.AddWithValue("@sN", lSerialN);

                    cmd3.ExecuteNonQuery();
                    sqlClients2.Close();
                }


            }
            else if (UC_LicenseView1.isLinked == true)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to unlink this client?", "Deactivate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //UNLINK CLIENT
                    //btnLinkLicense.Text = "Link";
                    sqlClients2.Open();
                    String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET mac=@mac, activatedT=@activatedT WHERE sN = '" + lSerialN + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
                    cmd3.Parameters.AddWithValue("@mac", String.Empty);
                    cmd3.Parameters.AddWithValue("@activatedT", String.Empty);//rdpName.Text);

                    cmd3.ExecuteNonQuery();
                    sqlClients2.Close();

                }
                else
                {

                }

            }

            ucLv.RefreshLicenseData();
        }

        


        private void btnBlockClient_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure to block this client?", "Block", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {

                SendCommand(activeSockets[activeClients.SelectedIndex], "</ras -disconnect -c>"); //Pouze vybraný klient
                                                                                                  //sendMessageDone.WaitOne();
                                                                                                  //Blacklist blacklist = new Blacklist(this, null);
                blacklist.BlockClient(selectedIDUserName, selectedIDIP, selectedIDMAC);
                blacklist.RefreshBanlist();

            }

        }

        private void btnBlacklist1_Click(object sender, EventArgs e)
        {
            blacklist = new Blacklist(this, null);
            blacklist.Show();
        }
    }

}

