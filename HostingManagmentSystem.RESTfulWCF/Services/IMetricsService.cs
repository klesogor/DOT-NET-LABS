using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using System.Text;
using System.Threading.Tasks;

namespace HostingManagmentSystem.RESTfulWCF.Services
{
    [ServiceContract]
    interface IMetricsService
    {
        [OperationContract(IsOneWay = true)]
        void AddMetrics(string msg);
    }
}
