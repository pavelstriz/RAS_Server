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
    public partial class BlackListAdd : Form
    {
        private Blacklist blacklist;
        private MainForm mainf1;
        public BlackListAdd(MainForm _mainform, Blacklist _blacklist)
        {
            InitializeComponent();

            blacklist = _blacklist;
            mainf1 = _mainform;
        }

        private void btnStorno1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (!String.IsNullOrEmpty(txtBLipAddress1.Text))
                {
                    blacklist.BlockClient(txtBLName1.Text, txtBLipAddress1.Text, txtBLmac1.Text);
                    mainf1.BlackListChecker();

                    for (int i = 0; i <= mainf1.activeSockets.Count; i++)
                    {
                        //MessageBox.Show(mainf1.clientsParam[i].clientIp.ToString());
                        //MessageBox.Show(mainf1.clientsParam[i].clientPort.ToString());


                        if (mainf1.blockedIps[i] == mainf1.clientsParam[i].clientIp)
                        {
                            mainf1.SendCommand(mainf1.clientsParam[i].clientSocket, "</ras -disconnect -c>");
                            

                        }

                        //MessageBox.Show(mainf1.blockedIps[i].ToString());
                        //MessageBox.Show(mainf1.clientsParam[i].clientIp.ToString());
                    }
                    blacklist.RefreshBanlist();



                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ip Address field is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
