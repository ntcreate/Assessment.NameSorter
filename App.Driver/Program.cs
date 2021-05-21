using App.Libraries.Constants;
using App.Libraries.Implementation;
using App.Libraries.Interface;

namespace App.Driver
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize NameSorter (OutputType: {Console | File | Both})
            INameSorter sorter = new NameSorter(args[0], OutputType.BOTH);

            // Performs Sorting & prints Output
            sorter.SortAndPrint();
        }
    }
}