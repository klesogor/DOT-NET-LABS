using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class VPS: Entity
    {
        [DataMember]
        public string OperatingSystem { get; set; }
        [DataMember]
        public string RAM { get; set; }
        [DataMember]
        public string CPU { get; set; }
        public string QualifiedName { get => $"{Owner?.Name ?? "noowner"}@{OperatingSystem}"; }
        [DataMember]
        public Guid? OwnerId { get; set; }
        [DataMember]
        public Guid? AdminId { get; set; }
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
