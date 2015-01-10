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

namespace ServiceTracker
{
  /// <summary>
  /// Client class
  /// </summary>
  public class Client
  {
    /// <summary>Gets or sets Client ID</summary>
    public int Id { get; set; }

    /// <summary>Gets or sets Client First Name</summary>
    public string FirstName { get; set; }

    /// <summary>Gets or sets Client Last Name</summary>
    public string LastName { get; set; }

    /// <summary>Gets or sets Client Phone number</summary>
    public string PhoneNumber { get; set; }

    /// <summary>Gets or sets Client Address</summary>
    public string Address { get; set; }
  }
}
