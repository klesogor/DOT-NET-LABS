using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public class VpsRepository : AbstractRepository<VPS>, IVpsRepository
    {
        public VpsRepository(IFileDriver driver) : base(driver)
        {
        }

        public IEnumerable<VPS> ByAdmin(Admin admin)
        {
            return All().Where(x => x.AdminId == admin.Id);
        }

        public IEnumerable<VPS> ByUser(User user)
        {
            return All().Where(x => x.OwnerId == user.Id);
        }
    }
}
