using System.Collections.Generic;
using System.IO;

namespace App.Libraries.Implementation
{
    // Partial: Helper Functions (IO).
    partial class FileProcessor
    {
        // Helper: Attempts to build path with given directory, outputs successfully built path.
        private bool TryBuildSourcePath(string directory, string fileName, out string path)
        {
            // Builds path with provided source file name
            path = Path.Combine(directory, fileName);

            // Returns whether path exists
            return File.Exists(path);
        }

        // Helper: Reads file from given directory, returns content in list.
        private List<string> ReadFileFromPath(string srcPath)
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
    }
}