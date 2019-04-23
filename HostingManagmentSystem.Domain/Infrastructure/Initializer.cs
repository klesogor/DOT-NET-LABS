using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using HostingManagmentSystem.Domain.Repositories.FileBased;
using HostingManagmentSystem.Domain.Repositories.FileBased.Drivers;
using System.Collections.Generic;
using System.Data.Linq;

namespace HostingManagmentSystem.Domain.Infrastructure
{
    public static class Initializer
    {
        private static bool _initialized = false;
        private static readonly string _connectionString = @"Server=localhost\MSSQLSERVER01;Database=HostingSystem;Trusted_Connection=True;";

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

        private static void InitDatabaseRepositories()
        {
            var dataContext = new DataContext(_connectionString);
            var _context = SimpleRepositoryContext.Of();
            _context.Set<Role, IRoleRepository>(new Repositories.Database.RoleRepository(dataContext));
            _context.Set<RoleAdmin, IRoleAdminRepository>(new Repositories.Database.RoleAdminRepository(dataContext));
            _context.Set<Admin, IAdminRepository>(new Repositories.Database.AdminRepository(dataContext));
            _context.Set<Ticket, ITicketRepository>(new Repositories.Database.TicketRepository(dataContext));
            _context.Set<User, IUserRepository>(new Repositories.Database.UserRepository(dataContext));
            _context.Set<VPS, IVpsRepository>(new Repositories.Database.VpsRepository(dataContext));
        }

        private static void GenerateSchema()
        {
            var dataContext = new DataContext(_connectionString);
            dataContext.ExecuteCommand(@"
              CREATE TABLE Admin
              (
                    Id UNIQUEIDENTIFIER NOT NULL,
                    Name varchar(50),
   	                Description varchar(255),
                    Ip varchar(15),
                    PRIMARY KEY (Id)
              );
            ");
            dataContext.ExecuteCommand(@"
                CREATE TABLE Role
                (
                    Id UNIQUEIDENTIFIER NOT NULL,
                    Claim varchar(255),
                    Description varchar(255),
                    PRIMARY KEY(Id)
                );
            ");
            dataContext.ExecuteCommand(@"
                CREATE TABLE RoleAdmin
                (
                    Id UNIQUEIDENTIFIER NOT NULL,
                    AdminId UNIQUEIDENTIFIER NOT NULL,
                    RoleId UNIQUEIDENTIFIER NOT NULL,
                    PRIMARY KEY(Id)
                );
            ");
            dataContext.ExecuteCommand(@"
                CREATE TABLE Ticket
                (
                    Id UNIQUEIDENTIFIER NOT NULL,
                    UserId UNIQUEIDENTIFIER NOT NULL,
                    VpsId UNIQUEIDENTIFIER NOT NULL,
                    Description varchar(255),
                    Date date,
                    AdminId UNIQUEIDENTIFIER,
                    PRIMARY KEY(Id)
                );
            ");
            dataContext.ExecuteCommand(" CREATE TABLE \"User\" "+
               "(" +
                   "Id UNIQUEIDENTIFIER NOT NULL," +
                   "Name varchar(255)," +
                   "Phone varchar(255)," +
                   "Surname varchar(255)," +
                   "Secret varchar(255)," +
                   "PRIMARY KEY(Id)" +
               ");"
               );
            dataContext.ExecuteCommand(@"
              CREATE TABLE VPS
               (
                   Id UNIQUEIDENTIFIER NOT NULL,
                   OperatingSystem varchar(255),
                   RAM varchar(255),
                   CPU varchar(255),
                   OwnerId UNIQUEIDENTIFIER,
                   AdminId UNIQUEIDENTIFIER,
                   PRIMARY KEY(Id)
               );
            ");
        }

        public static void Init(bool shouldSeed = false, bool shouldUseDatabase = true)
        {
            if (_initialized) return;
            if (shouldUseDatabase && shouldSeed) GenerateSchema();
            if (shouldUseDatabase) {
                InitDatabaseRepositories();
            } else {
                InitRepositories();
            }
            if (shouldSeed) Seed();
            _initialized = true;
        }
    }
}
