using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Models
{
    /// <summary>
    ///     A logger for a <see cref="ObfuscationTask" />.
    /// </summary>
    public interface ILogger
    {
        #region Public Methods

        /// <summary>
        ///     Log debug message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogDebug(string message);

        /// <summary>
        ///     Log information message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogInfo(string message);

        /// <summary>
        ///     Log an error.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogError(string message);

        /// <summary>
        ///     Log a success message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogSuccess(string message);

        /// <summary>
        ///     Log a warning.
        /// </summary>
        /// <param name="message">The message to log.</param>
        void LogWarn(string message);

        #endregion
    }
}
