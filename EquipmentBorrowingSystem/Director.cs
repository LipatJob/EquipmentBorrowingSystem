using EquipmentBorrowingSystem.Backend;
using EquipmentBorrowingSystem.Controllers;
using EquipmentBorrowingSystem.Displays;
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

        private static Director Instance;
        public static Director GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Director();
            }
            return Instance;
        }

        private Director()
        {
            // Registered Controllers
            EquipmentManagementController = new EquipmentManagementController();
            EquipmentBorrowingController = new EquipmentBorrowingController();


            // 2. Registering Controller:
            // <Identifier>Controller = new <Name>Controller();
            // See example below
            EmptyController = new EmptyController();
        }

        public EquipmentManagementController EquipmentManagementController { get; }

        // 1. Registering Controller:
        // public <Name>Controller <Identifier>Controller { get; }
        // See example below

        public EquipmentBorrowingController EquipmentBorrowingController { get; }
        public EmptyController EmptyController { get; }


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
