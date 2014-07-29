using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
    public partial class AddClient : Form
    {
        Client client = new Client();
        String tempClientId;
        public AddClient()
        {
            InitializeComponent();
        }

        public AddClient(string clientName)
        {
            InitializeComponent();

            //send clients name to be queried.
            if(clientName != null)
            {
                Query_Customer(clientName);
                btnAddCall.Enabled = true;
                btnEdit.Enabled = true;
            }
                

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {   
           
            //Check to make sure that no required textbox is empty.
            if (tbFirstName.Text != "" && tbLastName.Text != "" && tbPhone.Text != "" && tbAddress.Text != "")
            {

                if (lblNumber.Text != "")
                {
                    //run query to update client if they already exist
                    Update_Client();
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    //run add query to add client info to database
                    Insert_Client();
                    DialogResult = DialogResult.Yes;
                }
                
            }

        }

        private void btnAddCall_Click(object sender, EventArgs e)
        {
            ServiceCallGUI ticket = new ServiceCallGUI(tempClientId);
            DialogResult dialogResult = ticket.ShowDialog();

            if (ticket.DialogResult == DialogResult.Yes)
            {
                lbServiceCalls.Items.Clear();
                SQLiteDatabase db;

                try
                {
                    db = new SQLiteDatabase();

                    DataTable tickets;

                    String ticketQuery = "select * from ServiceTicket";

                    tickets = db.GetDataTable(ticketQuery);
                    
                    foreach (DataRow row in tickets.Rows)
                    {
                        if (row["client"].ToString() == lblNumber.Text.ToString())
                        {
                            lbServiceCalls.Items.Add(row["visitDate"].ToString() + " @ " + row["visitTime"].ToString());
                        }
                    }                    
                }
                catch (Exception fail)
                {
                    String error = "The following error has occurred:\n\n";
                    error += fail.Message.ToString() + "\n\n";
                    MessageBox.Show(error);
                }
            }
            else
            {
                //Do nothing?
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        public void Insert_Client()
        {
            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                //DataTable Clients;

                String command = "INSERT INTO Client (firstName,lastName,address,phone)";
                command += " VALUES ('" + tbFirstName.Text + "','" + tbLastName.Text + "','" + tbAddress.Text + "','" + tbPhone.Text + "');";

                db.ExecuteNonQuery(command);

                MessageBox.Show("Client successfully added.");
                DialogResult = DialogResult.Yes;
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }
        }

        public void Query_Customer(string name)
        {
            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable clients;
                DataTable tickets;

                String clientQuery = "SELECT * FROM Client";
                String ticketQuery = "select * from ServiceTicket";

                clients = db.GetDataTable(clientQuery);
                tickets = db.GetDataTable(ticketQuery);

                foreach (DataRow r in clients.Rows)
                {
                    if ( (r["firstName"].ToString() + " " + r["lastName"].ToString()) == name)
                    {
                        lblNumber.Text = r["id"].ToString();
                        tbFirstName.Text = r["firstName"].ToString();
                        tbLastName.Text = r["lastName"].ToString();
                        tbAddress.Text = r["address"].ToString();
                        tbPhone.Text = r["phone"].ToString();
                        tempClientId = r["id"].ToString();

                        foreach (DataRow row in tickets.Rows)
                        {
                            if (row["client"].ToString() == r["id"].ToString())
                            {
                                lbServiceCalls.Items.Add(row["visitDate"].ToString() + " @ " + row["visitTime"].ToString());
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
            }
 
        }

        public void Query_Customer(int customer_id)
        {
            //SELECT firstName,lastName,address,phone
            //FROM Client
            //WHERE id = '1';
        }

        public void Update_Client()
        {            
            //Create Database object
            SQLiteDatabase db = new SQLiteDatabase();
            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add("firstName", tbFirstName.Text);
            data.Add("lastName", tbLastName.Text);
            data.Add("address", tbAddress.Text);
            data.Add("phone", tbPhone.Text);

            try
            {
                db.Update("Client", data, String.Format("Client.id = {0}", lblNumber.Text));
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
                this.Close();
            }

        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbServiceCalls.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a Service Call");
            }
            else
            {
                ServiceCallGUI ticket = new ServiceCallGUI(tempClientId, lbServiceCalls.SelectedItem.ToString());
                DialogResult dialogResult = ticket.ShowDialog();

                if (ticket.DialogResult == DialogResult.Yes)
                {
                    lbServiceCalls.Items.Clear();
                    SQLiteDatabase db;

                    try
                    {
                        db = new SQLiteDatabase();

                        DataTable tickets;

                        String ticketQuery = "select * from ServiceTicket";

                        tickets = db.GetDataTable(ticketQuery);

                        foreach (DataRow row in tickets.Rows)
                        {
                            if (row["client"].ToString() == lblNumber.Text.ToString())
                            {
                                lbServiceCalls.Items.Add(row["visitDate"].ToString() + " @ " + row["visitTime"].ToString());
                            }
                        }
                    }
                    catch (Exception fail)
                    {
                        String error = "The following error has occurred:\n\n";
                        error += fail.Message.ToString() + "\n\n";
                        MessageBox.Show(error);
                    }
                }
            }
        }

    }
}
