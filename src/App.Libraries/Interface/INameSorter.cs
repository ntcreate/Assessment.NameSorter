using App.Libraries.Model;
using System.Collections.Generic;

namespace App.Libraries.Interface
{
    /// <summary>
    /// Interface that specifies the function signatures of NameSorter.
    /// </summary>
    public interface INameSorter
    {
        /// <summary>
        /// Sorts the list via LastName, then FirstName, in ascending order.
        /// </summary>
        IEnumerable<NameModel> Sort(IEnumerable<NameModel> nameList);
    }
}