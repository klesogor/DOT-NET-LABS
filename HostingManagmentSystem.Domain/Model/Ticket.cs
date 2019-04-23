using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    [Table]
    public sealed class Ticket : Entity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public override Guid Id { get => id; set => id = value; }
        [DataMember]
        [Column]
        public string Description { get; set; }
        [DataMember]
        [Column]
        public DateTime Date { get; set; }
        [DataMember]
        [Column]
        public Guid? UserId { get; set; }
        [DataMember]
        [Column]
        public Guid? VpsId { get; set; }
        [DataMember]
        [Column]
        public Guid? AdminId { get; set; }

        public User User
        {
            get => _context.Get<User,IUserRepository>().ById(UserId);
            set => UserId = value != null ? (Guid?)value.Id : null;
        }
        public VPS VPS
        {
            get => _context.Get<VPS, IVpsRepository>().ById(VpsId);
            set => VpsId = value != null ? (Guid?)value.Id : null;
        }
        public Admin Admin
        {
            get => _context.Get<Admin, IAdminRepository>().ById(AdminId);
            set => AdminId =  (Guid?)value.Id ?? null;
        }

        public Ticket(string description, DateTime date, User user, VPS vPS, Admin admin)
        {
            Description = description;
            Date = date;
            User = user;
            VPS = vPS;
            Admin = admin;
        }

        public Ticket()
        {
        }

        public override string ToString()
        {
            return Admin?.Name + " " + User?.Name;
        }
    }
}
