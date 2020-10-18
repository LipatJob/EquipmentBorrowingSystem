using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    //okay so basically nothing sa taas
    //sa baba lahat ng objects
    //ok ok

    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class EmptyGuiDisplay
    {
        private TextBox emptyTextBox;

        public override void BindModelToView()
        {
            emptyTextBox.Text = Model.Name;
        }

        //pwede ko ba resize yung objects ko sa design na lang?
        //would it change something sa code?
        //for example, naglagay na ako ng objects sa InitializeComponent(), tapos iniba ko yung size sa design
        //AH okay gegege

        public override void BindViewToModel()
        {
            // This class is called when you want to save the values in your view

            // Put Logic here to put Values of View to Model
            Model.Name = emptyTextBox.Text;
        }

        partial void InitializeComponent()
        {

        }
    }



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




}
