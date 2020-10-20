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
        Panel titlePl;
        Label loginLb;

        partial void InitializeComponent()
        {
            Height = 400;
            Width = 700;

            int tempWidth = Width;
            titlePl = new Panel() {
                Dock = DockStyle.Top,
                Width = tempWidth,
                Height = 80,
                BackColor = Color.FromArgb(0, 33, 78),
            };

            var mclLb = new Label() {
                Text = "MCL Equipment Borrowing System",
                Font = new Font(FontFamily.GenericSansSerif, 18),
                Dock = DockStyle.Bottom,
                ForeColor = Color.White,
                Size =  new Size(400,40)
                
                };

            titlePl.Controls.Add(mclLb);

            loginLb = new Label()
            {
                Text = "Borrower Login",
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Location = new Point(150, 110),
                Size = new Size(400, 40)

            };

            emailLb = new Label() { 
                Text = "Email",
                Location = new Point(150, 150),
                Font = new Font(FontFamily.GenericSansSerif, 12)};

            passwordLb = new Label() { 
                Text = "Password", 
                Location = new Point(150, 200), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            emailTb = new TextBox() { 
                Location = new Point(280, 150), 
                Size = new Size(259, 30), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            passwordTb = new TextBox()
            {
                Location = new Point(280, 200),
                Size = new Size(259, 30),
                Font = new Font(FontFamily.GenericSansSerif, 12)  };

            loginBtn = new Button() { 
                Text = "Login",
                Size = new Size(100, 35),
                Location = new Point(350, 250), 
                Font = new Font(FontFamily.GenericSansSerif, 12) };

            Controls.AddRange(new Control[] { emailLb, passwordLb, emailTb, passwordTb, loginBtn, titlePl, loginLb});

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
