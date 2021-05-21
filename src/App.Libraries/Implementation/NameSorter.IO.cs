using App.Libraries.Constants;
using App.Libraries.Exceptions;
using App.Libraries.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace App.Libraries.Implementation
{
    // Partial: Houses Helper Functions (IO)
    partial class NameSorter
    {
        // Helper: Attempts to build path with given directory, outputs successfully built path
        private bool TryBuildPath(string directory, out string path)
        {
            // Builds path with source file name "unsorted-names-list.txt"
            path = Path.Combine(directory, FileName.SOURCE);

            // Returns whether path exists
            return File.Exists(path);
        }

        // Helper: Reads file from given directory, returns content in list
        private List<string> InputFileContent(string srcPath)
        {
            // Prep output
            List<string> contentList = new List<string>();

            // Reads file content with StreamReader
            using (StreamReader sr = new StreamReader(srcPath))
            {
                // Read first line
                string line = sr.ReadLine();

                // Case: Loop till end of stream content
                while (line != null)
                {
                    // Read line and add content to list (Trim trailing whitespaces)
                    contentList.Add(line.Trim());

                    // Read next line
                    line = sr.ReadLine();
                }
            }

            return contentList;
        }

        // Helper: Output to either File / Console / Both based on given Output Type
        private void OutputSortedList(List<NameModel> nameList, string outputType)
        {
            // Case: Based on output type
            switch (outputType)
            {
                // Type: Console
                case OutputType.CONSOLE:
                    OutputToConsole(nameList);
                    break;

                // Type: File
                case OutputType.FILE:
                    OutputToFile(nameList);
                    break;

                // Type: Console & File
                case OutputType.BOTH:
                    OutputToConsole(nameList);
                    OutputToFile(nameList);
                    break;

                // Type: Unknown
                default:
                    throw new InvalidOutputTypeException($"Unknown Output Type ({outputType}).");
            };
        }

        // Helper: Use the directory given in source file, to output a sorted destination file
        private void OutputToFile(List<NameModel> nameList)
        {
            // Build destination path (Directory path verified to exist during input)
            string destPath = Path.Combine(this._directory, FileName.DESTINATION);

            // Open StreamWriter
            using (StreamWriter writer = new StreamWriter(destPath))
            {
                // For each NameModel
                foreach (NameModel model in nameList)
                {
                    // Write full name to file
                    writer.WriteLine(model.FullName);
                }
            }
        }

        // Helper: Print output of sorted destination file onto console
        private void OutputToConsole(List<NameModel> nameList)
        {
            // For each NameModel
            foreach (NameModel model in nameList)
            {
                // Write full name to console
                Console.WriteLine(model.FullName);
            }
        }
    }
}