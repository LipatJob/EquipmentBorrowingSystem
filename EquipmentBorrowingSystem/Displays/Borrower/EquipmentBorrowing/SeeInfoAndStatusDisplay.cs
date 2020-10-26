using EquipmentBorrowingSystem.Backend.Models;
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

            foreach (var equipment in Model.Equipments)
            {
                equipmentBorrowedLV.Items.Add(
                    new ListViewItem(new[] {
                    equipment.EquipmentType.Name,
                    equipment.Code}));
            }
        }


        TextBox borrowerTb;
        TextBox statusTb;
        TextBox dateBorrowedTb;
        TextBox expectedReturnDateTb;
        RichTextBox reasonRTB;
        ListView equipmentBorrowedLV;
        partial void InitializeComponent()
        {
            var titleLb = new Label() { Text = "Equipment Request", AutoSize = true, Font = new Font(FontFamily.GenericSansSerif, 12)};
            var borrowerLb = new Label() { Text = "Borrower Email", AutoSize = true };
            var statusLb = new Label() { Text = "Status", AutoSize = true };
            var dateBorrowedLb = new Label() { Text = "Date Borrowed", AutoSize = true };
            var expectedReturnDateLb = new Label() { Text = "Expected Return Date", AutoSize = true };
            var reasonLb = new Label() { Text = "Reason", AutoSize = true };
            var equipmentBorrowedLb = new Label() { Text = "Equipment Borrowed", AutoSize = true};

            borrowerTb = new TextBox() { Width = 150};
            statusTb = new TextBox() { Width = 150 };
            dateBorrowedTb = new TextBox() { Width = 150 };
            expectedReturnDateTb = new TextBox() { Width = 150 };
            reasonRTB = new RichTextBox() { Size = new Size(550, 100) };
            equipmentBorrowedLV = new ListView() { Size = new Size(260, 90), View = View.Details};


            // Initialize List View
            equipmentBorrowedLV.Columns.AddRange(
                new[]{
                new ColumnHeader{ Text = "Type" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Code" , TextAlign = HorizontalAlignment.Left, Width = 100} });

            LocationHandler handler = new LocationHandler(0, 0, 125, 30);

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
            reasonLb.Location = handler.Down().Left().GetPosition();
            reasonRTB.Location = handler.AddY(20).GetPosition();


            itemPanel.Controls.AddRange(new Control[] {
                titleLb,
                borrowerLb, dateBorrowedLb, expectedReturnDateLb, equipmentBorrowedLb,  reasonLb, statusLb,
                borrowerTb, dateBorrowedTb, expectedReturnDateTb, equipmentBorrowedLV, reasonRTB, statusTb });
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
