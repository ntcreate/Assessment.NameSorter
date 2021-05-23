using App.Libraries.Interface;
using App.Libraries.Model;
using System.Collections.Generic;
using System.Linq;

namespace App.Libraries.Implementation
{
    /// <summary>
    /// Implementation of function signatures for NameSorter.
    /// </summary>
    public class NameSorter : INameSorter
    {
        // Fn: Sorts the list via LastName, then FirstName, in ascending order.
        public IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameList)
        {
            return nameList
                .OrderBy(m => m.LastName)
                .ThenBy(m => m.FirstName)
                .ToList();
        }
    }
}