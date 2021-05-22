using App.Libraries.Model;
using System.Collections.Generic;

namespace App.Libraries.Interface
{
    /// <summary>
    /// Interface that specifies the function signatures of FileProcessor.
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Finds the file based on filename and Directory provided in Constructor.
        /// Reads provided name list from file.
        /// </summary>
        IEnumerable<NameModel> ReadFile(string fileName);

        /// <summary>
        /// Writes provided name list into Console.
        /// </summary>
        void WriteToConsole(IEnumerable<NameModel> nameList);

        /// <summary>
        /// Writes into the file based on fileName and Directory provided in Constructor.
        /// Writes provided name list into file.
        /// </summary>
        void WriteToFile(IEnumerable<NameModel> nameList, string fileName);
    }
}