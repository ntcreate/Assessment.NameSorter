namespace App.Libraries.Interface
{
    /// <summary>
    /// Interface that specifies the function signatures of NameSorter
    /// </summary>
    public interface INameSorter
    {
        /// <summary>
        /// Read the names based on Directory provided in Constructor.
        /// <br />
        /// Thereafter, proceeds to sort the list via LastName, then FirstName, in ascending order.
        /// <br />
        /// Finally, prints output based on OutputType provided in Constructor.
        /// </summary>
        void SortAndPrint();
    }
}