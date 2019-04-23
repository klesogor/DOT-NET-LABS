using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    [Table]
    public sealed class VPS: Entity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public override Guid Id { get => id; set => id = value; }
        [DataMember]
        [Column]
        public string OperatingSystem { get; set; }
        [DataMember]
        [Column]
        public string RAM { get; set; }
        [DataMember]
        [Column]
        public string CPU { get; set; }
        [DataMember]
        [Column(CanBeNull = true)]
        public Guid? OwnerId { get; set; }
        [DataMember]
        [Column(CanBeNull =true)]
        public Guid? AdminId { get; set; }

        public string QualifiedName { get => $"{Owner?.Name ?? "noowner"}@{OperatingSystem}"; }

        public User Owner {
            get => _context.Get<User, IUserRepository>().ById(OwnerId);
            set => OwnerId = value != null ? (Guid?)value.Id : null;
        }
        public Admin Admin {
            get => _context.Get<Admin, IAdminRepository>().ById(AdminId);
            set => AdminId = value != null ? (Guid?)value.Id : null;
        }

        public VPS(string operatingSystem, string rAM, string cPU, User owner, Admin admin)
        {
            OperatingSystem = operatingSystem;
            RAM = rAM;
            CPU = cPU;
            Owner = owner;
            Admin = admin;
        }

        public VPS()
        {
        }

        public override string ToString()
        {
            return QualifiedName;
        }
    }
}
