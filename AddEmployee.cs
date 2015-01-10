//-----------------------------------------------------------------------
// <copyright file="AddEmployee.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
  /// <summary>
  /// Add Employee
  /// </summary>
  public partial class AddEmployee : Form
  {
    /// <summary>Worker to add or edit</summary>
    private Worker m_worker = new Worker();

    /// <summary>Temp name to check against</summary>
    private string temp;

    /// <summary>Database query object</summary>
    private DatabaseQuery m_queries = new DatabaseQuery();

    /// <summary>
    /// Initializes a new instance of the AddEmployee class
    /// </summary>
    public AddEmployee()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the AddEmployee class
    /// </summary>
    /// <param name="name">Employee name</param>
    public AddEmployee(string name)
    {
      InitializeComponent();
      temp = name;

      cbCorrectiveActionsStatus.SelectedIndex = 1;

      if (name != null)
      {
        Dictionary<string, Worker> workers = m_queries.QueryForAllWorkers("null");

        foreach (KeyValuePair<string, Worker> pair in workers)
        {
          if ((pair.Value.FirstName + " " + pair.Value.LastName) == name)
          {
            lbEmployeeNum.Text = pair.Value.ID.ToString();
            tbFirstName.Text = pair.Value.FirstName;
            tbLastName.Text = pair.Value.LastName;
            tbUsername.Text = pair.Value.Username;
            tbPassword.Text = pair.Value.Password;
            switch (pair.Value.WorkerType)
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

            tbCorrectiveActions.Text = pair.Value.CorrectiveActions;
            switch (pair.Value.ActionStatus)
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
    }

    /// <summary>
    /// Button event for submit button
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnSubmit_Click(object sender, EventArgs e)
    {
      if (temp == null)
      {
        if (tbFirstName.Text != string.Empty && tbLastName.Text != string.Empty 
          && tbUsername.Text != string.Empty && tbPassword.Text != string.Empty 
          && cbCorrectiveActionsStatus.Text != string.Empty && cbEmployeeType.Text != string.Empty)
        {
          DatabaseInsert();
          DialogResult = DialogResult.Yes;
        }
        else
        {
          MessageBox.Show("All fields are required except Corrective Actions.");
        }
      }
      else
      {
        if (tbFirstName.Text != string.Empty && tbLastName.Text != string.Empty 
          && tbUsername.Text != string.Empty && tbPassword.Text != string.Empty 
          && cbCorrectiveActionsStatus.Text != string.Empty && cbEmployeeType.Text != string.Empty)
        {
          DatabaseUpdate();
          DialogResult = DialogResult.Yes;
        }
        else
        {
          MessageBox.Show("All fields are required except Corrective Actions.");
        }
      }
    }

    /// <summary>
    /// Button event for cancel button
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.No;
    }

    /// <summary>
    /// Insert into database
    /// </summary>
    private void DatabaseInsert()
    {
      Dictionary<string, string> data = new Dictionary<string, string>();
      data.Add("firstName", tbFirstName.Text);
      data.Add("lastName", tbLastName.Text);
      data.Add("username", tbUsername.Text);
      data.Add("password", tbPassword.Text);
      data.Add("type", cbEmployeeType.SelectedItem.ToString());
      data.Add("correctiveActions", tbCorrectiveActions.Text);
      data.Add("actionStatus", cbCorrectiveActionsStatus.SelectedItem.ToString());

      m_queries.InsertQuery(data);
    }

    /// <summary>
    /// Update entry in database
    /// </summary>
    private void DatabaseUpdate()
    {
      if (temp != null)
      {
        Dictionary<string, string> data = new Dictionary<string, string>();
        data.Add("firstName", tbFirstName.Text);
        data.Add("lastName", tbLastName.Text);
        data.Add("username", tbUsername.Text);
        data.Add("password", tbPassword.Text);
        data.Add("type", cbEmployeeType.SelectedItem.ToString());
        data.Add("correctiveActions", tbCorrectiveActions.Text);
        data.Add("actionStatus", cbCorrectiveActionsStatus.SelectedItem.ToString());

        m_queries.UpdateQuery(data, lbEmployeeNum.Text);
      }
    }
  }
}
