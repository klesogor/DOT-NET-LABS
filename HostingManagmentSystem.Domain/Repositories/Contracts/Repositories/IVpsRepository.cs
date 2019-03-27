using HostingManagmentSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.Contracts.Repositories
{
    public interface IVpsRepository: IRepository<VPS>
    {
        IEnumerable<VPS> ByUser(User user);
        IEnumerable<VPS> ByAdmin(Admin admin);
    }
}
