using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System.Data.Linq;
namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public sealed class AdminRepository : AbstractRepository<Admin>, IAdminRepository
    {
        public AdminRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
