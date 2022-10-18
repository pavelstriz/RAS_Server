using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;

namespace TcpServer
{
    public partial class UC_RemoteCommand1 : UserControl
    {
        private MainForm _mainForm;
        private int timeBetweenConsoleOutput = 500;

        public SqlConnection sqlBlockedClients = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");

        public UC_RemoteCommand1(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }
        public static void DelayAction(int millisecond, Action action)
        {
            var timer = new System.Windows.Forms.Timer();
            timer.Tick += delegate

            {
                action.Invoke();
                timer.Stop();
            };

            timer.Interval = millisecond;
            timer.Start();
        }
        
        public static string exCommandFromServer;
        
        private void btnExecuteCommand_Click(object sender, EventArgs e)
        {
            txtRemoteCommandConsole.AppendText(">> " + txtCommandToSend.Text + "\n");
            DelayAction(timeBetweenConsoleOutput, new Action(() =>

            {

                try
                {


                    if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_shutdownMachine)) //SHUTDOWN
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(17);
                        //MessageBox.Show(commandToSend);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<ShutdownMachine>");


                        if (!txtCommandToSend.Text.Contains("-t"))
                        {

                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " is shutting down immediately" + ".\n");
                        }
                        else
                        {
                            string extractedTime = string.Empty;
                            for (int i = 0; i < commandToSend.Length; i++)
                            {
                                if (Char.IsDigit(commandToSend[i]))
                                    extractedTime += commandToSend[i];
                            }
                            int milliseconds = Int32.Parse(extractedTime) * 1000;
                            TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                            string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                    " is shutting down in " + formattedTimeSpan + ".\n");
                        }
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_restartMachine)) //RESTART
                    {

                        string commandToSend = txtCommandToSend.Text.Substring(16);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<RestartMachine>");

                        if (!txtCommandToSend.Text.Contains("-t"))
                        {

                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " is restarting immediately" + ".\n");
                        }
                        else
                        {
                            string extractedTime = string.Empty;
                            for (int i = 0; i < commandToSend.Length; i++)
                            {
                                if (Char.IsDigit(commandToSend[i]))
                                    extractedTime += commandToSend[i];
                            }
                            int milliseconds = Int32.Parse(extractedTime) * 1000;
                            TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                            string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                    " is restarting in " + formattedTimeSpan + ".\n");
                        }
                    }

                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_stopTimedCommand)) //STOP TIMED OPERATION
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(11);
                        if (!txtCommandToSend.Text.Contains("-a"))
                        {
                            return;
                        }
                        else
                        {
                            _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<StopTimedOperation>");


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " is stopping timed operation immediately" + ".\n");
                        }

                    }



                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_logoffMachine)) //LOGOFF
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(15);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<LogoffMachine>");

                        if (!txtCommandToSend.Text.Contains("-t"))
                        {


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " is logging off immediately" + ".\n");
                        }
                        else
                        {
                            string extractedTime = string.Empty;
                            for (int i = 0; i < commandToSend.Length; i++)
                            {
                                if (Char.IsDigit(commandToSend[i]))
                                    extractedTime += commandToSend[i];
                            }
                            int milliseconds = Int32.Parse(extractedTime) * 1000;
                            TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                            string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                    " is logging off in " + formattedTimeSpan + ".\n");
                        }
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_lockMachine)) //LOCKMACHINE
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(13);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<LockMachine>");


                        txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " is locking up immediately" + ".\n");


                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_poweroffMachine)) //POWEROFF
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure to poweroff clients machine?\n This option can cause system startup problems in some cases.", "PowerOff", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {

                            string commandToSend = txtCommandToSend.Text.Substring(17);
                            _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<PoweroffMachine>");

                            if (!txtCommandToSend.Text.Contains("-t"))
                            {

                                txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                " is restarting immediately" + ".\n");
                            }
                            else
                            {
                                string extractedTime = string.Empty;
                                for (int i = 0; i < commandToSend.Length; i++)
                                {
                                    if (Char.IsDigit(commandToSend[i]))
                                        extractedTime += commandToSend[i];
                                }
                                int milliseconds = Int32.Parse(extractedTime) * 1000;
                                TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                                string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                                txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                        " is restarting in " + formattedTimeSpan + ".\n");
                            }

                        }
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_hibernateMachine)) //HIBERNATE
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(18);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<HibernateMachine>");

                        if (!txtCommandToSend.Text.Contains("-t"))
                        {


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " set to hibernate immediately" + ".\n");
                        }
                        else
                        {
                            string extractedTime = string.Empty;
                            for (int i = 0; i < commandToSend.Length; i++)
                            {
                                if (Char.IsDigit(commandToSend[i]))
                                    extractedTime += commandToSend[i];
                            }
                            int milliseconds = Int32.Parse(extractedTime) * 1000;
                            TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                            string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                    " is set to hibernate after " + formattedTimeSpan + ".\n");
                        }
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_sleepMachine)) //SLEEP
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(14);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<SleepMachine>");

                        if (!txtCommandToSend.Text.Contains("-t"))
                        {


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                            " set to sleep immediately" + ".\n");
                        }
                        else
                        {
                            string extractedTime = string.Empty;
                            for (int i = 0; i < commandToSend.Length; i++)
                            {
                                if (Char.IsDigit(commandToSend[i]))
                                    extractedTime += commandToSend[i];
                            }
                            int milliseconds = Int32.Parse(extractedTime) * 1000;
                            TimeSpan dateDifference = new TimeSpan(0, 0, 0, 0, milliseconds);
                            string formattedTimeSpan = string.Format("{0:D2}h {1:D2}m {2:D2}s", dateDifference.Hours, dateDifference.Minutes, dateDifference.Seconds);


                            txtRemoteCommandConsole.AppendText("Computer " + _mainForm.selectedIDIP +
                                    " is set to sleep after " + formattedTimeSpan + ".\n");
                        }
                    }
                    else if (txtCommandToSend.Text == RemoteCommandsToClient.rem_shutdownClient) //SHUTDOWN CLIENT
                    {
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], "<" + RemoteCommandsToClient.rem_shutdownClient + ">");

                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                                    " is shutting down immediately." + ".\n");
                    }
                    else if (txtCommandToSend.Text == RemoteCommandsToClient.rem_restartClient) //RESTART CLIENT
                    {
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], "<" + RemoteCommandsToClient.rem_restartClient + ">");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                                    " is restarting immediately." + ".\n");
                    }
                    else if (txtCommandToSend.Text == RemoteCommandsToClient.rem_disconnectClient) //DISCONNECT CLIENT
                    {
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], "<" + RemoteCommandsToClient.rem_disconnectClient + ">");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                                    " is disconnecting immediately." + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_msg)) //SEND MESSAGE
                    {

                        string messageToSend = txtCommandToSend.Text.Substring(10);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], messageToSend + "<MESSAGE>");


                        txtRemoteCommandConsole.AppendText("Sending message to " + _mainForm.selectedIDIP +
                                    ": [" + messageToSend + "]" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.cmd_promtCommands))
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(4);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<ExecutePrompt>");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_clearConsole))
                    {
                        txtRemoteCommandConsole.Clear();
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_blockClient))
                    {
                        string commandToSend = txtCommandToSend.Text;
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], "<" + RemoteCommandsToClient.rem_disconnectClient + ">");
                        //_mainForm.BlockClient();
                        if (commandToSend.Contains("-c"))
                        {
                            
                            txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                                    " added to blacklist" + ".\n");
                        }
                        else
                        {
                            commandToSend = txtCommandToSend.Text.Substring(10);
                            txtRemoteCommandConsole.AppendText("Client " + commandToSend +
                                        " added to blacklist" + ".\n");
                        }
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_unblockClient))
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(12);
                        //_mainForm.UnblockClient(commandToSend);

                        txtRemoteCommandConsole.AppendText("Client " + commandToSend +
                        " removed from blacklist" + ".\n");


                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_monitorTimeoutAC)) //AC Monitor timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(24);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<AC_MonitorTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " AC display timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_monitorTimeoutDC)) //DC Monitor timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(24);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<DC_MonitorTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " DC display timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_sleepTimeoutAC)) //AC Sleep timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(22);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<AC_SleepTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " AC sleep timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_sleepTimeoutDC)) //DC Sleep timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(22);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<DC_SleepTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " DC sleep timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_hibernateTimeoutAC)) // AC Hibernate timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(26);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<AC_HibernateTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " DC hibernate timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                    else if (txtCommandToSend.Text.Contains(RemoteCommandsToClient.rem_hibernateTimeoutDC)) // DC Hibernate timeout
                    {
                        string commandToSend = txtCommandToSend.Text.Substring(26);
                        _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1], commandToSend + "<DC_HibernateTimeout>");
                        txtRemoteCommandConsole.AppendText("Client " + _mainForm.selectedIDIP +
                        " AC hibernate timeout set to: " + commandToSend + " minutes" + ".\n");
                    }
                }
                catch
                {

                }

            }));



        }
        CommandHelp1 commandHelp1;
        bool btnCommandShow = false;
        int clicks = 0;
        private void btnShowCommands_Click(object sender, EventArgs e)
        {
            clicks++;

            

            Point p = new Point();
            p.X = 0;
            p.Y = 25;
            Point location = btnShowCommands.PointToScreen(p);
            
            if (clicks == 1)
            {
                commandHelp1 = new CommandHelp1();
                commandHelp1.StartPosition = FormStartPosition.Manual;
                commandHelp1.Location = location; //btnShowCommands.Location;
                commandHelp1.Show();
            }
            else if (clicks >= 2)
            {
                clicks = 0;
                commandHelp1.Close();
            }
        }
    }
}
