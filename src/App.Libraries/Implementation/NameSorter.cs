using App.Libraries.Constants;
using App.Libraries.Exceptions;
using App.Libraries.Interface;
using App.Libraries.Model;
using System;
using System.Collections.Generic;

namespace App.Libraries.Implementation
{
    public partial class NameSorter : INameSorter
    {
        private readonly string _directory = string.Empty;
        private readonly string _outputType = string.Empty;

        /// <summary>
        /// Read the names based on given Directory in NameSorter Constructor.
        /// <br />
        /// Thereafter, proceeds to sort the list via LastName, then FirstName.
        /// <br />
        /// Finally, outputs based on provided Output Type.
        /// <para>See Also <seealso cref="OutputType"/> for available list of Output Types.</para>
        /// </summary>
        /// <param name="directory">Path directory where source file can be read. This directory shall also be used to write output file.</param>
        /// <param name="outputType">Outputs sorted list of file based on provided Output Types.</param>
        public NameSorter(string directory, string outputType = OutputType.BOTH)
        {
            this._directory = directory;
            this._outputType = outputType;
        }

        // Fn: Reads File, Sorts & Prints File Content
        public void SortAndPrint()
        {
            try
            {
                // Case: Successfully Builds Source Path
                if (TryBuildPath(this._directory, out string srcPath))
                {
                    // Reads file from generated path
                    List<string> contentList = InputFileContent(srcPath);

                    // Maps contents to Models
                    List<NameModel> nameList = MapToNameList(contentList);

                    // Performs Sorting with given Models
                    nameList = SortNameList(nameList);

                    // Outputs Sorted Name List based on given Output type
                    OutputSortedList(nameList, this._outputType);
                }

                // Case: File cannot be found / invalid on built path
                else
                {
                    // Throws exception
                    throw new InvalidSourceFileException($"File ({FileName.SOURCE}) with provided directory ({this._directory}) cannot be found.");
                }
            }

            // Exception captured
            catch (Exception ex)
            {
                // Prints Exception Message in Console
                Console.WriteLine(ex.Message);
            }
        }
    }
}