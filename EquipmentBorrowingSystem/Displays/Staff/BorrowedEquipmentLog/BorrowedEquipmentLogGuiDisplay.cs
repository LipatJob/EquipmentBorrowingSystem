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
        private ComboBox requestStatus;
        private Label MCLHeader;
        private ListView RequestLog;
        private Label BELsub;
        private Button BackButton;
        List<EquipmentRequest> EquipmentRequests;

        public void BindModelToView()
        {
            
            foreach (EquipmentRequest request in Model)
            {
                RequestLog.Items.Add(new ListViewItem(new string[] { request.RequestStatusID.ToString(), request.Id.ToString()}));
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
            this.requestStatus = new System.Windows.Forms.ComboBox();
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
            this.tableLayoutBELog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.47619F));
            this.tableLayoutBELog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.52381F));
            this.tableLayoutBELog.Size = new System.Drawing.Size(733, 420);
            this.tableLayoutBELog.TabIndex = 0;
            // 
            // TitlePanel
            // 
            this.TitlePanel.Controls.Add(this.BELsub);
            this.TitlePanel.Controls.Add(this.MCLHeader);
            this.TitlePanel.Location = new System.Drawing.Point(3, 3);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(727, 101);
            this.TitlePanel.TabIndex = 0;
            // 
            // BELsub
            // 
            this.BELsub.AutoSize = true;
            this.BELsub.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BELsub.Location = new System.Drawing.Point(205, 49);
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
            this.MCLHeader.Location = new System.Drawing.Point(10, 10);
            this.MCLHeader.Name = "MCLHeader";
            this.MCLHeader.Size = new System.Drawing.Size(707, 39);
            this.MCLHeader.TabIndex = 0;
            this.MCLHeader.Text = "Malayan Colleges Laguna Borrowing System";
            this.MCLHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LogPanel
            // 
            this.LogPanel.Controls.Add(this.BackButton);
            this.LogPanel.Controls.Add(this.RequestLog);
            this.LogPanel.Controls.Add(this.requestStatus);
            this.LogPanel.Location = new System.Drawing.Point(3, 110);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(727, 307);
            this.LogPanel.TabIndex = 1;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(642, 269);
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
            this.RequestLog.Location = new System.Drawing.Point(175, 30);
            this.RequestLog.MultiSelect = false;
            this.RequestLog.Name = "RequestLog";
            this.RequestLog.Size = new System.Drawing.Size(436, 262);
            this.RequestLog.TabIndex = 1;
            this.RequestLog.UseCompatibleStateImageBehavior = false;
            this.RequestLog.View = System.Windows.Forms.View.Details;
            // 
            // requestStatus
            // 
            this.requestStatus.FormattingEnabled = true;
            this.requestStatus.Location = new System.Drawing.Point(17, 30);
            this.requestStatus.Name = "requestStatus";
            this.requestStatus.Size = new System.Drawing.Size(121, 21);
            this.requestStatus.TabIndex = 0;
            // 
            // BorrowedEquipmentLogGuiDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 444);
            this.Controls.Add(this.tableLayoutBELog);
            this.Name = "BorrowedEquipmentLogGuiDisplay";
            this.Text = "Form1";
            this.tableLayoutBELog.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void BackButton_Click(object sender, EventArgs e)
        {

        }


    }

    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class BorrowedEquipmentLogGuiDisplay : GuiDisplay<IEnumerable<EquipmentRequest>>
    {
        //   Replace with class name              Replace with model class
        //   VVVVVVVVVVVVVVV                      VVVVVV
        public BorrowedEquipmentLogGuiDisplay(IEnumerable<EquipmentRequest> model) 
            : base(model)
        {
            InitializeComponent();
            BindModelToView();
        }
                   
        public BorrowedEquipmentLogGuiDisplay()
        {
            // This Constructor allows you to use the designer
        }

        partial void InitializeComponent();

    }


}
