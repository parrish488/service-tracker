//-----------------------------------------------------------------------
// <copyright file="ServiceTracker.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
  /// <summary>
  /// Service tracker class
  /// </summary>
  public partial class ServiceTracker : Form
  {
    /// <summary>Session object</summary>
    private Session m_session = new Session();

    /// <summary>Query object</summary>
    private DatabaseQuery m_queries = new DatabaseQuery();

    /// <summary>
    /// Initializes a new instance of the ServiceTracker class
    /// </summary>
    public ServiceTracker()
    {
      InitializeComponent();

      UserAuthentication();

      tbDate.Text = DateTime.Now.ToLongDateString();
      tbTime.Text = DateTime.Now.ToLongTimeString();
      Timer tmr = new Timer();
      tmr.Interval = 1000;
      tmr.Tick += new EventHandler(Timer_Elapsed);
      tmr.Start();
    }

    /// <summary>
    /// User authenticator
    /// </summary>
    private void UserAuthentication()
    {
      UserLogin login = new UserLogin();
      DialogResult dialogResult = login.ShowDialog();

      if (login.DialogResult == DialogResult.Yes)
      {
        m_session.Employee = login.Employee;
        m_session.StartSession(System.DateTime.Now.ToShortDateString(), System.DateTime.Now.ToLongTimeString());

        if (m_session.Employee.WorkerType == "Manager")
        {
          LoadManagerMainScreen();
        }
        else if (m_session.Employee.WorkerType == "Technician")
        {
          LoadTechnicianMainScreen();
        }
        else
        {
          LoadCustServMainScreen();
        }
      }
      else
      {
        Application.Exit();
      }
    }

    #region Events

    /// <summary>
    /// Exit strip item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    /// <summary>
    /// Update time
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void Timer_Elapsed(object sender, EventArgs e)
    {
      tbTime.Text = DateTime.Now.ToLongTimeString();
      tbDate.Text = DateTime.Now.ToLongDateString();
    }

    /// <summary>
    /// User task 1 button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnUserTask1_Click(object sender, EventArgs e)
    {
      if (m_session.Employee.WorkerType == "Manager")
      {
        InfoAccessor information = new InfoAccessor("CloseTicket");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenTicketWindow(information.NameOther, information.Date);
          ManagerCloseUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
      else if (m_session.Employee.WorkerType == "Technician")
      {
        InfoAccessor information = new InfoAccessor("CompleteTicket", m_session.Employee.FirstName + " " + m_session.Employee.LastName);
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenTicketWindow(information.NameOther, information.Date);
          TechnicianPendingUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
      else
      {
        InfoAccessor information = new InfoAccessor("Client");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenClientWindow(information.NameOther);
          CSRUnassignedUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
            CSRUnassignedUpdate();
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
            CSRUnassignedUpdate();
          }
        }
      }
    }

    /// <summary>
    /// User task 2 button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnUserTask2_Click(object sender, EventArgs e)
    {
      if (m_session.Employee.WorkerType == "Manager")
      {
        InfoAccessor information = new InfoAccessor("Corrective");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenEmployeeWindow(information.NameOther);
          ManagerCloseUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
      else if (m_session.Employee.WorkerType == "Technician")
      {
        InfoAccessor information = new InfoAccessor("UnassignedTicket");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenTicketWindow(information.NameOther, information.Date);
          TechnicianPendingUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
      else
      {
        InfoAccessor information = new InfoAccessor("Client");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenClientWindow(information.NameOther);
          CSRUnassignedUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
            CSRUnassignedUpdate();
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
            CSRUnassignedUpdate();
          }
        }
      }
    }

    /// <summary>
    /// User task 3 button event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void BtnUserTask3_Click(object sender, EventArgs e)
    {
      if (m_session.Employee.WorkerType == "Manager")
      {
        InfoAccessor information = new InfoAccessor("Employee");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenEmployeeWindow(information.NameOther);
          ManagerCloseUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
      else if (m_session.Employee.WorkerType == "Technician")
      {
        Statistics stats = new Statistics();
        DialogResult dialogResult = stats.ShowDialog();
      }
      else
      {
        InfoAccessor information = new InfoAccessor("Employee");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenEmployeeWindow(information.NameOther);
          ManagerCloseUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
    }

    /// <summary>
    /// Logout menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      UserAuthentication();
    }

    #region ManagerMenu

    /// <summary>
    /// Close ticket menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void CloseTicketsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (m_session.Employee.WorkerType == "Manager")
      {
        InfoAccessor information = new InfoAccessor("CloseTicket");
        DialogResult dialogResult = information.ShowDialog();

        if (information.DialogResult == DialogResult.Yes)
        {
          OpenTicketWindow(information.NameOther, information.Date);
          ManagerCloseUpdate();
        }
        else if (information.DialogResult == DialogResult.OK)
        {
          if (information.Employee == true)
          {
            OpenEmployeeWindow(null);
          }

          if (information.Client == true)
          {
            OpenClientWindow(null);
          }
        }
      }
    }

    /// <summary>
    /// Corrective actions menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void CorrectiveActionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("Corrective");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenEmployeeWindow(information.NameOther);
        ManagerCloseUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
        }
      }
    }

    /// <summary>
    /// Manage employees menu item click event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void ManageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("Employee");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenEmployeeWindow(information.NameOther);
        ManagerCloseUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
        }
      }
    }

    #endregion

    #region TechnicianMenu

    /// <summary>
    /// Complete visit menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void CompleteVisitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("CompleteTicket", m_session.Employee.FirstName + " " + m_session.Employee.LastName);
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenTicketWindow(information.NameOther, information.Date);
        TechnicianPendingUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
        }
      }
    }

    /// <summary>
    /// View unassigned visits menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void ViewUnassignedVisitsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("UnassignedTicket");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenTicketWindow(information.NameOther, information.Date);
        TechnicianPendingUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
        }
      }
    }

    /// <summary>
    /// Statistics menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Statistics stats = new Statistics();
      DialogResult dialogResult = stats.ShowDialog();
    }

    #endregion

    #region CSRMenu

    /// <summary>
    /// View clients menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void ViewClientsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("Client");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenClientWindow(information.NameOther);
        CSRUnassignedUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
          CSRUnassignedUpdate();
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
          CSRUnassignedUpdate();
        }
      }
    }

    /// <summary>
    /// Schedule visits menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void ScheduleVisitsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("Client");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenClientWindow(information.NameOther);
        CSRUnassignedUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
          CSRUnassignedUpdate();
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
          CSRUnassignedUpdate();
        }
      }
    }

    /// <summary>
    /// Add corrective action menu item event
    /// </summary>
    /// <param name="sender">sender object</param>
    /// <param name="e">e arguments</param>
    private void AddCorrectiveActionToolStripMenuItem_Click(object sender, EventArgs e)
    {
      InfoAccessor information = new InfoAccessor("Employee");
      DialogResult dialogResult = information.ShowDialog();

      if (information.DialogResult == DialogResult.Yes)
      {
        OpenEmployeeWindow(information.NameOther);
        CSRUnassignedUpdate();
      }
      else if (information.DialogResult == DialogResult.OK)
      {
        if (information.Employee == true)
        {
          OpenEmployeeWindow(null);
          CSRUnassignedUpdate();
        }

        if (information.Client == true)
        {
          OpenClientWindow(null);
          CSRUnassignedUpdate();
        }
      }
    }

    #endregion

    #endregion

    #region LoadingScreens

    /// <summary>
    /// Load manager main screen
    /// </summary>
    private void LoadManagerMainScreen()
    {
      MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
      lblWelcome.Text = "Welcome " + m_session.Employee.FirstName + " " + m_session.Employee.LastName;
      lblTableDescription.Text = "Pending Ticket Closures";
      btnUserTask1.Text = "Close Tickets";
      btnUserTask2.Text = "Corrective Actions Needed";
      btnUserTask3.Text = "Manage Employees";
      //// Manager Menu
      closeTicketsToolStripMenuItem.Enabled = true;
      correctiveActionsToolStripMenuItem.Enabled = true;
      manageEmployeesToolStripMenuItem.Enabled = true;
      //// Technician Menu
      completeVisitToolStripMenuItem.Enabled = true;
      viewUnassignedVisitsToolStripMenuItem.Enabled = true;
      statisticsToolStripMenuItem.Enabled = true;
      //// CSR Menu
      viewClientsToolStripMenuItem1.Enabled = true;
      scheduleVisitsToolStripMenuItem.Enabled = true;
      addCorrectiveActionToolStripMenuItem.Enabled = true;

      ManagerCloseUpdate();
    }

    /// <summary>
    /// Load technician main screen
    /// </summary>
    private void LoadTechnicianMainScreen()
    {
      MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
      lblWelcome.Text = "Welcome " + m_session.Employee.FirstName + " " + m_session.Employee.LastName;
      lblTableDescription.Text = "Pending Service Calls";
      btnUserTask1.Text = "Complete Visit";
      btnUserTask2.Text = "View Unassigned Visits";
      btnUserTask3.Text = "Statistics";
      //// Manager Menu
      closeTicketsToolStripMenuItem.Enabled = false;
      correctiveActionsToolStripMenuItem.Enabled = false;
      manageEmployeesToolStripMenuItem.Enabled = false;
      //// Technician Menu
      completeVisitToolStripMenuItem.Enabled = true;
      viewUnassignedVisitsToolStripMenuItem.Enabled = true;
      statisticsToolStripMenuItem.Enabled = true;
      //// CSR Menu
      viewClientsToolStripMenuItem1.Enabled = true;
      scheduleVisitsToolStripMenuItem.Enabled = true;
      addCorrectiveActionToolStripMenuItem.Enabled = true;

      TechnicianPendingUpdate();
    }

    /// <summary>
    /// Load CSR main screen
    /// </summary>
    private void LoadCustServMainScreen()
    {
      MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
      lblWelcome.Text = "Welcome " + m_session.Employee.FirstName + " " + m_session.Employee.LastName;
      lblTableDescription.Text = "Unassigned Service Calls";
      btnUserTask1.Text = "View Clients";
      btnUserTask2.Text = "Schedule Visits";
      btnUserTask3.Text = "Add Corrective Action";
      //// Manager Menu
      closeTicketsToolStripMenuItem.Enabled = false;
      correctiveActionsToolStripMenuItem.Enabled = false;
      manageEmployeesToolStripMenuItem.Enabled = false;
      //// Technician Menu
      completeVisitToolStripMenuItem.Enabled = false;
      viewUnassignedVisitsToolStripMenuItem.Enabled = false;
      statisticsToolStripMenuItem.Enabled = false;
      //// CSR Menu
      viewClientsToolStripMenuItem1.Enabled = true;
      scheduleVisitsToolStripMenuItem.Enabled = true;
      addCorrectiveActionToolStripMenuItem.Enabled = true;

      CSRUnassignedUpdate();
    }

    #endregion

    #region OpenWindows

    /// <summary>
    /// Open window for tickets
    /// </summary>
    /// <param name="name">Client name</param>
    /// <param name="date">Ticket date</param>
    private void OpenTicketWindow(string name, string date)
    {
      ServiceCallGUI serviceCall = new ServiceCallGUI(name, date);
      DialogResult dialogResult = serviceCall.ShowDialog();

      if (serviceCall.DialogResult == DialogResult.Yes)
      {
        if (m_session.Employee.WorkerType == "Manager")
        {
          ManagerCloseUpdate();
        }
        else if (m_session.Employee.WorkerType == "Technician")
        {
          TechnicianPendingUpdate();
        }
      }
    }

    /// <summary>
    /// Open window for employees
    /// </summary>
    /// <param name="name">Employee name</param>
    private void OpenEmployeeWindow(string name)
    {
      AddEmployee employee = new AddEmployee(name);
      DialogResult dialogResult = employee.ShowDialog();

      if (employee.DialogResult == DialogResult.Yes)
      {
        ManagerCloseUpdate();
      }
    }

    /// <summary>
    /// Open window for clients
    /// </summary>
    /// <param name="name">Client name</param>
    private void OpenClientWindow(string name)
    {
      AddClient client = new AddClient(name);
      DialogResult dialogResult = client.ShowDialog();

      if (client.DialogResult == DialogResult.Yes)
      {
        switch (m_session.Employee.WorkerType)
        {
          case "Manager":
            ManagerCloseUpdate();
            break;
          case "Technician":
            TechnicianPendingUpdate();
            break;
          default:
            break;
        }
      }
    }

    #endregion

    #region DatagridUpdaters

    /// <summary>
    /// Manager grid updater
    /// </summary>
    private void ManagerCloseUpdate()
    {
      dgvUserData.Rows.Clear();

      Dictionary<int, Client> clients = m_queries.QueryForAllClients(-1);
      Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(clients);

      foreach (KeyValuePair<int, ServiceCall> pair in tickets)
      {
        if (pair.Value.JobStatus == "Visit Completed")
        {
          DataGridViewRow row = new DataGridViewRow();
          row.CreateCells(dgvUserData);
          foreach (KeyValuePair<int, Client> pairOther in clients)
          {
            if (pair.Value.ClientId == pairOther.Value.Id)
            {
              row.Cells[0].Value = pairOther.Value.FirstName + " " + pairOther.Value.LastName;
            }
          }

          row.Cells[1].Value = pair.Value.Date;
          row.Cells[2].Value = pair.Value.Time;
          dgvUserData.Rows.Add(row);
          dgvUserData.AutoResizeColumns();
          dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
        }
      }
      
      dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    /// <summary>
    /// Technician grid updater
    /// </summary>
    private void TechnicianPendingUpdate()
    {
      dgvUserData.Rows.Clear();

      Dictionary<int, Client> clients = m_queries.QueryForAllClients(-1);
      Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(clients);

      foreach (KeyValuePair<int, ServiceCall> pair in tickets)
      {
        if (pair.Value.JobStatus == "Assigned")
        {
          if (pair.Value.Tech == m_session.Employee.FirstName + " " + m_session.Employee.LastName)
          {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvUserData);
            foreach (KeyValuePair<int, Client> pairOther in clients)
            {
              if (pair.Value.ClientId == pairOther.Value.Id)
              {
                row.Cells[0].Value = pairOther.Value.FirstName + " " + pairOther.Value.LastName;
              }
            }

            row.Cells[1].Value = pair.Value.Date;
            row.Cells[2].Value = pair.Value.Time;
            dgvUserData.Rows.Add(row);
            dgvUserData.AutoResizeColumns();
            dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
          }
        }
      }

      dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    /// <summary>
    /// CSR grid updater
    /// </summary>
    private void CSRUnassignedUpdate()
    {
      dgvUserData.Rows.Clear();

      Dictionary<int, Client> clients = m_queries.QueryForAllClients(-1);
      Dictionary<int, ServiceCall> tickets = m_queries.QueryForAllServiceCalls(clients);

      foreach (KeyValuePair<int, ServiceCall> pair in tickets)
      {
        if (pair.Value.JobStatus == "Unassigned")
        {
          DataGridViewRow row = new DataGridViewRow();
          row.CreateCells(dgvUserData);
          foreach (KeyValuePair<int, Client> pairOther in clients)
          {
            if (pair.Value.ClientId == pairOther.Value.Id)
            {
              row.Cells[0].Value = pairOther.Value.FirstName + " " + pairOther.Value.LastName;
            }
          }

          row.Cells[1].Value = pair.Value.Date;
          row.Cells[2].Value = pair.Value.Time;
          dgvUserData.Rows.Add(row);
          dgvUserData.AutoResizeColumns();
          dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
        }
      }

      dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    }

    #endregion
  }
}
