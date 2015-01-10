//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="ParrishCorp">
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceTracker
{
  /// <summary>
  /// Database query class for holding queries
  /// </summary>
  public class DatabaseQuery
  {
    /// <summary>
    /// Query for all workers
    /// </summary>
    /// <param name="worker">Worker to look for. "null" returns all, any other number returns specific worker</param>
    /// <returns>Dictionary of workers</returns>
    public Dictionary<string, Worker> QueryForAllWorkers(string worker)
    {
      Dictionary<string, Worker> tempEmployees = new Dictionary<string, Worker>();

      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable employees;
        string query = "select * from Worker";
        employees = db.GetDataTable(query);

        if (worker == "null")
        {
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

            tempEmployees.Add(tempWorker.Username, tempWorker);
          }
        }
        else
        {
          foreach (DataRow r in employees.Rows)
          {
            if (r["username"].ToString() == worker)
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

              tempEmployees.Add(tempWorker.Username, tempWorker);
            }
          }
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

    /// <summary>
    /// Query for all clients
    /// </summary>
    /// <param name="clientId">-1 returns all clients, any other number returns specific client</param>
    /// <returns>Dictionary of clients</returns>
    public Dictionary<int, Client> QueryForAllClients(int clientId)
    {
      // -1 for all, any other number is for a specified client
      Dictionary<int, Client> tempClients = new Dictionary<int, Client>();

      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable employees;
        string query = "select * from Client";
        employees = db.GetDataTable(query);

        if (clientId == -1)
        {
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
        else
        {
          foreach (DataRow r in employees.Rows)
          {
            if (int.Parse(r["id"].ToString()) == clientId)
            {
              Client tempClient = new Client();
              tempClient.FirstName = r["firstName"].ToString();
              tempClient.LastName = r["lastName"].ToString();
              tempClient.Id = int.Parse(r["id"].ToString());
              tempClient.Address = r["address"].ToString();
              tempClient.PhoneNumber = r["phone"].ToString();

              tempClients.Add(tempClient.Id, tempClient);
            }
          }
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

    /// <summary>
    /// Query for all service calls
    /// </summary>
    /// <param name="clientList">Dictionary of clients</param>
    /// <returns>Dictionary of service calls</returns>
    public Dictionary<int, ServiceCall> QueryForAllServiceCalls(Dictionary<int, Client> clientList)
    {
      ////-1 is for all tickets, any other number is for specified ticket
      Dictionary<int, ServiceCall> tempServiceCalls = new Dictionary<int, ServiceCall>();

      SQLiteDatabase db;

      try
      {
        db = new SQLiteDatabase();
        DataTable tickets;

        string ticketQuery = "select * from ServiceTicket";
        tickets = db.GetDataTable(ticketQuery);

        foreach (DataRow r in tickets.Rows)
        {
          ServiceCall visit = new ServiceCall();
          visit.Id = int.Parse(r["id"].ToString());
          visit.ClientId = int.Parse(r["client"].ToString());
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
        string error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }

      return tempServiceCalls;
    }

    /// <summary>
    /// Query to update database
    /// </summary>
    /// <param name="updateData">Data to be updated</param>
    /// <param name="format">Format string</param>
    public void UpdateQuery(Dictionary<string, string> updateData, string format)
    {
      SQLiteDatabase db = new SQLiteDatabase();

      try
      {
        db.Update("ServiceTicket", updateData, string.Format("ServiceTicket.Id = {0}", format));
      }
      catch (Exception fail)
      {
        string error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }
    }

    /// <summary>
    /// Query to insert data
    /// </summary>
    /// <param name="insertData">Data to be inserted</param>
    public void InsertQuery(Dictionary<string, string> insertData)
    {
      SQLiteDatabase db = new SQLiteDatabase();

      try
      {
        db.Insert("ServiceTicket", insertData);
      }
      catch (Exception fail)
      {
        string error = "The following error has occurred:\n\n";
        error += fail.Message.ToString() + "\n\n";
        MessageBox.Show(error);
      }
    }
  }
}
