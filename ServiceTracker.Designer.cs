namespace ServiceTracker
{
    partial class ServiceTracker
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceTracker));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correctiveActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageEmployeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.technicianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completeVisitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUnassignedVisitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomerService = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClientsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCorrectiveActionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.btnUserTask1 = new System.Windows.Forms.Button();
            this.btnUserTask3 = new System.Windows.Forms.Button();
            this.btnUserTask2 = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvUserData = new System.Windows.Forms.DataGridView();
            this.Client = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTableDescription = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.managerToolStripMenuItem,
            this.technicianToolStripMenuItem,
            this.mnuCustomerService});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // managerToolStripMenuItem
            // 
            this.managerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTicketsToolStripMenuItem,
            this.correctiveActionsToolStripMenuItem,
            this.manageEmployeesToolStripMenuItem});
            this.managerToolStripMenuItem.Name = "managerToolStripMenuItem";
            this.managerToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.managerToolStripMenuItem.Text = "Manager";
            // 
            // closeTicketsToolStripMenuItem
            // 
            this.closeTicketsToolStripMenuItem.Name = "closeTicketsToolStripMenuItem";
            this.closeTicketsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.closeTicketsToolStripMenuItem.Text = "Close Tickets";
            this.closeTicketsToolStripMenuItem.Click += new System.EventHandler(this.closeTicketsToolStripMenuItem_Click);
            // 
            // correctiveActionsToolStripMenuItem
            // 
            this.correctiveActionsToolStripMenuItem.Name = "correctiveActionsToolStripMenuItem";
            this.correctiveActionsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.correctiveActionsToolStripMenuItem.Text = "Corrective Actions Needed";
            this.correctiveActionsToolStripMenuItem.Click += new System.EventHandler(this.correctiveActionsToolStripMenuItem_Click);
            // 
            // manageEmployeesToolStripMenuItem
            // 
            this.manageEmployeesToolStripMenuItem.Name = "manageEmployeesToolStripMenuItem";
            this.manageEmployeesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.manageEmployeesToolStripMenuItem.Text = "Manage Employees";
            this.manageEmployeesToolStripMenuItem.Click += new System.EventHandler(this.manageEmployeesToolStripMenuItem_Click);
            // 
            // technicianToolStripMenuItem
            // 
            this.technicianToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completeVisitToolStripMenuItem,
            this.viewUnassignedVisitsToolStripMenuItem,
            this.statisticsToolStripMenuItem});
            this.technicianToolStripMenuItem.Name = "technicianToolStripMenuItem";
            this.technicianToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.technicianToolStripMenuItem.Text = "Technician";
            // 
            // completeVisitToolStripMenuItem
            // 
            this.completeVisitToolStripMenuItem.Name = "completeVisitToolStripMenuItem";
            this.completeVisitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.completeVisitToolStripMenuItem.Text = "Complete Visit";
            this.completeVisitToolStripMenuItem.Click += new System.EventHandler(this.completeVisitToolStripMenuItem_Click);
            // 
            // viewUnassignedVisitsToolStripMenuItem
            // 
            this.viewUnassignedVisitsToolStripMenuItem.Name = "viewUnassignedVisitsToolStripMenuItem";
            this.viewUnassignedVisitsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.viewUnassignedVisitsToolStripMenuItem.Text = "View Unassigned Visits";
            this.viewUnassignedVisitsToolStripMenuItem.Click += new System.EventHandler(this.viewUnassignedVisitsToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.statisticsToolStripMenuItem.Text = "Visit Statistics";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // mnuCustomerService
            // 
            this.mnuCustomerService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewClientsToolStripMenuItem1,
            this.scheduleVisitsToolStripMenuItem,
            this.addCorrectiveActionToolStripMenuItem});
            this.mnuCustomerService.Name = "mnuCustomerService";
            this.mnuCustomerService.Size = new System.Drawing.Size(111, 20);
            this.mnuCustomerService.Text = "Customer Service";
            // 
            // viewClientsToolStripMenuItem1
            // 
            this.viewClientsToolStripMenuItem1.Name = "viewClientsToolStripMenuItem1";
            this.viewClientsToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.viewClientsToolStripMenuItem1.Text = "View Clients";
            this.viewClientsToolStripMenuItem1.Click += new System.EventHandler(this.viewClientsToolStripMenuItem1_Click);
            // 
            // scheduleVisitsToolStripMenuItem
            // 
            this.scheduleVisitsToolStripMenuItem.Name = "scheduleVisitsToolStripMenuItem";
            this.scheduleVisitsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.scheduleVisitsToolStripMenuItem.Text = "Schedule Visits";
            this.scheduleVisitsToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisitsToolStripMenuItem_Click);
            // 
            // addCorrectiveActionToolStripMenuItem
            // 
            this.addCorrectiveActionToolStripMenuItem.Name = "addCorrectiveActionToolStripMenuItem";
            this.addCorrectiveActionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addCorrectiveActionToolStripMenuItem.Text = "Add Corrective Action";
            this.addCorrectiveActionToolStripMenuItem.Click += new System.EventHandler(this.addCorrectiveActionToolStripMenuItem_Click);
            // 
            // tbDate
            // 
            this.tbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDate.Enabled = false;
            this.tbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDate.Location = new System.Drawing.Point(521, 448);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(245, 14);
            this.tbDate.TabIndex = 50;
            this.tbDate.Text = "(Date)";
            this.tbDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbTime
            // 
            this.tbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTime.Enabled = false;
            this.tbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTime.Location = new System.Drawing.Point(521, 468);
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(245, 14);
            this.tbTime.TabIndex = 51;
            this.tbTime.Text = "(Time)";
            this.tbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUserTask1
            // 
            this.btnUserTask1.Location = new System.Drawing.Point(61, 174);
            this.btnUserTask1.Name = "btnUserTask1";
            this.btnUserTask1.Size = new System.Drawing.Size(113, 42);
            this.btnUserTask1.TabIndex = 1;
            this.btnUserTask1.Text = "UserTask1";
            this.btnUserTask1.UseVisualStyleBackColor = true;
            this.btnUserTask1.Click += new System.EventHandler(this.btnUserTask1_Click);
            // 
            // btnUserTask3
            // 
            this.btnUserTask3.Location = new System.Drawing.Point(61, 270);
            this.btnUserTask3.Name = "btnUserTask3";
            this.btnUserTask3.Size = new System.Drawing.Size(113, 42);
            this.btnUserTask3.TabIndex = 3;
            this.btnUserTask3.Text = "UserTask3";
            this.btnUserTask3.UseVisualStyleBackColor = true;
            this.btnUserTask3.Click += new System.EventHandler(this.btnUserTask3_Click);
            // 
            // btnUserTask2
            // 
            this.btnUserTask2.Location = new System.Drawing.Point(61, 222);
            this.btnUserTask2.Name = "btnUserTask2";
            this.btnUserTask2.Size = new System.Drawing.Size(113, 42);
            this.btnUserTask2.TabIndex = 2;
            this.btnUserTask2.Text = "UserTask2";
            this.btnUserTask2.UseVisualStyleBackColor = true;
            this.btnUserTask2.Click += new System.EventHandler(this.btnUserTask2_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 46);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(754, 31);
            this.lblWelcome.TabIndex = 56;
            this.lblWelcome.Text = "Welcome, (User Name)";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvUserData
            // 
            this.dgvUserData.AllowUserToAddRows = false;
            this.dgvUserData.AllowUserToDeleteRows = false;
            this.dgvUserData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUserData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Client,
            this.VisitDay,
            this.VisitTime});
            this.dgvUserData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUserData.Enabled = false;
            this.dgvUserData.Location = new System.Drawing.Point(243, 150);
            this.dgvUserData.MultiSelect = false;
            this.dgvUserData.Name = "dgvUserData";
            this.dgvUserData.ReadOnly = true;
            this.dgvUserData.ShowEditingIcon = false;
            this.dgvUserData.Size = new System.Drawing.Size(491, 277);
            this.dgvUserData.TabIndex = 57;
            // 
            // Client
            // 
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // VisitDay
            // 
            this.VisitDay.HeaderText = "Visit Day";
            this.VisitDay.Name = "VisitDay";
            this.VisitDay.ReadOnly = true;
            // 
            // VisitTime
            // 
            this.VisitTime.HeaderText = "Visit Time";
            this.VisitTime.Name = "VisitTime";
            this.VisitTime.ReadOnly = true;
            // 
            // lblTableDescription
            // 
            this.lblTableDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTableDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableDescription.Location = new System.Drawing.Point(243, 127);
            this.lblTableDescription.Name = "lblTableDescription";
            this.lblTableDescription.Size = new System.Drawing.Size(491, 20);
            this.lblTableDescription.TabIndex = 58;
            this.lblTableDescription.Text = "(User Specified Tasks)";
            this.lblTableDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serviceTracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 494);
            this.Controls.Add(this.lblTableDescription);
            this.Controls.Add(this.dgvUserData);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnUserTask2);
            this.Controls.Add(this.btnUserTask3);
            this.Controls.Add(this.btnUserTask1);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "serviceTracker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Tracker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem technicianToolStripMenuItem;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomerService;
        private System.Windows.Forms.Button btnUserTask1;
        private System.Windows.Forms.Button btnUserTask3;
        private System.Windows.Forms.Button btnUserTask2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvUserData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Client;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisitTime;
        private System.Windows.Forms.Label lblTableDescription;
        private System.Windows.Forms.ToolStripMenuItem closeTicketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correctiveActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageEmployeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completeVisitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewUnassignedVisitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewClientsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCorrectiveActionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}

