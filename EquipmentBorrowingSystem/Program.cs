using EquipmentBorrowingSystem.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace EquipmentBorrowingSystem
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string flag = ApplicationResources.ResourceManager.GetString("InitializeData");
            if (flag == "true")
            {
                DataInitialization scaffold = new DataInitialization();
                scaffold.Run();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Director director = new Director();
            director.ShowDisplay(director.borrowerController.Login());
        }
    }
}
