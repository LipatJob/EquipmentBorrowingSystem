using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentBorrowingSystem.Repository
{
    abstract class Repository
    {
        protected RepositoryState RepositoryState { get; }

        public Repository(RepositoryState repositoryState)
        {
            RepositoryState = repositoryState;
        }
    }
}
