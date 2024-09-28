using AsmResolver.DotNet;
using ProwlynxNET.Core.Services.Marker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Services
{
    /// <summary>
    ///     The marker service contains the marker information and handles adding markings and checking if markings exist.
    /// </summary>
    public interface IMarkerService : IService
    {
        #region Public Properties

        /// <summary>
        ///     The database of marker information for the marker service.
        /// </summary>
        MarkerInfo Database { get; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Add an obfuscation info to the marker database.
        /// </summary>
        /// <param name="info">The obfuscation info. Cannot be null.</param>
        void AddMark(ObfuscationInfo info);

        /// <summary>
        ///     Add a mark for the given arguments.
        /// </summary>
        /// <param name="target">The target definition.</param>
        /// <param name="protectionName">The protection name from the calling <see cref="IProtection" />.</param>
        /// <param name="exclude">Whether to disallow protection.</param>
        /// <param name="applyToMembers">Whether to apply the same mark to methods.</param>
        void AddMark(IMemberDefinition target, string protectionName, bool exclude, bool applyToMembers);

        /// <summary>
        ///     Check whether the protection can protect the type.
        /// </summary>
        /// <param name="currentProtection">The protection currently running.</param>
        /// <param name="targetType">The target type to protect.</param>
        /// <param name="checkForPropagation">Used internally for recursion. Whether to check that the types apply to members.</param>
        /// <param name="defaultToTrue">Whether to default return true when it is not excluded.</param>
        /// <returns>Whether the protection can protect the target type.</returns>
        bool CanProtect(IProtection currentProtection, TypeDefinition targetType, bool checkForPropagation = false, bool defaultToTrue = true);

        /// <summary>
        ///     Check whether the protection can protect a given method.
        /// </summary>
        /// <param name="currentProtection">The protection currently running.</param>
        /// <param name="targetMethod">The method that is to be protected.</param>
        /// <param name="defaultToTrue">Whether to default return true when it is not excluded.</param>
        /// <returns>Whether the protection can protect the target method.</returns>
        bool CanProtect(IProtection currentProtection, MethodDefinition targetMethod, bool defaultToTrue = true);

        /// <summary>
        ///     Check whether the protection can protect a given event.
        /// </summary>
        /// <param name="currentProtection">The protection currently running.</param>
        /// <param name="targetEvent">The event that is to be protected.</param>
        /// <param name="defaultToTrue">Whether to default return true when it is not excluded.</param>
        /// <returns>Whether the protection can protect the target event.</returns>
        bool CanProtect(IProtection currentProtection, EventDefinition targetEvent, bool defaultToTrue = true);

        /// <summary>
        ///     Check whether the protection can protect a given property.
        /// </summary>
        /// <param name="currentProtection">The protection currently running.</param>
        /// <param name="targetProperty">The property that is to be protected.</param>
        /// <param name="defaultToTrue">Whether to default return true when it is not excluded.</param>
        /// <returns>Whether the protection can protect the target property.</returns>
        bool CanProtect(IProtection currentProtection, PropertyDefinition targetProperty, bool defaultToTrue = true);

        #endregion
    }
}
