using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsmResolver.DotNet;

namespace ProwlynxNET.Core.Services.Marker
{
    /// <inheritdoc />
    public class MarkerService : IMarkerService
    {
        #region Public Properties

        /// <inheritdoc />
        public MarkerInfo Database { get; } = new MarkerInfo();

        /// <inheritdoc />
        public string Name => nameof(MarkerService);

        /// <inheritdoc />
        public string Description => "Marker service provides access to marker and marker info database.";

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void AddMark(IMemberDefinition target, string protectionName, bool exclude, bool applyToMembers)
        {
            Database.Obfuscations.Add(new ObfuscationInfo
            {
                Name = protectionName,
                Def = target,
                Exclude = exclude,
                ApplyToMembers = applyToMembers
            });
        }

        /// <inheritdoc />
        public void AddMark(ObfuscationInfo info)
        {
            Database.Obfuscations.Add(info);
        }

        /// <inheritdoc />
        public bool CanProtect(IProtection currentProtection, TypeDefinition targetType, bool checkForPropagation = false, bool defaultToTrue = true)
        {
            if (targetType == null) throw new ArgumentException(nameof(targetType));

            var declaringType = targetType.DeclaringType;
            if (declaringType != null)
                if (!CanProtect(currentProtection, declaringType, true))
                    return false;

            List<ObfuscationInfo> typeObfs;
            if (checkForPropagation)
                typeObfs = Database.Obfuscations
                                   .Where(o =>
                                              o.Name == currentProtection.ProtectionName &&
                                              o.IsTypeDef &&
                                              o.TypeDef == targetType &&
                                              o.ApplyToMembers
                                   )
                                   .ToList();
            else
                typeObfs = Database.Obfuscations
                                   .Where(o =>
                                              o.Name == currentProtection.ProtectionName &&
                                              o.IsTypeDef &&
                                              o.TypeDef == targetType
                                   )
                                   .ToList();

            if (typeObfs.Count > 0)
                foreach (var o in typeObfs)
                    if (o.Exclude)
                        return false;

            return defaultToTrue;
        }

        /// <inheritdoc />
        public bool CanProtect(IProtection currentProtection, MethodDefinition targetMethod, bool defaultToTrue = true)
        {
            if (targetMethod == null) throw new ArgumentException(nameof(targetMethod));

            var declaringType = targetMethod.DeclaringType;
            if (declaringType != null)
                if (!CanProtect(currentProtection, declaringType))
                    return false;
            var hasHit = false;
            // Search the methoddef records.
            List<ObfuscationInfo> methodObfs = Database.Obfuscations
                                                       .Where(o =>
                                                                  o.Name == currentProtection.ProtectionName &&
                                                                  o.IsMethodDef &&
                                                                  o.MethodDef == targetMethod
                                                       )
                                                       .ToList();
            if (methodObfs.Count > 0)
                foreach (var o in methodObfs)
                {
                    if (o.Exclude)
                    {
                        return false;
                    }
                    else
                    {
                        hasHit = true;
                    }
                }
                    
          

            if (!hasHit && defaultToTrue)
            {
                return true;
            }
            else if (hasHit)
            {
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public bool CanProtect(IProtection currentProtection, EventDefinition targetEvent, bool defaultToTrue = true)
        {
            if (targetEvent == null) throw new ArgumentException(nameof(targetEvent));

            var declaringType = targetEvent.DeclaringType;
            if (declaringType != null)
                if (!CanProtect(currentProtection, declaringType))
                    return false;

            // Search the eventdef records.
            List<ObfuscationInfo> eventObfs = Database.Obfuscations
                                                      .Where(o =>
                                                                 o.Name == currentProtection.ProtectionName &&
                                                                 o.IsEventDef &&
                                                                 o.EventDef == targetEvent
                                                      )
                                                      .ToList();
            if (eventObfs.Count > 0)
                foreach (var o in eventObfs)
                    if (o.Exclude)
                        return false;

            return defaultToTrue;
        }

        /// <inheritdoc />
        public bool CanProtect(IProtection currentProtection, PropertyDefinition targetProperty, bool defaultToTrue = true)
        {
            if (targetProperty == null) throw new ArgumentException(nameof(targetProperty));

            var declaringType = targetProperty.DeclaringType;
            if (declaringType != null)
                if (!CanProtect(currentProtection, declaringType))
                    return false;

            // Search the propertydef records.
            List<ObfuscationInfo> propertyObfs = Database.Obfuscations
                                                         .Where(o =>
                                                                    o.Name == currentProtection.ProtectionName &&
                                                                    o.IsPropertyDef &&
                                                                    o.PropertyDef == targetProperty
                                                         )
                                                         .ToList();
            if (propertyObfs.Count > 0)
                foreach (var o in propertyObfs)
                    if (o.Exclude)
                        return false;

            return defaultToTrue;
        }

        #endregion
    }
}
