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
        public EquipmentManagementController EquipmentManagementController { get; }

        // 1. Registering Controller:
        // public <Name>Controller <Identifier>Controller { get; }
        // See example below
        public EmptyController EmptyController { get; }

    public Director()
        {
            State = new ApplicationState();
            EquipmentManagementController = new EquipmentManagementController(this);

            // 2. Registering Controller:
            // <Identifier>Controller = new <Name>Controller(this);
            // See example below
            EmptyController = new EmptyController(this);
        }


        public void ShowDisplay(Display display)
        {
            display.ShowDisplay();
        }

        public void ShowGuiView(Form view)
        {
            view.ShowDialog();
        }
    }
}
