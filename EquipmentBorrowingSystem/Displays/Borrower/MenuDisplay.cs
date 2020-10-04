using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Borrower
{
    class MenuDisplay : CliDisplay<Object>
    {
        public MenuDisplay(Object model) : base(model)
        {

        }

        public override void ShowDisplay()
        {
            Console.WriteLine("" +
                "A. Equipment List" +
                "B. Login");
            string s = JHelper.InputString("input");
            decimal d = JHelper.InputDecimal("");
        }
    }
}
