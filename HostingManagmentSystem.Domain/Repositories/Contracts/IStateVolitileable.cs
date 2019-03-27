using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.Contracts
{
    public interface IStateVolitileable
    {
        void PersistState();
    }
}
