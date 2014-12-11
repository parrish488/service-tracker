using System;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
  public partial class InfoAccessor : Form
  {
    String addType;
    public bool employee = false;
    public bool client = false;
    public bool ticket = false;
    public string name;
    public string date;
    private string employeeName;
    public InfoAccessor()
    {
      InitializeComponent();
    }

    public InfoAccessor(String type)
    {
      InitializeComponent();
      addType = type;
      if (addType == "Ticket" || addType == "CloseTicket" || addType == "CompleteTicket" || addType == "UnassignedTicket")
      {
        btnAddNew.Enabled = false;
      }
      populate();
    }

    public InfoAccessor(String type, String employee)
    {
      InitializeComponent();
      addType = type;
      employeeName = employee;
      if (addType == "Ticket" || addType == "CloseTicket" || addType == "CompleteTicket")
      {
        btnAddNew.Enabled = false;
      }
      populate();
    }

    private void btnSelect_Click(object sender, EventArgs e)
    {
      bool exists = false;
      for (int i = 0; i < lbInfo.Items.Count; i++)
      {
        if (lbInfo.GetSelected(i))
        {
          exists = true;
        }
      }
      if (exists)
      {
        DialogResult = DialogResult.Yes;
        if (addType == "CloseTicket" || addType == "CompleteTicket" || addType == "UnassignedTicket")
        {

        }
        else
        {
          name = lbInfo.SelectedItem.ToString();
        }
      }
      else
      {
        MessageBox.Show("Select an Item");
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    private void btnAddNew_Click(object sender, EventArgs e)
    {
      if (addType == "Client")
      {
        client = true;
        DialogResult = DialogResult.OK;
      }
      else
      {
        employee = true;
        DialogResult = DialogResult.OK;
      }
    }

    private void populate()
    {
      switch (addType)
      {
        case "Client":
          {
            this.Text = "Viewing Clients";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable clients;
              String query = "select * from Client";
              clients = db.GetDataTable(query);

              foreach (DataRow r in clients.Rows)
              {
                lbInfo.Items.Add(r["firstName"].ToString() + " " + r["lastName"].ToString());
              }
            }
            catch (Exception fail)
            {
              String error = "The following error has occurred:\n\n";
              error += fail.Message.ToString() + "\n\n";
              MessageBox.Show(error);
            }
          }
          break;

        case "Corrective":
          {
            this.Text = "Viewing Employees";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable employees;
              String query = "select * from Worker";
              employees = db.GetDataTable(query);

              foreach (DataRow r in employees.Rows)
              {
                if (r["actionStatus"].ToString() == "Pending Management Review")
                {
                  lbInfo.Items.Add(r["firstName"].ToString() + " " + r["lastName"].ToString());
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
          break;

        case "Employee":
          {
            this.Text = "Viewing Employees";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable employees;
              String query = "select * from Worker";
              employees = db.GetDataTable(query);

              foreach (DataRow r in employees.Rows)
              {
                lbInfo.Items.Add(r["firstName"].ToString() + " " + r["lastName"].ToString());
              }
            }
            catch (Exception fail)
            {
              String error = "The following error has occurred:\n\n";
              error += fail.Message.ToString() + "\n\n";
              MessageBox.Show(error);
            }
          }
          break;
        case "CloseTicket":
          {
            this.Text = "Viewing Tickets";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable clients;
              DataTable tickets;
              String clientQuery = "select * from Client";
              String ticketQuery = "select * from ServiceTicket";
              clients = db.GetDataTable(clientQuery);
              tickets = db.GetDataTable(ticketQuery);

              foreach (DataRow r in tickets.Rows)
              {
                if (r["status"].ToString() == "Visit Completed")
                {
                  foreach (DataRow rw in clients.Rows)
                  {
                    if (rw["id"].ToString() == r["client"].ToString())
                    {
                      lbInfo.Items.Add(r["visitDate"].ToString() + " " + " @ " + r["visitTime"].ToString() + " -- " + rw["firstName"].ToString() + " " + rw["lastName"].ToString());
                      name = r["client"].ToString();
                      date = r["visitDate"].ToString() + " ";
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
          break;
        case "CompleteTicket":
          {
            this.Text = "Viewing Tickets";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable clients;
              DataTable tickets;
              String clientQuery = "select * from Client";
              String ticketQuery = "select * from ServiceTicket";
              clients = db.GetDataTable(clientQuery);
              tickets = db.GetDataTable(ticketQuery);

              foreach (DataRow r in tickets.Rows)
              {
                if (r["status"].ToString() == "Assigned" && r["assignedTech"].ToString() == employeeName)
                {
                  foreach (DataRow rw in clients.Rows)
                  {
                    if (rw["id"].ToString() == r["client"].ToString())
                    {
                      lbInfo.Items.Add(r["visitDate"].ToString() + " " + " @ " + r["visitTime"].ToString() + " -- " + rw["firstName"].ToString() + " " + rw["lastName"].ToString());
                      name = r["client"].ToString();
                      date = r["visitDate"].ToString() + " ";
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
          break;
        case "UnassignedTicket":
          {
            this.Text = "Viewing Tickets";
            SQLiteDatabase db;

            try
            {
              db = new SQLiteDatabase();
              DataTable clients;
              DataTable tickets;
              String clientQuery = "select * from Client";
              String ticketQuery = "select * from ServiceTicket";
              clients = db.GetDataTable(clientQuery);
              tickets = db.GetDataTable(ticketQuery);

              foreach (DataRow r in tickets.Rows)
              {
                if (r["status"].ToString() == "Unassigned")
                {
                  foreach (DataRow rw in clients.Rows)
                  {
                    if (rw["id"].ToString() == r["client"].ToString())
                    {
                      lbInfo.Items.Add(r["visitDate"].ToString() + " " + " @ " + r["visitTime"].ToString() + " -- " + rw["firstName"].ToString() + " " + rw["lastName"].ToString());
                      name = r["client"].ToString();
                      date = r["visitDate"].ToString() + " ";
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
          break;
        default:
          break;
      }
    }
  }
}
