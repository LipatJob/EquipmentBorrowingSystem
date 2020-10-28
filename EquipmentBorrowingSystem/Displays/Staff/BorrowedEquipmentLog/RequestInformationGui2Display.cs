using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    partial class RequestInformationGui2Display : SeeInfoAndStatusDisplay
    {
        private Button ApproveButton;
        private Button DenyButton;
        private Button AddViolationButton;
        private Button ReturnButton;

        public RequestInformationGui2Display(EquipmentRequest request) : base(request)
        {
            var actionPanel = new Panel() { Dock = DockStyle.Bottom, Padding = new Padding(10, 10, 30, 10), Height = 50 };
            ReturnButton = new Button() { Text = "Accomplish Request", Dock = DockStyle.Left, Enabled = false, AutoSize = true};
            ApproveButton = new Button() { Text = "Approve", Dock = DockStyle.Right, Enabled = false};
            DenyButton = new Button() { Text = "Deny", Dock = DockStyle.Right, Enabled = false};
            ReturnButton.Click += ReturnRequest;
            ApproveButton.Click += ApproveRequest;
            DenyButton.Click += DenyRequest;

            
            AddViolationButton = new Button() { Text = "Add Violation", Location = new System.Drawing.Point(480, 0), Enabled = true, AutoSize=true };
            AddViolationButton.Click += AddViolation;
            


            if (request.RequestStatus.Name == "Pending")
            {
                ApproveButton.Enabled = true;
                DenyButton.Enabled = true;
            }
            else if (request.RequestStatus.Name == "Active")
            {
                ReturnButton.Enabled = true;
            }

            actionPanel.Controls.Add(ReturnButton);
            actionPanel.Controls.Add(DenyButton);
            actionPanel.Controls.Add(ApproveButton);
            itemPanel.Controls.Add(actionPanel);
            itemPanel.Controls.Add(AddViolationButton);
            Height += 50;

            equipmentBorrowedLV.DoubleClick += new EventHandler(SeeEquipment);
        }

        private void SeeEquipment(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView.SelectedItems[0];

            int id = (int)item.Tag;

            this.Hide();
            this.Close();
            Director.ShowDisplay(Director.EquipmentManagementController.ViewEquipment(id));
            Director.ShowDisplay(Director.EquipmentManagementController.ViewEquipment(Model.Id));
        }


        //Latest Edit: Mark Anthony Mamauag
        //Description: Added Button Events, regarding requst approval and denial

        void AddViolation(object sender, EventArgs e)
        {
            int idVal = Model.Id;
            this.Hide();
            Director.ViolationManagementController.AddViolation(Model.BorrowerID, Model.Id);
            Director.ShowDisplay(Director.ViolationManagementController.AddViolation(Model.BorrowerID, Model.Id));
        }

        void ApproveRequest(object sender, EventArgs e)
        {
            string message = "Approve this request?";
            MessageBoxButtons choice = MessageBoxButtons.YesNo;
            DialogResult confirm = MessageBox.Show(message, "Approval", choice);
            if (confirm == DialogResult.Yes)
            {
                //Approve the Requst
                int idVal = Model.Id;
                this.Hide();
                Director.BorrowedEquipmentLogController.ApproveRequest(idVal);
            }
        }
        void DenyRequest(object sender, EventArgs e)
        {
            string message = "Deny this request?";
            MessageBoxButtons choice = MessageBoxButtons.YesNo;
            DialogResult confirm = MessageBox.Show(message, "Deny", choice);
            if (confirm == DialogResult.Yes)
            {
                //Deny the Request
                int idVal = Model.Id;
                this.Hide();
                Director.BorrowedEquipmentLogController.DenyRequest(idVal);
            }
        }

        void ReturnRequest(object sender, EventArgs e)
        {
            string message = "Accomplish Request?";
            MessageBoxButtons choice = MessageBoxButtons.YesNo;
            DialogResult confirm = MessageBox.Show(message, "Approval", choice);
            if (confirm == DialogResult.Yes)
            {
                //Deny the Request
                int idVal = Model.Id;
                this.Hide();
                Director.BorrowedEquipmentLogController.AccomplishRequest(idVal);

            }
        }


    }
}
