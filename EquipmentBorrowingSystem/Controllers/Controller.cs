using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Controllers
{
    abstract class Controller
    {
        protected Director Director { get; }
        public Controller(Director director)
        {
            Director = director;
        }
    }
}
