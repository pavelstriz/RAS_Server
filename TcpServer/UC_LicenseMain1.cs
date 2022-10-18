using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpServer
{
    public partial class UC_LicenseMain1 : UserControl
    {
        private MainForm _mainForm;
        //private UC_LicenseAdd1 _uC_LicenseAdd1;
        public UC_LicenseMain1(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            //_uC_LicenseAdd1 = uC_LicenseAdd1;
        }
        UC_LicenseAdd1 ucLa;
        UC_LicenseView1 ucLv;
        private async void btnAddLicense_Click(object sender, EventArgs e)
        {
            /*_mainForm.tabPage2.Controls.Clear();
            ucLa = new UC_LicenseAdd1(null);
            ucLa.Dock = DockStyle.Fill;
            _mainForm.tabPage2.Controls.Add(ucLa);
            */
            try
            {
                MainForm.ucLm.Visible = false;
                MainForm.ucLa.Visible = true; //Add
                MainForm.ucLv.Visible = false;
                //return Task.CompletedTask;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnLicenseView1_Click(object sender, EventArgs e)
        {
            MainForm.ucLm.Visible = false;
            MainForm.ucLa.Visible = false;
            MainForm.ucLv.Visible = true; //View


            /*_mainForm.tabPage2.Controls.Clear();
            ucLv = new UC_LicenseView1(null);
            ucLv.Dock = DockStyle.Fill;
            _mainForm.tabPage2.Controls.Add(ucLv);
            */
        }
    }
}
