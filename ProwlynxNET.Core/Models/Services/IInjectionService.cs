using AsmResolver.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Services
{
    /// <summary>
    ///     A service that provides the ability to copy types and methods into another module.
    /// </summary>
    public interface IInjectionService : IService
    {
        #region Public Methods

        /// <summary>
        ///     Injects the specified Module to another module.
        ///     Does NOT add the result to the module.
        /// </summary>
        /// <param name="injectModule">The source ModuleDefMD.</param>
        /// <param name="target">The target module.</param>
        IList<TypeDefinition> Inject(ModuleDefinition injectModule, ModuleDefinition target);

        /// <summary>
        ///     Injects the specified definition to another module.
        ///     Does NOT add the result to the module.
        /// </summary>
        /// <param name="def">The source definition.</param>
        /// <param name="target">The target module.</param>
        /// <returns>The injected definition.</returns>
        IMemberDefinition Inject(IMemberDefinition def, ModuleDefinition target);

        /// <summary>
        ///     Injects the specified definitions to another module.
        ///     Does NOT add the result to the module.
        /// </summary>
        /// <param name="def">The source definitions.</param>
        /// <param name="target">The target module.</param>
        /// <returns>The injected definitions.</returns>
        IList<IMemberDefinition> Inject(IEnumerable<IMemberDefinition> def, ModuleDefinition target);

        #endregion
    }
}
