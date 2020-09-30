using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views.Borrower
{
    class MenuDisplay : CliDisplay
    {
        public MenuDisplay(Director director) : base(director)
        {

        }
        public override void ShowDisplay()
        {
            Console.WriteLine("Hello World");
            Console.ReadLine();
            director.ShowDisplay(director.borrowerController.Login());
        }
    }
}
