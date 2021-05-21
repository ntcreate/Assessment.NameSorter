# Assessment.NameSorter
This repo houses the NameSorter Console Application built using .NET Core 3.1 as Target Framework.

## Getting Started
### Instructions
1. Clone the repository using the command git clone https://github.com/ntcreate/Assessment.NameSorter.git into your Visual Studio.
2. Clean and Build the solution App.Driver.sln.

### To Note
- Console App (**App.Driver**) is built with netcoreapp3.1 as TargetFramework. This requires the installation of .NET Core Runtime 3.1, or otherwise please change to supported TargetFramework for your host.
- Libraries (**App.Libraries**) is built with netstandard2.1 as TargetFramework. 
- The default Console App takes in 1 Argument in Main Function, which is the directory which "unsorted-names-list.txt" resides.
- The default 1st Argument is set as "C://TestCases/". Please have the file "unsorted-files-list.txt" in the current directory. Otherwise, you may change the directory as deemed appropriate.
- In the scenario where your test case fails, kindly reference <repo>/sample/ to run the basic test case.

## Usage
To use Assessment.NameSorter, import the dependent libraries.
````csharp
using App.Libraries;
````

### Initialization
Initialize NameSorter as shown below. NameSorter only has 1 non-default constructor. 
The constructor takes in 2 parameters.
- **Directory** -The directory in which Source file with name "unsorted-names-list.txt" should reside and Destination file will be generated.
- **OutputType** - The output approach for the sorted list of names.
  - *OutputType.CONSOLE* - Outputs into Console only. 
  - *OutputType.FILE* - Outputs into the file "sorted-names-list.txt", with given Directory. 
  - *OutputType.BOTH* - Performs both Console & File output operations.
````csharp
INameSorter sorter = new NameSorter("C://TestCase/", OutputType.BOTH);
````

### SortAndPrint()
This is the only interfacing function for INameSorter. This function attempts to:
- Read the file content from given Directory (Directory set during initialization)
- Sort the Name list (By LastName, then FirstName)
- Output the sorted name list (OutputType set during initialization)
````csharp
sorter.SortAndPrint();
````

### Sample
This code snippet is a reference to App.Driver's Program.cs, where the 1st argument of Main Function is taken in as Directory.
````csharp
private static void Main(string[] args)
{
    // Initialize NameSorter (OutputType: {Console | File | Both})
    INameSorter sorter = new NameSorter(args[0], OutputType.BOTH);

    // Performs Sorting & prints Output
    sorter.SortAndPrint();
}
````
