﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rastreabilidade.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Log {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Log() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BIC.Strings.Log", typeof(Log).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Recuperando caso de uso {0}. Resultado: {1}.
        /// </summary>
        public static string DEBUG_GetCasoUso {
            get {
                return ResourceManager.GetString("DEBUG_GetCasoUso", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Recuperando modulo {0}. Resultado: {1}.
        /// </summary>
        public static string DEBUG_GetModulo {
            get {
                return ResourceManager.GetString("DEBUG_GetModulo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Recuperando tabela {0}. Resultado: {1}.
        /// </summary>
        public static string DEBUG_GetTabela {
            get {
                return ResourceManager.GetString("DEBUG_GetTabela", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Busca por {0} encontrou {1} resultados..
        /// </summary>
        public static string DEBUG_SearchPerformed {
            get {
                return ResourceManager.GetString("DEBUG_SearchPerformed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Algum fanfarrão tentou salvar um modulo vazio... tsc tsc tsc.
        /// </summary>
        public static string ERROR_TryingToSaveEmptyModule {
            get {
                return ResourceManager.GetString("ERROR_TryingToSaveEmptyModule", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Algum fanfarrão tentou salvar uma tabela vazia... tsc tsc tsc.
        /// </summary>
        public static string ERROR_TryingToSaveEmptyTable {
            get {
                return ResourceManager.GetString("ERROR_TryingToSaveEmptyTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Algum fanfarrão tentou salvar um caso de uso vazio... tsc tsc tsc.
        /// </summary>
        public static string ERROR_TryingToSaveEmptyUseCase {
            get {
                return ResourceManager.GetString("ERROR_TryingToSaveEmptyUseCase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O modulo {0} foi deletado com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_ModuleDeleted {
            get {
                return ResourceManager.GetString("INFO_ModuleDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O modulo {0} foi salvo com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_ModuleSaved {
            get {
                return ResourceManager.GetString("INFO_ModuleSaved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A tabela {0} foi deletado com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_TableDeleted {
            get {
                return ResourceManager.GetString("INFO_TableDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A tabela {0} foi salva com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_TableSaved {
            get {
                return ResourceManager.GetString("INFO_TableSaved", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O caso de uso {0} foi deletado com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_UseCaseDeleted {
            get {
                return ResourceManager.GetString("INFO_UseCaseDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O caso de uso {0} foi salvo com sucesso #todoscomemora!.
        /// </summary>
        public static string INFO_UseCaseSaved {
            get {
                return ResourceManager.GetString("INFO_UseCaseSaved", resourceCulture);
            }
        }
    }
}
