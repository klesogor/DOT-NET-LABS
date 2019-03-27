using HostingManagmentSystem.Domain.Model;
using System.Collections.Generic;

namespace HostingManagmentSystem.Domain.Repositories.Contracts
{
    public interface IFileDriver
    {
        void Serialize<T>(IEnumerable<T> elements) where T : Entity;
        IEnumerable<T> Deserialize<T>() where T : Entity;
    }
}
