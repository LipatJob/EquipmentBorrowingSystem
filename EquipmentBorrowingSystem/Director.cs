using EquipmentBorrowingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquipmentBorrowingSystem
{
    class Director
    {
        private RepositoryState State { get; }
        private User CurrentUser { get; set; }
        public Director()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            State = new RepositoryState();
            Form window = new Form();

            window.SetBounds(500, 500, 700, 700);
            Application.Run(window);
        }
    }
}
