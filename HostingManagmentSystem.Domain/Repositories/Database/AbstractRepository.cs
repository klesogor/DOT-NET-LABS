using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Linq;

namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : Entity
    {
        #region vars
        private readonly List<T> _cache = new List<T>();
        private readonly List<T> _new = new List<T>();
        private readonly List<T> _deleted = new List<T>();
        protected readonly IRepositoryContext context;
        private readonly DataContext _dataContext;
        private readonly Table<T> _table;
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
        protected AbstractRepository(DataContext dataContext)
        {
            context = SimpleRepositoryContext.Of();
            _dataContext = dataContext;
            _table = dataContext.GetTable<T>();
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
            _deleted.Add(t);
            _cache.Remove(t);
        }

        public virtual T Persist(T t)
        {
            assertDataLoaded();
            if (!_cache.Exists(x => x.Id.Equals(t.Id))) {
                _cache.Add(t);
                _new.Add(t);
                return t;
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
                _cache.AddRange(_fetch());
                is_loaded = true;
            }
        }

        private List<T> _fetch()
        {
            return _table.Select(row => row).ToList();
        }

        public void PersistState()
        {
            _table.InsertAllOnSubmit(_new);
            _table.DeleteAllOnSubmit(_deleted);

            _new.Clear();
            _deleted.Clear();

            _dataContext.SubmitChanges();
        }

        public void PersistMany(IEnumerable<T> t)
        {
            t.ForEach(x => Persist(x));
        }

        #endregion
    }
}
