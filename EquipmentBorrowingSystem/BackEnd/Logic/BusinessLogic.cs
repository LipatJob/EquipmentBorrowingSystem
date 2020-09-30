using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.BackEnd.Logic
{
    abstract class BusinessLogic
    {
        protected ApplicationState RepositoryState { get; }

        public BusinessLogic(ApplicationState repositoryState)
        {
            RepositoryState = repositoryState;
        }
    }
}
