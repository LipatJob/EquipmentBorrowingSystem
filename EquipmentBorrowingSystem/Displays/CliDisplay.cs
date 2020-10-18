using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Displays
{
    abstract class CliDisplay<BaseModel> : Display
    {
        protected BaseModel Model;
        protected Director Director;
        public CliDisplay(BaseModel model)
        {
            this.Director = Director.GetInstance();
            this.Model = model;
        }

        public abstract void ShowDisplay();
    }
}
