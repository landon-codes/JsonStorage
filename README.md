# JsonStorage

A simple C# library for managing JSON-based key-value storage in .NET applications.

## Description

JsonStorage provides an easy-to-use interface for storing and retrieving data in JSON files. It allows you to persist application data, configuration settings, or any key-value pairs to disk using JSON format.

## Features

- Simple key-value storage API
- Automatic JSON file creation and management
- Load and save operations
- Bulk key-value operations
- File existence checking
- Clear storage functionality

## Installation

### Manual Installation

1. Clone or download this repository
2. Add the `JsonStorage.csproj` to your solution
3. Reference the project in your application

### Binary Installation

1. Download the Nuget package file from the [GitHub repository's](https://github.com/landon-codes/JsonStorage) release page
2. Add a reference to the installed Nuget package
3. Reference the  project in your application

### CLI Installation

1. Open a CLI terminal
2. Navigate to your project directory
3. Run `dotnet package add landon-codes.JsonStorage` 
4. Reference the project in your application

## Usage

JsonStorage provides several classes to manage Json files in your .NET projects.
- `StorageArray<T>`
- `StorageList<T>`
- `StorageDictionary<TKey, TValue>`

*There is also the interface IStorage which can be used for making your own classes.*

All of the previously mentioned classes implement [IStorage](Storage.cs) implement a function for reading and writing Json files.
They also include constructor arguments to customize the functionality of the class.

## Requirements

- .NET 10.0 or later
- System.Text.Json (included in .NET Core/.NET 5+)

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Authors

landon-codes and contributors
