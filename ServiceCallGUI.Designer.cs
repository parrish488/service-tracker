//-----------------------------------------------------------------------
// <copyright file="ServiceCallGUI.cs" company="ParrishCorp">
//     Copyright (c) ParrishCorp. All rights reserved.
// </copyright>
//
// <revisionHistory> 
// Jul 11, 2014     J. Parrish      Initial Implementation
// </revisionHistory> 
//-----------------------------------------------------------------------
namespace ServiceTracker
{
  /// <summary>
  /// Service call user interface designer
  /// </summary>
  public partial class ServiceCallGUI
  {
    /// <summary>First name text box</summary>
    private System.Windows.Forms.TextBox tbFirstName;

    /// <summary>Last name text box</summary>
    private System.Windows.Forms.TextBox tbLastName;

    /// <summary>Address text box</summary>
    private System.Windows.Forms.TextBox tbAddress;

    /// <summary>Phone number text box</summary>
    private System.Windows.Forms.TextBox tbPhoneNumber;

    /// <summary>Comments text box</summary>
    private System.Windows.Forms.TextBox tbVisitComments;

    /// <summary>First name label</summary>
    private System.Windows.Forms.Label lblFirstName;

    /// <summary>Last name label</summary>
    private System.Windows.Forms.Label lblLastName;

    /// <summary>Address label</summary>
    private System.Windows.Forms.Label lblAddress;

    /// <summary>Phone number label</summary>
    private System.Windows.Forms.Label lblPhone;

    /// <summary>Comments label</summary>
    private System.Windows.Forms.Label lblComments;

    /// <summary>Submit button</summary>
    private System.Windows.Forms.Button btnSubmit;

    /// <summary>Cancel button</summary>
    private System.Windows.Forms.Button btnCancel;

    /// <summary>Ticket number label</summary>
    private System.Windows.Forms.Label lblTicketNumber;

    /// <summary>Selected date</summary>
    private System.Windows.Forms.DateTimePicker dtpDate;

    /// <summary>Selected time</summary>
    private System.Windows.Forms.DateTimePicker dtpTime;

    /// <summary>Call receiver label</summary>
    private System.Windows.Forms.Label lblCSReceiver;

    /// <summary>Job status combo box</summary>
    private System.Windows.Forms.ComboBox cbJobStatus;

    /// <summary>Job status label</summary>
    private System.Windows.Forms.Label lblJobStatus;

    /// <summary>Assigned tech combo box</summary>
    private System.Windows.Forms.ComboBox cbAssignedTech;

    /// <summary>Assigned tech label</summary>
    private System.Windows.Forms.Label lblAssignedTech;

    /// <summary>Call taken by combo box</summary>
    private System.Windows.Forms.ComboBox cbTakenBy;

