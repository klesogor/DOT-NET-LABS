using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class Ticket : Entity
    {
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public Guid? UserId { get; set; }
        [DataMember]
        public Guid? VpsId { get; set; }
        [DataMember]
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
