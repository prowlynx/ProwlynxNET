using ProwlynxNET.Core.Extensions;
using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsmResolver.DotNet;

namespace ProwlynxNET.Core.Services.Argument
{
    /// <summary>
    ///     A service that handles arguments passed to protections via an attribute on a definition.
    /// </summary>
    public class AttributeArgumentService : IAttributeArgumentService<ArgumentInfo>
    {
        #region Public Properties

        /// <inheritdoc />
        public List<ArgumentInfo> Database { get; } = new List<ArgumentInfo>();

        /// <inheritdoc />
        public string Name => nameof(AttributeArgumentService);

        /// <inheritdoc />
        public string Description => "Provides access to arguments passed to a definition using custom attributes.";

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void Add(IMemberDefinition definition, string protectionName, string name, string value,
                                bool applyToMembers)
        {
            ArgumentInfo info;
            if (!Exists(definition, protectionName))
            {
                info = new ArgumentInfo
                {
                    Def = definition,
                    ApplyToMembers = applyToMembers,
                    Name = protectionName
                };
                Database.Add(info);
            }
            else
            {
                info = Database.First(d => d.Def == definition);
            }

            if (!info.Arguments.ContainsKey(name))
                info.Arguments.Add(name, value);
            else
                info.Arguments[value] = value;
        }

        /// <inheritdoc />
        public void Add(ArgumentInfo info)
        {
            if (!Exists(info.Def, info.Name))
            {
                Database.Add(info);
            }
            else
            {
                var existingInfo = Database.First(d => d.Name == info.Name && d.Def == info.Def);
                existingInfo.Arguments.AddOrUpdate(info.Arguments);
                existingInfo.ApplyToMembers = info.ApplyToMembers;
            }
        }

        /// <inheritdoc />
        public bool Exists(IMemberDefinition definition, string protectionName)
        {
            return Database.Any(d => d.Name == protectionName && d.Def == definition);
        }

        /// <inheritdoc />
        public ArgumentDictionary GetArguments(IProtection protection, IMemberDefinition definition)
        {
            return new ArgumentDictionary(GetArguments(definition, protection.ProtectionName,
                                                       info => info.Name == protection.ProtectionName &&
                                                               info.Def == definition));
        }

        #endregion

        #region Private Methods

        private Dictionary<string, string> GetArguments(IMemberDefinition definition, string protectionName,
                                                        Func<ArgumentInfo, bool> clause)
        {

            Dictionary<string, string> args = new Dictionary<string, string>();
            if (definition.DeclaringType != null)
            {
                Dictionary<string, string> propagatedArgs = GetArguments(definition.DeclaringType, protectionName,
                                                                         info => info.ApplyToMembers &&
                                                                                 info.Def == definition.DeclaringType &&
                                                                                 info.Name == protectionName
                );
                if (propagatedArgs.Count > 0) args.AddOrUpdate(propagatedArgs);
            }

            var argInfo = Database.FirstOrDefault(clause);

            if (argInfo == null)
                return args;

            return argInfo.Exclude ? new Dictionary<string, string>() : args.AddOrUpdate(argInfo.Arguments);
        }

        #endregion
    }
}
