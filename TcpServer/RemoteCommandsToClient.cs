using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    class RemoteCommandsToClient
    {
        ///<summary
        /// Server commands
        /// </summary>
        public static string rem_clearConsole = "/clear";

        /// <summary>
        /// RAS COMMANDS
        /// </summary>


        //Machine commands
        public static string rem_stopTimedCommand = "/ras -timer"; //Stop timed operation


        public static string rem_shutdownMachine = "/ras -shutdown -m"; //Shutdown machine with timer (milliseconds)
        public static string rem_restartMachine = "/ras -restart -m"; //Restart machine with timer (seconds)
        public static string rem_poweroffMachine = "/ras -poweroff -m"; //Turn power off
        public static string rem_hibernateMachine = "/ras -hibernate -m"; //Set machine to hibernate
        public static string rem_sleepMachine = "/ras -sleep -m"; //Set machine to hibernate
        public static string rem_logoffMachine = "/ras -logoff -m"; //Logoff user
        public static string rem_lockMachine = "/ras -lock -m"; //Lock up machine

        /// AC / DC Settings
        public static string rem_monitorTimeoutAC = "/ras -set monitor -ac -d"; //vypnutí monitoru (baterie)
        public static string rem_monitorTimeoutDC = "/ras -set monitor -dc -d"; //vypnutí monitoru (síť)
        public static string rem_sleepTimeoutAC = "/ras -set sleep -ac -d"; //režim spánku (baterie)
        public static string rem_sleepTimeoutDC = "/ras -set sleep -dc -d"; //režim spánku (síť)
        public static string rem_hibernateTimeoutAC = "/ras -set hibernate -ac -d"; //režim hibernace (baterie)
        public static string rem_hibernateTimeoutDC = "/ras -set hibernate -dc -d"; //režim hibernace (síť)

        
        


        public static string rem_msg = "/ras -msg "; //Send message to client
        
        public static string rem_setPowerSupply = "/ras -set power supply"; //Set power suppy sleep to x (minutes)
        public static string rem_setAutoLock = "/ras -set autolock"; //Set autolock to x (minutes)

        //public static string rem_showTasks = "/ras -show tasks"; //Show tasks
        //public static string rem_setTask = "/ras -set task"; //Create task with name
        //public static string rem_deleteTask = "/ras -set task"; //Delete task from scheduler

        //Client commands
        public static string rem_shutdownClient = "/ras -shutdown -c"; //Shutdown client process;
        public static string rem_disconnectClient = "/ras -disconnect -c"; //Disconnect client;
        public static string rem_blockClient = "/ras -ban "; //Block client;
        public static string rem_unblockClient = "/ras -unban "; //Unblock client;


        //public static string rem_blockClient = "/ras -disconnect -c"; //Block client;
        public static string rem_restartClient = "/ras -restart -c"; //Restart client process;
        /// <summary>
        /// CMD SHELL COMMANDS
        /// </summary>

        public static string cmd_promtCommands = "/cmd";




    }
}
