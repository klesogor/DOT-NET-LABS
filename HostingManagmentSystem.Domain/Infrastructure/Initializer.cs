using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.Domain.Repositories.FileBased;
using HostingManagmentSystem.Domain.Repositories.FileBased.Drivers;
using System.Collections.Generic;

namespace HostingManagmentSystem.Domain.Infrastructure
{
    public static class Initializer
    {
        private static bool _initialized = false;

        private static void Seed()
        {
            var _context = SimpleRepositoryContext.Of();

            var roles = new List<Role>
            {
                new Role("Supervisor", "Root access"),
                new Role("Tech support", "No root access")
            };

            var admin = new Admin("127.0.0.1", "root", "root@localhost");
            var user = new User("Test", "Test", "+88005553535", "qwerty");
            var vps = new VPS("Ubuntu", "8 Гб", "1.2MHz" , null, null);

            _context.Get<Role, IRoleRepository>().PersistMany(roles);
            _context.Get<Admin, IAdminRepository>().Persist(admin);
            _context.Get<User, IUserRepository>().Persist(user);
            _context.Get<VPS, IVpsRepository>().Persist(vps);

            _context.PersistState();

            throw new System.Exception("Can't continue in seed mode");
        }

        private static void InitRepositories()
        {
            var driver = new XmlDriver();
            var _context = SimpleRepositoryContext.Of();
            _context.Set<Role, IRoleRepository>(new RoleRepository(driver));
            _context.Set<RoleAdmin, IRoleAdminRepository>(new RoleAdminRepository(driver));
            _context.Set<Admin, IAdminRepository>(new AdminRepository(driver));
            _context.Set<Ticket, ITicketRepository>(new TicketRepository(driver));
            _context.Set<User, IUserRepository>(new UserRepository(driver));
            _context.Set<VPS, IVpsRepository>(new VpsRepository(driver));
        }

        public static void Init(bool shouldSeed = false)
        {
            if (_initialized) return;
            InitRepositories();
            if (shouldSeed) Seed();
            _initialized = true;
        }
    }
}
