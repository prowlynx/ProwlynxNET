using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Argument
{
    /// <summary>
    ///     A read-only dictionary for arguments.
    /// </summary>
    public class ArgumentDictionary : ReadOnlyDictionary<string, string>
    {
        #region Public Properties

        /// <summary>
        ///     Get a value for a particular key. Values are represented by an empty string if none exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The value, or an empty string.</returns>
        public new string this[string key]
        {
            get => ContainsKey(key) ? base[key] : string.Empty;
            set => throw new InvalidOperationException();
        }

        #endregion

        #region Constructors

        /// <inheritdoc />
        public ArgumentDictionary(IDictionary<string, string> dictionary)
            : base(dictionary)
        {
        }

        #endregion
    }
}
