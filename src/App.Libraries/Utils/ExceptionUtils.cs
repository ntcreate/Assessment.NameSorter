using System;

namespace App.Libraries.Utils
{
    /// <summary>
    /// Static Utility functions (Exception).
    /// </summary>
    public static class ExceptionUtils
    {
        /// <summary>
        /// Performs generic try / catch operation, along with error handling required for library.
        /// </summary>
        public static void WithExceptionHandling(Action action)
        {
            try
            {
                // Attempts to run the required action
                action?.Invoke();
            }

            // Exception captured
            catch (Exception ex)
            {
                // Prints Exception Message in Console
                Console.WriteLine(ex.Message);

                // Pre-maturely ends operation
                Environment.Exit(0);
            }
        }
    }
}