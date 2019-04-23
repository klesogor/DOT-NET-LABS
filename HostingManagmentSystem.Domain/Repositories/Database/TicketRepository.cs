using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System.Data.Linq;

namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public sealed class TicketRepository : AbstractRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
