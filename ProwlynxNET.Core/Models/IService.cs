using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     A service that a <see cref="IServiceProvider" /> provides.
    /// </summary>
    public interface IService
    {
        #region Public Properties

        /// <summary>
        ///     The unique name of the service.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Description of the service.
        /// </summary>
        string Description { get; }

        #endregion
    }
}
