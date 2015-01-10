﻿//-----------------------------------------------------------------------
// <copyright file="SQLiteDatabase.cs" company="ParrishCorp">
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
using System.Data.SQLite;
using System.Windows.Forms;

namespace ServiceTracker
{
  /// <summary>
  /// SQLite Database interface
  /// </summary>
  public class SQLiteDatabase
  {
    /// <summary>Database connection</summary>
    private string dbConnection;

    /// <summary>
    /// Initializes a new instance of the SQLiteDatabase class
    /// </summary>
    public SQLiteDatabase()
    {
      dbConnection = "Data Source=ServiceTracker.db";
    }

    /// <summary>
    /// Initializes a new instance of the SQLiteDatabase class
    /// </summary>
    /// <param name="inputFile">Database file</param>
    public SQLiteDatabase(string inputFile)
    {
      dbConnection = string.Format("Data Source={0}", inputFile);
    }

    /// <summary>
    /// Initializes a new instance of the SQLiteDatabase class
    /// </summary>
    /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
    public SQLiteDatabase(Dictionary<string, string> connectionOpts)
    {
      string str = string.Empty;
      foreach (KeyValuePair<string, string> row in connectionOpts)
      {
        str += string.Format("{0}={1}; ", row.Key, row.Value);
      }

      str = str.Trim().Substring(0, str.Length - 1);
      dbConnection = str;
    }

    /// <summary>
    /// Allows user to query database
    /// </summary>
    /// <param name="sql">Sql query to run</param>
    /// <returns>A DataTable containing the result set</returns>
    public DataTable GetDataTable(string sql)
    {
      DataTable dt = new DataTable();
      try
      {
        SQLiteConnection cnn = new SQLiteConnection(dbConnection);
        cnn.Open();
        SQLiteCommand mycommand = new SQLiteCommand(cnn);
        mycommand.CommandText = sql;
        SQLiteDataReader reader = mycommand.ExecuteReader();
        dt.Load(reader);
        reader.Close();
        cnn.Close();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }

      return dt;
    }

    /// <summary>
    /// Allows the programmer to interact with the database for purposes other than a query
    /// </summary>
    /// <param name="sql">Sql query to run</param>
    /// <returns>Number of rows updated</returns>
    public int ExecuteNonQuery(string sql)
    {
      SQLiteConnection cnn = new SQLiteConnection(dbConnection);
      cnn.Open();
      SQLiteCommand mycommand = new SQLiteCommand(cnn);
      mycommand.CommandText = sql;
      int rowsUpdated = mycommand.ExecuteNonQuery();
      cnn.Close();
      return rowsUpdated;
    }
    
    /// <summary>
    /// Allows the programmer to easily update rows in the DB
    /// </summary>
    /// <param name="tableName">The table to update</param>
    /// <param name="data">A dictionary containing Column names and their new values</param>
    /// <param name="where">The where clause for the update statement</param>
    /// <returns>A boolean true or false to signify success or failure</returns>
    public bool Update(string tableName, Dictionary<string, string> data, string where)
    {
      string vals = string.Empty;
      bool returnCode = true;
      if (data.Count >= 1)
      {
        foreach (KeyValuePair<string, string> val in data)
        {
          vals += string.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
        }

        vals = vals.Substring(0, vals.Length - 1);
      }

      try
      {
        this.ExecuteNonQuery(string.Format("update {0} set {1} where {2};", tableName, vals, where));
      }
      catch
      {
        returnCode = false;
      }

      return returnCode;
    }

    /// <summary>
    /// Allows the programmer to easily delete rows from the DB
    /// </summary>
    /// <param name="tableName">The table from which to delete</param>
    /// <param name="where">The where clause for the delete</param>
    /// <returns>A boolean true or false to signify success or failure</returns>
    public bool Delete(string tableName, string where)
    {
      bool returnCode = true;
      try
      {
        this.ExecuteNonQuery(string.Format("delete from {0} where {1};", tableName, where));
      }
      catch (Exception fail)
      {
        MessageBox.Show(fail.Message);
        returnCode = false;
      }

      return returnCode;
    }

    /// <summary>
    /// Allows the programmer to easily insert into the DB
    /// </summary>
    /// <param name="tableName">The table into which we insert the data.</param>
    /// <param name="data">A dictionary containing the column names and data for the insert.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool Insert(string tableName, Dictionary<string, string> data)
    {
      string columns = string.Empty;
      string values = string.Empty;
      bool returnCode = true;
      foreach (KeyValuePair<string, string> val in data)
      {
        columns += string.Format(" {0},", val.Key.ToString());
        values += string.Format(" '{0}',", val.Value);
      }

      columns = columns.Substring(0, columns.Length - 1);
      values = values.Substring(0, values.Length - 1);
      try
      {
        this.ExecuteNonQuery(string.Format("insert into {0}({1}) values({2});", tableName, columns, values));
      }
      catch (Exception fail)
      {
        MessageBox.Show(fail.Message);
        returnCode = false;
      }

      return returnCode;
    }

    /// <summary>
    /// Allows the programmer to easily delete all data from the DB.
    /// </summary>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool ClearDB()
    {
      DataTable tables;
      try
      {
        tables = this.GetDataTable("select NAME from SQLITE_MASTER where type='table' order by NAME;");
        foreach (DataRow table in tables.Rows)
        {
          this.ClearTable(table["NAME"].ToString());
        }

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Allows the user to easily clear all data from a specific table.
    /// </summary>
    /// <param name="table">The name of the table to clear.</param>
    /// <returns>A boolean true or false to signify success or failure.</returns>
    public bool ClearTable(string table)
    {
      try
      {
        this.ExecuteNonQuery(string.Format("delete from {0};", table));
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
