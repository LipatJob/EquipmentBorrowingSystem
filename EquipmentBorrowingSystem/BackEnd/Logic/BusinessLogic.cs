using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Backend.Logic
{
    abstract class BusinessLogic
    {
        protected ApplicationState ApplicationState { get; }

        public BusinessLogic(ApplicationState applicationState)
        {
            ApplicationState = applicationState;
        }
    }
}
