using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
  public partial class ServiceCallGUI : Form
  {
    ServiceCall info = new ServiceCall();
    string tempId;
    bool update = false;

    public ServiceCallGUI()
    {
      InitializeComponent();
      update = false;
    }

    public ServiceCallGUI(string clientId)
    {
      InitializeComponent();
      tempId = clientId;
      update = false;
      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable tickets;
        DataTable clients;

        String ticketQuery = "select * from Worker";
        String clientQuery = "select * from Client";
        tickets = db.GetDataTable(ticketQuery);
        clients = db.GetDataTable(clientQuery);

        foreach (DataRow r in clients.Rows)
        {
          if (r["id"].ToString() == clientId)
          {
            tbFirstName.Text = r["firstName"].ToString();
            tbLastName.Text = r["lastName"].ToString();
            tbAddress.Text = r["address"].ToString();
            tbPhoneNumber.Text = r["phone"].ToString();
          }
        }

        foreach (DataRow r in tickets.Rows)
        {
          cbAssignedTech.Items.Add(r["firstName"] + " " + r["lastName"]);
          cbTakenBy.Items.Add(r["firstName"] + " " + r["lastName"]);
        }
      }
      catch (Exception fail)
      {
        String error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }
    }

    public ServiceCallGUI(string clientId, string ticketDate)
    {
      InitializeComponent();
      string[] s = ticketDate.Split('@');
      tempId = clientId;
      update = true;
      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable worker;
        DataTable clients;
        DataTable tickets;

        String workerQuery = "select * from Worker";
        String clientQuery = "select * from Client";
        String ticketQuery = "select * from ServiceTicket";
        worker = db.GetDataTable(workerQuery);
        clients = db.GetDataTable(clientQuery);
        tickets = db.GetDataTable(ticketQuery);

        foreach (DataRow r in clients.Rows)
        {
          if (r["id"].ToString() == clientId)
          {
            tbFirstName.Text = r["firstName"].ToString();
            tbLastName.Text = r["lastName"].ToString();
            tbAddress.Text = r["address"].ToString();
            tbPhoneNumber.Text = r["phone"].ToString();
          }
        }

        foreach (DataRow r in worker.Rows)
        {
          cbAssignedTech.Items.Add(r["firstName"] + " " + r["lastName"]);
          cbTakenBy.Items.Add(r["firstName"] + " " + r["lastName"]);
        }

        foreach (DataRow r in tickets.Rows)
        {
          if (r["client"].ToString() == clientId && (r["visitDate"].ToString() + " ") == s[0].ToString())
          {
            for (int i = 0; i < cbAssignedTech.Items.Count; i++)
            {
              if (cbAssignedTech.Items[i].ToString() == r["assignedTech"].ToString())
              {
                cbAssignedTech.SelectedIndex = i;
              }
            }
            for (int i = 0; i < cbJobStatus.Items.Count; i++)
            {
              if (cbJobStatus.Items[i].ToString() == r["status"].ToString())
              {
                cbJobStatus.SelectedIndex = i;
              }
            }
            for (int i = 0; i < cbTakenBy.Items.Count; i++)
            {
              if (cbTakenBy.Items[i].ToString() == r["callTaker"].ToString())
              {
                cbTakenBy.SelectedIndex = i;
              }
            }
            lbTicketNumber.Text = r["id"].ToString();
            tbVisitComments.Text = r["comments"].ToString();
            string temp = r["visitDate"].ToString();
            DateTime tempDate = DateTime.Parse(temp);
            dtpDate.Value = tempDate;
            string temp1 = r["visitTime"].ToString();
            DateTime tempTime = DateTime.Parse(temp1);
            dtpTime.Value = tempTime;
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

    private void btnSubmit_Click(object sender, EventArgs e)
    {
      if (tbFirstName.Text != "" && tbLastName.Text != "" && tbPhoneNumber.Text != ""
         && tbAddress.Text != "" && tbVisitComments.Text != "" && cbTakenBy.Text != ""
         && cbJobStatus.Text != "" && cbAssignedTech.Text != "" && dtpTime.Text != ""
         && dtpDate.Text != "")
      {
        if (update == false)
        {
          databaseInsert();
          DialogResult = DialogResult.Yes;
        }
        else
        {
          databaseUpdate();
          DialogResult = DialogResult.Yes;
        }
      }
      else
      {
        MessageBox.Show("All fields are required.");
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.No;
    }

    private void databaseInsert()
    {
      SQLiteDatabase db = new SQLiteDatabase();
      Dictionary<String, String> data = new Dictionary<string, string>();

      data.Add("comments", tbVisitComments.Text.ToString());

      data.Add("callTaker", cbTakenBy.SelectedItem.ToString());
      data.Add("status", cbJobStatus.SelectedItem.ToString());
      data.Add("assignedTech", cbAssignedTech.SelectedItem.ToString());

      data.Add("visitTime", dtpTime.Value.ToShortTimeString());
      data.Add("visitDate", dtpDate.Value.ToShortDateString());
      data.Add("client", tempId);

      try
      {
        db.Insert("ServiceTicket", data);
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
      //Create Database object
      SQLiteDatabase db = new SQLiteDatabase();
      Dictionary<String, String> data = new Dictionary<string, string>();
      data.Add("comments", tbVisitComments.Text.ToString());

      data.Add("callTaker", cbTakenBy.SelectedItem.ToString());
      data.Add("status", cbJobStatus.SelectedItem.ToString());
      data.Add("assignedTech", cbAssignedTech.SelectedItem.ToString());

      data.Add("visitTime", dtpTime.Value.ToShortTimeString());
      data.Add("visitDate", dtpDate.Value.ToShortDateString());
      data.Add("client", tempId);
      try
      {
        db.Update("ServiceTicket", data, String.Format("ServiceTicket.Id = {0}", lbTicketNumber.Text));
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
}

