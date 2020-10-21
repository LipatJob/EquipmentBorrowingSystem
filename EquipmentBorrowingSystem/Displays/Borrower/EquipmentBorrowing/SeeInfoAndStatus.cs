using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    // See Current Requests Class
    partial class SeeInfoAndStatus
    {
        private ListView CurrentRequests;
        private TableLayoutPanel tbLayout;
        private Panel MainPanel;
        private Panel LogPanel;
        private Label WindowHeader;
        private Label BorrowerLabel;
        private Button BackButton;

        public void BindModelToView()
        {
            CurrentRequests.View = View.Details;
            CurrentRequests.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            CurrentRequests.Columns.Add("Status", 100);
            CurrentRequests.Columns.Add("Equipment", 150);
            CurrentRequests.Columns.Add("Date Borrowed", 150);

            foreach (EquipmentRequest request in Model.ToList())
            {
                CurrentRequests.Items.Add(new ListViewItem(new string[] { request.RequestStatus.Name, request.Equipment.Name, request.DateBorrowed.ToString()}));
            }
        }

        partial void InitializeComponent()
        {
            // Object Initialization
            this.tbLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BorrowerLabel = new System.Windows.Forms.Label();
            this.WindowHeader = new System.Windows.Forms.Label();
            this.LogPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.CurrentRequests = new System.Windows.Forms.ListView();

            this.tbLayout.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.LogPanel.SuspendLayout();
            this.SuspendLayout();

            // Event Methods
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            this.WindowHeader.Click += new System.EventHandler(this.WindowHeader_Click);

            this.tbLayout.ColumnCount = 1;
            this.tbLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbLayout.Controls.Add(this.MainPanel, 0, 0);
            this.tbLayout.Controls.Add(this.LogPanel, 0, 1);
            this.tbLayout.Location = new System.Drawing.Point(12, 12);
            this.tbLayout.Name = "tbLayout";
            this.tbLayout.RowCount = 2;
            this.tbLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.08547F));
            this.tbLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.91453F));
            this.tbLayout.Size = new System.Drawing.Size(476, 468);
            this.tbLayout.TabIndex = 0;
 
            this.MainPanel.Controls.Add(this.BorrowerLabel);
            this.MainPanel.Controls.Add(this.WindowHeader);
            this.MainPanel.Location = new System.Drawing.Point(3, 3);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(461, 88);
            this.MainPanel.TabIndex = 0;
 
            this.BorrowerLabel.AutoSize = true;
            this.BorrowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrowerLabel.Location = new System.Drawing.Point(176, 49);
            this.BorrowerLabel.Name = "BorrowerLabel";
            this.BorrowerLabel.Size = new System.Drawing.Size(124, 31);
            this.BorrowerLabel.TabIndex = 2;
            this.BorrowerLabel.Text = "Borrower";
            this.BorrowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
 
            this.WindowHeader.AutoSize = true;
            this.WindowHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowHeader.Location = new System.Drawing.Point(47, 10);
            this.WindowHeader.Name = "WindowHeader";
            this.WindowHeader.Size = new System.Drawing.Size(390, 39);
            this.WindowHeader.TabIndex = 0;
            this.WindowHeader.Text = "Current Request History";
            this.WindowHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
 
            this.LogPanel.Controls.Add(this.BackButton);
            this.LogPanel.Controls.Add(this.CurrentRequests);
            this.LogPanel.Location = new System.Drawing.Point(3, 97);
            this.LogPanel.Name = "LogPanel";
            this.LogPanel.Size = new System.Drawing.Size(470, 368);
            this.LogPanel.TabIndex = 1;

            this.BackButton.Location = new System.Drawing.Point(774, 30);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;

            this.CurrentRequests.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.CurrentRequests.HideSelection = false;
            this.CurrentRequests.Location = new System.Drawing.Point(17, 3);
            this.CurrentRequests.MultiSelect = false;
            this.CurrentRequests.Name = "CurrentRequests";
            this.CurrentRequests.Size = new System.Drawing.Size(444, 362);
            this.CurrentRequests.TabIndex = 1;
            this.CurrentRequests.UseCompatibleStateImageBehavior = false;
            this.CurrentRequests.View = System.Windows.Forms.View.Details;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 492);
            itemPanel.Controls.Add(this.tbLayout);
            this.Name = "SeeInfoAndStatus";
            this.Text = "Form1";
            this.tbLayout.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.LogPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        //Latest Edit: Mark Anthony Mamauag
        //Description: Modified functionality of Back Button Event

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Director.ShowDisplay(Director.BorrowerMainController.BorrowerMenu());
        }
        private void WindowHeader_Click(object sender, EventArgs e)
        {

        }
    }

    partial class SeeInfoAndStatus : GuiDisplay<IEnumerable<EquipmentRequest>>
    {
        
        public SeeInfoAndStatus(IEnumerable<EquipmentRequest> model)
            : base(model)
        {
            InitializeComponent();
            BindModelToView();
        }
        
        public SeeInfoAndStatus()
        {

        }
        partial void InitializeComponent();

    }
}
