using EquipmentBorrowingSystem.Backend.Logic;
using EquipmentBorrowingSystem.Backend.Models;
using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Displays.Template
{
    partial class LoginDisplay : GuiDisplay<User>
    {
        //   Replace with class name      
        //   VVVVVVVVVVVVVVV                 
        public LoginDisplay(User model) // <<< Replace with model class
            : base(model)
        {
            // The GUI Stuff must be implemented in the partial class below
            // Fold this Class after initializing
            InitializeComponent();
        }

        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public LoginDisplay()
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
    partial class LoginDisplay
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
        protected TextBox emailTb;
        protected TextBox passwordTb;
        Button loginBtn;
        partial void InitializeComponent()
        {
            emailLb = new Label();
            passwordLb = new Label();
            emailTb = new TextBox();
            passwordTb = new TextBox();
            loginBtn = new Button();

            Controls.AddRange(new Control[] { emailLb, passwordLb, emailTb, passwordTb, loginBtn });

            // Style Components
            emailLb.Text = "Email";
            passwordLb.Text = "Password";
            loginBtn.Text = "Login";

            emailLb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            passwordLb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            emailTb.Width = 125;
            passwordTb.Width = 125;
            emailLb.Width = 75;
            passwordLb.Width = 75;

            passwordTb.PasswordChar = '*';


            // Layout Components
            LocationHandler handler = new LocationHandler(5, 5, 75, 25);
            emailLb.Location = handler.GetPosition();
            passwordLb.Location = handler.Down().GetPosition();

            emailTb.Location = handler.Up().Right().GetPosition();
            passwordTb.Location = handler.Down().GetPosition();

            loginBtn.Location = handler.Down().GetPosition();

            // Add Action Handlers
            loginBtn.Click += LoginPressed;
        }

        public void LoginPressed(object sender, EventArgs e)
        {
            BindViewToModel();
            Response response = LoginAction();
            if (response.Success)
            {
                Hide();
                Close();
                NextAction();
                return;
            }
            else
            {
                MessageBox.Show("Please check your email or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public virtual void NextAction()
        {

        }

        public virtual Response LoginAction()
        {
            return null;
        }



    }
}
