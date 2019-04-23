using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    [Table]
    public sealed class RoleAdmin: Entity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public override Guid Id { get => id; set => id = value; }
        [DataMember]
        public Guid AdminId { get; set; }
        [DataMember]
        public Guid RoleId { get; set; }
    }
}
