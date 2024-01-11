using AsmResolver.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     A class that provides helpful properties for the underlying <see cref="Def" />.
    /// </summary>
    public abstract class DefinitionInfo
    {
        #region Public Properties

        /// <summary>
        ///     Whether the obfuscation info has a definition attached.
        /// </summary>
        public bool HasDef => Def != null;

        /// <summary>
        ///     Whether the <see cref="Def" /> is a method definition.
        /// </summary>
        public bool IsMethodDef => Def is MethodDefinition;

        /// <summary>
        ///     Whether the <see cref="Def" /> is a field definition.
        /// </summary>
        public bool IsFieldDef => Def is FieldDefinition;

        /// <summary>
        ///     Whether the <see cref="Def" /> is a type definition.
        /// </summary>
        public bool IsTypeDef => Def is TypeDefinition;

        /// <summary>
        ///     Whether the <see cref="Def" /> is a event definition.
        /// </summary>
        public bool IsEventDef => Def is EventDefinition;

        /// <summary>
        ///     Whether the <see cref="Def" /> is a property definition.
        /// </summary>
        public bool IsPropertyDef => Def is PropertyDefinition;

        /// <summary>
        ///     The type definition (or null).
        /// </summary>
        public TypeDefinition? TypeDef => Def as TypeDefinition;

        /// <summary>
        ///     The method definition (or null).
        /// </summary>
        public MethodDefinition? MethodDef => Def as MethodDefinition;

        /// <summary>
        ///     The event definition (or null).
        /// </summary>
        public EventDefinition? EventDef => Def as EventDefinition;

        /// <summary>
        ///     The property definition (or null).
        /// </summary>
        public PropertyDefinition? PropertyDef => Def as PropertyDefinition;

        /// <summary>
        ///     The definition (property, method, type, etc.)
        /// </summary>
        public required IMemberDefinition Def { get; set; }

        #endregion
    }
}
