using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ServiceTracker
{
    public partial class ServiceTracker : Form
    {
        Session session = new Session();

        private DatabaseQuery query = new DatabaseQuery();

        private Dictionary<int, Worker> employees = new Dictionary<int, Worker>();

        private Dictionary<int, Client> clients = new Dictionary<int, Client>();

        private Dictionary<int, ServiceCall> serviceCalls = new Dictionary<int, ServiceCall>();

        public ServiceTracker()
        {
            InitializeComponent();
            employees = query.QueryForAllWorkers();
            clients = query.QueryForAllClients();
            serviceCalls = query.QueryForAllServiceCalls(clients);

            UserAuthentication();            

            #region TimeKeeper

            //This code keeps the date and time updating
            tbDate.Text = DateTime.Now.ToLongDateString();
            tbTime.Text = DateTime.Now.ToLongTimeString();
            Timer tmr = new Timer();
            tmr.Interval = 1000;//ticks every 1 second
            tmr.Tick += new EventHandler(Timer_Elapsed);
            tmr.Start();

            #endregion
        }
          
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       

        //Event for updating to time and date
        private void Timer_Elapsed(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToLongTimeString();
            tbDate.Text = DateTime.Now.ToLongDateString();
        }

        private void LoadManagerMainScreen()
        {
            MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
            lblWelcome.Text = "Welcome " + session.Employee.FirstName + " " + session.Employee.LastName;
            lblTableDescription.Text = "Pending Ticket Closures";
            btnUserTask1.Text = "Close Tickets";
            btnUserTask2.Text = "Corrective Actions Needed";
            btnUserTask3.Text = "Manage Employees";
            //Manager Menu
            closeTicketsToolStripMenuItem.Enabled = true;
            correctiveActionsToolStripMenuItem.Enabled = true;
            manageEmployeesToolStripMenuItem.Enabled = true;
            //Technician Menu
            completeVisitToolStripMenuItem.Enabled = true;
            viewUnassignedVisitsToolStripMenuItem.Enabled = true;
            statisticsToolStripMenuItem.Enabled = true;
            //CSR Menu
            viewClientsToolStripMenuItem1.Enabled = true;
            scheduleVisitsToolStripMenuItem.Enabled = true;
            addCorrectiveActionToolStripMenuItem.Enabled = true;

            ManagerCloseUpdate();
        }

        private void LoadTechnicianMainScreen()
        {
            MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
            lblWelcome.Text = "Welcome " + session.Employee.FirstName + " " + session.Employee.LastName;
            lblTableDescription.Text = "Pending Service Calls";
            btnUserTask1.Text = "Complete Visit";
            btnUserTask2.Text = "View Unassigned Visits";
            btnUserTask3.Text = "Statistics";
            //Manager Menu
            closeTicketsToolStripMenuItem.Enabled = false;
            correctiveActionsToolStripMenuItem.Enabled = false;
            manageEmployeesToolStripMenuItem.Enabled = false;
            //Technician Menu
            completeVisitToolStripMenuItem.Enabled = true;
            viewUnassignedVisitsToolStripMenuItem.Enabled = true;
            statisticsToolStripMenuItem.Enabled = true;
            //CSR Menu
            viewClientsToolStripMenuItem1.Enabled = true;
            scheduleVisitsToolStripMenuItem.Enabled = true;
            addCorrectiveActionToolStripMenuItem.Enabled = true;

            TechnicianPendingUpdate();
        }

        private void LoadCustServMainScreen()
        {
            MessageBox.Show("Login Success!", "Log In", MessageBoxButtons.OK);
            lblWelcome.Text = "Welcome " + session.Employee.FirstName + " " + session.Employee.LastName;
            lblTableDescription.Text = "Unassigned Service Calls";
            btnUserTask1.Text = "View Clients";
            btnUserTask2.Text = "Schedule Visits";
            btnUserTask3.Text = "Add Corrective Action";
            //Manager Menu
            closeTicketsToolStripMenuItem.Enabled = false;
            correctiveActionsToolStripMenuItem.Enabled = false;
            manageEmployeesToolStripMenuItem.Enabled = false;
            //Technician Menu
            completeVisitToolStripMenuItem.Enabled = false;
            viewUnassignedVisitsToolStripMenuItem.Enabled = false;
            statisticsToolStripMenuItem.Enabled = false;
            //CSR Menu
            viewClientsToolStripMenuItem1.Enabled = true;
            scheduleVisitsToolStripMenuItem.Enabled = true;
            addCorrectiveActionToolStripMenuItem.Enabled = true;

            CSRUnassignedUpdate();

        }

        private void UserAuthentication()
        {
            UserLogin login = new UserLogin(employees);
            DialogResult dialogResult = login.ShowDialog();
            
            if (login.DialogResult == DialogResult.Yes)
            {
                session.Employee = login.GetEmployee();
                session.StartSession(System.DateTime.Now.ToShortDateString(), System.DateTime.Now.ToLongTimeString());

                if (session.Employee.WorkerType == "Manager")
                {
                    LoadManagerMainScreen();
                }
                else if (session.Employee.WorkerType == "Technician")
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

        private void dgvUserData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //3 Functions
            //One for Manager
            //One for Technician
            //One for CSR
            //Each will show needed tasks
        }

        private void btnUserTask1_Click(object sender, EventArgs e)
        {
            if (session.Employee.WorkerType == "Manager")
            {
                InfoAccessor information = new InfoAccessor("CloseTicket");
                DialogResult dialogResult = information.ShowDialog();

                if (information.DialogResult == DialogResult.Yes)
                {
                    OpenTicketWindow(information.name, information.date);
                    ManagerCloseUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }

            else if (session.Employee.WorkerType == "Technician")
            {
                InfoAccessor information = new InfoAccessor("CompleteTicket", session.Employee.FirstName + " " + session.Employee.LastName);
                DialogResult dialogResult = information.ShowDialog();

                if(information.DialogResult == DialogResult.Yes)
                {
                    OpenTicketWindow(information.name, information.date);
                    TechnicianPendingUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }

            else
            {
                InfoAccessor information = new InfoAccessor("Client");
                DialogResult dialogResult = information.ShowDialog();

                if(information.DialogResult == DialogResult.Yes)
                {
                    OpenClientWindow(information.name);
                    CSRUnassignedUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                        CSRUnassignedUpdate();
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                        CSRUnassignedUpdate();
                    }
                }
            }
            
        }

        private void btnUserTask2_Click(object sender, EventArgs e)
        {
            if (session.Employee.WorkerType == "Manager")
            {
                InfoAccessor information = new InfoAccessor("Corrective");
                DialogResult dialogResult = information.ShowDialog();

                if (information.DialogResult == DialogResult.Yes)
                {
                    OpenEmployeeWindow(information.name);
                    ManagerCloseUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }

            else if (session.Employee.WorkerType == "Technician")
            {
                InfoAccessor information = new InfoAccessor("UnassignedTicket");
                DialogResult dialogResult = information.ShowDialog();

                if (information.DialogResult == DialogResult.Yes)
                {
                    OpenTicketWindow(information.name, information.date);
                    TechnicianPendingUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
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
                    OpenClientWindow(information.name);
                    CSRUnassignedUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                        CSRUnassignedUpdate();
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                        CSRUnassignedUpdate();
                    }
                }
            }
        }

        private void btnUserTask3_Click(object sender, EventArgs e)
        {
            if (session.Employee.WorkerType == "Manager")
            {
                InfoAccessor information = new InfoAccessor("Employee");
                DialogResult dialogResult = information.ShowDialog();

                if (information.DialogResult == DialogResult.Yes)
                {
                    OpenEmployeeWindow(information.name);
                    ManagerCloseUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }


            else if (session.Employee.WorkerType == "Technician")
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
                    OpenEmployeeWindow(information.name);
                    ManagerCloseUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }
        }

        private void OpenTicketWindow(string name, string date)
        {
            ServiceCallGUI serviceCall = new ServiceCallGUI(name, date);
            DialogResult dialogResult = serviceCall.ShowDialog();

            if (serviceCall.DialogResult == DialogResult.Yes)
            {
                if (session.Employee.WorkerType == "Manager")
                {
                    ManagerCloseUpdate();
                }
                else if (session.Employee.WorkerType == "Technician")
                {
                    TechnicianPendingUpdate();
                }
            }
        }

        private void OpenEmployeeWindow(string name)
        {
            AddEmployee employee = new AddEmployee(name);
            DialogResult dialogResult = employee.ShowDialog();

            if (employee.DialogResult == DialogResult.Yes)
            {
                ManagerCloseUpdate();
            }
        }

        private void OpenClientWindow(string name)
        {
            AddClient client = new AddClient(name);
            DialogResult dialogResult = client.ShowDialog();

            if (client.DialogResult == DialogResult.Yes)
            {
                switch (session.Employee.WorkerType)
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

        #region ManagerMenu

        private void closeTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (session.Employee.WorkerType == "Manager")
            {
                InfoAccessor information = new InfoAccessor("CloseTicket");
                DialogResult dialogResult = information.ShowDialog();

                if (information.DialogResult == DialogResult.Yes)
                {
                    OpenTicketWindow(information.name, information.date);
                    ManagerCloseUpdate();
                }
                else if (information.DialogResult == DialogResult.OK)
                {
                    if (information.employee == true)
                    {
                        OpenEmployeeWindow(null);
                    }
                    if (information.client == true)
                    {
                        OpenClientWindow(null);
                    }
                }
            }
        }

        private void correctiveActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("Corrective");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                OpenEmployeeWindow(information.name);
                ManagerCloseUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                }
            }
        }

        private void manageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("Employee");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                OpenEmployeeWindow(information.name);
                ManagerCloseUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                }
            }
        }

        #endregion

        #region TechnicianMenu

        private void completeVisitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("CompleteTicket", session.Employee.FirstName + " " + session.Employee.LastName);
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                OpenTicketWindow(information.name, information.date);
                TechnicianPendingUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                }
            }
        }

        private void viewUnassignedVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("UnassignedTicket");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                OpenTicketWindow(information.name, information.date);
                TechnicianPendingUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                }
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics();
            DialogResult dialogResult = stats.ShowDialog();
        }

        #endregion

        #region CSRMenu

        private void viewClientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("Client");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                //Take client number, then use it to find the info for the specified client
                OpenClientWindow(information.name);
                CSRUnassignedUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                    CSRUnassignedUpdate();
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                    CSRUnassignedUpdate();
                }
            }
        }

        private void scheduleVisitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("Client");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                OpenClientWindow(information.name);
                CSRUnassignedUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                    CSRUnassignedUpdate();
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                    CSRUnassignedUpdate();
                }
            }
        }

        private void addCorrectiveActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoAccessor information = new InfoAccessor("Employee");
            DialogResult dialogResult = information.ShowDialog();

            if (information.DialogResult == DialogResult.Yes)
            {
                //Take employee number, then use it to find the info for the specified employee
                OpenEmployeeWindow(information.name);
                CSRUnassignedUpdate();
            }
            else if (information.DialogResult == DialogResult.OK)
            {
                if (information.employee == true)
                {
                    OpenEmployeeWindow(null);
                    CSRUnassignedUpdate();
                }
                if (information.client == true)
                {
                    OpenClientWindow(null);
                    CSRUnassignedUpdate();
                }
            }
        }

        #endregion

        private void ManagerCloseUpdate()
        {
            dgvUserData.Rows.Clear();
            
            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable tickets;
                DataTable clients;

                String ticketQuery = "select * from ServiceTicket";
                String clientQuery = "select * from Client";
                tickets = db.GetDataTable(ticketQuery);
                clients = db.GetDataTable(clientQuery);

                foreach (DataRow r in tickets.Rows)
                {
                    if (r["status"].ToString() == "Visit Completed")
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvUserData);
                        foreach (DataRow rw in clients.Rows)
                        {
                            //Add Ticket to be closed
                            if (r["client"].ToString() == rw["id"].ToString())
                            {
                                row.Cells[0].Value = rw["firstName"].ToString() + " " + rw["lastName"].ToString();
                            }
                        }
                        row.Cells[1].Value = r["visitDate"].ToString();
                        row.Cells[2].Value = r["visitTime"].ToString();
                        dgvUserData.Rows.Add(row);
                        dgvUserData.AutoResizeColumns();
                        dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }
            dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void TechnicianPendingUpdate()
        {
            dgvUserData.Rows.Clear();

            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable tickets;
                DataTable clients;

                String ticketQuery = "select * from ServiceTicket";
                String clientQuery = "select * from Client";
                tickets = db.GetDataTable(ticketQuery);
                clients = db.GetDataTable(clientQuery);

                foreach (DataRow r in tickets.Rows)
                {
                    if (r["status"].ToString() == "Assigned")
                    {
                        if (r["assignedTech"].ToString() == session.Employee.FirstName + " " + session.Employee.LastName)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dgvUserData);
                            foreach (DataRow rw in clients.Rows)
                            {
                                //Add Ticket to be closed
                                if (r["client"].ToString() == rw["id"].ToString())
                                {
                                    row.Cells[0].Value = rw["firstName"].ToString() + " " + rw["lastName"].ToString();
                                }
                            }
                            row.Cells[1].Value = r["visitDate"].ToString();
                            row.Cells[2].Value = r["visitTime"].ToString();
                            dgvUserData.Rows.Add(row);
                            dgvUserData.AutoResizeColumns();
                            dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
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
            dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void CSRUnassignedUpdate()
        {
            dgvUserData.Rows.Clear();

            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable tickets;
                DataTable clients;

                String ticketQuery = "select * from ServiceTicket";
                String clientQuery = "select * from Client";
                tickets = db.GetDataTable(ticketQuery);
                clients = db.GetDataTable(clientQuery);

                foreach (DataRow r in tickets.Rows)
                {
                    if (r["status"].ToString() == "Unassigned")
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dgvUserData);
                        foreach (DataRow rw in clients.Rows)
                        {
                            //Add Ticket to be closed
                            if (r["client"].ToString() == rw["id"].ToString())
                            {
                                row.Cells[0].Value = rw["firstName"].ToString() + " " + rw["lastName"].ToString();
                            }
                        }
                        row.Cells[1].Value = r["visitDate"].ToString();
                        row.Cells[2].Value = r["visitTime"].ToString();
                        dgvUserData.Rows.Add(row);
                        dgvUserData.AutoResizeColumns();
                        dgvUserData.Sort(dgvUserData.Columns[1], ListSortDirection.Ascending);
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }
            dgvUserData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAuthentication();            
        }
    }
}
