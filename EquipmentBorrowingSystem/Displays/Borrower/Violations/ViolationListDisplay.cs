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
    partial class ViolationListDisplay
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
            listView.Items.Add(new ListViewItem(new[] {
                violation.Violation.name,
                violation.RequestId.ToString(),
                violation.AmountCharged.ToString(),
                violation.Resolved.ToString()
            }));
        }

        private ListView CreateList()
        {
            var list = new ListView { Dock = DockStyle.Fill, View = View.Details, FullRowSelect = true, MultiSelect = false};
            list.Columns.AddRange(new[]{
                new ColumnHeader{ Text = "Violation" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Request ID" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Amount Charged" , TextAlign = HorizontalAlignment.Left, Width = 100},
                new ColumnHeader{ Text = "Resolved" , TextAlign = HorizontalAlignment.Left, Width = 100}});
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
            Width = 500;
            Height = 300;

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
    partial class ViolationListDisplay : GuiDisplay<IEnumerable<BorrowerViolation>>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public ViolationListDisplay(IEnumerable<BorrowerViolation> model) // <<< Replace with model class
            : base(model)
        {
            InitializeComponent();
        }

        public ViolationListDisplay()
        {
        }

        partial void InitializeComponent();

    }

}
