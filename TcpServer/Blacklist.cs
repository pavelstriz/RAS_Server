using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpServer
{
    public partial class Blacklist : Form
    {
        public SqlConnection sqlBlockedClients = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");

        private MainForm mainForm;
        private BlackListAdd blackListAdd;
        public Blacklist(MainForm _mainForm, BlackListAdd _blackListAdd)
        {
            InitializeComponent();

            mainForm = _mainForm;
            blackListAdd = _blackListAdd;

        }
        public SqlConnection sqlBanlist1 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");

        public void BlockClient(string blockName, string blockIp, string blockMAC) //
        {
            try
            {

                SqlCommand checkLicenseId = new SqlCommand("SELECT COUNT(*) FROM " + Constants.tableL_BlockClients + " WHERE ipAddress = '"+blockIp+"'", sqlBlockedClients);
                sqlBlockedClients.Open();
                int UserIdExist = (int)checkLicenseId.ExecuteScalar();
                sqlBlockedClients.Close();

                //MSG IKONA_TRUE
                //UPRAVIT ZÁZNAM
                if (UserIdExist <= 0) //POKUD NEEXISTUJE ZÁZNAM
                {
                    sqlBlockedClients.Open();
                    string query1 = "INSERT INTO " + Constants.tableL_BlockClients + " (userName,ipAddress,macAddress,reason)" +
                    " VALUES (@userName,@ipAddress,@macAddress,@reason)";

                    SqlCommand cmd1 = new SqlCommand(query1, sqlBlockedClients);


                    cmd1.Parameters.AddWithValue("@userName", blockName);//selectedIDUserName);
                    cmd1.Parameters.AddWithValue("@ipAddress", blockIp);//selectedIDIP);
                    cmd1.Parameters.AddWithValue("@macAddress", blockMAC);//selectedIDMAC);
                    cmd1.Parameters.AddWithValue("@reason", "");
                    cmd1.ExecuteNonQuery();

                    sqlBlockedClients.Close();

                }
                else
                {
                    MessageBox.Show("This client is already in blacklist.","Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    /*sqlClients3.Open();
                    String query3 = "UPDATE " + Constants.tableL_BlockClients + " SET userName=@userName, ipAddress=@ipAddress, reason";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients3);

                    cmd3.Parameters.AddWithValue("@licenseStatus", "Activated");
                    //MessageBox.Show(_daysLeft);
                    cmd3.Parameters.AddWithValue("@daysLeft", _daysLeft);
                    cmd3.Parameters.AddWithValue("@macAddress", onlineMac);//rdpName.Text);

                    cmd3.ExecuteNonQuery();
                    sqlClients3.Close();*/

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UnblockClient(string unblockIP)
        {
            sqlBlockedClients.Open();
            String query4 = "DELETE FROM " + Constants.tableL_BlockClients + " WHERE ipAddress = @ipAddress";
            SqlCommand cmd4 = new SqlCommand(query4, sqlBlockedClients);
            cmd4.Parameters.AddWithValue("@ipAddress", unblockIP);
            cmd4.ExecuteNonQuery();
            sqlBlockedClients.Close();

        }
        public void RefreshBanlist()
        {
            sqlBanlist1.Open();
            String query1 = "SELECT id as ' ', userName as 'Nickname', ipAddress as 'Ip Address', macAddress as 'MAC' FROM " + Constants.tableL_BlockClients + "";// " ORDER BY lastTimeConnected DESC";
            //String query2 = "SELECT mac, startT, expT, activatedT, enabled FROM " + Constants.tableL_BlockClients + "";
            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, sqlBanlist1);
            DataTable dt1 = new System.Data.DataTable();
            SDA1.Fill(dt1);

            //SqlCommand cmd1 = new SqlCommand(query2, sqlBanlist1);
            /*SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                
            }*/

            dgvBanlist1.DataSource = dt1;

            sqlBanlist1.Close();

        }


        private void Banlist_Load(object sender, EventArgs e)
        {
            dgvBanlist1.RowTemplate.Height = 20;

            RefreshBanlist();

            dgvBanlist1.Columns[0].Width = 7;
            dgvBanlist1.Columns[1].Width = 20;
            dgvBanlist1.Columns[2].Width = 20;
            dgvBanlist1.Columns[3].Width = 130;

            dgvBanlist1.EnableHeadersVisualStyles = false;
            dgvBanlist1.ColumnHeadersDefaultCellStyle.BackColor = Color.White;

            dgvBanlist1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvBanlist1.ColumnHeadersHeight = 25;
            dgvBanlist1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRemove1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Do you want unban this client?", "Banlist", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                UnblockClient(dgvBanlist1.Rows[dgvBanlist1.CurrentCell.RowIndex].Cells[2].Value.ToString());
                RefreshBanlist();
            }
            
        }
        public bool btnAddIsClicked = false;
        public bool btnEditIsClicked = false;
        private void btnAddToBlacklist_Click(object sender, EventArgs e)
        {
            btnAddIsClicked = true;
            BlackListAdd blacklistAdd = new BlackListAdd(mainForm, this);
            blacklistAdd.ShowDialog();
        }

        private void btnEditBlacklist_Click(object sender, EventArgs e)
        {
            btnEditIsClicked = true;
            BlackListAdd blacklistAdd = new BlackListAdd(mainForm, this);
            blacklistAdd.txtBLName1.Text = dgvBanlist1.Rows[dgvBanlist1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            blacklistAdd.txtBLipAddress1.Text = dgvBanlist1.Rows[dgvBanlist1.CurrentCell.RowIndex].Cells[2].Value.ToString();
            blacklistAdd.txtBLmac1.Text = dgvBanlist1.Rows[dgvBanlist1.CurrentCell.RowIndex].Cells[3].Value.ToString();
            blacklistAdd.ShowDialog();

            
        }
    }
}
