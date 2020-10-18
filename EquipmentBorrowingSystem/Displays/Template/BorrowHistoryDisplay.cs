using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Borrower.BorrowerAccount
{
    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class BorrowerHistoryDisplay
    {

        public override void BindModelToView()
        {
            foreach (EquipmentRequest request in Model)
            {
                borrowHistory.Items.Add(new ListViewItem(new[]{
                    request.Id.ToString(),
                    request.Equipment.Name,
                    request.RequestStatus.Name,
                    request.Equipment.EquipmentType.Name,
                    request.DateBorrowed.ToString()}));
            }
        }

        //pwede ko ba resize yung objects ko sa design na lang?
        //would it change something sa code?
        //for example, naglagay na ako ng objects sa InitializeComponent(), tapos iniba ko yung size sa design
        //AH okay gegege

        public override void BindViewToModel()
        {
        }


        ListView borrowHistory;

        partial void InitializeComponent()
        {
            Height = 300;
            Width = 500;

            borrowHistory = new ListView { Width = 200, Height = 200, View = View.Details};
            borrowHistory.Width = this.Width;
            borrowHistory.Height = this.Height;

            borrowHistory.Columns.AddRange(new[] {
                new ColumnHeader{ Text = "Equipment ID" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Equipment Name" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Status" , TextAlign = HorizontalAlignment.Left, Width = 75},
                new ColumnHeader{ Text = "Equipment Type" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Date Borrowed" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Date Returned" , TextAlign = HorizontalAlignment.Left, Width = 100},

            });

            Controls.AddRange(new[] { borrowHistory });
            BindModelToView();
        }
    }


    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class BorrowerHistoryDisplay : GuiDisplay<IEnumerable<EquipmentRequest>>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public BorrowerHistoryDisplay(IEnumerable<EquipmentRequest> model) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public BorrowerHistoryDisplay()
        {
            // This Constructor allows you to use the designer. 
        }

        // put all GUI in the implementation of this method
        partial void InitializeComponent();
    }



}