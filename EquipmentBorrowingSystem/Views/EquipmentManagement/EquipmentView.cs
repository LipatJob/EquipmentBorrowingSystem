using EquipmentBorrowingSystem.Repository;
using EquipmentBorrowingSystem.Repository.ViewModels;
using EquipmentBorrowingSystem.Views.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views.EquipmentManagement
{
    class EquipmentView : Form
    {
        public enum ViewState { EDIT, ADD, VIEW}
        public EquipmentViewModel model { get; set; }
        private StaffRepository repository;

        public EquipmentView(EquipmentViewModel equipment, StaffRepository repository, ViewState state)
        {
            this.model = equipment;
            this.repository = repository;
            InitializeComponent();
            SetState(state);
        }

        private TableLayoutPanel mainPanel;
        private TableLayoutPanel fieldsPanel;
        private FlowLayoutPanel actionPanel;

        private Label nameLabel;
        private Label equipmentLabel;
        private Label conditionLabel;

        private TextBox nameTextBox;
        private ComboBox equipmentTypeComboBox;
        private ComboBox conditionTypeComboBox;

        private Button editAddButton;
        private Button closeButton;
        private Button deleteButton;

        private void InitializeComponent()
        {
            
            // Initialize Components
            fieldsPanel = new TableLayoutPanel();
            actionPanel = new FlowLayoutPanel();
            mainPanel = new TableLayoutPanel();

            nameLabel = new CLabel("Name", 200, 50, 0, 0);
            equipmentLabel = new CLabel("Equipment Type", 200, 50, 0, 0);
            conditionLabel = new CLabel("Condition", 200, 50, 0, 0);

            nameTextBox = new TextBox();
            equipmentTypeComboBox = new ComboBox();
            conditionTypeComboBox = new ComboBox();

            editAddButton   = new Button();
            closeButton     = new Button();
            deleteButton    = new Button();

            // Set Values
            closeButton.Text = "Close";
            deleteButton.Text = "Delete";

            // Layout Fields
            fieldsPanel.ColumnCount = 2;
            fieldsPanel.RowCount = 5;

            fieldsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            fieldsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            fieldsPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            fieldsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

            fieldsPanel.Controls.Add(nameLabel,0, 0);
            fieldsPanel.Controls.Add(equipmentLabel,0,1);
            fieldsPanel.Controls.Add(conditionLabel, 0, 2);
            fieldsPanel.Controls.Add(nameTextBox, 1, 0);
            fieldsPanel.Controls.Add(equipmentTypeComboBox, 1, 1);
            fieldsPanel.Controls.Add(conditionTypeComboBox, 1, 2);

            // Layout Actions
            actionPanel.Width = this.Width;
            actionPanel.Controls.Add(closeButton);
            actionPanel.Controls.Add(deleteButton);
            actionPanel.Controls.Add(editAddButton);

            // Layoout Main Panel
            mainPanel.Location = new Point(0, 0);
            mainPanel.Size = new Size(this.Width, this.Height);

            mainPanel.ColumnCount = 1;
            mainPanel.RowCount = 2;

            mainPanel.Controls.Add(fieldsPanel, 0, 0);
            mainPanel.Controls.Add(actionPanel, 0, 1);

            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));

            this.Controls.Add(mainPanel);
        }

        public void SetState(ViewState state)
        {
                 if (state == ViewState.ADD)  { AddMode();  }
            else if (state == ViewState.EDIT) { EditMode(); }
            else if (state == ViewState.VIEW) { ViewMode(); }
        }

        public void ResetMode()
        {
            nameTextBox.Enabled = true;
            equipmentTypeComboBox.Enabled = true;
            conditionTypeComboBox.Enabled = true;
            editAddButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        public void EditMode()
        {
            bindModelToView();
            ResetMode();
            editAddButton.Text = "Exit";
            editAddButton.Click += new EventHandler(EditAction);
        }

        public void AddMode()
        {
            bindModelToView();
            ResetMode();
            editAddButton.Text = "Add";
            editAddButton.Click += new EventHandler(AddAction);


        }

        public void ViewMode()
        {
            ResetMode();
            nameTextBox.Enabled = false;
            equipmentTypeComboBox.Enabled = false;
            conditionTypeComboBox.Enabled = false;
            editAddButton.Enabled = false;
            deleteButton.Enabled = false;
        }

        private void AddAction(object sender, EventArgs e)
        {
            bindViewToModel();
            repository.AddEquipment(model);
        }

        private void EditAction(object sender, EventArgs e)
        {
            bindViewToModel();
            repository.EditEquipment(model);
        }

        private void DeleteAction(object sender, EventArgs e)
        {
            bindViewToModel();
            repository.DeleteEquipment(model);
        }

        private void bindViewToModel()
        {
            model.name = nameTextBox.Text;
            model.equipmentType = equipmentTypeComboBox.Text;
            model.condition = conditionTypeComboBox.Text;
        }

        private void bindModelToView()
        {
            nameTextBox.Text = model.name;
            equipmentTypeComboBox.Items.AddRange(model.equipmentTypes.ToArray());
            conditionTypeComboBox.Items.AddRange(model.conditions.ToArray());
            equipmentTypeComboBox.SelectedItem = model.equipmentType;
            conditionTypeComboBox.SelectedItem = model.condition;
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            var viewModel = new EquipmentViewModel();
            viewModel.name = "Table Tennis";
            viewModel.equipmentType = "Table";
            viewModel.condition = "OK";
            viewModel.equipmentTypes = new string[] { "Table Tennis", "Table" }.ToArray();
            viewModel.conditions = new string[] { "OK", "Damaged" }.ToArray();

            Application.Run(new EquipmentView(viewModel, null, ViewState.ADD));
        }

    }
}
