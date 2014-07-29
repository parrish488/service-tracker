//-----------------------------------------------------------------------
// <copyright file="Authenticator.cs" company="ParrishCorp">
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
        private bool error = false;

        /// <summary>Holder for the employee</summary>
        private Worker employee = new Worker();

        /// <summary>Collection of employees based on user ID</summary>
        private Dictionary<int, Worker> employees = new Dictionary<int, Worker>();

        /// <summary>
        /// Initializes a new instance of the UserLogin class
        /// </summary>
        /// <param name="emps">employee database</param>
        public UserLogin(Dictionary<int, Worker> emps)
        {
            InitializeComponent();
            employees = emps;
        }

        /// <summary>
        /// Gets the employee that is signing in
        /// </summary>
        /// <returns>worker object</returns>
        public Worker GetEmployee()
        {
            return employee;
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
            int temp;
            if (int.TryParse(tbEmpID.Text, out temp) && employees.ContainsKey(int.Parse(tbEmpID.Text)))
            {
                if (tbPassword.Text == employees[int.Parse(tbEmpID.Text)].Password)
                {
                    employee = employees[int.Parse(tbEmpID.Text)];
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
            else
            {
                error = true;
            }           

            if (error == false)
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
