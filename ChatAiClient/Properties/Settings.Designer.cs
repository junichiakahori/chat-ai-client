﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatAiClient.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://api.openai.com/")]
        public string ApiUrlSample {
            get {
                return ((string)(this["ApiUrlSample"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://chatgpt2.zeabur.app/proxy/")]
        public string ApiUrl {
            get {
                return ((string)(this["ApiUrl"]));
            }
            set {
                this["ApiUrl"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("質問内容を入力し、送信ボタンを押してください。")]
        public string NavigationMessageInit {
            get {
                return ((string)(this["NavigationMessageInit"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("質問内容を送信中。回答を受信するまでお待ちください。")]
        public string NavigationMessageSubmission {
            get {
                return ((string)(this["NavigationMessageSubmission"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("回答内容をご確認ください。再度質問する場合は質問内容を入力し、送信ボタンを押してください。")]
        public string NavigationMessageNormal {
            get {
                return ((string)(this["NavigationMessageNormal"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("送信をキャンセルしました。再度質問する場合は質問内容を入力し、送信ボタンを押してください。")]
        public string NavigationMessageCancel {
            get {
                return ((string)(this["NavigationMessageCancel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("エラーが発生しました。エラーログをご確認ください。")]
        public string NavigationMessageError {
            get {
                return ((string)(this["NavigationMessageError"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("例外が発生しました。エラーログをご確認ください。")]
        public string NavigationMessageException {
            get {
                return ((string)(this["NavigationMessageException"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("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")]
        public string ApiKey {
            get {
                return ((string)(this["ApiKey"]));
            }
            set {
                this["ApiKey"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://github.com/junichiakahori/chat-ai-client")]
        public string HelpUrl {
            get {
                return ((string)(this["HelpUrl"]));
            }
        }
    }
}
