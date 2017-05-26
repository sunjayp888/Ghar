﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Egharpay.Business.EmailServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailData", Namespace="http://schemas.datacontract.org/2004/07/SharedTypes.DataContracts")]
    [System.SerializableAttribute()]
    public partial class EmailData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> BCCAddressListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BodyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> CCAddressListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FromAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsHtmlField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<string> ToAddressListField;
        
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
        public System.Collections.Generic.List<string> BCCAddressList {
            get {
                return this.BCCAddressListField;
            }
            set {
                if ((object.ReferenceEquals(this.BCCAddressListField, value) != true)) {
                    this.BCCAddressListField = value;
                    this.RaisePropertyChanged("BCCAddressList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Body {
            get {
                return this.BodyField;
            }
            set {
                if ((object.ReferenceEquals(this.BodyField, value) != true)) {
                    this.BodyField = value;
                    this.RaisePropertyChanged("Body");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> CCAddressList {
            get {
                return this.CCAddressListField;
            }
            set {
                if ((object.ReferenceEquals(this.CCAddressListField, value) != true)) {
                    this.CCAddressListField = value;
                    this.RaisePropertyChanged("CCAddressList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FromAddress {
            get {
                return this.FromAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.FromAddressField, value) != true)) {
                    this.FromAddressField = value;
                    this.RaisePropertyChanged("FromAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsHtml {
            get {
                return this.IsHtmlField;
            }
            set {
                if ((this.IsHtmlField.Equals(value) != true)) {
                    this.IsHtmlField = value;
                    this.RaisePropertyChanged("IsHtml");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<string> ToAddressList {
            get {
                return this.ToAddressListField;
            }
            set {
                if ((object.ReferenceEquals(this.ToAddressListField, value) != true)) {
                    this.ToAddressListField = value;
                    this.RaisePropertyChanged("ToAddressList");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmailServiceReference.IEmailService")]
    public interface IEmailService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmail", ReplyAction="http://tempuri.org/IEmailService/SendEmailResponse")]
        void SendEmail(Egharpay.Business.EmailServiceReference.EmailData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmail", ReplyAction="http://tempuri.org/IEmailService/SendEmailResponse")]
        System.Threading.Tasks.Task SendEmailAsync(Egharpay.Business.EmailServiceReference.EmailData data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmailWithSimpleAttachments", ReplyAction="http://tempuri.org/IEmailService/SendEmailWithSimpleAttachmentsResponse")]
        void SendEmailWithSimpleAttachments(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.Dictionary<string, byte[]> attachments);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmailWithSimpleAttachments", ReplyAction="http://tempuri.org/IEmailService/SendEmailWithSimpleAttachmentsResponse")]
        System.Threading.Tasks.Task SendEmailWithSimpleAttachmentsAsync(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.Dictionary<string, byte[]> attachments);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmailWithAttachments", ReplyAction="http://tempuri.org/IEmailService/SendEmailWithAttachmentsResponse")]
        void SendEmailWithAttachments(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.List<System.Guid> documentGuids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmailService/SendEmailWithAttachments", ReplyAction="http://tempuri.org/IEmailService/SendEmailWithAttachmentsResponse")]
        System.Threading.Tasks.Task SendEmailWithAttachmentsAsync(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.List<System.Guid> documentGuids);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmailServiceChannel : Egharpay.Business.EmailServiceReference.IEmailService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmailServiceClient : System.ServiceModel.ClientBase<Egharpay.Business.EmailServiceReference.IEmailService>, Egharpay.Business.EmailServiceReference.IEmailService {
        
        public EmailServiceClient() {
        }
        
        public EmailServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmailServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmailServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void SendEmail(Egharpay.Business.EmailServiceReference.EmailData data) {
            base.Channel.SendEmail(data);
        }
        
        public System.Threading.Tasks.Task SendEmailAsync(Egharpay.Business.EmailServiceReference.EmailData data) {
            return base.Channel.SendEmailAsync(data);
        }
        
        public void SendEmailWithSimpleAttachments(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.Dictionary<string, byte[]> attachments) {
            base.Channel.SendEmailWithSimpleAttachments(data, attachments);
        }
        
        public System.Threading.Tasks.Task SendEmailWithSimpleAttachmentsAsync(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.Dictionary<string, byte[]> attachments) {
            return base.Channel.SendEmailWithSimpleAttachmentsAsync(data, attachments);
        }
        
        public void SendEmailWithAttachments(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.List<System.Guid> documentGuids) {
            base.Channel.SendEmailWithAttachments(data, documentGuids);
        }
        
        public System.Threading.Tasks.Task SendEmailWithAttachmentsAsync(Egharpay.Business.EmailServiceReference.EmailData data, System.Collections.Generic.List<System.Guid> documentGuids) {
            return base.Channel.SendEmailWithAttachmentsAsync(data, documentGuids);
        }
    }
}