    /// <summary>Ticket number label</summary>
    private System.Windows.Forms.Label lbTicketNumber;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }

      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.tbFirstName = new System.Windows.Forms.TextBox();
      this.tbLastName = new System.Windows.Forms.TextBox();
      this.tbAddress = new System.Windows.Forms.TextBox();
      this.tbPhoneNumber = new System.Windows.Forms.TextBox();
      this.tbVisitComments = new System.Windows.Forms.TextBox();
      this.lblFirstName = new System.Windows.Forms.Label();
      this.lblLastName = new System.Windows.Forms.Label();
      this.lblAddress = new System.Windows.Forms.Label();
      this.lblPhone = new System.Windows.Forms.Label();
      this.lblComments = new System.Windows.Forms.Label();
      this.btnSubmit = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lblTicketNumber = new System.Windows.Forms.Label();
      this.dtpDate = new System.Windows.Forms.DateTimePicker();
      this.dtpTime = new System.Windows.Forms.DateTimePicker();
      this.lblCSReceiver = new System.Windows.Forms.Label();
      this.cbJobStatus = new System.Windows.Forms.ComboBox();
      this.lblJobStatus = new System.Windows.Forms.Label();
      this.cbAssignedTech = new System.Windows.Forms.ComboBox();
      this.lblAssignedTech = new System.Windows.Forms.Label();
      this.cbTakenBy = new System.Windows.Forms.ComboBox();
      this.lbTicketNumber = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // tbFirstName
      // 
      this.tbFirstName.Location = new System.Drawing.Point(187, 64);
      this.tbFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbFirstName.Name = "tbFirstName";
      this.tbFirstName.Size = new System.Drawing.Size(331, 22);
      this.tbFirstName.TabIndex = 0;
      // 
      // tbLastName
      // 
      this.tbLastName.Location = new System.Drawing.Point(187, 96);
      this.tbLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbLastName.Name = "tbLastName";
      this.tbLastName.Size = new System.Drawing.Size(331, 22);
      this.tbLastName.TabIndex = 1;
      // 
      // tbAddress
      // 
      this.tbAddress.Location = new System.Drawing.Point(187, 128);
      this.tbAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbAddress.Name = "tbAddress";
      this.tbAddress.Size = new System.Drawing.Size(331, 22);
      this.tbAddress.TabIndex = 2;
      // 
      // tbPhoneNumber
      // 
      this.tbPhoneNumber.Location = new System.Drawing.Point(187, 160);
      this.tbPhoneNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbPhoneNumber.Name = "tbPhoneNumber";
      this.tbPhoneNumber.Size = new System.Drawing.Size(331, 22);
      this.tbPhoneNumber.TabIndex = 3;
      // 
      // tbVisitComments
      // 
      this.tbVisitComments.Location = new System.Drawing.Point(675, 164);
      this.tbVisitComments.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbVisitComments.Multiline = true;
      this.tbVisitComments.Name = "tbVisitComments";
      this.tbVisitComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbVisitComments.Size = new System.Drawing.Size(331, 181);
      this.tbVisitComments.TabIndex = 9;
      // 
      // lblFirstName
      // 
      this.lblFirstName.AutoSize = true;
      this.lblFirstName.Location = new System.Drawing.Point(64, 68);
      this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblFirstName.Name = "lblFirstName";
      this.lblFirstName.Size = new System.Drawing.Size(115, 17);
      this.lblFirstName.TabIndex = 5;
      this.lblFirstName.Text = "Client First Name";
      // 
      // lblLastName
      // 
      this.lblLastName.AutoSize = true;
      this.lblLastName.Location = new System.Drawing.Point(63, 100);
      this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblLastName.Name = "lblLastName";
      this.lblLastName.Size = new System.Drawing.Size(115, 17);
      this.lblLastName.TabIndex = 6;
      this.lblLastName.Text = "Client Last Name";
      // 
      // lblAddress
      // 
      this.lblAddress.AutoSize = true;
      this.lblAddress.Location = new System.Drawing.Point(80, 132);
      this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblAddress.Name = "lblAddress";
      this.lblAddress.Size = new System.Drawing.Size(99, 17);
      this.lblAddress.TabIndex = 7;
      this.lblAddress.Text = "Client Address";
      // 
      // lblPhone
      // 
      this.lblPhone.AutoSize = true;
      this.lblPhone.Location = new System.Drawing.Point(36, 164);
      this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblPhone.Name = "lblPhone";
      this.lblPhone.Size = new System.Drawing.Size(142, 17);
      this.lblPhone.TabIndex = 8;
      this.lblPhone.Text = "Client Phone Number";
      // 
      // lblComments
      // 
      this.lblComments.AutoSize = true;
      this.lblComments.Location = new System.Drawing.Point(563, 167);
      this.lblComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblComments.Name = "lblComments";
      this.lblComments.Size = new System.Drawing.Size(104, 17);
      this.lblComments.TabIndex = 9;
      this.lblComments.Text = "Visit Comments";
      // 
      // btnSubmit
      // 
      this.btnSubmit.Location = new System.Drawing.Point(388, 388);
      this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnSubmit.Name = "btnSubmit";
      this.btnSubmit.Size = new System.Drawing.Size(100, 28);
      this.btnSubmit.TabIndex = 10;
      this.btnSubmit.Text = "Submit";
      this.btnSubmit.UseVisualStyleBackColor = true;
      this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(567, 388);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 28);
      this.btnCancel.TabIndex = 11;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // lblTicketNumber
      // 
      this.lblTicketNumber.AutoSize = true;
      this.lblTicketNumber.Location = new System.Drawing.Point(817, 11);
      this.lblTicketNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTicketNumber.Name = "lblTicketNumber";
      this.lblTicketNumber.Size = new System.Drawing.Size(104, 17);
      this.lblTicketNumber.TabIndex = 13;
      this.lblTicketNumber.Text = "Ticket Number:";
      // 
      // dtpDate
      // 
      this.dtpDate.Location = new System.Drawing.Point(704, 91);
      this.dtpDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.dtpDate.Name = "dtpDate";
      this.dtpDate.Size = new System.Drawing.Size(261, 22);
      this.dtpDate.TabIndex = 7;
      // 
      // dtpTime
      // 
      this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
      this.dtpTime.Location = new System.Drawing.Point(784, 123);
      this.dtpTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.dtpTime.Name = "dtpTime";
      this.dtpTime.ShowUpDown = true;
      this.dtpTime.Size = new System.Drawing.Size(113, 22);
      this.dtpTime.TabIndex = 8;
      this.dtpTime.Value = new System.DateTime(2014, 3, 21, 12, 0, 0, 0);
      // 
      // lblCSReceiver
      // 
      this.lblCSReceiver.AutoSize = true;
      this.lblCSReceiver.Location = new System.Drawing.Point(81, 256);
      this.lblCSReceiver.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCSReceiver.Name = "lblCSReceiver";
      this.lblCSReceiver.Size = new System.Drawing.Size(95, 17);
      this.lblCSReceiver.TabIndex = 18;
      this.lblCSReceiver.Text = "Call Taken By";
      // 
      // cbJobStatus
      // 
      this.cbJobStatus.FormattingEnabled = true;
      this.cbJobStatus.Items.AddRange(new object[] {
            "Unassigned",
            "Assigned",
            "Visit Completed",
            "Callback Completed"});
      this.cbJobStatus.Location = new System.Drawing.Point(187, 286);
      this.cbJobStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbJobStatus.Name = "cbJobStatus";
      this.cbJobStatus.Size = new System.Drawing.Size(331, 24);
      this.cbJobStatus.TabIndex = 5;
      // 
      // lblJobStatus
      // 
      this.lblJobStatus.AutoSize = true;
      this.lblJobStatus.Location = new System.Drawing.Point(103, 289);
      this.lblJobStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblJobStatus.Name = "lblJobStatus";
      this.lblJobStatus.Size = new System.Drawing.Size(75, 17);
      this.lblJobStatus.TabIndex = 20;
      this.lblJobStatus.Text = "Job Status";
      // 
      // cbAssignedTech
      // 
      this.cbAssignedTech.FormattingEnabled = true;
      this.cbAssignedTech.Location = new System.Drawing.Point(187, 320);
      this.cbAssignedTech.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbAssignedTech.Name = "cbAssignedTech";
      this.cbAssignedTech.Size = new System.Drawing.Size(331, 24);
      this.cbAssignedTech.TabIndex = 6;
      // 
      // lblAssignedTech
      // 
      this.lblAssignedTech.AutoSize = true;
      this.lblAssignedTech.Location = new System.Drawing.Point(36, 324);
      this.lblAssignedTech.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblAssignedTech.Name = "lblAssignedTech";
      this.lblAssignedTech.Size = new System.Drawing.Size(139, 17);
      this.lblAssignedTech.TabIndex = 22;
      this.lblAssignedTech.Text = "Technician Assigned";
      // 
      // cbTakenBy
      // 
      this.cbTakenBy.FormattingEnabled = true;
      this.cbTakenBy.Location = new System.Drawing.Point(187, 252);
      this.cbTakenBy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbTakenBy.Name = "cbTakenBy";
      this.cbTakenBy.Size = new System.Drawing.Size(331, 24);
      this.cbTakenBy.TabIndex = 4;
      // 
      // lbTicketNumber
      // 
      this.lbTicketNumber.AutoSize = true;
      this.lbTicketNumber.Location = new System.Drawing.Point(956, 11);
      this.lbTicketNumber.Name = "lbTicketNumber";
      this.lbTicketNumber.Size = new System.Drawing.Size(0, 17);
      this.lbTicketNumber.TabIndex = 23;
      // 
      // ServiceCallGUI
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1057, 433);
      this.Controls.Add(this.lbTicketNumber);
      this.Controls.Add(this.cbTakenBy);
      this.Controls.Add(this.lblAssignedTech);
      this.Controls.Add(this.cbAssignedTech);
      this.Controls.Add(this.lblJobStatus);
      this.Controls.Add(this.cbJobStatus);
      this.Controls.Add(this.lblCSReceiver);
      this.Controls.Add(this.dtpTime);
      this.Controls.Add(this.dtpDate);
      this.Controls.Add(this.lblTicketNumber);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSubmit);
      this.Controls.Add(this.lblComments);
      this.Controls.Add(this.lblPhone);
      this.Controls.Add(this.lblAddress);
      this.Controls.Add(this.lblLastName);
      this.Controls.Add(this.lblFirstName);
      this.Controls.Add(this.tbVisitComments);
      this.Controls.Add(this.tbPhoneNumber);
      this.Controls.Add(this.tbAddress);
      this.Controls.Add(this.tbLastName);
      this.Controls.Add(this.tbFirstName);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ServiceCallGUI";
      this.Text = "Edit Service Call";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
  }
}