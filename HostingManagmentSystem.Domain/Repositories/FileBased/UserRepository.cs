using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HostingManagmentSystem.Domain.Repositories.FileBased
{
    public class UserRepository : AbstractRepository<User>, IUserRepository
    {
        public UserRepository(IFileDriver driver) : base(driver)
        {
        }
    }
}
