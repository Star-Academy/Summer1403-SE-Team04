﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FullTextSearch {
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
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FullTextSearch.Resources", typeof(Resources).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assets/advance_inverted_index.json.
        /// </summary>
        internal static string AdvanceInverIndexPath {
            get {
                return ResourceManager.GetString("AdvanceInverIndexPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assets/files.
        /// </summary>
        internal static string DocumentsPath {
            get {
                return ResourceManager.GetString("DocumentsPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter your word (if you want to finish the program enter &apos;exit&apos;) :.
        /// </summary>
        internal static string EnterWordMessage {
            get {
                return ResourceManager.GetString("EnterWordMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assets/inverted_index.json.
        /// </summary>
        internal static string InvertedIndexDataPath {
            get {
                return ResourceManager.GetString("InvertedIndexDataPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Query Is not processable since it&apos;s null or empty.
        /// </summary>
        internal static string NullOrEmptyQueryExceptionMessage {
            get {
                return ResourceManager.GetString("NullOrEmptyQueryExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Assets/small_words.txt.
        /// </summary>
        internal static string SmallWordsPath {
            get {
                return ResourceManager.GetString("SmallWordsPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to strategy not found pleas check your name.
        /// </summary>
        internal static string StrategyExceptionMessage {
            get {
                return ResourceManager.GetString("StrategyExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Nothing was found for your word.
        /// </summary>
        internal static string WordNotFoundMessage {
            get {
                return ResourceManager.GetString("WordNotFoundMessage", resourceCulture);
            }
        }
    }
}
