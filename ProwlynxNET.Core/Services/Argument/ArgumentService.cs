using ProwlynxNET.Core.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Argument
{
    /// <summary>
    ///     An argument service for a single <see cref="IProtection" />.
    /// </summary>
    public class ArgumentService : IArgumentService
    {
        #region Public Properties

        /// <inheritdoc />
        public string Name { get; set; }

        /// <inheritdoc />
        public string Description => $"Argument Service for {Name}";

        /// <inheritdoc />
        public Dictionary<string, object> Arguments { get; set; }

        /// <inheritdoc />
        public object this[string name]
        {
            get => Arguments[name]!;
            set => Arguments[name] = value;
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Create an argument service for a particular <see cref="IProtection" />.
        /// </summary>
        /// <param name="protectionName">The unique name for the protection.</param>
        public ArgumentService(string protectionName)
        {
            Name = protectionName;
            Arguments = new Dictionary<string, object>();
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public void Add(string name, object value)
        {
            Arguments.Add(name, value);
        }

        /// <inheritdoc />
        public bool Has(string name)
        {
            return Arguments.ContainsKey(name);
        }

        #endregion
    }
}
