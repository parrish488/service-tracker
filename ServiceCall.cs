//-----------------------------------------------------------------------
// <copyright file="ServiceCall.cs" company="ParrishCorp">
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
  /// Service call class
  /// </summary>
  public class ServiceCall
  {
    /// <summary>Gets or sets the service call id</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets the service call client id</summary>
    public int ClientId { get; set; }

    /// <summary>Gets or sets the service call client first name</summary>
    public string FirstName { get; set; }

    /// <summary>Gets or sets the service call client last name</summary>
    public string LastName { get; set; }

    /// <summary>Gets or sets the service call client address</summary>
    public string Address { get; set; }

    /// <summary>Gets or sets the service call client phone</summary>
    public string Phone { get; set; }

    /// <summary>Gets or sets the service call comments</summary>
    public string Comments { get; set; }

    /// <summary>Gets or sets the service call date</summary>
    public string Date { get; set; }

    /// <summary>Gets or sets the service call time</summary>
    public string Time { get; set; }

    /// <summary>Gets or sets the service call call taker</summary>
    public string CallTaker { get; set; }

    /// <summary>Gets or sets the service call job status</summary>
    public string JobStatus { get; set; }

    /// <summary>Gets or sets the service call assigned tech</summary>
    public string Tech { get; set; }
  }
}
