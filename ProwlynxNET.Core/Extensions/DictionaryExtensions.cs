using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Extensions
{
    /// <summary>
    ///     A collection of extensions for dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        #region Public Methods

        /// <summary>
        ///     Add or update the current dictionary with the additional dictionary.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="current">The current dictionary.</param>
        /// <param name="additional">The additional data to take and add or update in the current dictionary.</param>
        /// <returns>The current dictionary, there is no need to use the return value.</returns>
        public static Dictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(
            this Dictionary<TKey, TValue> current, Dictionary<TKey, TValue> additional)
        {
            foreach (KeyValuePair<TKey, TValue> pair in additional)
                if (current.ContainsKey(pair.Key))
                    current[pair.Key] = pair.Value;
                else
                    current.Add(pair.Key, pair.Value);

            return current;
        }

        #endregion
    }
}
