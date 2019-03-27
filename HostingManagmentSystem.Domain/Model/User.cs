using HostingManagmentSystem.Domain.Exception;
using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class User: Entity
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Secret { get; set; }
        public IEnumerable<VPS> VPS
        {
            get => _context.Get<VPS,IVpsRepository>().ByUser(this);
        }

        public User(string name, string surname, string phone, string secret)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Secret = secret;
        }

        public User()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
