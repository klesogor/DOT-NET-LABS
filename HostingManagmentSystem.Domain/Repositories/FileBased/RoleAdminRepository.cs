using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public class RoleAdminRepository : AbstractRepository<RoleAdmin>, IRoleAdminRepository
    {
        public RoleAdminRepository(IFileDriver driver) : base(driver)
        {
        }

        public void Attach(Admin admin, IEnumerable<Role> roles)
        {
            Detach(admin);
            roles.ForEach(x => Persist(new RoleAdmin() { AdminId = admin.Id, RoleId = x.Id }));
        }

        public void Detach(Admin admin)
        {
            All().Where(x => x.AdminId.Equals(admin.Id)).ForEach(x => Delete(x));
        }

        public IEnumerable<Role> ByAdmin(Admin admin)
        {
            return All()
                .Where(x => x.AdminId == admin.Id)
                .Select(x => context.Get<Role, IRoleRepository>().ById(x.AdminId));
        }
    }
}
