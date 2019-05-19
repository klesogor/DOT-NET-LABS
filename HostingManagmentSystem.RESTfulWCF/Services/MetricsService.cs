using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;

namespace HostingManagmentSystem.RESTfulWCF.Services
{
    class MetricsService : IMetricsService
    {
        public MetricsService(){}

        public void AddMetrics(string msg)
        {
            Console.WriteLine("Received metrics: {0}", msg);
        }
    }
}
