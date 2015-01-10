//-----------------------------------------------------------------------
// <copyright file="ServiceCallGUI.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceTracker
{
  /// <summary>
  /// Service call user interface class
  /// </summary>
  public partial class ServiceCallGUI : Form
  {
    /// <summary>Query object</summary>
    private DatabaseQuery m_queries = new DatabaseQuery();

    /// <summary>Temporary client id</summary>
    private string m_tempClientId;

    /// <summary>Update flag</summary>
    private bool m_update = false;

    /// <summary>
    /// Initializes a new instance of the ServiceCallGUI class
    /// </summary>
    public ServiceCallGUI()
    {
      InitializeComponent();
      m_update = false;
    }

    /// <summary>
    /// Initializes a new instance of the ServiceCallGUI class
    /// </summary>
    /// <param name="clientId">Client id number</param>
    public ServiceCallGUI(string clientId)
    {
      InitializeComponent();
      m_tempClientId = clientId;
      m_update = false;
      Dictionary<int, Client> clients = m_queries.QueryForAllClients(int.Parse(m_tempClientId));

      tbFirstName.Text = clients[int.Parse(clientId)].FirstName;
      tbLastName.Text = clients[int.Parse(clientId)].LastName;
      tbAddress.Text = clients[int.Parse(clientId)].Address;
      tbPhoneNumber.Text = clients[int.Parse(clientId)].PhoneNumber;

      Dictionary<string, Worker> workers = m_queries.QueryForAllWorkers("null");

      foreach (KeyValuePair<string, Worker> pair in workers)
      {
        cbAssignedTech.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
        cbTakenBy.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
      }
    }

    /// <summary>
    /// Initializes a new instance of the ServiceCallGUI class
    /// </summary>
    /// <param name="clientId">Client id number</param>
    /// <param name="ticketDate">Ticket date</param>
    public ServiceCallGUI(string clientId, string ticketDate)
    {
      InitializeComponent();
      string[] s = ticketDate.Split('@');
      m_tempClientId = clientId;
      m_update = true;

      Dictionary<int, Client> clients = m_queries.QueryForAllClients(int.Parse(m_tempClientId));

      tbFirstName.Text = clients[int.Parse(clientId)].FirstName;
      tbLastName.Text = clients[int.Parse(clientId)].LastName;
      tbAddress.Text = clients[int.Parse(clientId)].Address;
      tbPhoneNumber.Text = clients[int.Parse(clientId)].PhoneNumber;

      Dictionary<string, Worker> workers = m_queries.QueryForAllWorkers("null");

      foreach (KeyValuePair<string, Worker> pair in workers)
      {
        cbAssignedTech.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
        cbTakenBy.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
      }

      Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(m_queries.QueryForAllClients(-1));

      foreach (KeyValuePair<int, ServiceCall> pair in tickets)
      {
        if (pair.Value.ClientId.ToString() == clientId && pair.Value.Date.ToString() == s[0].ToString())
        {
          for (int i = 0; i < cbAssignedTech.Items.Count; i++)
          {
            if (cbAssignedTech.Items[i].ToString() == pair.Value.Tech.ToString())
            {
              cbAssignedTech.SelectedIndex = i;
            }
          }

          for (int i = 0; i < cbJobStatus.Items.Count; i++)
          {
            if (cbJobStatus.Items[i].ToString() == pair.Value.JobStatus.ToString())
            {
              cbJobStatus.SelectedIndex = i;
            }
          }

          for (int i = 0; i < cbTakenBy.Items.Count; i++)
          {
            if (cbTakenBy.Items[i].ToString() == pair.Value.CallTaker.ToString())
            {
              cbTakenBy.SelectedIndex = i;
            }
          }

          lbTicketNumber.Text = pair.Value.Id.ToString();
          tbVisitComments.Text = pair.Value.Comments.ToString();
          string temp = pair.Value.Date.ToString();
          DateTime tempDate = DateTime.Parse(temp);
          dtpDate.Value = tempDate;
          string temp1 = pair.Value.Time.ToString();
          DateTime tempTime = DateTime.Parse(temp1);
          dtpTime.Value = tempTime;
        }
      }
    }

    /// <summary>
    /// Submit button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnSubmit_Click(object sender, EventArgs e)
    {
      if (tbFirstName.Text != string.Empty && tbLastName.Text != string.Empty && tbPhoneNumber.Text != string.Empty
         && tbAddress.Text != string.Empty && tbVisitComments.Text != string.Empty && cbTakenBy.Text != string.Empty
         && cbJobStatus.Text != string.Empty && cbAssignedTech.Text != string.Empty && dtpTime.Text != string.Empty
         && dtpDate.Text != string.Empty)
      {
        if (m_update == false)
        {
          DatabaseInsert();
          DialogResult = DialogResult.Yes;
        }
        else
        {
          DatabaseUpdate();
          DialogResult = DialogResult.Yes;
        }
      }
      else
      {
        MessageBox.Show("All fields are required.");
      }
    }

    /// <summary>
    /// Cancel button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.No;
    }

    /// <summary>
    /// Database insert
    /// </summary>
    private void DatabaseInsert()
    {
      Dictionary<string, string> data = new Dictionary<string, string>();

      data.Add("comments", tbVisitComments.Text.ToString());

      data.Add("callTaker", cbTakenBy.SelectedItem.ToString());
      data.Add("status", cbJobStatus.SelectedItem.ToString());
      data.Add("assignedTech", cbAssignedTech.SelectedItem.ToString());

      data.Add("visitTime", dtpTime.Value.ToShortTimeString());
      data.Add("visitDate", dtpDate.Value.ToShortDateString());
      data.Add("client", m_tempClientId);

      m_queries.InsertQuery(data);
    }

    /// <summary>
    /// Database update
    /// </summary>
    private void DatabaseUpdate()
    {
      Dictionary<string, string> data = new Dictionary<string, string>();
      data.Add("comments", tbVisitComments.Text.ToString());

      data.Add("callTaker", cbTakenBy.SelectedItem.ToString());
      data.Add("status", cbJobStatus.SelectedItem.ToString());
      data.Add("assignedTech", cbAssignedTech.SelectedItem.ToString());

      data.Add("visitTime", dtpTime.Value.ToShortTimeString());
      data.Add("visitDate", dtpDate.Value.ToShortDateString());
      data.Add("client", m_tempClientId);

      m_queries.UpdateQuery(data, lbTicketNumber.Text);      
    }
  }
}
