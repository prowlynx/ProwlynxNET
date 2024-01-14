using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models.Services
{
    /// <summary>
    ///     The argument service used by a single <see cref="IProtection" /> to check for arguments to alter the way in which a
    ///     <see cref="IProtection" /> would run.
    /// </summary>
    public interface IArgumentService : IService
    {
        #region Public Properties

        /// <summary>
        ///     The list of arguments for a particular <see cref="IProtection" />
        /// </summary>
        Dictionary<string, object> Arguments { get; }

        /// <summary>
        ///     Get an argument value by its name (key).
        /// </summary>
        /// <param name="name">The name of the argument (key) passed in when added.</param>
        /// <returns>The value of the argument.</returns>
        object this[string name] { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Add an argument to the current argument service.
        /// </summary>
        /// <param name="name">The name of the argument (key)</param>
        /// <param name="value">The value of the argument</param>
        void Add(string name, object value);

        /// <summary>
        ///     Check whether the argument name exists.
        /// </summary>
        /// <param name="name">The name of the argument (key) passed in when added.</param>
        /// <returns>Whether or not the argument exists.</returns>
        bool Has(string name);

        #endregion
    }
}
