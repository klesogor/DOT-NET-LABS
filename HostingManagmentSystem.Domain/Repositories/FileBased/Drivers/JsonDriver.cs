using HostingManagmentSystem.Domain.Model;
using HostingManagmentSystem.Domain.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace HostingManagmentSystem.Domain.Repositories.FileBased.Drivers
{
    public sealed class JsonDriver : IFileDriver
    {
        public IEnumerable<T> Deserialize<T>() where T : Entity
        {
            try
            {
                using (var stream = new FileStream(typeof(T).Name + ".json", FileMode.Open))
                {
                    var serializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
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
            using (var stream = new FileStream(typeof(T).Name + ".json", FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
                serializer.WriteObject(stream, elements);
            }
        }
    }
}
