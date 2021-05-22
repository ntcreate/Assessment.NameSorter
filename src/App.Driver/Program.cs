using App.Libraries.Constants;
using App.Libraries.Implementation;
using App.Libraries.Interface;
using App.Libraries.Model;
using System.Collections.Generic;

namespace App.Console
{
    internal class Program
    {
        // Main: Used to demonstrate usage of IFileProcessor & INameSorter functions
        private static void Main(string[] args)
        {
            // 1st argument is taken in as directory param
            string directory = args[0];

            // Initializes FileProcessor & NameSorter
            IFileProcessor processor = new FileProcessor(directory);
            INameSorter sorter = new NameSorter();

            // Finds filename from given directory, reads file & map to NameModel
            IEnumerable<NameModel> nameList = processor.ReadFile(FileName.SOURCE);

            // Performs sorting on name list
            IEnumerable<NameModel> sortedList = sorter.Sort(nameList);

            // Writes to console
            processor.WriteToConsole(sortedList);

            // Writes to file
            processor.WriteToFile(sortedList, FileName.DESTINATION);
        }
    }
}