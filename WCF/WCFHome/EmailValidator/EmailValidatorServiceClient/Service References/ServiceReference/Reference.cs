﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmailValidatorServiceClient.ServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IEmailValidator")]
    public interface IEmailValidator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailValidator/ValidateAddress", ReplyAction="http://tempuri.org/IEmailValidator/ValidateAddressResponse")]
        bool ValidateAddress(string emailAddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailValidator/ValidateAddress", ReplyAction="http://tempuri.org/IEmailValidator/ValidateAddressResponse")]
        System.Threading.Tasks.Task<bool> ValidateAddressAsync(string emailAddress);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmailValidatorChannel : EmailValidatorServiceClient.ServiceReference.IEmailValidator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmailValidatorClient : System.ServiceModel.ClientBase<EmailValidatorServiceClient.ServiceReference.IEmailValidator>, EmailValidatorServiceClient.ServiceReference.IEmailValidator {
        
        public EmailValidatorClient() {
        }
        
        public EmailValidatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmailValidatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailValidatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailValidatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool ValidateAddress(string emailAddress) {
            return base.Channel.ValidateAddress(emailAddress);
        }
        
        public System.Threading.Tasks.Task<bool> ValidateAddressAsync(string emailAddress) {
            return base.Channel.ValidateAddressAsync(emailAddress);
        }
    }
}