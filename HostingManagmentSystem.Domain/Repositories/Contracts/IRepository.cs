using HostingManagmentSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.Contracts
{
    public interface IRepository<T>: IStateVolitileable where T:Entity
    {
        IEnumerable<T> All();
        ObservableCollection<T> AllObservable();
        T ById(Guid? id);
        T Persist(T t);
        void PersistMany(IEnumerable<T> t);
        void Delete(T t);
    }
}
