using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public class RoleRepository : AbstractRepository<Role>, IRoleRepository
    {
        public RoleRepository(IFileDriver driver) : base(driver)
        {
        }
    }
}
