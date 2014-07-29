 using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
    public partial class AddEmployee : Form
    {
        Worker worker = new Worker();
        string temp;
        public AddEmployee()
        {
            InitializeComponent();
        }

        public AddEmployee(string name)
        {
            InitializeComponent();
            temp = name;
            #region populate fields
            cbCorrectiveActionsStatus.SelectedIndex = 1;

            if (name != null)
            {
                //Create Database object
                SQLiteDatabase db;
                try
                {
                    db = new SQLiteDatabase();
                    DataTable workers;
                    String query = "select * from Worker";
                    workers = db.GetDataTable(query);

                    // Or looped through for some other reason
                    foreach (DataRow r in workers.Rows)
                    {
                        if ((r["firstName"].ToString() + " " + r["lastName"].ToString()) == name)
                        {
                            lbEmployeeNum.Text = r["Id"].ToString();
                            tbFirstName.Text = r["firstName"].ToString();
                            tbLastName.Text = r["lastName"].ToString();
                            tbUsername.Text = r["username"].ToString();
                            tbPassword.Text = r["password"].ToString();
                            switch (r["type"].ToString())
                            {
                                case "Manager":
                                    {
                                        cbEmployeeType.SelectedIndex = 0;
                                        break;
                                    }
                                case "Technician":
                                    {
                                        cbEmployeeType.SelectedIndex = 1;
                                        break;
                                    }
                                case "Customer Service":
                                    {
                                        cbEmployeeType.SelectedIndex = 2;
                                        break;
                                    }
                            }
                            tbCorrectiveActions.Text = r["correctiveActions"].ToString();
                            switch (r["actionStatus"].ToString())
                            {
                                case "Pending Management Review":
                                    {
                                        cbCorrectiveActionsStatus.SelectedIndex = 0;
                                        break;
                                    }
                                case "No Action Needed":
                                    {
                                        cbCorrectiveActionsStatus.SelectedIndex = 1;
                                        break;
                                    }
                            }
                        }
                    }
                }
                catch (Exception fail)
                {
                    String error = "The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n\n";
                    MessageBox.Show(error);
                    this.Close();
                }
            }

            #endregion

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        { 
            if (temp == null)
            {
                if (tbFirstName.Text != "" && tbLastName.Text != "" && tbUsername.Text != "" && tbPassword.Text != "" && cbCorrectiveActionsStatus.Text != "" && cbEmployeeType.Text != "")
                {
                    databaseInsert();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("All fields are required except Corrective Actions.");
                }
            }

            else
            {
                if (tbFirstName.Text != "" && tbLastName.Text != "" && tbUsername.Text != "" && tbPassword.Text != "" && cbCorrectiveActionsStatus.Text != "" && cbEmployeeType.Text != "")
                {
                    databaseUpdate();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("All fields are required except Corrective Actions.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void databaseInsert()
        {
            //Create Database object
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add("firstName", tbFirstName.Text);
            data.Add("lastName", tbLastName.Text);
            data.Add("username", tbUsername.Text);
            data.Add("password", tbPassword.Text);
            data.Add("type", cbEmployeeType.SelectedItem.ToString());
            data.Add("correctiveActions", tbCorrectiveActions.Text);
            data.Add("actionStatus", cbCorrectiveActionsStatus.SelectedItem.ToString());
            try
            {
                db.Insert("Worker", data);
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }
        }

        private void databaseUpdate()
        {
            if (temp != null)
            {
                //Create Database object
                SQLiteDatabase db = new SQLiteDatabase();
                Dictionary<String, String> data = new Dictionary<string,string>();
                data.Add("firstName", tbFirstName.Text);
                data.Add("lastName", tbLastName.Text);
                data.Add("username", tbUsername.Text);
                data.Add("password", tbPassword.Text);
                data.Add("type", cbEmployeeType.SelectedItem.ToString());
                data.Add("correctiveActions", tbCorrectiveActions.Text);
                data.Add("actionStatus", cbCorrectiveActionsStatus.SelectedItem.ToString());
                try
                {
                    db.Update("Worker", data, String.Format("Worker.Id = {0}", lbEmployeeNum.Text));
                }
                catch (Exception fail)
                {
                    String error = "The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n\n";
                    MessageBox.Show(error);
                    this.Close();
                }
            }
        }

        private void cbCorrectiveActionsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
