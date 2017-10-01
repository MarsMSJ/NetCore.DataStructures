
#.NET Core 2.0 Data Structures

This is a library containing some data structures written in C# using the .Net core framework. Not for production use (yet.) :)

## Getting Started

### Prerequisities

In order to build and run this code you'll need the .NET core CLI tools. Head over to Microsoft's .Net core web site and install on your OS of choice.

* [Microsoft .NET and C#] (https://www.microsoft.com/net/core#macos) Required to build and run this code.

### Installing

First we need to clone the project directory to your workstation

```
git clone https://github.com/MarsMSJ/NetCore.DataStructures
```

Second, we need to restore the packages needed to build this project.
```
dotnet restore
```

Lastly, lets build and run the code with the provided driver program.
```
dotnet run
```

## Unit Test

The following test are include:

#### BST 
- Pre order, post order, in-order (sorting), and in-level walk, insert, removal, and property tests.

To run the unit tests simply type the following in the terminal:
```
dotnet test NCDSL-test/*.csproj
```


## Deployment

Use the following command to publish.
```
dotnet publish
```

Located dll file in the publish directory in the bin/debug folder. To add the library as a dependency to another project simple type the following in the terminal from your app's directory:
```
dotnet add YourApp/Project.csproj reference NCDSL/*.csproj
```

Then in add the following line to the top of your code:
```
using NCDSL
```
Code away!

## To Do

Look for the nuget package soon. 

## Contributing
Please read [CONTRIBUTING.md](https://gist.github.com/PurpleBooth/b24679402957c63ec426) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

I use [SemVer](http://semver.org/) for versioning. 

