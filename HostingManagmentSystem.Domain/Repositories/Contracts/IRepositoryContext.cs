using HostingManagmentSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.Contracts
{
    public interface IRepositoryContext: IStateVolitileable
    {
        V Get<T,V>() where V : IRepository<T> where T : Entity;
        IRepositoryContext Set<T,V>(V repository) where V: IRepository<T> where T:Entity;
    }
}
