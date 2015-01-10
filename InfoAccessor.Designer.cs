//-----------------------------------------------------------------------
// <copyright file="InfoAccessor.cs" company="ParrishCorp">
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
  /// Info Accessor Designer
  /// </summary>
  public partial class InfoAccessor
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>Select button</summary>
    private System.Windows.Forms.Button btnSelect;

    /// <summary>Cancel button</summary>
    private System.Windows.Forms.Button btnCancel;

    /// <summary>Info label</summary>
    private System.Windows.Forms.ListBox lbInfo;

    /// <summary>Add button</summary>
    private System.Windows.Forms.Button btnAddNew;

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
      this.btnSelect = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.lbInfo = new System.Windows.Forms.ListBox();
      this.btnAddNew = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnSelect
      // 
      this.btnSelect.Location = new System.Drawing.Point(16, 278);
      this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnSelect.Name = "btnSelect";
      this.btnSelect.Size = new System.Drawing.Size(100, 28);
      this.btnSelect.TabIndex = 2;
      this.btnSelect.Text = "Select";
      this.btnSelect.UseVisualStyleBackColor = true;
      this.btnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(263, 278);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(100, 28);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
      // 
      // lbInfo
      // 
      this.lbInfo.FormattingEnabled = true;
      this.lbInfo.ItemHeight = 16;
      this.lbInfo.Location = new System.Drawing.Point(16, 15);
      this.lbInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.lbInfo.Name = "lbInfo";
      this.lbInfo.Size = new System.Drawing.Size(345, 228);
      this.lbInfo.Sorted = true;
      this.lbInfo.TabIndex = 1;
      // 
      // btnAddNew
      // 
      this.btnAddNew.Location = new System.Drawing.Point(140, 278);
      this.btnAddNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnAddNew.Name = "btnAddNew";
      this.btnAddNew.Size = new System.Drawing.Size(100, 28);
      this.btnAddNew.TabIndex = 3;
      this.btnAddNew.Text = "Add New";
      this.btnAddNew.UseVisualStyleBackColor = true;
      this.btnAddNew.Click += new System.EventHandler(this.BtnAddNew_Click);
      // 
      // InfoAccessor
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(379, 321);
      this.Controls.Add(this.btnAddNew);
      this.Controls.Add(this.lbInfo);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnSelect);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InfoAccessor";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "(Info)";
      this.ResumeLayout(false);

    }

    #endregion
  }
}