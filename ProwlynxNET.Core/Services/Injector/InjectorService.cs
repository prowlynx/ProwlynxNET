using AsmResolver.DotNet;
using AsmResolver.DotNet.Cloning;
using ProwlynxNET.Core.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Injector
{
    /// <summary>
    ///     The primary injector for injecting types into a target module.
    /// </summary>
    public class InjectorService : IInjectionService
    {
        #region Public Properties

        /// <inheritdoc />
        public string Name => nameof(InjectorService);

        /// <inheritdoc />
        public string Description =>
            "A service that provides the ability to copy types and methods into another module.";

        /// <inheritdoc />
        public IList<TypeDefinition> Inject(ModuleDefinition injectModule, ModuleDefinition target)
        {
            var cloner = new MemberCloner(target);

            var typesToInject = injectModule.GetAllTypes();

            return new MemberCloner(target)
                    .Include(typesToInject)
                    .Clone()
                    .ClonedMembers
                    .Where(x => x is TypeDefinition)
                    .Cast<TypeDefinition>()
                    .ToList();
        }

        /// <inheritdoc />
        public T Inject<T>(T def, ModuleDefinition target) where T : IMemberDefinition
        {
            var results = new MemberCloner(target)
                                .Include(def)
                                .Clone();
            return results.GetClonedMember(def);
        }

        /// <inheritdoc />
        public IList<IMemberDescriptor> Inject<T>(IEnumerable<T> def, ModuleDefinition target) where T : IMemberDefinition
        {
            var results = new MemberCloner(target)
                                // Why...? .NET...
                                .Include(def.Cast<IMemberDefinition>())
                                .Clone();
            return results.ClonedMembers
                .ToList();
        }

        #endregion
    }
}
