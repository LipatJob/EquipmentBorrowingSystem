using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                var item = new ListViewItem(new[]{
                    request.Id.ToString(),
                    request.RequestStatus.Name,
                    string.Join(", ", request.Equipments.Select(e=>e.Code)),
                    request.DateBorrowed.ToString(),
                    request.ExpectedReturnDate.ToString(), });
                item.Tag = request.Id;
                borrowHistory.Items.Add(item);
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
            borrowHistory = new ListView {Dock = DockStyle.Fill, View = View.Details, MultiSelect = false, FullRowSelect = true };

            borrowHistory.Columns.AddRange(new[] {
                new ColumnHeader{ Text = "Request ID" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Status" , TextAlign = HorizontalAlignment.Left, Width = 75},
                new ColumnHeader{ Text = "Equipment Borrowed" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Date Borrowed" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Expted Return Date" , TextAlign = HorizontalAlignment.Left, Width = 100},
            });
            borrowHistory.DoubleClick += RequestClicked;
            itemPanel.Controls.Add(borrowHistory);
            BindModelToView();
        }

        private void RequestClicked(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView.SelectedItems[0];

            int id = (int)item.Tag;
            this.Hide();
            Director.ShowDisplay(Director.EquipmentBorrowingController.ViewRequest(id));
            this.Show();
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