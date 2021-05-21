using App.Libraries.Constants;
using App.Libraries.Exceptions;
using App.Libraries.Model;
using System.Collections.Generic;

namespace App.Libraries.Implementation
{
    // Partial: Houses Helper Functions (Mapper)
    partial class NameSorter
    {
        // Helper: Maps content list to model list
        private List<NameModel> MapToNameList(List<string> contentList)
        {
            // Prep output
            List<NameModel> nameList = new List<NameModel>();

            // For each content
            foreach (string content in contentList)
            {
                // Map to model
                nameList.Add(MapToModel(content));
            }

            return nameList;
        }

        // Helper: Maps content to model
        private NameModel MapToModel(string content)
        {
            int seperatorIndex = 0;

            // Split each word by whitespace
            string[] wordList = content.Split(' ');

            // As Max Given Name is 3, the minimum given names with maximum words is (3 Given Name + 1 Last Name)
            // Case: 4 or less words in 1 line
            if (wordList.Length <= (NameConstants.MAX_GIVEN_NAME_LENGTH + 1))
            {
                // Last name is assumed to be the final word
                // Get index of last occurrence whitespace
                seperatorIndex = content.LastIndexOf(' ');
            }

            // Case: More than 4 words in 1 line
            else
            {
                // As there may have up to 3 Given names,
                // Get index of 3rd occurrence of white space
                seperatorIndex = GetIndexByOccurrence(content, 3);
            }

            // First name is assumed to be everything before seperatorIndex
            string firstName = content.Substring(0, seperatorIndex).Trim();

            // Last name is assumed to be everything after seperatorIndex
            string lastName = content.Substring(seperatorIndex, (content.Length - seperatorIndex)).Trim();

            // Returns model
            return new NameModel
            {
                FirstName = firstName,
                LastName = lastName,
                FullName = content
            };
        }

        // Helper: Gets index of string after N-th amount of whitespace occurrence
        private int GetIndexByOccurrence(string content, int n)
        {
            int occurCounter = 0;

            // Loop through each char in content
            for (int i = 0; i < content.Length; i++)
            {
                // Case: If char is whitespace
                if (content[i] == ' ')
                {
                    // Increase counter
                    occurCounter++;
                }

                // Case: If counter reaches specified occurrence (n)
                if (occurCounter == n)
                {
                    // Returns index
                    return i;
                }
            }

            // Exception: Not expected to reach here, assuming use-case is (n=3)
            throw new OccurIndexOutOfRangeException($"Unable to get index with occurrence ({n}) in word ({content}).");
        }
    }
}