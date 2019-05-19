using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostingManagmentSystem.RESTfulWCF.Services
{
    public partial class HostingSystemService : IHostingSystemService
    {
        public bool CreateVps(VPS vps)
        {
            try
            {
                vps.Id = Guid.NewGuid();
                _context.Get<VPS, IVpsRepository>().Persist(vps);
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }

        public bool UpdateVps(VPS vps)
        {
            try
            {
                var repo = _context.Get<VPS, IVpsRepository>();
                var savedVps = repo.ById(vps.Id);
                savedVps.AdminId = vps.AdminId;
                savedVps.OwnerId = vps.OwnerId;
                savedVps.RAM = vps.RAM;
                savedVps.CPU = vps.CPU;
                savedVps.OperatingSystem = vps.OperatingSystem;
                _context.PersistState();

                return true;
            }
            catch (Exception) { return false; }
        }

        public IEnumerable<VPS> GetVps()
        {
            return _context.Get<VPS, IVpsRepository>().All();
        }

        public VPS GetVpsById(Guid id)
        {
            return _context.Get<VPS, IVpsRepository>().ById(id);
        }
    }
}