using App.Libraries.Constants;
using App.Libraries.Exceptions;
using App.Libraries.Interface;
using App.Libraries.Model;
using App.Libraries.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace App.Libraries.Implementation
{
    /// <summary>
    /// Implementation of function signatures for FileProcessor.
    /// </summary>
    public partial class FileProcessor : IFileProcessor
    {
        private readonly string _directory = string.Empty;

        /// <param name="directory">Path directory where source file can be read. This directory shall also be used to write output file.</param>
        public FileProcessor(string directory)
        {
            this._directory = directory;
        }

        // Fn: Finds the file based on filename and Directory provided in Constructor.
        public IEnumerable<NameModel> ReadFile(string fileName)
        {
            // Prep output
            IEnumerable<NameModel> nameList = new List<NameModel>();

            // With Exception Handling
            ExceptionUtils.WithExceptionHandling(() =>
            {
                // Case: Successfully Builds Source Path
                if (TryBuildSourcePath(this._directory, fileName, out string srcPath))
                {
                    // Reads file from generated path
                    List<string> contentList = ReadFileFromPath(srcPath);

                    // Maps contents to Models
                    nameList = MapToNameList(contentList);
                }

                // Case: File cannot be found / invalid on built path
                else
                {
                    // Throws exception
                    throw new InvalidSourceFileException($"File ({FileName.SOURCE}) cannot be found in provided directory ({this._directory}).");
                }
            });

            return nameList;
        }

        // Fn: Writes provided name list into Console.
        public void WriteToConsole(IEnumerable<NameModel> nameList)
        {
            // With Exception Handling
            ExceptionUtils.WithExceptionHandling(() =>
            {
                // For each NameModel
                foreach (NameModel model in nameList)
                {
                    // Write full name to console
                    Console.WriteLine(model.FullName);
                }
            });
        }

        // Fn: Writes into the file based on fileName and Directory provided in Constructor.
        public void WriteToFile(IEnumerable<NameModel> nameList, string fileName)
        {
            // With Exception Handling
            ExceptionUtils.WithExceptionHandling(() =>
            {
                // Build destination path (Directory path verified to exist during input)
                string destPath = Path.Combine(this._directory, fileName);

                // Writes file content with StreamWriter
                using (StreamWriter writer = new StreamWriter(destPath))
                {
                    // For each NameModel
                    foreach (NameModel model in nameList)
                    {
                        // Write full name to file
                        writer.WriteLine(model.FullName);
                    }
                }
            });
        }
    }
}