using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Displays;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views.Staff.BorrowedEquipmentLog
{
    partial class BorrowedEquipmentLog2GuiDisplay
    {

        


        private void AddItem(ListView listView, EquipmentRequest request)
        {
            var item = new ListViewItem(new string[] { request.RequestStatus.Name, request.Borrower.Email, request.Equipment.Name, request.Equipment.EquipmentCondition.Name, 
                request.Reason, request.DateBorrowed.ToString(), request.DateReturned.ToString(), request.ExpectedReturnDate.ToString() });
            item.Tag = request.Id;
            listView.Items.Add(item);
        }


        private ListView CreateList()
        {
            var list = new ListView { Dock = DockStyle.Fill, View = View.Details, MultiSelect = false};
            list.Columns.AddRange(new[]{
                 new ColumnHeader{ Text = "Status" , TextAlign = HorizontalAlignment.Left, Width = 150},
                new ColumnHeader{ Text = "Borrower" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Equipment" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Condition" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Reason" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Date Borrowed" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Date Returned" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Expected Return Date" , TextAlign = HorizontalAlignment.Left, Width = 100},
            });

            list.DoubleClick += new EventHandler(SelectedItem);

            return list;
        }

        private void SelectedItem(object sender, EventArgs e)
        {
            ListView listView = (ListView) sender;

            if (listView.SelectedItems.Count == 0) { return;  }
            ListViewItem item = listView.SelectedItems[0];

            int id = (int) item.Tag;

            this.Hide();
            this.Close();
            Director.ShowDisplay(Director.BorrowedEquipmentLogController.RequestInformation(id));
        }

        public override void BindModelToView()
        {
            foreach (EquipmentRequest request in Model.ToList())
            {
                string status = request.RequestStatus.Name;
                if (status == "Pending") { AddItem(pendingList, request); }
                else if (status == "Denied") { AddItem(deniedList, request); }
                else if (status == "Active") { AddItem(activeList, request); }
                else if (status == "Complete") { AddItem(completeList, request); }
                AddItem(allList, request);
            }

            foreach (EquipmentRequest request in Director.BorrowedEquipmentLogController.GetOverdueRequests())
            {
                AddItem(overdueList, request);
            }
        }

        TabControl tabs;

        TabPage allTab;
        ListView allList;

        TabPage pendingTab;
        ListView pendingList;

        TabPage deniedTab;
        ListView deniedList;

        TabPage activeTab;
        ListView activeList;

        TabPage completeTab;
        ListView completeList;

        TabPage overdueTab;
        ListView overdueList;

        partial void InitializeComponent()
        {
            Text = "Violations";
            tabs = new TabControl { TabIndex = 0, Dock = DockStyle.Fill, Location = new Point(0, 0) };

            // Unresolved Violations
            allTab = new TabPage("All");
            pendingTab = new TabPage("Pending");
            deniedTab = new TabPage("Denied");
            activeTab = new TabPage("Active");
            completeTab = new TabPage("Complete");
            overdueTab = new TabPage("Overdue");

            tabs.TabPages.AddRange(new[] { allTab, pendingTab, deniedTab, activeTab, completeTab, overdueTab });


            allList = CreateList();
            pendingList = CreateList();
            deniedList = CreateList();
            activeList = CreateList();
            completeList = CreateList();
            overdueList = CreateList();

            allTab.Controls.Add(allList);
            pendingTab.Controls.Add(pendingList);
            deniedTab.Controls.Add(deniedList);
            activeTab.Controls.Add(activeList);
            completeTab.Controls.Add(completeList);
            overdueTab.Controls.Add(overdueList);

            itemPanel.Controls.Add(tabs);

            BindModelToView();
        }
    }

    partial class BorrowedEquipmentLog2GuiDisplay : GuiDisplay<IEnumerable<EquipmentRequest>>
    {
        public BorrowedEquipmentLog2GuiDisplay(IEnumerable<EquipmentRequest> model) 
            : base(model)
        {
            InitializeComponent();
        }                
        public BorrowedEquipmentLog2GuiDisplay()
        {

        }
        partial void InitializeComponent();
    }
}
