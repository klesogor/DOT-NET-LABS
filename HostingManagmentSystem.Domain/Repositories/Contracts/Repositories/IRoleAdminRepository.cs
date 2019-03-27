using HostingManagmentSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.Contracts.Repositories
{
    public interface IRoleAdminRepository: IRepository<RoleAdmin>
    {
        IEnumerable<Role> ByAdmin(Admin admin);
        void Attach(Admin admin, IEnumerable<Role> roles);
        void Detach(Admin admin);
    }
}
