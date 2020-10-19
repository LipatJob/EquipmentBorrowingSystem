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

namespace EquipmentBorrowingSystem.Displays.Staff.EquipmentManagement
{
    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class EquipmentGuiDisplay
    {
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        
        public void BindModelToView()
        {
            
            idTb.Text = Model.Id.ToString();
            nameTb.Text = Model.Name.ToString();
            
            typeCb.SelectedItem = Model.EquipmentType.Name;
            conditionCb.SelectedItem = Model.EquipmentCondition.Name;
        }

        public void BindViewToModel()
        {
            Model.Name = nameTb.Text;
            Model.EquipmentTypeID = types[typeCb.SelectedIndex].Id;
            Model.ConditionID = conditions[conditionCb.SelectedIndex].Id;
        }


        private void SetAddMode()
        {
            idTb.Enabled = false;
            nameTb.Enabled = true;
            typeCb.Enabled = true;
            conditionCb.Enabled = true;
            saveBtn.Enabled = true;
            deleteBtn.Enabled = false;
            this.saveBtn.Click += new EventHandler(this.AddAction);
        }

        private void SetViewMode()
        {
            BindModelToView();
            idTb.Enabled = false;
            nameTb.Enabled = false;
            typeCb.Enabled = false;
            conditionCb.Enabled = false;
            saveBtn.Enabled = false;
            deleteBtn.Click += new EventHandler(this.DeleteAction);
            editBtn.Click += new EventHandler(this.EditAction);
        }

        private void SetEditMode()
        {
            idTb.Enabled = false;
            nameTb.Enabled = true;
            typeCb.Enabled = true;
            conditionCb.Enabled = true;
            saveBtn.Enabled = true;
            editBtn.Enabled = false;
            this.saveBtn.Click += new EventHandler(this.SaveAction);

        }

        private void EditAction(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void DeleteAction(object sender, EventArgs e)
        {
            BindViewToModel();
            if(MessageBox.Show("Are you sure you want to delete this equipment?", "Confirm Delete",  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {

            }
            Response response = Director.EquipmentManagementController.DeleteEquipment(Model.Id);

            if (response.Success)
            {
                MessageBox.Show("Equipment has been deleted", "Delete Success");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
            }
            else
            {
                MessageBox.Show("Something went wrong. Please try again", "Delete Failed");
            }
        }

        private void AddAction(object sender, EventArgs e)
        {
            BindViewToModel();
            Response response = Director.EquipmentManagementController.AddEquipment(Model);

            if (response.Success)
            {
                MessageBox.Show("Add Equipment Success", "Equipment has been Added");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
            }
            else
            {
                MessageBox.Show("Add Equipment Failed", "Something went wrong Please try again.");
            }
        }

        private void SaveAction(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nameTb.Text))
            {
                MessageBox.Show("Name must Not be empty", "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BindViewToModel();
            Response response = Director.EquipmentManagementController.EditEquipment(Model);

            if (response.Success)
            {
                MessageBox.Show("Equipment has been edited", "Edit Success");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
            }
            else
            {
                MessageBox.Show("Something went wrong. please try again", "Edit Failed");
            }
        }


        Label idLb;
        Label nameLb;
        Label typeLb;
        Label conditionLb;

        TextBox idTb;
        TextBox nameTb;
        ComboBox typeCb;
        ComboBox conditionCb;

        Button saveBtn;
        Button editBtn;
        Button deleteBtn;

        List<EquipmentType> types;
        List<EquipmentCondition> conditions;

        partial void InitializeComponent()
        {
            // Initialize Components
            int tbWidth = 75;
            idLb = new Label { Text = "ID", TextAlign = ContentAlignment.MiddleRight, Width = tbWidth };
            nameLb = new Label { Text = "Name", TextAlign = ContentAlignment.MiddleRight, Width = tbWidth };
            typeLb = new Label { Text = "Type", TextAlign = ContentAlignment.MiddleRight, Width = tbWidth };
            conditionLb = new Label { Text = "Condition", TextAlign = ContentAlignment.MiddleRight, Width = tbWidth };

            idTb = new TextBox();
            nameTb = new TextBox();
            typeCb = new ComboBox();
            conditionCb = new ComboBox();

            saveBtn = new Button { Text = "Save" };
            editBtn = new Button { Text = "Edit" };
            deleteBtn = new Button { Text = "Delete" };

            Controls.AddRange(new Control[] { nameTb, typeCb, conditionCb, nameLb, typeLb, conditionLb, idTb, idLb, saveBtn, deleteBtn, editBtn});

            // Initialize Values
            types = ApplicationState.GetInstance().EquipmentTypes.Values.ToList();
            conditions = ApplicationState.GetInstance().EquipmentConditions.Values.ToList();
            typeCb.Items.AddRange(types.Select(e => e.Name).ToArray());
            conditionCb.Items.AddRange(conditions.Select(e => e.Name).ToArray());
            typeCb.SelectedIndex = 0;
            conditionCb.SelectedIndex = 0;

            // Set Mode
            if (mode == ViewMode.ADD) { SetAddMode(); }
            else if (mode == ViewMode.VIEW) { SetViewMode(); }

            // Layout Components
            LocationHandler handler = new LocationHandler(5, 5, 100, 25);
            deleteBtn.Location = handler.Right().Right().GetPosition();
            editBtn.Location = handler.Down().GetPosition();
            handler.Left().Left().Up().AmountX = tbWidth;
            idLb.Location           = handler.Down().GetPosition();
            nameLb.Location         = handler.Down().GetPosition();
            typeLb.Location         = handler.Down().GetPosition();
            conditionLb.Location    = handler.Down().GetPosition();

            handler.Up().Up().Up().Up().Right();

            idTb.Location           = handler.Down().GetPosition();
            nameTb.Location         = handler.Down().GetPosition();
            typeCb.Location         = handler.Down().GetPosition();
            conditionCb.Location    = handler.Down().GetPosition();

            saveBtn.Location        = handler.Down().GetPosition();
        }



    }

    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class EquipmentGuiDisplay : GuiDisplay<Equipment>
    {
        public enum ViewMode { ADD, VIEW }

        ViewMode mode;

        //   Replace with class name              Replace with model class
        //   VVVVVVVVVVVVVVV                      VVVVVV
        public EquipmentGuiDisplay(Equipment model, ViewMode mode)
            : base(model)
        {
            this.mode = mode;
            InitializeComponent();
        }


        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public EquipmentGuiDisplay()
        {
            // This Constructor allows you to use the designer
        }

        partial void InitializeComponent();

    }
}
