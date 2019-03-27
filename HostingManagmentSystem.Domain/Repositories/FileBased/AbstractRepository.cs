using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        #region vars
        private readonly List<T> _cache = new List<T>();
        private readonly IFileDriver _driver;
        protected readonly IRepositoryContext context;
        private bool is_loaded = false;
        #endregion
        #region props
        //makes inner collection immutable for better encapsulation
        protected IEnumerable<T> cache
        {
            get
            {
                return _cache.Select(i => i).ToList();
            }
        }
        #endregion
        #region methods
        protected AbstractRepository(IFileDriver driver)
        {
            _driver = driver;
            context = SimpleRepositoryContext.Of();
        }

        public IEnumerable<T> All()
        {
            assertDataLoaded();
            return cache;
        }

        public T ById(Guid? id)
        {
            if (id is null) return null;
            assertDataLoaded();
            return cache.Where(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public void Delete(T t)
        {
            assertDataLoaded();
            _cache.Remove(t);
        }

        public virtual T Persist(T t)
        {
            assertDataLoaded();
            if (!_cache.Exists(x => x.Id.Equals(t.Id))){
                _cache.Add(t);
            }
            return t;
        }

        public ObservableCollection<T> AllObservable()
        {
            return new ObservableCollection<T>(_cache);
        }

        //Lazy loading
        private void assertDataLoaded()
        {
            if (!is_loaded)
            {
                _cache.AddRange(_driver.Deserialize<T>());
                is_loaded = true;
            }
        }

        public void PersistState()
        {
            _driver.Serialize(_cache);
        }

        public void PersistMany(IEnumerable<T> t)
        {
            t.ForEach(x => Persist(x));
        }
        #endregion
    }
}
