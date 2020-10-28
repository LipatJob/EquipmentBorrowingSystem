using JobLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays.Template
{
    

    class MessageCliDisplay : CliDisplay<string>
    {
        //   Replace with class name              
        //   VVVVVVVVVVVVVVV                      
        public MessageCliDisplay(string model) //<<< Replace with model class
            : base(model)
        {

        }

        public override void ShowDisplay()
        {
            Console.WriteLine(Model);
            JHelper.InputString("Press Enter to Continue...");
        }

    }

}
