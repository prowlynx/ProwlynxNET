using ProwlynxNET.Core.Models.Services;
using ProwlynxNET.Core.Services.Argument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.ServiceProviders
{
    /// <summary>
    ///     The attribute argument provider for the <see cref="AttributeArgumentService" />.
    /// </summary>
    public class AttributeArgumentProvider : ServiceProviderBase<IAttributeArgumentService<ArgumentInfo>>
    {
        #region Constructors

        /// <summary>
        ///     Create a new attribute argument provider adding a single <see cref="AttributeArgumentService" /> service.
        /// </summary>
        public AttributeArgumentProvider()
        {
            // Just populate the attribute argument service.
            Services.Add(new AttributeArgumentService());
        }

        #endregion
    }
}
