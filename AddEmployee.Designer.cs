//-----------------------------------------------------------------------
// <copyright file="AddEmployee.Designer.cs" company="ParrishCorp">
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
  /// AddEmployee designer
  /// </summary>
  public partial class AddEmployee
  {
    /// <summary>Designer components</summary>
    private System.Windows.Forms.Button btnSubmit;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Button btnCancel;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.TextBox tbCorrectiveActions;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblEmployeeNumber;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblCorrectiveActions;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblFirstName;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblEmployeeLastName;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblEmployeeUserName;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblEmployeePassword;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblEmployeeType;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.TextBox tbFirstName;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.TextBox tbLastName;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.TextBox tbUsername;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.TextBox tbPassword;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.ComboBox cbEmployeeType;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.ComboBox cbCorrectiveActionsStatus;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lblCorrectiveActionsStatus;

    /// <summary>Designer components</summary>
    private System.Windows.Forms.Label lbEmployeeNum;

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
      this.btnSubmit = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.tbCorrectiveActions = new System.Windows.Forms.TextBox();
      this.lblEmployeeNumber = new System.Windows.Forms.Label();
      this.lblCorrectiveActions = new System.Windows.Forms.Label();
      this.lblFirstName = new System.Windows.Forms.Label();
      this.lblEmployeeLastName = new System.Windows.Forms.Label();
      this.lblEmployeeUserName = new System.Windows.Forms.Label();
      this.lblEmployeePassword = new System.Windows.Forms.Label();
      this.lblEmployeeType = new System.Windows.Forms.Label();
      this.tbFirstName = new System.Windows.Forms.TextBox();
      this.tbLastName = new System.Windows.Forms.TextBox();
      this.tbUsername = new System.Windows.Forms.TextBox();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.cbEmployeeType = new System.Windows.Forms.ComboBox();
      this.cbCorrectiveActionsStatus = new System.Windows.Forms.ComboBox();
      this.lblCorrectiveActionsStatus = new System.Windows.Forms.Label();
      this.lbEmployeeNum = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // btnSubmit
      // 
      this.btnSubmit.Location = new System.Drawing.Point(285, 251);
      this.btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnSubmit.Name = "btnSubmit";
      this.btnSubmit.Size = new System.Drawing.Size(100, 28);
      this.btnSubmit.TabIndex = 8;
      this.btnSubmit.Text = "Submit";
      this.btnSubmit.UseVisualStyleBackColor = true;
      this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(523, 251);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 28);
      this.btnCancel.TabIndex = 9;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // tbCorrectiveActions
      // 
      this.tbCorrectiveActions.Location = new System.Drawing.Point(613, 58);
      this.tbCorrectiveActions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbCorrectiveActions.Multiline = true;
      this.tbCorrectiveActions.Name = "tbCorrectiveActions";
      this.tbCorrectiveActions.Size = new System.Drawing.Size(280, 120);
      this.tbCorrectiveActions.TabIndex = 6;
      // 
      // lblEmployeeNumber
      // 
      this.lblEmployeeNumber.AutoSize = true;
      this.lblEmployeeNumber.Location = new System.Drawing.Point(673, 16);
      this.lblEmployeeNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblEmployeeNumber.Name = "lblEmployeeNumber";
      this.lblEmployeeNumber.Size = new System.Drawing.Size(132, 17);
      this.lblEmployeeNumber.TabIndex = 4;
      this.lblEmployeeNumber.Text = "Employee Number: ";
      // 
      // lblCorrectiveActions
      // 
      this.lblCorrectiveActions.AutoSize = true;
      this.lblCorrectiveActions.Location = new System.Drawing.Point(481, 62);
      this.lblCorrectiveActions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCorrectiveActions.Name = "lblCorrectiveActions";
      this.lblCorrectiveActions.Size = new System.Drawing.Size(122, 17);
      this.lblCorrectiveActions.TabIndex = 5;
      this.lblCorrectiveActions.Text = "Corrective Actions";
      // 
      // lblFirstName
      // 
      this.lblFirstName.AutoSize = true;
      this.lblFirstName.Location = new System.Drawing.Point(16, 62);
      this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblFirstName.Name = "lblFirstName";
      this.lblFirstName.Size = new System.Drawing.Size(142, 17);
      this.lblFirstName.TabIndex = 6;
      this.lblFirstName.Text = "Employee First Name";
      // 
      // lblEmployeeLastName
      // 
      this.lblEmployeeLastName.AutoSize = true;
      this.lblEmployeeLastName.Location = new System.Drawing.Point(15, 94);
      this.lblEmployeeLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblEmployeeLastName.Name = "lblEmployeeLastName";
      this.lblEmployeeLastName.Size = new System.Drawing.Size(142, 17);
      this.lblEmployeeLastName.TabIndex = 7;
      this.lblEmployeeLastName.Text = "Employee Last Name";
      // 
      // lblEmployeeUserName
      // 
      this.lblEmployeeUserName.AutoSize = true;
      this.lblEmployeeUserName.Location = new System.Drawing.Point(19, 126);
      this.lblEmployeeUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblEmployeeUserName.Name = "lblEmployeeUserName";
      this.lblEmployeeUserName.Size = new System.Drawing.Size(139, 17);
      this.lblEmployeeUserName.TabIndex = 8;
      this.lblEmployeeUserName.Text = "Employee Username";
      // 
      // lblEmployeePassword
      // 
      this.lblEmployeePassword.AutoSize = true;
      this.lblEmployeePassword.Location = new System.Drawing.Point(21, 158);
      this.lblEmployeePassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblEmployeePassword.Name = "lblEmployeePassword";
      this.lblEmployeePassword.Size = new System.Drawing.Size(135, 17);
      this.lblEmployeePassword.TabIndex = 9;
      this.lblEmployeePassword.Text = "Employee Password";
      // 
      // lblEmployeeType
      // 
      this.lblEmployeeType.AutoSize = true;
      this.lblEmployeeType.Location = new System.Drawing.Point(51, 190);
      this.lblEmployeeType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblEmployeeType.Name = "lblEmployeeType";
      this.lblEmployeeType.Size = new System.Drawing.Size(106, 17);
      this.lblEmployeeType.TabIndex = 10;
      this.lblEmployeeType.Text = "Employee Type";
      // 
      // tbFirstName
      // 
      this.tbFirstName.Location = new System.Drawing.Point(165, 58);
      this.tbFirstName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbFirstName.Name = "tbFirstName";
      this.tbFirstName.Size = new System.Drawing.Size(285, 22);
      this.tbFirstName.TabIndex = 1;
      // 
      // tbLastName
      // 
      this.tbLastName.Location = new System.Drawing.Point(165, 90);
      this.tbLastName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbLastName.Name = "tbLastName";
      this.tbLastName.Size = new System.Drawing.Size(285, 22);
      this.tbLastName.TabIndex = 2;
      // 
      // tbUsername
      // 
      this.tbUsername.Location = new System.Drawing.Point(165, 122);
      this.tbUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbUsername.Name = "tbUsername";
      this.tbUsername.Size = new System.Drawing.Size(285, 22);
      this.tbUsername.TabIndex = 3;
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(165, 154);
      this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.Size = new System.Drawing.Size(285, 22);
      this.tbPassword.TabIndex = 4;
      // 
      // cbEmployeeType
      // 
      this.cbEmployeeType.DisplayMember = "3";
      this.cbEmployeeType.FormattingEnabled = true;
      this.cbEmployeeType.Items.AddRange(new object[] {
            "Manager",
            "Technician",
            "Customer Service"});
      this.cbEmployeeType.Location = new System.Drawing.Point(165, 186);
      this.cbEmployeeType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbEmployeeType.Name = "cbEmployeeType";
      this.cbEmployeeType.Size = new System.Drawing.Size(285, 24);
      this.cbEmployeeType.TabIndex = 5;
      // 
      // cbCorrectiveActionsStatus
      // 
      this.cbCorrectiveActionsStatus.FormattingEnabled = true;
      this.cbCorrectiveActionsStatus.Items.AddRange(new object[] {
            "Pending Management Review",
            "No Action Needed"});
      this.cbCorrectiveActionsStatus.Location = new System.Drawing.Point(613, 185);
      this.cbCorrectiveActionsStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cbCorrectiveActionsStatus.Name = "cbCorrectiveActionsStatus";
      this.cbCorrectiveActionsStatus.Size = new System.Drawing.Size(280, 24);
      this.cbCorrectiveActionsStatus.TabIndex = 7;
      // 
      // lblCorrectiveActionsStatus
      // 
      this.lblCorrectiveActionsStatus.AutoSize = true;
      this.lblCorrectiveActionsStatus.Location = new System.Drawing.Point(512, 190);
      this.lblCorrectiveActionsStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblCorrectiveActionsStatus.Name = "lblCorrectiveActionsStatus";
      this.lblCorrectiveActionsStatus.Size = new System.Drawing.Size(91, 17);
      this.lblCorrectiveActionsStatus.TabIndex = 18;
      this.lblCorrectiveActionsStatus.Text = "Action Status";
      // 
      // lbEmployeeNum
      // 
      this.lbEmployeeNum.AutoSize = true;
      this.lbEmployeeNum.Location = new System.Drawing.Point(812, 16);
      this.lbEmployeeNum.Name = "lbEmployeeNum";
      this.lbEmployeeNum.Size = new System.Drawing.Size(0, 17);
      this.lbEmployeeNum.TabIndex = 19;
      // 
      // AddEmployee
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(911, 294);
      this.Controls.Add(this.lbEmployeeNum);
      this.Controls.Add(this.lblCorrectiveActionsStatus);
      this.Controls.Add(this.cbCorrectiveActionsStatus);
      this.Controls.Add(this.cbEmployeeType);
      this.Controls.Add(this.tbPassword);
      this.Controls.Add(this.tbUsername);
      this.Controls.Add(this.tbLastName);
      this.Controls.Add(this.tbFirstName);
      this.Controls.Add(this.lblEmployeeType);
      this.Controls.Add(this.lblEmployeePassword);
      this.Controls.Add(this.lblEmployeeUserName);
      this.Controls.Add(this.lblEmployeeLastName);
      this.Controls.Add(this.lblFirstName);
      this.Controls.Add(this.lblCorrectiveActions);
      this.Controls.Add(this.lblEmployeeNumber);
      this.Controls.Add(this.tbCorrectiveActions);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSubmit);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddEmployee";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Editing Employee";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
  }
}