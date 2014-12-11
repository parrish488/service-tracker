using System;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
  public partial class Statistics : Form
  {
    int counter = 0;
    string tempName;

    public Statistics()
    {

      InitializeComponent();
      databaseQuery();
    }


    private void databaseQuery()
    {
      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable employees;
        String query = "select * from Worker";
        employees = db.GetDataTable(query);

        foreach (DataRow r in employees.Rows)
        {
          cbEmployee.Items.Add(r["firstName"].ToString() + " " + r["lastName"].ToString());
        }
      }
      catch (Exception fail)
      {
        String error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Yes;
    }

    private void btnDisplay_Click(object sender, EventArgs e)
    {
      tempName = cbEmployee.SelectedItem.ToString();
      counter = 0;
      //Query Database with name, then change label to show the count.
      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable employees;
        String query = "select * from ServiceTicket";
        employees = db.GetDataTable(query);

        foreach (DataRow r in employees.Rows)
        {
          if (r["assignedTech"].ToString() == tempName)
          {
            counter++;
          }
        }
      }
      catch (Exception fail)
      {
        String error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }
      lbCallCompleted.Text = "Number of Service calls completed: " + counter;
    }
  }
}

