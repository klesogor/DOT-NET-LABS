using HostingManagmentSystem.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HostingManagmentSystem.Domain.Model
{
    [DataContract]
    public sealed class Role:Entity
    {
        IEnumerable<Admin> Admins {
            get => throw NormalizationException.Of();
            set => throw NormalizationException.Of();
        }
        [DataMember]
        public string Claim { get; set; }
        [DataMember]
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
