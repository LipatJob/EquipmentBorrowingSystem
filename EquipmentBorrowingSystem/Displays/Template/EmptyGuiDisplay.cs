using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    //   Replace with class name              Replace with model class
    //   VVVVVVVVVVVVVVV                      VVVVVV
    partial class EmptyGuiDisplay : GuiDisplay<Empty>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public EmptyGuiDisplay(Empty model) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public EmptyGuiDisplay()
        {
            // This Constructor allows you to use the designer. 
        }

        // put all GUI in the implementation of this method
        partial void InitializeComponent();

    }

    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class EmptyGuiDisplay
    {
        private TextBox emptyTextBox;

        public void BindModelToView()
        {
            // This class is called when you want to display your model

            // Put Logic here to Put Values of Model to View
            emptyTextBox.Text = Model.Name;
        }

        public void BindViewToModel()
        {
            // This class is called when you want to save the values in your view

            // Put Logic here to put Values of View to Model
            Model.Name = emptyTextBox.Text;
        }

        partial void InitializeComponent()
        {
            this.emptyTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // emptyTextBox
            // 
            this.emptyTextBox.Location = new System.Drawing.Point(12, 12);
            this.emptyTextBox.Name = "emptyTextBox";
            this.emptyTextBox.Size = new System.Drawing.Size(100, 20);
            this.emptyTextBox.TabIndex = 0;
            // 
            // EmptyGuiDisplay
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.emptyTextBox);
            this.Name = "EmptyGuiDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }



}
