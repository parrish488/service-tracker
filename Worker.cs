//-----------------------------------------------------------------------
// <copyright file="Worker.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
using System;

namespace ServiceTracker
{
  /// <summary>
  /// Worker class to keep track of an employee
  /// </summary>
  public class Worker
  {
    /// <summary>
    /// Gets or sets the worker id
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the first name
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the username
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Gets or sets the password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the worker type
    /// </summary>
    public string WorkerType { get; set; }

    /// <summary>
    /// Gets or sets corrective actions
    /// </summary>
    public string CorrectiveActions { get; set; }

    /// <summary>
    /// Gets or sets action status
    /// </summary>
    public string ActionStatus { get; set; }
  }
}
