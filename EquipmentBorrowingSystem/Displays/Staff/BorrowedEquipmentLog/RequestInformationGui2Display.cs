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

            if(request.RequestStatus.Name == "Pending")
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
            Height += 50;

        }

        //Latest Edit: Mark Anthony Mamauag
        //Description: Added Button Events, regarding requst approval and denial

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
                Director.ShowDisplay(Director.StaffMainController.StaffMenu());
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
                Director.ShowDisplay(Director.StaffMainController.StaffMenu());
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
                Director.ShowDisplay(Director.StaffMainController.StaffMenu());

            }
        }


    }
}
