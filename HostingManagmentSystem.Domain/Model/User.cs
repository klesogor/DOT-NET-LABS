using HostingManagmentSystem.Domain.Repositories.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    [Table]
    public sealed class User: Entity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public override Guid Id { get => id; set => id = value; }
        [DataMember]
        [Column]
        public string Name { get; set; }
        [DataMember]
        [Column]
        public string Surname { get; set; }
        [DataMember]
        [Column]
        public string Phone { get; set; }
        [DataMember]
        [Column]
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
