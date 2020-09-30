using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views
{
    abstract class CliDisplay : Display
    {
        protected Director director;

        public CliDisplay(Director director)
        {
            this.director = director;
        }
        public abstract void ShowDisplay();
    }
}
