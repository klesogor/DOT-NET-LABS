﻿using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System.Data.Linq;

namespace HostingManagmentSystem.Domain.Repositories.Database
{
    public sealed class RoleRepository : AbstractRepository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
