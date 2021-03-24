﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthentifiedAccess.AuthenticatorSOAP {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticatorSOAP.IAuthenticator")]
    public interface IAuthenticator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticator/GetData", ReplyAction="http://tempuri.org/IAuthenticator/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticator/GetData", ReplyAction="http://tempuri.org/IAuthenticator/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticator/ValidateCredentials", ReplyAction="http://tempuri.org/IAuthenticator/ValidateCredentialsResponse")]
        bool ValidateCredentials(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticator/ValidateCredentials", ReplyAction="http://tempuri.org/IAuthenticator/ValidateCredentialsResponse")]
        System.Threading.Tasks.Task<bool> ValidateCredentialsAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticatorChannel : AuthentifiedAccess.AuthenticatorSOAP.IAuthenticator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticatorClient : System.ServiceModel.ClientBase<AuthentifiedAccess.AuthenticatorSOAP.IAuthenticator>, AuthentifiedAccess.AuthenticatorSOAP.IAuthenticator {
        
        public AuthenticatorClient() {
        }
        
        public AuthenticatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public bool ValidateCredentials(string username, string password) {
            return base.Channel.ValidateCredentials(username, password);
        }
        
        public System.Threading.Tasks.Task<bool> ValidateCredentialsAsync(string username, string password) {
            return base.Channel.ValidateCredentialsAsync(username, password);
        }
    }
}