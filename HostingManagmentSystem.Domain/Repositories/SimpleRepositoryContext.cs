using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories
{
    public sealed class SimpleRepositoryContext : IRepositoryContext
    {
        private readonly Dictionary<Type, object> _repos = new Dictionary<Type, object>();
        private static IRepositoryContext _instance;

        public V Get<T,V>() 
            where T : Entity
            where V : IRepository<T>
        {
            _repos.TryGetValue(typeof(T), out object res);
            return (V)res;
        }

        public IRepositoryContext Set<T, V>(V repository)
            where T : Entity
            where V : IRepository<T>
        {
            _repos.Add(typeof(T), repository);
            return this;
        }

        public static IRepositoryContext Of()
        {
            if (_instance == null) {
                _instance = new SimpleRepositoryContext();
            }
            return _instance;
        }

        public void PersistState()
        {
            _repos.ForEach(kp => ((IStateVolitileable)kp.Value).PersistState());
        }
    }
}
