using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
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

        List<EquipmentType> types;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox conditionComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label label4;
        List<EquipmentCondition> conditions;

        public void InitializeComboBoxes()
        {
            types = ApplicationState.GetInstance().EquipmentTypes.Values.ToList();
            conditions = ApplicationState.GetInstance().EquipmentConditions.Values.ToList();
            typeComboBox.Items.AddRange(types.Select(e => e.Name).ToArray());
            conditionComboBox.Items.AddRange(conditions.Select(e => e.Name).ToArray());
        }
        public void BindModelToView()
        {
            
            idTextBox.Text = Model.Id.ToString();
            nameTextBox.Text = Model.Name.ToString();
            
            typeComboBox.SelectedItem = Model.EquipmentType.Name;
            conditionComboBox.SelectedItem = Model.EquipmentCondition.Name;
        }

        public void BindViewToModel()
        {
            Model.Name = nameTextBox.Text;
            Model.EquipmentTypeID = types[typeComboBox.SelectedIndex].Id;
            Model.ConditionID = conditions[conditionComboBox.SelectedIndex].Id;
        }


        private void SetAddMode()
        {
            idTextBox.Enabled = false;
            nameTextBox.Enabled = true;
            typeComboBox.Enabled = true;
            conditionComboBox.Enabled = true;
            saveButton.Enabled = true;
            this.saveButton.Click += new EventHandler(this.AddAction);
        }

        private void SetViewMode()
        {
            idTextBox.Enabled = false;
            nameTextBox.Enabled = false;
            typeComboBox.Enabled = false;
            conditionComboBox.Enabled = false;
            saveButton.Enabled = false;
        }

        private void SetEditMode()
        {
            idTextBox.Enabled = false;
            nameTextBox.Enabled = true;
            typeComboBox.Enabled = true;
            conditionComboBox.Enabled = true;
            saveButton.Enabled = true;
            this.saveButton.Click += new EventHandler(this.SaveAction);

        }

        private void EditAction(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void DeleteAction(object sender, EventArgs e)
        {
            BindViewToModel();
            Response response = Director.EquipmentManagementController.DeleteEquipment(Model.Id);

            if (response.Success)
            {
                MessageBox.Show("Delete Success", "Equipment has been Deleted");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
            }
            else
            {
                MessageBox.Show("Delete Failed", "Something went wrong Please try again.");
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
            BindViewToModel();
            Response response = Director.EquipmentManagementController.EditEquipment(Model);

            if (response.Success)
            {
                MessageBox.Show("Edit Success", "Equipment has been edited");
                this.Hide();
                this.Close();
                Director.ShowDisplay(Director.EquipmentManagementController.EquipmentMenu());
            }
            else
            {
                MessageBox.Show("Edit Failed", "Something went wrong Please try again.");
            }
        }



        partial void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.conditionComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79.41509F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 143.5849F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(426, 300);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Location = new System.Drawing.Point(3, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 35);
            this.panel1.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(9, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(339, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 73);
            this.panel2.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(268, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Equipment Borrowing System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(290, 29);
            this.label5.TabIndex = 3;
            this.label5.Text = "Malayan Colleges Laguna";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(339, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.EditAction);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DeleteAction);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Location = new System.Drawing.Point(3, 82);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 138);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.84487F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.15513F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.nameTextBox, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.conditionComboBox, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.typeComboBox, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.idTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 129);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameTextBox.Location = new System.Drawing.Point(147, 34);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(200, 22);
            this.nameTextBox.TabIndex = 3;
            // 
            // conditionComboBox
            // 
            this.conditionComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.conditionComboBox.FormattingEnabled = true;
            this.conditionComboBox.Location = new System.Drawing.Point(147, 97);
            this.conditionComboBox.Name = "conditionComboBox";
            this.conditionComboBox.Size = new System.Drawing.Size(200, 24);
            this.conditionComboBox.TabIndex = 5;
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(147, 63);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(200, 24);
            this.typeComboBox.TabIndex = 4;
            // 
            // idTextBox
            // 
            this.idTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.idTextBox.Location = new System.Drawing.Point(147, 4);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(129, 22);
            this.idTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Equipment ID";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Condition";
            // 
            // EquipmentGuiDisplay
            // 
            this.ClientSize = new System.Drawing.Size(426, 300);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EquipmentGuiDisplay";
            this.Load += new System.EventHandler(this.EquipmentGuiDisplay_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void EquipmentGuiDisplay_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        
    }

    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class EquipmentGuiDisplay : GuiDisplay<Equipment>
    {
        public enum ViewMode { ADD, VIEW}

        //   Replace with class name              Replace with model class
        //   VVVVVVVVVVVVVVV                      VVVVVV
        public EquipmentGuiDisplay(Equipment model, ViewMode mode)
            : base(model)
        {
            InitializeComponent();
            InitializeComboBoxes();
            if (mode == ViewMode.ADD)
            {
                SetAddMode();
            }
            else
            {
                BindModelToView();
                SetViewMode();
            }
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
