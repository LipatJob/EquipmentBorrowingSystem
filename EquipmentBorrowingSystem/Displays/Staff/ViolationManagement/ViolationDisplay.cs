using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Borrower.Violations
{
    partial class ViolationDisplay
    {

        public override void BindModelToView()
        {
            requestIdTb.Text = Model.EquipmentRequest.Id.ToString();
            borrowerEmailTb.Text = Model.EquipmentRequest.Borrower.Email;
            violationCb.SelectedItem = Model.Violation;
            if(Model.Resolved)
            {
                resolvedYes.Select();
            }
            else
            {
                resolvedNo.Select();
            }
            amountChargedTb.Text = Model.AmountCharged.ToString();
        }

        public override void BindViewToModel()
        {
            Model.AmountCharged = int.Parse(amountChargedTb.Text);
            if(resolvedYes.Checked)
            {
                Model.Resolved = true;
            }
            else
            {
                Model.Resolved = false;
            }
        }

        public void ViewMode()
        {
            requestIdTb.Enabled = false;
            borrowerEmailTb.Enabled = false;
            violationCb.Enabled = false;
            resolvedGroup.Enabled = false;
            amountChargedTb.Enabled = false;
            saveBtn.Enabled = false;
            deleteBtn.Enabled = false;
            editBtn.Click += new EventHandler(EditClick);
            BindModelToView();
        }

        public void EditMode()
        {
            requestIdTb.Enabled = false;
            borrowerEmailTb.Enabled = true;
            violationCb.Enabled = true;
            resolvedGroup.Enabled = true;
            amountChargedTb.Enabled = true;
            saveBtn.Enabled = true;
            deleteBtn.Enabled = true;
            deleteBtn.Click += new EventHandler(DeleteAction);
            saveBtn.Click += new EventHandler(EditAction);
        }

        public void AddMode()
        {
            requestIdTb.Enabled = false;
            borrowerEmailTb.Enabled = false;
            violationCb.Enabled = true;
            resolvedGroup.Enabled = true;
            amountChargedTb.Enabled = true;
            saveBtn.Enabled = true;
            saveBtn.Click += new EventHandler(AddAction);
        }

        private void EditClick(object sender, EventArgs e)
        {
            saveBtn.Enabled = true;
            EditMode();
        }

        private void DeleteAction(object sender, EventArgs e)
        {
            BindViewToModel();
            if (MessageBox.Show("Are you sure you want to delete this violation?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Response response = Director.ViolationManagementController.DeleteViolation(Model.Id);

            if (response.Success)
            {
                MessageBox.Show("Violation has been deleted", "Delete Success");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.ViolationManagementController.SeeViolations());
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again", "Delete Failed");
            }
        }


        private void AddAction(object sender, EventArgs e)
        {
            BindViewToModel();
            Response response = Director.ViolationManagementController.AddViolation(Model);

            if (response.Success)
            {
                MessageBox.Show("Add Violation Success", "Violation has been Added");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.ViolationManagementController.SeeViolations());
            }
            else
            {
                MessageBox.Show("Add Violation Failed", "Something went wrong Please try again.");
            }
        }

        private void EditAction(object sender, EventArgs e)
        {
            BindViewToModel();
            Response response = Director.ViolationManagementController.EditViolation(Model);

            if (response.Success)
            {
                MessageBox.Show("Add Violation Success", "Violation has been Added");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.ViolationManagementController.SeeViolations());
            }
            else
            {
                MessageBox.Show("Add Violation Failed", "Something went wrong Please try again.");
            }
        }

        private void ViewRequestAction(object sender, EventArgs e)
        {
            Director.ShowDisplay(Director.BorrowedEquipmentLogController.RequestInformation(Model.RequestId));
        }



        Label requestIdLb;
        Label borrowerEmailLb;
        Label violationLb;
        Label resolvedLb;
        Label amountChargedLb;

        TextBox requestIdTb;
        TextBox borrowerEmailTb;
        ComboBox violationCb;
        RadioButton resolvedYes;
        RadioButton resolvedNo;
        Panel resolvedGroup;
        TextBox amountChargedTb;

        Button viewRequestBtn;
        Button editBtn;
        Button saveBtn;
        Button deleteBtn;

        partial void InitializeComponent()
        {
            int fontSize = 12;
            var temp = new Label();
            Font defaultFont = temp.Font;
            int labelWidth = 140;
            LocationHandler handler = new LocationHandler(0, 0, labelWidth, 30);

            var titleLb = new Label() {
                Text = "Borrower Violation",
                Location = handler.GetPosition(),
                Font = new Font(defaultFont.Name, 12),
                AutoSize = true
            };

            handler.X = 20;

            requestIdLb = new Label() {
                Text = "Request ID",
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                Width = labelWidth,
            };

            viewRequestBtn = new Button()
            {
                Text = "View Request",
                Location = new Point(labelWidth + 75 + 30, handler.Y),
                Size = new Size(150, 25),
                Font = defaultFont
            };

            borrowerEmailLb = new Label() { 
                Text = "Borrower Email",
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                Width = labelWidth,
            };
            violationLb = new Label()
            {
                Text = "Violation",
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                Width = labelWidth,
            };
            amountChargedLb = new Label()
            {
                Text = "Amount Charged",
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                Width = labelWidth,
            };
            resolvedLb = new Label() { 
                Text = "Resolved",
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                Width = labelWidth,
            };


            handler.Up().Up().Up().Up().Right();

            requestIdTb = new TextBox() {
                Location = handler.GetPosition(),
                Width = 75,
                Font = defaultFont
            };
            borrowerEmailTb = new TextBox() {
                Location = handler.Down().GetPosition(),
                Width = 250,
                Font = defaultFont
            };
            violationCb = new ComboBox()
            {
                Location = handler.Down().GetPosition(),
                Width = 250,
                Font = defaultFont,
                DataSource = ApplicationState.GetInstance().Violations.Values.ToList(),
                ValueMember = "Id",
                DisplayMember = "name"
            };
            amountChargedTb = new TextBox()
            {
                Location = handler.Down().GetPosition(),
                Width = 250,
                Font = defaultFont
            };
            resolvedYes = new RadioButton { 
                Text= "Yes",
                Font = defaultFont
            };
            resolvedNo = new RadioButton {
                Text = "No",
                Location = new Point(75, 0),
                Font = defaultFont
            };
            resolvedGroup   = new Panel() {
                Location = handler.Down().GetPosition(),
                Font = defaultFont,
                
            };


            var actionsPl = new Panel {  Dock = DockStyle.Bottom, Padding = new Padding(0, 10, 30, 10), Height = 50};

            deleteBtn = new Button()
            {
                Text = "Delete",
                Dock = DockStyle.Left,
                Font = defaultFont
            };

            saveBtn = new Button()
            {
                Text = "Save",
                Dock = DockStyle.Right,
                Font = defaultFont
            };

            editBtn = new Button() { 
                Text = "Edit",
                Dock = DockStyle.Right,
                Font = defaultFont
            };

            actionsPl.Controls.AddRange(new Control[] { deleteBtn, editBtn, saveBtn });
           
            
            resolvedGroup.Controls.AddRange(new Control[] { resolvedNo, resolvedYes });

            this.itemPanel.Controls.AddRange(new Control[] {
                titleLb,
                requestIdLb, borrowerEmailLb, resolvedLb, amountChargedLb,
                requestIdTb, borrowerEmailTb, amountChargedTb, 
                viewRequestBtn, actionsPl, resolvedGroup, violationCb, violationLb});

            Height = handler.Down().Y + actionsPl.Height +titlePl.Height + 50;


            viewRequestBtn.Click += new EventHandler(ViewRequestAction);

            if (mode == Modes.ADD)
            {
                AddMode();
            }
            else
            {
                ViewMode();
            }
        }
    }



    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class ViolationDisplay : GuiDisplay<BorrowerViolation>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV    

        public enum Modes { ADD, VIEW }
        Modes mode;
        public ViolationDisplay(BorrowerViolation model, Modes mode) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            this.mode = mode;
            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public ViolationDisplay()
        {
            // This Constructor allows you to use the designer. 
        }

        // put all GUI in the implementation of this method
        partial void InitializeComponent();

    }




}
