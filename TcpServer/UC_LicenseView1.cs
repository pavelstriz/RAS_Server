using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace TcpServer
{
    public partial class UC_LicenseView1 : UserControl
    {
        private MainForm _mainForm; 
        public UC_LicenseView1(MainForm mainForm)
        {
            InitializeComponent();

            //_licenseMain1 = licenseMain1; 
            _mainForm = mainForm; //NASTAVÍ MAIN FORM JAKO NADŘAZENÉ OKNO
        }
        public SqlConnection sqlClients0 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients1 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");
        public SqlConnection sqlClients2 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");

        private void UC_LicenseView1_Load(object sender, EventArgs e)
        {
            

            txtGenDate.Text = String.Empty;
            txtExpDate.Text = String.Empty;
            txtActDate.Text = String.Empty;
            txtLicStatus.Text = String.Empty;

            


            

            RefreshLicenseData();

            if (dgvLicenses1.Rows.Count >= 1)
                selectedSn = dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString();

            /*if (String.IsNullOrEmpty(macAddress))
            {
                isLinked = false;
            }
            else
            {
                isLinked = true;
            }*/
        }

        public static bool isLinked;
       
        public static bool licenseEnabled;
        private string macAddress;
        public void RefreshLicenseData()
        {
            //Thread.Sleep(1000);
            sqlClients1.Open();
            String query1 = "SELECT id as ' ', sN as 'Serial', mac as 'MAC', userName as 'Nickname' FROM " + Constants.tableActiveLicenses + "";// " ORDER BY lastTimeConnected DESC";
            SqlDataAdapter SDA1 = new SqlDataAdapter(query1, sqlClients1);
            DataTable dt1 = new System.Data.DataTable();
            SDA1.Fill(dt1);

            String query2 = "SELECT mac, startT, expT, activatedT, enabled FROM " + Constants.tableActiveLicenses + ""; // WHERE sN='"+selectedSn+"'";
            
            SqlCommand cmd1 = new SqlCommand(query2, sqlClients1);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                txtGenDate.Text = dr1["startT"].ToString();
                txtExpDate.Text = dr1["expT"].ToString();
                txtActDate.Text = dr1["activatedT"].ToString();
                
                licenseEnabled = Boolean.Parse(dr1["enabled"].ToString());
                macAddress = dr1["mac"].ToString();
            }

            dgvLicenses1.DataSource = dt1;
            sqlClients1.Close();



            if (String.IsNullOrEmpty(macAddress))
            {
                isLinked = false;
            }
            else
            {
                isLinked = true;
            }
            dgvLicenses1.DataSource = dt1;
            sqlClients1.Close();

            //MessageBox.Show(macAddress);

            if (licenseEnabled == true) //JE ZAPLÁ
             {
                 //txtLicStatus.Text = "Activated";
                 btnLinkLicense.Enabled = true;
                 btnDeactivateLicense.Text = "Deactivate";

                if (isLinked == false) // NENI PŘIŘAZENÁ
                {
                    //MessageBox.Show("HERE");

                    txtLicStatus.Text = "Unlinked";
                    btnLinkLicense.Text = "Link";
                    if (_mainForm.activeClients.Items.Count == 0)
                    {
                        btnLinkLicense.Enabled = false;
                    }
                }
                else if (isLinked == true)
                {

                    txtLicStatus.Text = "Linked";
                    btnLinkLicense.Text = "Unlink";

                }


            }
             else if(licenseEnabled == false)
             {
                btnLinkLicense.Enabled = false;
                txtLicStatus.Text = "Disabled";
                 
                btnDeactivateLicense.Text = "Activate";
                if(isLinked == false)
                {
                    btnLinkLicense.Text = "Link";
                }
                else if(isLinked == true)
                {
                    btnLinkLicense.Text = "Unlink";
                }
            }



            dgvLicenses1.Columns[0].Width = 3;
            dgvLicenses1.Columns[1].Width = 15;
            dgvLicenses1.Columns[2].Width = 20;
            dgvLicenses1.Columns[3].Width = 80;
            dgvLicenses1.RowTemplate.Height = 20;
            dgvLicenses1.EnableHeadersVisualStyles = false;
            dgvLicenses1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLicenses1.ColumnHeadersHeight = 25;
            dgvLicenses1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }

        public void btnDeleteLicense_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectedId + "\n" + selectedSn);
            sqlClients2.Open();
            String query3 = "DELETE FROM " + Constants.tableActiveLicenses + " WHERE id = '" + selectedId + "'";
            SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
            cmd3.ExecuteNonQuery();
            sqlClients2.Close();

            sqlClients2.Open();
            String query4 = "UPDATE " + Constants.tableL_AR + " SET active=@active WHERE sN=@sN";
            SqlCommand cmd4 = new SqlCommand(query4, sqlClients2);

            cmd4.Parameters.AddWithValue("@active", false);
            cmd4.Parameters.AddWithValue("@sN", selectedSn);//rdpName.Text);

            cmd4.ExecuteNonQuery();
            sqlClients2.Close();

            RefreshLicenseData();
            _mainForm.LoadLicensesToCB(); //OBNOVÍ COMBOBOX S LICENCEMA
        }
        string lActivatedT;

        
        private void btnLinkLicense_Click(object sender, EventArgs e)
        {
            //EVERY CLICK BOOL CHANGES

            if (isLinked == false)
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
                    cmd3.Parameters.AddWithValue("@mac", _mainForm.selectedIDMAC);
                    cmd3.Parameters.AddWithValue("@activatedT", lActivatedT);
                    cmd3.Parameters.AddWithValue("@sN", dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    MessageBox.Show(dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString());
                    cmd3.ExecuteNonQuery();
                    sqlClients2.Close();
                }


            }
            else if (isLinked == true)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to unlink this client?", "Deactivate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //UNLINK CLIENT
                    //btnLinkLicense.Text = "Link";
                    sqlClients2.Open();
                    String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET mac=@mac, activatedT=@activatedT WHERE sN = '" + selectedSn + "'";
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
            
            RefreshLicenseData();


        }

        public static  string selectedId;
        public static string selectedSn;
        private void dgvLicenses1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            selectedId = dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            selectedSn = dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString();
        }

        private void btnDeactivateLicense_Click(object sender, EventArgs e)
        {
            if (licenseEnabled)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to disable this license?", "Deactivate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //DEATIVATE CLIENT
                    sqlClients2.Open();
                    String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET enabled=@enabled WHERE sN = '" + selectedSn + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
                    cmd3.Parameters.AddWithValue("@enabled", false);

                    cmd3.ExecuteNonQuery();
                    sqlClients2.Close();
                }
                else
                {

                }
            }
            else if (!licenseEnabled)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to enable this license?", "Deactivate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    //ACTIVAETE CLIENT
                    //txtLicStatus.Text = "";
                    sqlClients2.Open();
                    String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET enabled=@enabled WHERE sN = '" + selectedSn + "'";
                    SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);
                    cmd3.Parameters.AddWithValue("@enabled", true);

                    cmd3.ExecuteNonQuery();
                    sqlClients2.Close();
                }
                else
                {

                }
            }
            RefreshLicenseData();
        }

        private void dgvLicenses1_SelectionChanged(object sender, EventArgs e)
        {
            
                selectedId = dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[0].Value.ToString();
                selectedSn = dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            //selectedSn = dgvLicenses1.CurrentCell.RowIndex.ToString();

            String query2 = "SELECT mac, startT, expT, activatedT, enabled FROM " + Constants.tableActiveLicenses + " WHERE sN='"+selectedSn+"'";
            sqlClients2.Open();
            SqlCommand cmd2 = new SqlCommand(query2, sqlClients2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                txtGenDate.Text = dr2["startT"].ToString();
                txtExpDate.Text = dr2["expT"].ToString();
                txtActDate.Text = dr2["activatedT"].ToString();

                licenseEnabled = Boolean.Parse(dr2["enabled"].ToString());
                macAddress = dr2["mac"].ToString();

                /*if(String.IsNullOrEmpty(macAddress))
                {
                    btnLinkLicense.Text = "Link";

                }
                else
                {
                    btnLinkLicense.Text = "Unlink"
                }*/

            }
            sqlClients2.Close();

            //RefreshLicenseData();

            //MessageBox.Show(selectedSn);
            try
                {
                    //RefreshLicenseData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void btnViewBackToM_Click(object sender, EventArgs e)
        {
            MainForm.ucLm.Visible = true; //Back to main
            MainForm.ucLa.Visible = false;
            MainForm.ucLv.Visible = false;
        }

        private void btnLicenseLink2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(_mainForm.selectedIDMAC);
            //MessageBox.Show(selectedSn);
            
            

            lActivatedT = DateTime.Today.ToShortDateString();

            sqlClients2.Open();
            String query3 = "UPDATE " + Constants.tableActiveLicenses + " SET mac=@mac, activatedT=@activatedT WHERE sN=@sN";
            SqlCommand cmd3 = new SqlCommand(query3, sqlClients2);

            cmd3.Parameters.AddWithValue("@mac", _mainForm.selectedIDMAC);
            cmd3.Parameters.AddWithValue("@activatedT", lActivatedT);//rdpName.Text);
            cmd3.Parameters.AddWithValue("@sN", dgvLicenses1.Rows[dgvLicenses1.CurrentCell.RowIndex].Cells[1].Value.ToString());//rdpName.Text);

            cmd3.ExecuteNonQuery();
            sqlClients2.Close();

            RefreshLicenseData();

        }

        private void btnEditExpiration_Click(object sender, EventArgs e)
        {
            EditExpiration editExpiration = new EditExpiration(this);
            editExpiration.ShowDialog();
        }
    }
}
