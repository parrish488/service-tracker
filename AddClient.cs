//-----------------------------------------------------------------------
// <copyright file="AddClient.cs" company="ParrishCorp">
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
  /// User interface for adding and editing a client
  /// </summary>
  public partial class AddClient : Form
  {
    /// <summary>Client to be added</summary>
    private Client m_client = new Client();

    /// <summary>Temporary client ID</summary>
    private string m_tempClientId;

    /// <summary>Database query object</summary>
    private DatabaseQuery m_queries = new DatabaseQuery();

    /// <summary>
    /// Initializes a new instance of the AddClient class
    /// </summary>
    public AddClient()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Initializes a new instance of the AddClient class
    /// </summary>
    /// <param name="clientName">Client to find</param>
    public AddClient(string clientName)
    {
      InitializeComponent();

      // send clients name to be queried.
      if (clientName != null)
      {
        Query_Customer(clientName);
        btnAddCall.Enabled = true;
        btnEdit.Enabled = true;
      }
    }

    /// <summary>
    /// Button event for submit button
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnSubmit_Click(object sender, EventArgs e)
    {
      // Check to make sure that no required textbox is empty.
      if (tbFirstName.Text != string.Empty && tbLastName.Text != string.Empty 
        && tbPhone.Text != string.Empty && tbAddress.Text != string.Empty)
      {
        if (lblNumber.Text != string.Empty)
        {
          // run query to update client if they already exist
          Update_Client();
          DialogResult = DialogResult.Yes;
        }
        else
        {
          // run add query to add client info to database
          Insert_Client();
          DialogResult = DialogResult.Yes;
        }
      }
    }

    /// <summary>
    /// Button event for adding a service call
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnAddCall_Click(object sender, EventArgs e)
    {
      ServiceCallGUI ticket = new ServiceCallGUI(m_tempClientId);
      DialogResult dialogResult = ticket.ShowDialog();

      if (ticket.DialogResult == DialogResult.Yes)
      {
        lbServiceCalls.Items.Clear();

        Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(m_queries.QueryForAllClients(-1));

        foreach (KeyValuePair<int, ServiceCall> pair in tickets)
        {
          if (pair.Value.ClientId.ToString() == lblNumber.Text.ToString())
          {
            lbServiceCalls.Items.Add(pair.Value.Date + " @ " + pair.Value.Time);
          }
        }
      }
      else
      {
        // Do nothing?
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
    /// Insert a new client
    /// </summary>
    private void Insert_Client()
    {
      Dictionary<string, string> data = new Dictionary<string, string>();

      data.Add("firstName", tbFirstName.Text);
      data.Add("lastName", tbLastName.Text);
      data.Add("address", tbAddress.Text);
      data.Add("phone", tbPhone.Text);

      m_queries.InsertQuery(data);
    }

    /// <summary>
    /// Query for customer by name
    /// </summary>
    /// <param name="name">Customer name</param>
    private void Query_Customer(string name)
    {
      Dictionary<int, Client> clients = m_queries.QueryForAllClients(-1);
      Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(clients);

      foreach (KeyValuePair<int, Client> pair in clients)
      {
        if ((pair.Value.FirstName + " " + pair.Value.LastName) == name)
        {
          lblNumber.Text = pair.Value.Id.ToString();
          tbFirstName.Text = pair.Value.FirstName;
          tbLastName.Text = pair.Value.LastName;
          tbAddress.Text = pair.Value.Address;
          tbPhone.Text = pair.Value.PhoneNumber;
          m_tempClientId = pair.Value.Id.ToString();

          foreach (KeyValuePair<int, ServiceCall> pairOther in tickets)
          {
            if (pairOther.Value.ClientId == pair.Value.Id)
            {
              lbServiceCalls.Items.Add(pairOther.Value.Date + " @ " + pairOther.Value.Time);
            }
          }
        }
      }
    }

    /// <summary>
    /// Update client
    /// </summary>
    private void Update_Client()
    {
      Dictionary<string, string> data = new Dictionary<string, string>();
      data.Add("firstName", tbFirstName.Text);
      data.Add("lastName", tbLastName.Text);
      data.Add("address", tbAddress.Text);
      data.Add("phone", tbPhone.Text);

      m_queries.UpdateQuery(data, lblNumber.Text);
    }

    /// <summary>
    /// Button event for edit button
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnEdit_Click(object sender, EventArgs e)
    {
      if (lbServiceCalls.SelectedItems.Count == 0)
      {
        MessageBox.Show("Select a Service Call");
      }
      else
      {
        string[] segments = lbServiceCalls.SelectedItem.ToString().Split(' ');
        ServiceCallGUI ticket = new ServiceCallGUI(m_tempClientId, segments[0]);
        DialogResult dialogResult = ticket.ShowDialog();

        if (ticket.DialogResult == DialogResult.Yes)
        {
          lbServiceCalls.Items.Clear();

          Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(m_queries.QueryForAllClients(-1));

          foreach (KeyValuePair<int, ServiceCall> pair in tickets)
          {
            if (pair.Value.ClientId.ToString() == lblNumber.Text)
            {
              lbServiceCalls.Items.Add(pair.Value.Date + " @ " + pair.Value.Time);
            }
          }
        }
      }
    }
  }
}
