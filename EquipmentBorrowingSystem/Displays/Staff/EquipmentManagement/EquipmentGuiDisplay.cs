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

        public override void BindModelToView()
        {
            
            idTb.Text = Model.Id.ToString();
            codeTb.Text = Model.Code.ToString();
            
            typeCb.SelectedItem = Model.EquipmentType.Name;
            conditionCb.SelectedItem = Model.EquipmentCondition.Name;
        }

        public override void BindViewToModel()
        {
            Model.EquipmentTypeID = (int)typeCb.SelectedValue;
            Model.ConditionID = (int)typeCb.SelectedValue;
        }


        private void SetAddMode()
        {
            titleLb.Text = "Add Equipment";
            idTb.Enabled = false;
            codeTb.Enabled = false;
            typeCb.Enabled = true;
            conditionCb.Enabled = true;
            saveBtn.Enabled = true;
            deleteBtn.Enabled = false;
            this.saveBtn.Click += new EventHandler(this.AddAction);
        }

        private void SetViewMode()
        {
            BindModelToView();
            titleLb.Text = "View Equipment";
            idTb.Enabled = false;
            codeTb.Enabled = false;
            typeCb.Enabled = false;
            conditionCb.Enabled = false;
            saveBtn.Enabled = false;
            deleteBtn.Click += new EventHandler(this.DeleteAction);
            editBtn.Click += new EventHandler(this.EditAction);
        }

        private void SetEditMode()
        {
            titleLb.Text = "Edit Equipment";
            idTb.Enabled = false;
            codeTb.Enabled = false;
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
            if(string.IsNullOrWhiteSpace(codeTb.Text))
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

        Label titleLb;
        Label idLb;
        Label nameLb;
        Label typeLb;
        Label conditionLb;

        TextBox idTb;
        TextBox codeTb;
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
            int tbWidth = 190;
            int lbWidth = 100;
            Font font = new Font(FontFamily.GenericSansSerif, 10);
            types = ApplicationState.GetInstance().EquipmentTypes.Values.ToList();
            conditions = ApplicationState.GetInstance().EquipmentConditions.Values.ToList();

            titleLb = new Label { Text = "Add Equipment", Width = 260, Font = new Font(FontFamily.GenericSansSerif, 14) };
            idLb = new Label { Text = "ID", Width = lbWidth, Font = font};
            nameLb = new Label { Text = "Code", Width = lbWidth, Font = font };
            typeLb = new Label { Text = "Type", Width = lbWidth, Font = font };
            conditionLb = new Label { Text = "Condition", Width = lbWidth, Font = font };


            idTb = new TextBox { Font = font, Width = tbWidth};
            codeTb = new TextBox { Font = font, Width = tbWidth };
            typeCb = new ComboBox { Font = font, Width = tbWidth };
            conditionCb = new ComboBox { Font = font, Width = tbWidth };

            saveBtn = new Button { Font = font, Text = "Save", Size = new Size(75, 30) };
            editBtn = new Button { Font = font, Text = "Edit", Size = new Size(75, 30) };
            deleteBtn = new Button { Font = font, Text = "Delete", Size = new Size(75, 30) };


            // Initialize Values
            typeCb.DataSource = types;
            typeCb.ValueMember = "Id";
            typeCb.DisplayMember = "Name";

            conditionCb.DataSource = conditions;
            conditionCb.ValueMember = "Id";
            conditionCb.DisplayMember = "Name";

            // Set Mode
            if (mode == ViewMode.ADD) { SetAddMode(); }
            else if (mode == ViewMode.VIEW) { SetViewMode(); }

            // Layout Components
            LocationHandler handler = new LocationHandler(0, 0, lbWidth, 40);
            titleLb.Location = handler.GetPosition();
            idLb.Location           = handler.Down().GetPosition();
            nameLb.Location         = handler.Down().GetPosition();
            typeLb.Location         = handler.Down().GetPosition();
            conditionLb.Location    = handler.Down().GetPosition();

            handler.Up().Up().Up().Up().Right();
            handler.AmountX = tbWidth;

            idTb.Location           = handler.Down().GetPosition();
            codeTb.Location         = handler.Down().GetPosition();
            typeCb.Location         = handler.Down().GetPosition();
            conditionCb.Location    = handler.Down().GetPosition();

            handler.X = 0;
            handler.AmountX = 80;
            handler.AmountY += 10;
            deleteBtn.Location = handler.Down().GetPosition();
            editBtn.Location = handler.Right().Right().GetPosition();
            saveBtn.Location = handler.Right().GetPosition();
            itemPanel.Controls.AddRange(new Control[] { codeTb, typeCb, conditionCb, nameLb, typeLb, conditionLb, idTb, idLb, saveBtn, deleteBtn, editBtn , titleLb});

            Height = 500;
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
