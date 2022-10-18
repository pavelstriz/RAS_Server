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
    public partial class UC_TaskScheduler1 : UserControl
    {
        private MainForm _mainForm;
        public UC_TaskScheduler1(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void cbRepeatsDate1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRepeatOption1.SelectedItem == "Days")
            {
                cbRepeatsNumber1.Items.Clear();
                cbRepeatsNumber1.Text = "1";
                for (int days = 1; days <= 30; days++)
                    cbRepeatsNumber1.Items.Add(days);
            }
            else if (cbRepeatOption1.SelectedItem == "Weeks")
            {
                cbRepeatsNumber1.Items.Clear();
                cbRepeatsNumber1.Text = "1";
                for (int weeks = 1; weeks <= 7; weeks++)
                    cbRepeatsNumber1.Items.Add(weeks);
            }
            else if (cbRepeatOption1.SelectedItem == "Months")
            {
                cbRepeatsNumber1.Items.Clear();
                cbRepeatsNumber1.Text = "1";
                for (int months = 1; months <= 12; months++)
                    cbRepeatsNumber1.Items.Add(months);
            }
            else if (cbRepeatOption1.SelectedItem == "Years")
            {
                cbRepeatsNumber1.Items.Clear();
                cbRepeatsNumber1.Text = "1";
                for (int years = 1; years <= 10; years++)
                    cbRepeatsNumber1.Items.Add(years);
            }
        }

        private void UC_TaskScheduler1_Load(object sender, EventArgs e)
        {
            cbRepeatOption1.SelectedItem = "Days";

        }

        private void chbEndsAt_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEndsAt.Checked)
            {
                dtpEndDate.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else if (!chbEndsAt.Checked)
            {
                dtpEndDate.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }

        public static string tsTaskName;
        public static string tsTaskDesc;
        public static string tsTaskProgScript;
        public static string tsTaskArgs;

        public static string tsTaskStartDate;
        public static string tsTaskStartTime;
        public static string tsTaskEndDate;
        public static string tsTaskEndTime;

        public static string tsTaskRepeatNumber;
        public static string tsTaskRepeatOption;

        private void btnExecuteTaskScheduler_Click(object sender, EventArgs e)
        {
            tsTaskName = txtTaskName.Text;
            tsTaskDesc = txtTaskDesc.Text;
            tsTaskProgScript = txtTaskProgScript.Text;
            tsTaskArgs = txtTaskArgs.Text;

            tsTaskStartDate = dtpStartDate.Text;
            tsTaskStartTime = dtpStartTime.Text;

            if (chbEndsAt.Checked)
            {
                tsTaskEndDate = dtpEndDate.Text;
                tsTaskEndTime = dtpEndTime.Text;
            }
            else
            {
                tsTaskEndDate = String.Empty;
                tsTaskEndTime = String.Empty;
            }

            tsTaskRepeatNumber = cbRepeatsNumber1.Text;
            tsTaskRepeatOption = cbRepeatOption1.Text;


            _mainForm.SendCommand(_mainForm.activeSockets[Int32.Parse(_mainForm.selectedID) - 1],
                tsTaskName + "\n" + tsTaskDesc + "\n" + tsTaskProgScript + "\n" + tsTaskArgs + "\n" + tsTaskStartDate + "\n" +
                tsTaskStartTime + "\n" + tsTaskEndDate + "\n" + tsTaskEndTime + "\n" + tsTaskRepeatNumber + "\n" + tsTaskRepeatOption + "<SetTaskSchedulerRule>");
        }





        /*
https://stackoverflow.com/questions/7394806/creating-scheduled-tasks

using (TaskService ts = new TaskService())
{
// Create a new task definition and assign properties
TaskDefinition td = ts.NewTask();
td.RegistrationInfo.Description = "Does something";

// Create a trigger that will fire the task at this time every other day
td.Triggers.Add(new DailyTrigger { DaysInterval = 2 });

// Create an action that will launch Notepad whenever the trigger fires
td.Actions.Add(new ExecAction("notepad.exe", "c:\\test.log", null));

// Register the task in the root folder
ts.RootFolder.RegisterTaskDefinition(@"Test", td);

// Remove the task we just created
ts.RootFolder.DeleteTask("Test");
}

*/


    }
}
