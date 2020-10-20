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

namespace EquipmentBorrowingSystem.Displays.Template
{
   

    //okay so basically nothing sa taas
    //sa baba lahat ng objects
    //ok ok

    //            Replace with class name              
    //            VVVVVVVVVVVVVVV 
    partial class LoginDisplay
    {

        public override void BindModelToView()
        {
        }

        public override void BindViewToModel()
        {
            // This class is called when you want to save the values in your view
            Model.Email = emailTb.Text;
            Model.Password = passwordTb.Text;
            // Put Logic here to put Values of View to Model
        }

        Label emailLb;
        Label passwordLb;
        public TextBox emailTb;
        public TextBox passwordTb;
        Button loginBtn;
        public Label loginLb;

        partial void InitializeComponent()
        {
            var itemsPanel = new Panel() { 
                Location = new Point(90, 110),
                AutoSize = true
            };


            loginLb = new Label()
            {
                Text = "Borrower Login",
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Location = new Point(0, 0),
                Size = new Size(400, 40)

            };

            emailLb = new Label() { 
                Text = "Email",
                Location = new Point(0, 40),
                Font = new Font(FontFamily.GenericSansSerif, 12)};

            passwordLb = new Label() { 
                Text = "Password", 
                Location = new Point(0, 90), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            emailTb = new TextBox() { 
                Location = new Point(130, 40), 
                Size = new Size(259, 30), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            passwordTb = new TextBox()
            {
                Location = new Point(130, 90),
                Size = new Size(259, 30),
                Font = new Font(FontFamily.GenericSansSerif, 12)  };

            loginBtn = new Button() { 
                Text = "Login",
                Size = new Size(100, 35),
                Location = new Point(200, 140), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            itemsPanel.Controls.AddRange(new Control[]{ loginLb,  emailLb, passwordLb, emailTb, passwordTb, loginBtn });

            Controls.AddRange(new Control[] { itemsPanel});

            passwordTb.PasswordChar = '*';

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
}
