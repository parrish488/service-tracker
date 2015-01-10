//-----------------------------------------------------------------------
// <copyright file="Statistics.cs" company="ParrishCorp">
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
  /// Statistics class
  /// </summary>
  public partial class Statistics : Form
  {
    /// <summary>Completed counter</summary>
    private int m_counter = 0;

    /// <summary>Completed counter</summary>
    private string m_tempName;

    /// <summary>Query object</summary>
    private DatabaseQuery queries = new DatabaseQuery();

    /// <summary>
    /// Initializes a new instance of the Statistics class
    /// </summary>
    public Statistics()
    {
      InitializeComponent();
      DatabaseQuery();
    }

    /// <summary>
    /// Query for employees
    /// </summary>
    private void DatabaseQuery()
    {
      Dictionary<string, Worker> workers = queries.QueryForAllWorkers("null");

      foreach (KeyValuePair<string, Worker> pair in workers)
      {
        cbEmployee.Items.Add(pair.Value.FirstName + " " + pair.Value.LastName);
      }
    }

    /// <summary>
    /// Close button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnClose_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Yes;
    }

    /// <summary>
    /// Display button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnDisplay_Click(object sender, EventArgs e)
    {
      m_tempName = cbEmployee.SelectedItem.ToString();
      m_counter = 0;

      Dictionary<int, ServiceCall> tickets = queries.QueryForAllServiceCalls(queries.QueryForAllClients(-1));

      foreach (KeyValuePair<int, ServiceCall> pair in tickets)
      {
        if (pair.Value.Tech == m_tempName && pair.Value.JobStatus == "Visit Completed")
        {
          m_counter++;
        }
      }

      lbCallCompleted.Text = "Number of Service calls completed: " + m_counter;
    }
  }
}