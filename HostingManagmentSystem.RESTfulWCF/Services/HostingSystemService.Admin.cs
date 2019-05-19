using System;
using System.Collections.Generic;
using HostingManagmentSystem.Domain.Model;
using System.Linq;
using System.Web;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
namespace HostingManagmentSystem.RESTfulWCF.Services
{
    public partial class HostingSystemService : IHostingSystemService
    {
        public Admin GetAdminById(Guid id)
        {
            return _context.Get<Admin, IAdminRepository>().ById(id);
        }

        public IEnumerable<Admin> GetAdmins()
        {
            return _context.Get<Admin, IAdminRepository>().All();
        }

        public bool CreateAdmin(Admin admin)
        {
            try
            {
                admin.Id = Guid.NewGuid();
                _context.Get<Admin, IAdminRepository>().Persist(admin);
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool UpdateAdmin(Admin admin)
        {
            try
            {
                var repo = _context.Get<Admin, IAdminRepository>();
                var savedAdmin = repo.ById(admin.Id);
                savedAdmin.Ip = admin.Ip;
                savedAdmin.Name = admin.Name;
                savedAdmin.Description = admin.Description;
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }
    }
}