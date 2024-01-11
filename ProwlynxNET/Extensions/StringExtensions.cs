using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProwlynxNET.Extensions
{
    /// <summary>
    ///     Collection of extension methods that operate exclusively on strings.
    /// </summary>
    public static class StringExtensions
    {
        #region Public Methods

        /// <summary>
        ///     Get a custom branded file path, defaults to _unnamed
        /// </summary>
        /// <param name="filePath">The filepath to brand.</param>
        /// <param name="brand">The brand to give it (goes after the file name, but before the extension.</param>
        /// <returns>A full file path with the custom brand (C:\something_brandhere.exe).</returns>
        public static string GetFilePath(this string filePath, string brand = "_prowlynx")
        {
            string outFile = filePath;
            int index = outFile.LastIndexOf('.');
            if (index != -1) outFile = outFile.Insert(index, brand);
            return outFile;
        }

        #endregion
    }
}
