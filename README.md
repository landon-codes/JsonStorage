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
- `Storage<T>`
- `StorageArray<>`
- `StorageList`
- `StorageDictionary`

*There is also the interface IStorage which can be used for making your own classes.*

### `Storage<T>`

This is the first class. It is intended to be usable with any data type that System.Text.Json can serialize. It has the least functionality, and requires the most setup but allows functionality for any other data types that don't have built-in functionality.

#### Properties

- `public T? container`

This is the object containts the data you will be working with. It requires setup in your program.

```csharp
// Initialize a Storage instance for a string
Storage<string> example = new Storage<string>("file.json");

// Set the container property to a string containing "Hello, World!"
example.container = "Hello, World!";
```

- `private string file`

This contains the file path for reading/writing your Json file. It is assigned during initialization and cannot be changed without creating a new instance.

#### Methods

- `public Storage(string path)`

This is the constructor for the class. It's only argument is the path to the file you are wanting to edit.

- `public void Check()`

This checks to make sure the file you are editing exists. If it does not, a valid file will automatically be created.

This method is also called in the Load() and Save() methods minimize bugs/errors.

- `public void Load()`

This loads the file into your program for you to work with.

- `public void Save()`

This writes your current container object to the file.

## Requirements

- .NET 9.0 or later
- System.Text.Json (included in .NET Core/.NET 5+)

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Authors

landon-codes and contributors