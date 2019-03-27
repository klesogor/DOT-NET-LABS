using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public class TicketRepository : AbstractRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(IFileDriver driver) : base(driver)
        {
        }
    }
}
