//-----------------------------------------------------------------------
// <copyright file="Session.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;

namespace ServiceTracker
{
  /// <summary>
  /// Session class used to track who logs in
  /// </summary>
  public class Session
  {
    /// <summary>
    /// Initializes a new instance of the Session class
    /// </summary>
    public Session()
    {
      Employee = new Worker();
    }

    /// <summary>
    /// Gets or sets the employee
    /// </summary>
    public Worker Employee { get; set; }

    /// <summary>
    /// Writes the employee username and the current time to a file to log who uses the program
    /// </summary>
    /// <param name="date">Current date</param>
    /// <param name="time">Current time</param>
    public void StartSession(string date, string time)
    {
      using (FileStream fileStream = new FileStream(Environment.CurrentDirectory + "\\Session Log.txt", FileMode.Append, FileAccess.Write))
      {
        using (StreamWriter sw = new StreamWriter(fileStream))
        {
          sw.WriteLine(Employee.Username + "    " + date + "   " + time);
        }
      }
    }
  }
}
