using AsmResolver.DotNet;
using ProwlynxNET.Core.Services.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Services
{
    /// <summary>
    ///     A service that handles arguments passed to protections via an attribute on a definition.
    /// </summary>
    public interface IAttributeArgumentService<T> : IService
    {
        #region Public Properties

        /// <summary>
        ///     A database storing <see cref="ArgumentInfo" />s for the service.
        /// </summary>
        List<T> Database { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Add or update an argument for a specific definition for a protection.
        /// </summary>
        /// <param name="definition">The definition.</param>
        /// <param name="protectionName">The <see cref="IProtection" /> name.</param>
        /// <param name="name">The name (key) of the argument.</param>
        /// <param name="value">The value of the argument.</param>
        /// <param name="applyToMembers">Whether to apply the argument to descending members.</param>
        void Add(IMemberDefinition definition, string protectionName, string name, string value, bool applyToMembers);

        /// <summary>
        ///     Add or update an argument from a given argument.
        /// </summary>
        /// <param name="info">The argument to add or update the existing.</param>
        void Add(ArgumentInfo info);

        /// <summary>
        ///     Check whether an entry exists for a definition for the specified protection.
        /// </summary>
        /// <param name="definition">The definition.</param>
        /// <param name="protectionName">The <see cref="IProtection" /> name.</param>
        /// <returns>Whether an entry exists.</returns>
        bool Exists(IMemberDefinition definition, string protectionName);

        /// <summary>
        ///     Get arguments that originated from an attribute for a specific protection that are applied to a specific
        ///     definition.
        /// </summary>
        /// <param name="protection">The protection.</param>
        /// <param name="definition">The definition.</param>
        /// <returns>The list of arguments.</returns>
        ArgumentDictionary GetArguments(IProtection protection, IMemberDefinition definition);

        #endregion
    }
}
