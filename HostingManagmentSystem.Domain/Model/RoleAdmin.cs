using System;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class RoleAdmin: Entity
    {
        [DataMember]
        public Guid AdminId { get; set; }
        [DataMember]
        public Guid RoleId { get; set; }
    }
}
