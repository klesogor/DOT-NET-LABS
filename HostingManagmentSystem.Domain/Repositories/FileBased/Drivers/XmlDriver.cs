using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace HostingManagmentSystem.Domain.Repositories.FileBased.Drivers
{
    public sealed class XmlDriver : IFileDriver
    {
        public IEnumerable<T> Deserialize<T>() where T : Entity
        {
            try
            {
                using (var stream = new FileStream(typeof(T).Name + ".xml", FileMode.Open))
                {
                    var serializer = new DataContractSerializer(typeof(IEnumerable<T>));
                    return (IEnumerable<T>)serializer.ReadObject(stream);
                }
            }
            catch (System.Exception)
            {
                return new List<T>();
            }
        }

        public void Serialize<T>(IEnumerable<T> elements) where T : Entity
        {
            using (var stream = new FileStream(typeof(T).Name + ".xml", FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(IEnumerable<T>));
                serializer.WriteObject(stream, elements);
            }
        }
    }
}
