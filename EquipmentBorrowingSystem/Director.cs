using EquipmentBorrowingSystem.Backend;
using EquipmentBorrowingSystem.Controllers;
using EquipmentBorrowingSystem.Controllers.Borrower;
using EquipmentBorrowingSystem.Controllers.Staff;
using EquipmentBorrowingSystem.Displays;
using JobLib;
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

        // 1. Registering Controller:
        // public <Name>Controller <Identifier>Controller { get; }
        // See example below

        // Staff Controllers
        public StaffMainController StaffMainController { get; }
        public StaffAccountController StaffAccountController { get; }
        public BorrowedEquipmentLogController BorrowedEquipmentLogController { get; }
        public EquipmentManagementController EquipmentManagementController { get; }
        public ViolationManagementController ViolationManagementController { get; }

        // Borrower Controllers
        public BorrowerMainController BorrowerMainController { get; }
        public BorrowerAccountController BorrowerAccountController { get; }
        public EquipmentBorrowingController EquipmentBorrowingController { get; }
        public BorrowerViolationsController BorrowerViolationsController { get; }



        public EmptyController EmptyController { get; }

        private Director()
        {
            // Registered Controllers
            // Staff
            StaffMainController = new StaffMainController();
            StaffAccountController = new StaffAccountController();
            BorrowedEquipmentLogController = new BorrowedEquipmentLogController();
            EquipmentManagementController = new EquipmentManagementController();
            ViolationManagementController = new ViolationManagementController();

            // Borrower
            EquipmentBorrowingController = new EquipmentBorrowingController();
            BorrowerMainController = new BorrowerMainController();
            BorrowerAccountController = new BorrowerAccountController();
            BorrowerViolationsController = new BorrowerViolationsController();

            // 2. Registering Controller:
            // <Identifier>Controller = new <Name>Controller();
            // See example below
            EmptyController = new EmptyController();
        }


        


        public void ShowDisplay(Display display)
        {
            display.ShowDisplay();
        }

        public void ShowGuiView(Form view)
        {
            Console.Clear();
            Console.WriteLine("Please See the GUI");
            view.ShowDialog();
            Console.Clear();
        }


    }
}
