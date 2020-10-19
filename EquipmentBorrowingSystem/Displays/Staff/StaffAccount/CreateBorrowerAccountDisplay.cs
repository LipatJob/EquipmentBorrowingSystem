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

namespace EquipmentBorrowingSystem.Displays.Staff.StaffAccount
{

    partial class CreateBorrowerAccountDisplay : GuiDisplay<User>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public CreateBorrowerAccountDisplay(User model) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public CreateBorrowerAccountDisplay()
        {
            // This Constructor allows you to use the designer. 
        }

        // put all GUI in the implementation of this method
        partial void InitializeComponent();

    }

    //okay so basically nothing sa taas
    //sa baba lahat ng objects
    //ok ok

    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class CreateBorrowerAccountDisplay
    {

        public void BindModelToView()
        {
        }

        public void BindViewToModel()
        {
            // This class is called when you want to save the values in your view
            Model.Email = emailTb.Text;
            Model.Password = passwordTb.Text;
            // Put Logic here to put Values of View to Model
        }

        Label emailLb;
        Label passwordLb;
        Label passwordConfirmLb;

        protected TextBox emailTb;
        protected TextBox passwordTb;
        protected TextBox passwordConfirmTb;

        Button createButton;
        partial void InitializeComponent()
        {
            emailLb             = new Label { Text = "Email", TextAlign = ContentAlignment.MiddleRight };
            passwordLb          = new Label { Text = "Password", TextAlign = ContentAlignment.MiddleRight };
            passwordConfirmLb   = new Label { Text = "Confirm Password", TextAlign = ContentAlignment.MiddleRight };
            emailTb             = new TextBox { Width = 125};
            passwordTb          = new TextBox { Width = 125, PasswordChar = '*' };
            passwordConfirmTb   = new TextBox { Width = 125, PasswordChar = '*' };
            createButton        = new Button { Text = "Create Borrower"};

            Controls.AddRange(new Control[] { emailLb, passwordLb, passwordConfirmLb, emailTb, passwordTb, passwordConfirmTb, createButton });

            // Layout Components
            LocationHandler handler = new LocationHandler(5, 5, 100, 25);
            emailLb.Location = handler.GetPosition();
            passwordLb.Location = handler.Down().GetPosition();
            passwordConfirmLb.Location = handler.Down().GetPosition();

            emailTb.Location = handler.Up().Up().Right().GetPosition();
            passwordTb.Location = handler.Down().GetPosition();
            passwordConfirmTb.Location = handler.Down().GetPosition();

            createButton.Location = handler.Down().GetPosition();

            // Add Action Handlers
            createButton.Click += CreateBorrowerPressed;
        }

        public void CreateBorrowerPressed(object sender, EventArgs e)
        {
            // Validate
            if(!(ValidateEmail() && ValidatePassword())) { return; }


            BindViewToModel();
            Response response = Director.StaffAccountController.CreateBorrowerAccount(Model);
            if (response.Success)
            {
                MessageBox.Show("Borrower Account Created", "Success" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Hide();
                Close();
                return;
            }
            else
            {
                MessageBox.Show("Please Try Again Letter", "Account Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool ValidateEmail()
        {
            string email = emailTb.Text;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Email Format Must be Valid", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public bool ValidatePassword()
        {
            string password = passwordTb.Text;
            string confirmpassword = passwordConfirmTb.Text;
            if(password != confirmpassword)
            {
                MessageBox.Show("Password Does not Match", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if(password.Length < 5)
            {
                MessageBox.Show("Password Must Have Atleast 5 Characters", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


    }

}
