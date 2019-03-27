using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class Admin: Entity
    {
        private string _ip;

        [DataMember]
        public string Name { get; set; }
        public IEnumerable<VPS> VPS
        {
            get => _context.Get<VPS, IVpsRepository>().ByAdmin(this);
       
        }
        public IEnumerable<Role> Roles {
            get => _context.Get<RoleAdmin, IRoleAdminRepository>().ByAdmin(this); 
         }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Ip {
            get => _ip;
            set {
                if (IPAddress.TryParse(value, out IPAddress addr))
                {
                    _ip = value;
                }
                else
                {
                    throw new ArgumentException("Not an IP address!");
                }
            }
        }

        public Admin(string ip, string name, string description)
        {
            Ip = ip;
            Name = name;
            Description = description;
        }

        public Admin() { }

        public override string ToString()
        {
            return Name;
        }
    }
}
