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
    public partial class UC_LicenseAdd1 : UserControl
    {

        private MainForm _mainForm;
        private UC_LicenseView1 ucLv;
        public UC_LicenseAdd1(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        public SqlConnection sqlClients1 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");


        License lcs;
        private string pKey;
        String salt = String.Empty;
        String hashedpassword;
        private int clientID;

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtPublicKey.TextLength > 0)
            {
                lcs = new License();

                salt = lcs.CreateSalt(10);
                hashedpassword = lcs.GenerateSHA256Hash(txtPublicKey.Text, salt);

                pKey = salt;
                txtVerKey.Text = hashedpassword;
            }
            else
            {
                txtVerKey.Text = String.Empty;
            }
        }
        public int UserIdExist;
        private async void ActivateClient(string table1, string table2)
        {
            UserIdExist = 0;
            try
            {
                SqlCommand check_User_Id = new SqlCommand("SELECT COUNT(*) FROM " + Constants.tableActiveLicenses + " WHERE (mac = @mac)", sqlClients1);
                sqlClients1.Open();
                check_User_Id.Parameters.AddWithValue("@mac", _mainForm.selectedIDMAC); /////////CHYBA
                UserIdExist = (int)check_User_Id.ExecuteScalar();
                sqlClients1.Close();

                //MSG IKONA_TRUE

                //UPRAVIT ZÁZNAM
                if (UserIdExist == 0) //POKUD NEXISTUJE ZÁZNAM
                {
                    //MessageBox.Show("testt");
                    if (!String.IsNullOrEmpty(txtPublicKey.Text) && !String.IsNullOrEmpty(txtVerKey.Text) && comboLicenseId.SelectedIndex != -1)
                    {
                        //INSERT CLIENT
                        sqlClients1.Open();
                        string query1 = "INSERT INTO " + table1 + " (userName, mac, sN, pK, vK, startT, expT, enabled)" +
                        " VALUES (@userName, @mac, @sN, @pK, @vK, @startT, @expT, @enabled)";

                        SqlCommand cmd1 = new SqlCommand(query1, sqlClients1);
                        //cmd1.Parameters.AddWithValue("@id", rdpName.Text);

                        string sinceDate = dateSince.Value.ToShortDateString();
                        string expDate = dateExp.Value.ToShortDateString();

                        cmd1.Parameters.AddWithValue("@userName", "");
                        cmd1.Parameters.AddWithValue("@mac", _mainForm.selectedIDMAC);
                        cmd1.Parameters.AddWithValue("@sN", comboLicenseId.SelectedItem.ToString());
                        cmd1.Parameters.AddWithValue("@pK", txtPublicKey.Text);
                        cmd1.Parameters.AddWithValue("@vK", txtVerKey.Text);
                        cmd1.Parameters.AddWithValue("@startT", sinceDate);
                        cmd1.Parameters.AddWithValue("@expT", expDate);
                        cmd1.Parameters.AddWithValue("@enabled", true);
                        cmd1.ExecuteNonQuery();

                        sqlClients1.Close();
                        //SELECT ID

                        await Task.Delay(5000);

                        sqlClients1.Open();
                        String query2 = "SELECT id FROM " + table1 + " WHERE pK='" + txtPublicKey.Text + "'";

                        SqlCommand cmd2 = new SqlCommand(query2, sqlClients1);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        while (dr2.Read())
                        {
                            clientID = Int32.Parse(dr2["id"].ToString());
                        }
                        sqlClients1.Close();
                        //INSERT PRIVATEK
                        sqlClients1.Open();
                        string query3 = "INSERT INTO " + table2 + " (id, sKey)" +
                        " VALUES (@id, @sKey)";

                        SqlCommand cmd3 = new SqlCommand(query3, sqlClients1);

                        cmd3.Parameters.AddWithValue("@id", clientID);//rdpName.Text);
                        cmd3.Parameters.AddWithValue("@sKey", salt);//rdpName.Text);
                        cmd3.ExecuteNonQuery();
                        sqlClients1.Close();

                        UpdateLicenseParameter();
                        
                    }
                    else
                    {
                        MessageBox.Show("Make sure there are no empty fields before trying again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This client is already parent to license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            cmd1.Parameters.AddWithValue("@sN", comboLicenseId.SelectedItem.ToString());//rdpName.Text);
            cmd1.ExecuteNonQuery();
            sqlClients1.Close();

            LoadLicensesToCB();

            txtPublicKey.Text = String.Empty;
            txtVerKey.Text = String.Empty;
            //txtLStatus.Text = "Activated";
            //clientList[clientIndex].RemoveAt(5);
            //clientList[clientIndex].Add("Activated");
        }
        public void LoadLicensesToCB()
        {
            comboLicenseId.Items.Clear();

            sqlClients1.Open();
            String query2 = "SELECT sN FROM " + Constants.tableL_AR + " WHERE active='" + false + "'";

            SqlCommand cmd2 = new SqlCommand(query2, sqlClients1);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            while (dr2.Read())
            {
                comboLicenseId.Items.Add(dr2["sN"].ToString());
            }
            sqlClients1.Close();

            if (comboLicenseId.Items.Count > 0)
                comboLicenseId.SelectedIndex = 0;

        }
        public void LicenseStatusStatement()
        {
            //if(MainForm.ucLv.txtLicStatus)
        }
        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mainForm.activeClients.SelectedIndex != -1 && !String.IsNullOrEmpty(txtClientIp.Text))
                {

                    ActivateClient(Constants.tableActiveLicenses, Constants.tablepK);

                    //ucLv = new UC_LicenseView1(null);
                    MainForm.ucLv.dgvLicenses1.Refresh();
                    MainForm.ucLv.RefreshLicenseData();

                }
                else
                {
                    MessageBox.Show("Select client to attach the license.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UC_LicenseAdd1_Load(object sender, EventArgs e)
        {
            LoadLicensesToCB();
        }
        
        private void btnViewBackToM_Click(object sender, EventArgs e)
        {
            try
            {
                MainForm.ucLm.Visible = true; //Back to main
                MainForm.ucLa.Visible = false;
                MainForm.ucLv.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
