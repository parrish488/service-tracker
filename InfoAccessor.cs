//-----------------------------------------------------------------------
// <copyright file="InfoAccessor.cs" company="ParrishCorp">
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
  /// Info accessor class
  /// </summary>
  public partial class InfoAccessor : Form
  {
    /// <summary>Add type</summary>
    private string m_addType;

    /// <summary>Employee name</summary>
    private string m_employeeName;

    /// <summary>Query object</summary>
    private DatabaseQuery queries = new DatabaseQuery();

    /// <summary>
    /// Initializes a new instance of the InfoAccessor class
    /// </summary>
    public InfoAccessor()
    {
      InitializeComponent();
      Employee = false;
      Client = false;
      Ticket = false;
    }

    /// <summary>
    /// Initializes a new instance of the InfoAccessor class
    /// </summary>
    /// <param name="type">Type of object to be used</param>
    public InfoAccessor(string type)
    {
      InitializeComponent();

      Employee = false;
      Client = false;
      Ticket = false;

      m_addType = type;

      if (m_addType == "Ticket" || m_addType == "CloseTicket" || m_addType == "CompleteTicket" || m_addType == "UnassignedTicket")
      {
        btnAddNew.Enabled = false;
      }

      Populate();
    }

    /// <summary>
    /// Initializes a new instance of the InfoAccessor class
    /// </summary>
    /// <param name="type">Type of object to be used</param>
    /// <param name="employee">Employee name</param>
    public InfoAccessor(string type, string employee)
    {
      InitializeComponent();

      Employee = false;
      Client = false;
      Ticket = false;

      m_addType = type;
      m_employeeName = employee;

      if (m_addType == "Ticket" || m_addType == "CloseTicket" || m_addType == "CompleteTicket")
      {
        btnAddNew.Enabled = false;
      }

      Populate();
    }

    /// <summary>Gets or sets a value indicating whether it is an employee</summary>
    public bool Employee { get; set; }

    /// <summary>Gets or sets a value indicating whether it is a client</summary>
    public bool Client { get; set; }

    /// <summary>Gets or sets a value indicating whether it is a ticket</summary>
    public bool Ticket { get; set; }

    /// <summary>Gets or sets name</summary>
    public string NameOther { get; set; }

    /// <summary>Gets or sets date</summary>
    public string Date { get; set; }

    /// <summary>
    /// Button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnSelect_Click(object sender, EventArgs e)
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

        if (m_addType == "CloseTicket" || m_addType == "CompleteTicket" || m_addType == "UnassignedTicket")
        {
          Dictionary<int, Client> clients = queries.QueryForAllClients(-1);
          string[] information = lbInfo.SelectedItem.ToString().Split();

          foreach (KeyValuePair<int, Client> pair in clients)
          {
            if (pair.Value.FirstName == information[6] && pair.Value.LastName == information[7])
            {
              NameOther = pair.Value.Id.ToString();
            }
          }
          
          Date = information[0];
        }
        else
        {
          NameOther = lbInfo.SelectedItem.ToString();
        }
      }
      else
      {
        MessageBox.Show("Select an Item");
      }
    }

    /// <summary>
    /// Cancel button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    /// <summary>
    /// Add button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnAddNew_Click(object sender, EventArgs e)
    {
      if (m_addType == "Client")
      {
        Client = true;
        DialogResult = DialogResult.OK;
      }
      else
      {
        Employee = true;
        DialogResult = DialogResult.OK;
      }
    }

    /// <summary>
    /// Populate the accessor
    /// </summary>
    private void Populate()
    {
      switch (m_addType)
      {
        case "Client":
          {
            this.Text = "Viewing Clients";

            Dictionary<int, Client> clients = queries.QueryForAllClients(-1);

            foreach (KeyValuePair<int, Client> pair in clients)
            {
              lbInfo.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
            }            
          }
           
          break;

        case "Corrective":
        case "Employee":
          {
            this.Text = "Viewing Employees";

            Dictionary<string, Worker> workers = queries.QueryForAllWorkers("null");

            foreach (KeyValuePair<string, Worker> pair in workers)
            {
              lbInfo.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
            }  
          }

          break;
        
        case "CloseTicket":
        case "CompleteTicket":
        case "UnassignedTicket":
          {
            this.Text = "Viewing Tickets";
            
            Dictionary<int, ServiceCall> tickets = queries.QueryForAllServiceCalls(queries.QueryForAllClients(-1));

            foreach (KeyValuePair<int, ServiceCall> pair in tickets)
            {
              if (pair.Value.JobStatus == "Visit Completed")
              {
                lbInfo.Items.Add(pair.Value.Date + " " + " @ " + pair.Value.Time + " -- " + pair.Value.FirstName + " " + pair.Value.LastName);
                NameOther = pair.Value.ClientId.ToString();
                Date = pair.Value.Date + " ";
              }
            }
          }

          break;
        default:
          break;
      }
    }
  }
}
