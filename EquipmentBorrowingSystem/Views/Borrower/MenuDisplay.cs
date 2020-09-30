using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views.Borrower
{
    class MenuDisplay : CliDisplay<Object>
    {
        public MenuDisplay(Director director, Object model) : base(director, model)
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
