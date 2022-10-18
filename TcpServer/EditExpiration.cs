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
    public partial class EditExpiration : Form
    {
        private readonly UC_LicenseView1 _uC_LicenseView;
        public EditExpiration(UC_LicenseView1 uC_LicenseView)
        {
            InitializeComponent();

            _uC_LicenseView = uC_LicenseView;
        }
        public SqlConnection sqlClients4 = new SqlConnection(@"Data Source=Pavel-LENOVO\SQLEXPRESS;Initial Catalog=RunAsAdmin;Integrated Security=True");


        private void btnSaveExpiration_Click(object sender, EventArgs e)
        {
            string sinceDate = dateSince.Value.ToShortDateString();
            string expDate = dateExp.Value.ToShortDateString();

            sqlClients4.Open();
            String query4 = "UPDATE " + Constants.tableActiveLicenses + " SET startT=@startT, expT=@expT WHERE sN=@sN";
            SqlCommand cmd4 = new SqlCommand(query4, sqlClients4);

            cmd4.Parameters.AddWithValue("@startT", sinceDate);
            cmd4.Parameters.AddWithValue("@expT", expDate);
            cmd4.Parameters.AddWithValue("@sN", UC_LicenseView1.selectedSn);//rdpName.Text);

            cmd4.ExecuteNonQuery();
            sqlClients4.Close();

            _uC_LicenseView.RefreshLicenseData();
            this.Close();
        }

        private void EditExpiration_Load(object sender, EventArgs e)
        {
            dateSince.Text = _uC_LicenseView.txtGenDate.Text;
            dateExp.Text = _uC_LicenseView.txtExpDate.Text;
        }
    }
}
