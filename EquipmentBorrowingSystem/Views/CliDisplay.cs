using EquipmentBorrowingSystem.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Views
{
    abstract class CliDisplay<BaseModel> : Display
    {
        protected Director Director;
        protected BaseModel Model;

        public CliDisplay(Director director, BaseModel model)
        {
            this.Director = director;
            this.Model = model;
        }
        public abstract void ShowDisplay();
    }
}
