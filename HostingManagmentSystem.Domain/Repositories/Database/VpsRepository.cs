using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public sealed class VpsRepository : AbstractRepository<VPS>, IVpsRepository
    {
        public VpsRepository(DataContext dataContext) : base(dataContext)
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
