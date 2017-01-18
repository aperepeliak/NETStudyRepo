﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductsServiceClient.ProductsServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/ProductsServiceLib")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductsServiceReference.IProductContract")]
    public interface IProductContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/GetAll", ReplyAction="http://tempuri.org/IProductContract/GetAllResponse")]
        ProductsServiceClient.ProductsServiceReference.Product[] GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/GetAll", ReplyAction="http://tempuri.org/IProductContract/GetAllResponse")]
        System.Threading.Tasks.Task<ProductsServiceClient.ProductsServiceReference.Product[]> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/Get", ReplyAction="http://tempuri.org/IProductContract/GetResponse")]
        ProductsServiceClient.ProductsServiceReference.Product Get(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/Get", ReplyAction="http://tempuri.org/IProductContract/GetResponse")]
        System.Threading.Tasks.Task<ProductsServiceClient.ProductsServiceReference.Product> GetAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/Remove", ReplyAction="http://tempuri.org/IProductContract/RemoveResponse")]
        void Remove(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductContract/Remove", ReplyAction="http://tempuri.org/IProductContract/RemoveResponse")]
        System.Threading.Tasks.Task RemoveAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductContractChannel : ProductsServiceClient.ProductsServiceReference.IProductContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductContractClient : System.ServiceModel.ClientBase<ProductsServiceClient.ProductsServiceReference.IProductContract>, ProductsServiceClient.ProductsServiceReference.IProductContract {
        
        public ProductContractClient() {
        }
        
        public ProductContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ProductsServiceClient.ProductsServiceReference.Product[] GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<ProductsServiceClient.ProductsServiceReference.Product[]> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public ProductsServiceClient.ProductsServiceReference.Product Get(int id) {
            return base.Channel.Get(id);
        }
        
        public System.Threading.Tasks.Task<ProductsServiceClient.ProductsServiceReference.Product> GetAsync(int id) {
            return base.Channel.GetAsync(id);
        }
        
        public void Remove(int id) {
            base.Channel.Remove(id);
        }
        
        public System.Threading.Tasks.Task RemoveAsync(int id) {
            return base.Channel.RemoveAsync(id);
        }
    }
}
