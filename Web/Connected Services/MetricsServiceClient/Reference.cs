﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.MetricsServiceClient {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MetricsServiceClient.IMetricsService")]
    public interface IMetricsService {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMetricsService/AddMetrics")]
        void AddMetrics(string msg);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IMetricsService/AddMetrics")]
        System.Threading.Tasks.Task AddMetricsAsync(string msg);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMetricsServiceChannel : Web.MetricsServiceClient.IMetricsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MetricsServiceClient : System.ServiceModel.ClientBase<Web.MetricsServiceClient.IMetricsService>, Web.MetricsServiceClient.IMetricsService {
        
        public MetricsServiceClient() {
        }
        
        public MetricsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MetricsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MetricsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MetricsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddMetrics(string msg) {
            base.Channel.AddMetrics(msg);
        }
        
        public System.Threading.Tasks.Task AddMetricsAsync(string msg) {
            return base.Channel.AddMetricsAsync(msg);
        }
    }
}