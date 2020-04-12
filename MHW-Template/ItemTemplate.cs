﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace MHW_Template
{
    using Microsoft.CSharp;
    using System.CodeDom;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using MHW_Template.Models;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class ItemTemplate : ItemTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("using System;\r\nusing System.ComponentModel;\r\nusing MHW_Editor.Assets;\r\nusing MHW_" +
                    "Editor.Models;\r\nusing MHW_Template;\r\nusing MHW_Template.Models;\r\n\r\nnamespace ");
            
            #line 20 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(_namespace));
            
            #line default
            #line hidden
            this.Write(" {\r\n    public partial class ");
            
            #line 21 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write(" {\r\n        public const uint StructSize = ");
            
            #line 22 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.size));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const ulong InitialOffset = ");
            
            #line 23 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.offsetInitial));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const long EntryCountOffset = ");
            
            #line 24 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.entryCountOffset));
            
            #line default
            #line hidden
            this.Write(";\r\n        public const string EncryptionKey = ");
            
            #line 25 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.encryptionKey == null ? "null" : $"\"{structData.encryptionKey}\""));
            
            #line default
            #line hidden
            this.Write(";\r\n        public override string UniqueId => $\"");
            
            #line 26 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(structData.uniqueIdFormula));
            
            #line default
            #line hidden
            this.Write("\";\r\n");
            
            #line 27 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

    var compiler = new CSharpCodeProvider();
    var sortIndex = 50;
    long offsetOffset = 0; // An offset to our offset for all subsequent offsets.
    long baseOffset = 0; // Used in autoOffset.

    foreach (var entry in structData.entries) {
        var realOffset = structData.autoOffset? baseOffset : (long) entry.offset + offsetOffset;
        offsetOffset += entry.addOffset;

        if (structData.autoOffset) {
            baseOffset += Marshal.SizeOf(entry.type);
        }

        var accessLevel = entry.accessLevel;
        if (accessLevel != "private") {
            accessLevel += " virtual";
        }

        var name = Regex.Replace(entry.displayName, @"[^\w\d]+", "_");
        if (entry.forceUnique) {
            name += $"_{sortIndex}";
        }

        var typeString = compiler.GetTypeOutput(new CodeTypeReference(entry.type));
        string returnString;
        var setCast = "";
        var getCast = "";

        if (entry.enumReturn == null) {
            returnString = typeString;
        } else {
            returnString = compiler.GetTypeOutput(new CodeTypeReference(entry.enumReturn));
            getCast = $"({returnString}) ";
            setCast = $"({typeString}) ";
        }

        // Main property.
        WriteLine("");
        WriteLine($"        public const string {name}_displayName = \"{entry.displayName}\";");
        WriteLine($"        public const int {name}_sortIndex = {sortIndex};");
        WriteLine($"        [SortOrder({name}_sortIndex)]");
        WriteLine($"        [DisplayName({name}_displayName)]");

        if (entry.dataSourceType != null) {
            WriteLine($"        [DataSource(DataSourceType.{entry.dataSourceType})]");
        }

        if (entry.readOnly) {
            WriteLine($"        [IsReadOnly]");
        }

        WriteLine($"        {accessLevel} {returnString} {name} {{");

        if (returnString == "bool") {
            WriteLine($"            get => {getCast}Convert.ToBoolean(GetData<{typeString}>({realOffset}));");
        } else {
            WriteLine($"            get => {getCast}GetData<{typeString}>({realOffset});");
        }

        // Always include a setter, even for readOnly. This enables us to bypass readOnly via command line switch.
        WriteLine("            set {");

        if (returnString == "bool") {
            WriteLine($"                if (Convert.ToBoolean(GetData<{typeString}>({realOffset})) == {entry.valueString}) return;"); // Do nothing if the value is the same.
            WriteLine($"                SetData({realOffset}, Convert.ToByte({entry.valueString}), nameof({name}));");
        } else {
            WriteLine($"                if ({getCast}GetData<{typeString}>({realOffset}) == {entry.valueString}) return;"); // Do nothing if the value is the same.
            WriteLine($"                SetData({realOffset}, {setCast}{entry.valueString}, nameof({name}));");
        }

        WriteLine("                OnPropertyChanged(nameof(Raw_Data));");
        WriteLine($"                OnPropertyChanged(nameof({name}));");

        if (entry.dataSourceType != null) {
            WriteLine($"                OnPropertyChanged(nameof({name}_button));");
        }

        if (entry.extraOnPropertyChanged != null) {
            foreach (var propertyToChange in entry.extraOnPropertyChanged) {
                var propertyToChangeName = Regex.Replace(propertyToChange, @"[^\w\d]+", "_");

                WriteLine($"                OnPropertyChanged(nameof({propertyToChangeName}));");
            }
        }

        WriteLine("            }");

        WriteLine("        }");

        if (entry.dataSourceType != null) {
            string dataSourceLookup;

            switch (entry.dataSourceType) {
                case DataSourceType.Items:
                    dataSourceLookup = "DataHelper.itemNames[MainWindow.locale]";
                    break;
                case DataSourceType.Skills:
                    dataSourceLookup = "DataHelper.skillNames[MainWindow.locale]";
                    break;
                case DataSourceType.SkillDat:
                    dataSourceLookup = "MainWindow.skillDatLookup[MainWindow.locale]";
                    break;
                case DataSourceType.CategorizedWeapons:
                    dataSourceLookup = "DataHelper.weaponIdNameLookup[Weapon_Type][MainWindow.locale]";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            WriteLine("");
            WriteLine($"        [SortOrder({name}_sortIndex)]");
            WriteLine($"        [DisplayName({name}_displayName)]");
            WriteLine($"        [CustomSorter(typeof({entry.dataSourceCustomSorter}))]");
            WriteLine($"        public string {name}_button => {dataSourceLookup}.TryGet({name}).ToStringWithId({name});");
        }

        if (entry.createPercentField) {
            WriteLine("");
            WriteLine($"        private float _{name}Percent;");
            WriteLine($"        [SortOrder({name}_sortIndex + 1)]");
            WriteLine($"        [DisplayName({name}_displayName + \"%\")]");
            WriteLine($"        public float {name}_percent {{");
            WriteLine($"            get => _{name}Percent;");
            WriteLine($"            set {{");
            WriteLine($"                _{name}Percent = value.Clamp(0f, 100f);");
            WriteLine($"                OnPropertyChanged(nameof({name}_percent));");
            WriteLine($"            }}");
            WriteLine($"        }}");
        }

        sortIndex += 50;
    }

            
            #line default
            #line hidden
            this.Write("\r\n        public const int lastSortIndex = ");
            
            #line 162 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(sortIndex));
            
            #line default
            #line hidden
            this.Write(";\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "R:\Games\Monster Hunter World\MHW-Editor\MHW-Template\ItemTemplate.tt"

private string @__namespaceField;

/// <summary>
/// Access the _namespace parameter of the template.
/// </summary>
private string _namespace
{
    get
    {
        return this.@__namespaceField;
    }
}

private string _classNameField;

/// <summary>
/// Access the className parameter of the template.
/// </summary>
private string className
{
    get
    {
        return this._classNameField;
    }
}

private global::MHW_Template.MhwStructData _structDataField;

/// <summary>
/// Access the structData parameter of the template.
/// </summary>
private global::MHW_Template.MhwStructData structData
{
    get
    {
        return this._structDataField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public virtual void Initialize()
{
    if ((this.Errors.HasErrors == false))
    {
bool _namespaceValueAcquired = false;
if (this.Session.ContainsKey("_namespace"))
{
    this.@__namespaceField = ((string)(this.Session["_namespace"]));
    _namespaceValueAcquired = true;
}
if ((_namespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("_namespace");
    if ((data != null))
    {
        this.@__namespaceField = ((string)(data));
    }
}
bool classNameValueAcquired = false;
if (this.Session.ContainsKey("className"))
{
    this._classNameField = ((string)(this.Session["className"]));
    classNameValueAcquired = true;
}
if ((classNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("className");
    if ((data != null))
    {
        this._classNameField = ((string)(data));
    }
}
bool structDataValueAcquired = false;
if (this.Session.ContainsKey("structData"))
{
    this._structDataField = ((global::MHW_Template.MhwStructData)(this.Session["structData"]));
    structDataValueAcquired = true;
}
if ((structDataValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("structData");
    if ((data != null))
    {
        this._structDataField = ((global::MHW_Template.MhwStructData)(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public class ItemTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
