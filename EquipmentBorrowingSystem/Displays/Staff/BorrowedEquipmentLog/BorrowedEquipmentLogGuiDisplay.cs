using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog
{
    partial class BorrowedEquipmentLogGuiDisplay
    {
        private TableLayoutPanel tableLayoutBELog;
        private Panel TitlePanel;
        private Panel LogPanel;
        private Label MCLHeader;
        private ListView RequestLog;
        private Label BELsub;
        private Button BackButton;  

        public void BindModelToView()
        {          
            RequestLog.View = View.Details;
            RequestLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            RequestLog.Columns.Add("Status", 100);
            RequestLog.Columns.Add("Borrower", 150);
            RequestLog.Columns.Add("Equipment", 150);
            RequestLog.Columns.Add("Condition", 75);
            RequestLog.Columns.Add("Reason", 200);
            RequestLog.Columns.Add("Date Borrowed", 150);
            RequestLog.Columns.Add("Date Returned", 150);            
            RequestLog.Columns.Add("Expected Return Date", 150);            

            foreach (EquipmentRequest request in Model.ToList())
            {                
                RequestLog.Items.Add(new ListViewItem(new string[] { request.RequestStatus.Name, request.Borrower.Email, request.Reason, request.DateBorrowed.ToString(), request.DateReturned.ToString(), request.ExpectedReturnDate.ToString()}));
                
            }            
            
        }

        partial void InitializeComponent()
        {
            this.tableLayoutBELog = new System.Windows.Forms.TableLayoutPanel();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.BELsub = new System.Windows.Forms.Label();
            this.MCLHeader = new System.Windows.Forms.Label();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.RequestLog = new System.Windows.Forms.ListView();
            this.tableLayoutBELog.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBELog
            // 
            this.tableLayoutBELog.ColumnCount = 1;
            this.tableLayoutBELog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutBELog.Controls.Add(this.TitlePanel, 0, 0);
            this.tableLayoutBELog.Controls.Add(this.LogPanel, 0, 1);
            this.tableLayoutBELog.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutBELog.Name = "tableLayoutBELog";
            this.tableLayoutBELog.RowCount = 2;
            this.tableLayoutBELog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.08547F));
            this.tableLayoutBELog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.91453F));
            this.tableLayoutBELog.Size = new System.Drawing.Size(871, 468);
            this.tableLayoutBELog.TabIndex = 0;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.BELsub);
            this.TitlePanel.Controls.Add(this.MCLHeader);
            this.TitlePanel.Location = new System.Drawing.Point(3, 3);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(865, 88);
            this.TitlePanel.TabIndex = 0;
            // 
            // BELsub
            // 
            this.BELsub.AutoSize = true;
            this.BELsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BELsub.Location = new System.Drawing.Point(289, 49);
            this.BELsub.Name = "BELsub";
            this.BELsub.Size = new System.Drawing.Size(315, 31);
            this.BELsub.TabIndex = 2;
            this.BELsub.Text = "Borrowed equipment Log";
            this.BELsub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MCLHeader
            // 
            this.MCLHeader.AutoSize = true;
            this.MCLHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MCLHeader.Location = new System.Drawing.Point(84, 10);
            this.MCLHeader.Name = "MCLHeader";
            this.MCLHeader.Size = new System.Drawing.Size(707, 39);
            this.MCLHeader.TabIndex = 0;
            this.MCLHeader.Text = "Malayan Colleges Laguna Borrowing System";
            this.MCLHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MCLHeader.Click += new System.EventHandler(this.MCLHeader_Click);
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.BackButton);
            this.LogPanel.Controls.Add(this.RequestLog);
            this.LogPanel.Location = new System.Drawing.Point(3, 97);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(865, 368);
            this.LogPanel.TabIndex = 1;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(774, 30);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // RequestLog
            // 
            this.RequestLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.RequestLog.HideSelection = false;
            this.RequestLog.Location = new System.Drawing.Point(17, 3);
            this.RequestLog.MultiSelect = false;
            this.RequestLog.Name = "RequestLog";
            this.RequestLog.Size = new System.Drawing.Size(751, 362);
            this.RequestLog.TabIndex = 1;
            this.RequestLog.UseCompatibleStateImageBehavior = false;
            this.RequestLog.View = System.Windows.Forms.View.Details;
            // 
            // BorrowedEquipmentLogGuiDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 492);
            this.Controls.Add(this.tableLayoutBELog);
            this.Name = "BorrowedEquipmentLogGuiDisplay";
            this.Text = "Form1";
            this.tableLayoutBELog.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //Latest Edit: Mark Anthony Mamauag
        //Description: Modified functionality of Back Button Event

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Director.ShowDisplay(Director.BorrowedEquipmentLogController.RequestsMenu());
        }

        private void MCLHeader_Click(object sender, EventArgs e)
        {

        }
    }

    partial class BorrowedEquipmentLogGuiDisplay : GuiDisplay<IEnumerable<EquipmentRequest>>
    {
        public BorrowedEquipmentLogGuiDisplay(IEnumerable<EquipmentRequest> model) 
            : base(model)
        {
            InitializeComponent();
            BindModelToView();
        }                
        public BorrowedEquipmentLogGuiDisplay()
        {

        }
        partial void InitializeComponent();
    }
}
