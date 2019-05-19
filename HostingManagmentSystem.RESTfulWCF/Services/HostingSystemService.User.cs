using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;

namespace HostingManagmentSystem.RESTfulWCF.Services
{
    public partial class HostingSystemService : IHostingSystemService
    {
        public User GetUserById(Guid id)
        {
            return _context.Get<User, IUserRepository>().ById(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Get<User, IUserRepository>().All();
        }
        public bool CreateUser(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                _context.Get<User, IUserRepository>().Persist(user);
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                var repo = _context.Get<User, IUserRepository>();
                var savedUser = repo.ById(user.Id);

                savedUser.Name = user.Name;
                savedUser.Phone = user.Name;
                savedUser.Secret = user.Secret;
                savedUser.Surname = user.Surname;

                repo.Persist(savedUser);
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}