//-----------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="ParrishCorp">
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
  /// User login designer
  /// </summary>
  public partial class UserLogin
  {
    /// <summary>Employee id label</summary>
    private System.Windows.Forms.Label lblEmpID;

    /// <summary>Employee password label</summary>
    private System.Windows.Forms.Label lblPassword;

    /// <summary>Employee id textbox</summary>
    private System.Windows.Forms.TextBox tbEmpID;

    /// <summary>Employee password textbox</summary>
    private System.Windows.Forms.TextBox tbPassword;

    /// <summary>Login button</summary>
    private System.Windows.Forms.Button btnLogin;

    /// <summary>Exit button</summary>
    private System.Windows.Forms.Button btnExit;

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
      this.lblEmpID = new System.Windows.Forms.Label();
      this.lblPassword = new System.Windows.Forms.Label();
      this.tbEmpID = new System.Windows.Forms.TextBox();
      this.tbPassword = new System.Windows.Forms.TextBox();
      this.btnLogin = new System.Windows.Forms.Button();
      this.btnExit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblEmpID
      // 
      this.lblEmpID.AutoSize = true;
      this.lblEmpID.Location = new System.Drawing.Point(45, 30);
      this.lblEmpID.Name = "lblEmpID";
      this.lblEmpID.Size = new System.Drawing.Size(55, 13);
      this.lblEmpID.TabIndex = 0;
      this.lblEmpID.Text = "Username";
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Location = new System.Drawing.Point(47, 69);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(53, 13);
      this.lblPassword.TabIndex = 1;
      this.lblPassword.Text = "Password";
      // 
      // tbEmpID
      // 
      this.tbEmpID.Location = new System.Drawing.Point(106, 27);
      this.tbEmpID.Name = "tbEmpID";
      this.tbEmpID.Size = new System.Drawing.Size(179, 20);
      this.tbEmpID.TabIndex = 1;
      // 
      // tbPassword
      // 
      this.tbPassword.Location = new System.Drawing.Point(106, 66);
      this.tbPassword.Name = "tbPassword";
      this.tbPassword.Size = new System.Drawing.Size(179, 20);
      this.tbPassword.TabIndex = 2;
      this.tbPassword.UseSystemPasswordChar = true;
      // 
      // btnLogin
      // 
      this.btnLogin.Location = new System.Drawing.Point(80, 114);
      this.btnLogin.Name = "btnLogin";
      this.btnLogin.Size = new System.Drawing.Size(75, 23);
      this.btnLogin.TabIndex = 3;
      this.btnLogin.Text = "Login";
      this.btnLogin.UseVisualStyleBackColor = true;
      this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
      // 
      // btnExit
      // 
      this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnExit.Location = new System.Drawing.Point(199, 114);
      this.btnExit.Name = "btnExit";
      this.btnExit.Size = new System.Drawing.Size(75, 23);
      this.btnExit.TabIndex = 4;
      this.btnExit.Text = "Exit";
      this.btnExit.UseVisualStyleBackColor = true;
      this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
      // 
      // UserLogin
      // 
      this.AcceptButton = this.btnLogin;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnExit;
      this.ClientSize = new System.Drawing.Size(354, 149);
      this.Controls.Add(this.btnExit);
      this.Controls.Add(this.btnLogin);
      this.Controls.Add(this.tbPassword);
      this.Controls.Add(this.tbEmpID);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.lblEmpID);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UserLogin";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "User Login";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
  }
}