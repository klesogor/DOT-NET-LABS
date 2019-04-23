using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Data.Linq.Mapping;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    //YAY! Infrastructure code in domain model! Also, a singleton!
    //So, basicly models SHOULD NOT KNOW A THING ABOUT SQL. But I'm out of time for creating DTO
    [DataContract]
    public abstract class Entity
    {
        protected Guid id;
        protected IRepositoryContext _context { get => SimpleRepositoryContext.Of(); }

        [DataMember]
        public abstract Guid Id { get; set; }

        protected Entity(Guid id)
        {
            this.id = id;
        }

        public Entity()
        {
            id = Guid.NewGuid();
        }
    }
}
