using EquipmentBorrowingSystem.Backend;
using EquipmentBorrowingSystem.Controllers;
using EquipmentBorrowingSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem
{
    class Director
    {
        public ApplicationState State { get; }
        public BorrowerController borrowerController { get; }
        public Director()
        {
            State = new ApplicationState();
            borrowerController = new BorrowerController(this);
        }


        public void ShowDisplay(Display display)
        {
            display.ShowDisplay();
        }

        public void ShowGuiView(GuiDisplay view)
        {
            view.ShowDialog();
        }
    }
}
