//-----------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="ParrishCorp">
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
  /// User login class
  /// </summary>
  public partial class UserLogin : Form
  {
    /// <summary>Check for authentication errors</summary>
    private bool m_error = false;

    /// <summary>Holder for the employee</summary>
    public Worker Employee { get; set; }

    /// <summary>
    /// Initializes a new instance of the UserLogin class
    /// </summary>
    public UserLogin()
    {
      InitializeComponent();
      Employee = new Worker();
    }

    /// <summary>
    /// Exit button event
    /// </summary>
    /// <param name="sender">Sender object</param>
    /// <param name="e">e parameters</param>
    private void BtnExit_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    /// <summary>
    /// Login button event
    /// </summary>
    /// <param name="sender">Sender Object</param>
    /// <param name="e">e parameters</param>
    private void BtnLogin_Click(object sender, EventArgs e)
    {
      LoginAction();
    }

    /// <summary>
    /// Login procedure
    /// </summary>
    private void LoginAction()
    {
      DatabaseQuery query = new DatabaseQuery();
      Dictionary<string, Worker> queryReturn = query.QueryForAllWorkers();

      if (queryReturn.ContainsKey(tbEmpID.Text))
      {
        if (tbPassword.Text == queryReturn[tbEmpID.Text].Password)
        {
          Employee = queryReturn[tbEmpID.Text];
          m_error = false;
        }
        else
        {
          m_error = true;
        }
      }
      else
      {
        m_error = true;
      }

      if (m_error == false)
      {
        DialogResult = DialogResult.Yes;
      }
      else
      {
        tbEmpID.Text = string.Empty;
        tbPassword.Text = string.Empty;
        MessageBox.Show("Username and/or Password Incorrect", "Invalid Login", MessageBoxButtons.OK);
      }
    }
  }
}
