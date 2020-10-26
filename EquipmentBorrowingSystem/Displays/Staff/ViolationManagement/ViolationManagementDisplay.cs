using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Borrower.Violations
{
    partial class ViolationManagementDisplay
    {
        public override void BindModelToView()
        {
            foreach (BorrowerViolation violation in Model)
            {
                if (!violation.Resolved)
                {
                    AddViolation(unresolvedList, violation);
                }
                AddViolation(historyList, violation);
            }
        }

        public override void BindViewToModel()
        {

        }

        private void AddViolation(ListView listView, BorrowerViolation violation)
        {
            var item = new ListViewItem(new[] {
                violation.EquipmentRequest.Borrower.Email,
                violation.Violation.name,
                string.Join(", ", violation.EquipmentRequest.Equipments.SelectMany(e=>e.EquipmentType.Name)),
                violation.AmountCharged.ToString(),
                violation.Resolved.ToString()
            });
            item.Tag = violation.Id;
            listView.Items.Add(item);
        }

        private void SelectedItem(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;

            if (listView.SelectedItems.Count == 0) { return; }
            ListViewItem item = listView.SelectedItems[0];

            int id = (int)item.Tag;

            this.Hide();
            this.Close();
            Director.ShowDisplay(Director.ViolationManagementController.DisplayViolation(id));
        }

        private ListView CreateList()
        {
            var list = new ListView { Dock = DockStyle.Fill, View = View.Details };
            list.Columns.AddRange(new[]{
                new ColumnHeader{ Text = "Email" , TextAlign = HorizontalAlignment.Left, Width = 150},
                new ColumnHeader{ Text = "Violation" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Request ID" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Amount Charged" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Resolved" , TextAlign = HorizontalAlignment.Left, Width = 100}});
            list.DoubleClick += new EventHandler(SelectedItem);
            return list;
        }



        TabControl tabs;

        TabPage unresolvedTab;
        ListView unresolvedList;

        TabPage historyTab;
        ListView historyList;

        partial void InitializeComponent()
        {
            Text = "Violations";
            tabs = new TabControl { TabIndex = 0, Dock = DockStyle.Fill, Location = new Point(0, 0) };

            // Unresolved Violations
            unresolvedTab = new TabPage("Unresolved");
            historyTab = new TabPage("History");
            tabs.TabPages.AddRange(new[] { unresolvedTab, historyTab });


            unresolvedList = CreateList();
            unresolvedTab.Controls.Add(unresolvedList);

            // History
            historyList = CreateList();
            historyTab.Controls.Add(historyList);

            itemPanel.Controls.Add(tabs);

            BindModelToView();
        }
    }



    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class ViolationManagementDisplay : GuiDisplay<IEnumerable<BorrowerViolation>>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public ViolationManagementDisplay(IEnumerable<BorrowerViolation> model) // <<< Replace with model class
            : base(model)
        {
            InitializeComponent();
        }

        public ViolationManagementDisplay()
        {
        }

        partial void InitializeComponent();

    }
}
