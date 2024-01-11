using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core
{
    /// <summary>
    ///     A logger that logs exclusively to <see cref="Console" />.
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        #region Public Methods

        /// <inheritdoc />
        public void LogDebug(string message)
        {
            Log(ConsoleColor.White, message);
        }

        /// <inheritdoc />
        public void LogInfo(string message)
        {
            Log(ConsoleColor.Cyan, message);
        }

        /// <inheritdoc />
        public void LogError(string message)
        {
            Log(ConsoleColor.Red, message);
        }

        /// <inheritdoc />
        public void LogSuccess(string message)
        {
            Log(ConsoleColor.Green, message);
        }

        /// <inheritdoc />
        public void LogWarn(string message)
        {
            Log(ConsoleColor.Yellow, message);
        }

        #endregion

        #region Private Methods

        private void Log(ConsoleColor c, string message)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        #endregion
    }
}
