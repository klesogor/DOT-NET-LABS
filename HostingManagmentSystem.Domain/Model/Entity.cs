using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Model
{
    //YAY! Infrastructure code in domain model! Also, a singleton!
    [DataContract]
    public abstract class Entity
    {
        protected Guid id;
        protected IRepositoryContext _context {get => SimpleRepositoryContext.Of(); }

        [DataMember]
        public Guid Id { get => id; private set => id = value; }

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
