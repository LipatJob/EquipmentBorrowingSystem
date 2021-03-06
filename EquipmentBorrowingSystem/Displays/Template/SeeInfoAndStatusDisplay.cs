﻿using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    // See Current Requests Class
    partial class SeeInfoAndStatusDisplay
    {

        public override void BindModelToView()
        {
            borrowerTb.Text = Model.Borrower.Email;
            statusTb.Text = Model.RequestStatus.Name;
            dateBorrowedTb.Text = Model.DateBorrowed.ToString();
            expectedReturnDateTb.Text = Model.ExpectedReturnDate.ToString();
            reasonRTB.Text = Model.Reason;

            string statusName = Model.RequestStatus.Name;
            if (statusName == "Active")
            {
                dateReturnedTb.Text = "Not Returned";
            }
            else if (statusName == "Denied" || statusName == "Pending")
            {
                dateReturnedTb.Text = "Not Borrowed";
            }
            else
            {
                dateReturnedTb.Text = Model.DateReturned.ToString();
            }


            foreach (var equipment in Model.Equipments)
            {
                var item = new ListViewItem(new[] {
                    equipment.EquipmentType.Name,
                    equipment.Code});
                item.Tag = equipment.Id;
                equipmentBorrowedLV.Items.Add(item);
            }
        }


        TextBox borrowerTb;
        TextBox statusTb;
        TextBox dateBorrowedTb;
        TextBox expectedReturnDateTb;
        TextBox dateReturnedTb;
        RichTextBox reasonRTB;
        protected ListView equipmentBorrowedLV;
        partial void InitializeComponent()
        {
            var titleLb = new Label() { Text = "Equipment Request", AutoSize = true, Font = new Font(FontFamily.GenericSansSerif, 12)};
            var borrowerLb = new Label() { Text = "Borrower Email", AutoSize = true };
            var statusLb = new Label() { Text = "Status", AutoSize = true };
            var dateBorrowedLb = new Label() { Text = "Date Borrowed", AutoSize = true };
            var expectedReturnDateLb = new Label() { Text = "Expected Return Date", AutoSize = true };
            var dateReturnedLb = new Label() { Text = "Date Returned", AutoSize = true };
            var reasonLb = new Label() { Text = "Reason", AutoSize = true };
            var equipmentBorrowedLb = new Label() { Text = "Equipment Borrowed", AutoSize = true};

            LocationHandler handler = new LocationHandler(0, 0, 125, 30);

            borrowerTb = new TextBox() { Width = 150, Enabled = false};
            statusTb = new TextBox() { Width = 150, Enabled = false };
            dateBorrowedTb = new TextBox() { Width = 150, Enabled = false };
            expectedReturnDateTb = new TextBox() { Width = 150, Enabled = false };
            dateReturnedTb = new TextBox() { Width = 150, Enabled = false };
            reasonRTB = new RichTextBox() { Size = new Size(550, 100), Enabled = false };
            equipmentBorrowedLV = new ListView() { Size = new Size(260, handler.AmountY * 4), View = View.Details, FullRowSelect = true, MultiSelect = false};


            // Initialize List View
            equipmentBorrowedLV.Columns.AddRange(
                new[]{
                new ColumnHeader{ Text = "Type" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Code" , TextAlign = HorizontalAlignment.Left, Width = 100} });


            // Layout Items
            titleLb.Location = handler.GetPosition();

            equipmentBorrowedLb.Location = handler.Down().SetX(300).GetPosition();
            equipmentBorrowedLV.Location = handler.AddY(20).GetPosition();
            handler.SetLocation(titleLb.Location);

            borrowerLb.Location = handler.AddX(10).Down().GetPosition();
            borrowerTb.Location = handler.Right().GetPosition();
            statusLb.Location = handler.Down().Left().GetPosition();
            statusTb.Location = handler.Right().GetPosition();
            dateBorrowedLb.Location = handler.Down().Left().GetPosition();
            dateBorrowedTb.Location = handler.Right().GetPosition();
            expectedReturnDateLb.Location = handler.Down().Left().GetPosition();
            expectedReturnDateTb.Location = handler.Right().GetPosition();
            dateReturnedLb.Location = handler.Down().Left().GetPosition();
            dateReturnedTb.Location = handler.Right().GetPosition();
            reasonLb.Location = handler.Down().Left().GetPosition();
            reasonRTB.Location = handler.AddY(20).GetPosition();


            itemPanel.Controls.AddRange(new Control[] {
                titleLb,
                borrowerLb, dateBorrowedLb, expectedReturnDateLb, dateReturnedLb, equipmentBorrowedLb,  reasonLb, statusLb,
                borrowerTb, dateBorrowedTb, expectedReturnDateTb, dateReturnedTb, equipmentBorrowedLV, reasonRTB, statusTb });

            Height += 30;
        }

    }

    partial class SeeInfoAndStatusDisplay : GuiDisplay<EquipmentRequest>
    {
        
        public SeeInfoAndStatusDisplay(EquipmentRequest model)
            : base(model)
        {
            InitializeComponent();
            BindModelToView();
        }
        
        public SeeInfoAndStatusDisplay()
        {
        }
        partial void InitializeComponent();

    }
}
