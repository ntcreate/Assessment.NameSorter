# Assessment.NameSorter
This repo houses the NameSorter Console Application built using .NET Core 3.1 as Target Framework.

## Getting Started
### Instructions
1. Clone the repository using the command git clone https://github.com/ntcreate/Assessment.NameSorter.git into your Visual Studio.
2. Clean and Build the solution Assessment.NameSorter.sln.

### To Note
- Console App solution (**App.Console**) is built with netcoreapp3.1 as TargetFramework. This requires the installation of .NET Core Runtime 3.1, or otherwise please change to supported TargetFramework for your host.
- Referencing Library solution (**App.Libraries**) is built with netstandard2.1 as TargetFramework. 
- The default Console App takes in 1 Argument in Main Function, which is the directory which "unsorted-names-list.txt" resides.
- The default 1st Argument is set as "C://TestCases/". Please have the file "unsorted-files-list.txt" in the current directory. Otherwise, you may change the directory as deemed appropriate.
- In the scenario where your test case fails, kindly reference ***repo/sample/*** to run the basic test case.

## Usage
To use Assessment.NameSorter, import the dependent libraries.
````csharp
using App.Libraries;
````

### Initialization
In this release, we have provided 2 interface to assist in the Assessment.NameSorter operations.

**IFileProcessor** - Interface that provides File Input & Output processing operations.
- *Directory* - Directory in which Source file with name "unsorted-names-list.txt" should reside and Destination file will be generated.
````csharp
IFileProcessor processor = new FileProcessor(directory);
````

**INameSorter** - Interface that provides name sorting operations.
````csharp
INameSorter sorter = new NameSorter();
````

### Sample
This code snippet is a reference to App.Console's Program.cs, where the 1st argument of Main Function is taken in as Directory.
````csharp
// Main: Used to demonstrate usage of IFileProcessor & INameSorter functions
private static void Main(string[] args)
{
    // 1st argument is taken in as directory param
    string directory = args[0];

    // Initializes FileProcessor & NameSorter
    IFileProcessor processor = new FileProcessor(directory);
    INameSorter sorter = new NameSorter();

    // Reads file content
    IEnumerable<NameModel> nameList = processor.ReadFile(FileName.SOURCE);

    // Performs sorting on name list
    IEnumerable<NameModel> sortedList = sorter.Sort(nameList);

    // Writes to console
    processor.WriteToConsole(sortedList);

    // Writes to file
    processor.WriteToFile(sortedList, FileName.DESTINATION);
}
````
