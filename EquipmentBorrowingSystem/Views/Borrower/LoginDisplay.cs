using EquipmentBorrowingSystem.BackEnd.Models;
using EquipmentBorrowingSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem.Views.Borrower
{
    class LoginDisplay : GuiDisplay
    {
        private User User{ get; set; }

        public LoginDisplay(Director director, User user) : base(director)
        {
            User = user;
            InitializeComponents();
        }

        Button next;
        public void InitializeComponents()
        {
            next = new Button();
            next.Click += new EventHandler(nextView);
            this.Controls.Add(next);
        }

        private void nextView(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            director.ShowDisplay(director.borrowerController.Menu());
        }


    }
}
