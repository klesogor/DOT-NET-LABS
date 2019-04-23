using HostingManagmentSystem.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    [Table]
    public sealed class Role:Entity
    {
        IEnumerable<Admin> Admins {
            get => throw NormalizationException.Of();
            set => throw NormalizationException.Of();
        }
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public override Guid Id { get => id; set => id = value; }
        [DataMember]
        [Column]
        public string Claim { get; set; }
        [DataMember]
        [Column]
        public string Description { get; set; }

        public Role(string claim, string description)
        {
            Claim = claim;
            Description = description;
        }

        public Role()
        {
        }

        public override string ToString()
        {
            return Claim;
        }
    }
}
