using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public sealed class RoleAdminRepository : AbstractRepository<RoleAdmin>, IRoleAdminRepository
    {
        public RoleAdminRepository(DataContext dataContext) : base(dataContext)
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
