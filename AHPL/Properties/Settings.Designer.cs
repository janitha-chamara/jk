//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MMS.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://ERP-QA.keells.lk:8000/sap/bc/srt/rfc/sap/zbapi_acc_document_post/601/zbapi" +
            "_acc_document_post/zbapi_acc_document_post")]
        public string AHPL_Acc_Document_Post_ZBAPI_ACC_DOCUMENT_POST {
            get {
                return ((string)(this["AHPL_Acc_Document_Post_ZBAPI_ACC_DOCUMENT_POST"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://CYNTHIA.KEELLS.LK:8000/sap/bc/srt/rfc/sap/zbapi_acc_document_post/100/zbap" +
            "i_acc_document_post/zbapi_acc_document_post")]
        public string AHPL_ISR_ZBAPI_ACC_DOCUMENT_POST {
            get {
                return ((string)(this["AHPL_ISR_ZBAPI_ACC_DOCUMENT_POST"]));
            }
        }
    }
}
