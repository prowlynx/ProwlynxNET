using ProwlynxNET.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Core.Services.Argument
{
    /// <summary>
    ///     A record of arguments for a particular definition.
    /// </summary>
    public class ArgumentInfo : DefinitionInfo
    {
        #region Public Properties

        /// <summary>
        ///     Whether or not the arguments should appear to lower members.
        /// </summary>
        public bool ApplyToMembers { get; set; }

        /// <summary>
        ///     The unique protection name that the arguments apply to.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        ///     Whether to exclude the arguments.
        /// </summary>
        public bool Exclude { get; set; }

        /// <summary>
        ///     The dictionary holding the arguments.
        /// </summary>
        public Dictionary<string, string> Arguments { get; set; } = new Dictionary<string, string>();

        #endregion

        #region Constructors

        /// <summary>
        ///     Create a new argument info with an empty argument dictionary.
        /// </summary>
        public ArgumentInfo()
        {

        }

        /// <summary>
        ///     Create a new argument info using the specified raw arguments. Raw arguments take the form of "key = value".
        ///     Optionally the key and value may be wrapped in single quotes so special characters like the "=", "," and " " can be
        ///     used.
        /// </summary>
        /// <param name="rawArguments">The raw arguments to use.</param>
        public ArgumentInfo(string rawArguments)
        {
            if (string.IsNullOrEmpty(rawArguments)) return;

            // Raw arguments are simply a list of arguments applied.
            // a = b, b = c, c = d, d=e, e =f
            // or
            // a = b, b = c, c = d, 'd'='e', 'e'='f'
            try
            {
                var inQuotes = false;
                string key = string.Empty;
                string operating = string.Empty;

                foreach (char c in rawArguments)
                    switch (c)
                    {
                        case ' ':
                            if (inQuotes) operating += c;

                            break;
                        case '\'':
                            inQuotes = !inQuotes;
                            break;
                        case '=':
                            if (inQuotes)
                            {
                                operating += c;
                            }
                            else
                            {
                                key = operating;
                                operating = string.Empty;
                            }

                            break;
                        case ',':
                            if (inQuotes)
                            {
                                operating += c;
                                break;
                            }

                            string value = operating;
                            operating = string.Empty;

                            if (!Arguments.ContainsKey(key))
                                Arguments.Add(key, value);
                            else
                                Arguments[key] = value;

                            // Reset key
                            key = string.Empty;
                            break;
                        default:
                            operating += c;
                            break;
                    }

                // Add remaining operating value to the dictionary.
                string value2 = operating;
                operating = string.Empty;

                if (!Arguments.ContainsKey(key))
                    Arguments.Add(key, value2);
                else
                    Arguments[key] = value2;

                // Reset key
                key = string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception with parsing argument info: {ex}");
            }
        }

        #endregion
    }
}
