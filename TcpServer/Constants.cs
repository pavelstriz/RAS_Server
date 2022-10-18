using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpServer
{
    class Constants
    {
        public static string tableActiveLicenses = "tbl_ActiveLicenses5";//"tbl_ActiveLicenses";//"tbl_Clients";
        public static string tablepK = "tbl_pK";
        public static string tableL_AR = "tbl_Licences_AR";
        public static string tableL_OnlineClients = "tbl_OnlineClients3";
        public static string tableL_BlockClients = "tbl_BlockedClients1";
        public static int maximumClients = 30; //Maximum connected clients
        public static int licenseCheckAfter = 3; //10

        public static int timeBetweenCMDConsoleOutput = 500;
    }
}
