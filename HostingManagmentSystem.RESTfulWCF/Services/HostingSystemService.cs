using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HostingManagmentSystem.Domain.Repositories.Contracts;

namespace HostingManagmentSystem.RESTfulWCF.Services
{
    public partial class HostingSystemService
    {
        private readonly IRepositoryContext _context;

        public HostingSystemService(IRepositoryContext context)
        {
            _context = context;
        }
    }
}