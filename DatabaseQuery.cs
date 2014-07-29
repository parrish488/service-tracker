using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTracker
{
    class DatabaseQuery
    {
        public Dictionary<int, Worker> QueryForAllWorkers()
        {
            Dictionary<int, Worker> tempEmployees = new Dictionary<int, Worker>();            

            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable employees;
                string query = "select * from Worker";
                employees = db.GetDataTable(query);

                foreach (DataRow r in employees.Rows)
                {
                    Worker tempWorker = new Worker();
                    tempWorker.FirstName = r["firstName"].ToString();
                    tempWorker.LastName = r["lastName"].ToString();
                    tempWorker.WorkerType = r["type"].ToString();
                    tempWorker.FirstName = r["firstName"].ToString();
                    tempWorker.Username = r["username"].ToString();
                    tempWorker.Password = r["password"].ToString();
                    tempWorker.ID = int.Parse(r["id"].ToString());
                    tempWorker.CorrectiveActions = r["correctiveActions"].ToString();
                    tempWorker.ActionStatus = r["actionStatus"].ToString();

                    tempEmployees.Add(tempWorker.ID, tempWorker);
                }
            }
            catch (Exception fail)
            {
                string error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }       

            return tempEmployees;
        }

        public Dictionary<int, Client> QueryForAllClients()
        {
            Dictionary<int, Client> tempClients = new Dictionary<int, Client>();

            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable employees;
                string query = "select * from Client";
                employees = db.GetDataTable(query);

                foreach (DataRow r in employees.Rows)
                {
                    Client tempClient = new Client();
                    tempClient.FirstName = r["firstName"].ToString();
                    tempClient.LastName = r["lastName"].ToString();
                    tempClient.FirstName = r["firstName"].ToString();
                    tempClient.Id = int.Parse(r["id"].ToString());
                    tempClient.Address = r["address"].ToString();
                    tempClient.PhoneNumber = r["phone"].ToString();

                    tempClients.Add(tempClient.Id, tempClient);
                }
            }
            catch (Exception fail)
            {
                string error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }

            return tempClients;
        }

        public Dictionary<int, ServiceCall> QueryForAllServiceCalls(Dictionary<int, Client> clientList)
        {
            Dictionary<int, ServiceCall> tempServiceCalls = new Dictionary<int, ServiceCall>();

            SQLiteDatabase db;

            try
            {
                db = new SQLiteDatabase();
                DataTable tickets;

                String ticketQuery = "select * from ServiceTicket";
                tickets = db.GetDataTable(ticketQuery);


                foreach (DataRow r in tickets.Rows)
                {
                    ServiceCall visit = new ServiceCall();
                    visit.Id = int.Parse(r["id"].ToString());
                    visit.FirstName = clientList[int.Parse(r["client"].ToString())].FirstName;
                    visit.LastName = clientList[int.Parse(r["client"].ToString())].LastName;
                    visit.Address = clientList[int.Parse(r["client"].ToString())].Address;
                    visit.Phone = clientList[int.Parse(r["client"].ToString())].PhoneNumber;
                    visit.Comments = r["comments"].ToString();
                    visit.Date = r["visitDate"].ToString();
                    visit.Time = r["visitTime"].ToString();                  
                    visit.JobStatus = r["status"].ToString();
                    visit.CallTaker = r["callTaker"].ToString();
                    visit.Tech = r["assignedTech"].ToString();

                    tempServiceCalls.Add(visit.Id, visit);
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }

            return tempServiceCalls;
        }
    }
}
