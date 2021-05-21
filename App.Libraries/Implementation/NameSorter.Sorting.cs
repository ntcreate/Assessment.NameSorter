using App.Libraries.Model;
using System.Collections.Generic;
using System.Linq;

namespace App.Libraries.Implementation
{
    // Partial: Houses Helper Functions (Mapper)
    partial class NameSorter
    {
        // Helper: Sort ModelList by LastName, then FirstName
        private List<NameModel> SortNameList(List<NameModel> modelList)
        {
            // Sort by LastName, then by FirstName
            return modelList
                .OrderBy(m => m.LastName)
                .ThenBy(m => m.FirstName)
                .ToList();
        }
    }
}