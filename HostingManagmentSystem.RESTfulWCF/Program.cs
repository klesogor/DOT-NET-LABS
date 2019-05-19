using HostingManagmentSystem.Domain.Infrastructure;
using HostingManagmentSystem.Domain.Repositories;
using HostingManagmentSystem.RESTfulWCF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace HostingManagmentSystem.RESTfulWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            Initializer.Init(false);

            StartMSMQProcessor(".\\private$\\MetricsQ");
            StartRestfulBackend(new Uri("http://localhost:8080/api"));

            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();
        }


        public static void StartRestfulBackend(Uri baseAddress)
        {
            ServiceHost host = new ServiceHost(
                   new HostingSystemService(SimpleRepositoryContext.Of()),
                   baseAddress);


            ServiceMetadataBehavior smb = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true
            };
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            var behaviour = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
            behaviour.InstanceContextMode = InstanceContextMode.Single;
            host.Description.Behaviors.Add(smb);
            host.Open();

            Console.WriteLine("The service is ready at {0}", baseAddress);

        }

        public static void StartMSMQProcessor(string queue)
        {
            ServiceHost serviceHost = new ServiceHost(typeof(MetricsService));

            if (!MessageQueue.Exists(queue))
            {
                MessageQueue.Create(queue, false);
            }
            serviceHost.Open();

            Console.WriteLine("The msmq service is ready.");
            Console.WriteLine("The msmq service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);

        }
    }
}
