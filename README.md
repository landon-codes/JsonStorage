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

### NuGet Package

```bash
dotnet add package JsonStorage
```

### Manual Installation

1. Clone or download this repository
2. Add the `JsonStorage.csproj` to your solution
3. Reference the JsonStorage project in your application

## Usage

### Basic Usage

```csharp
using JsonStorage;

// Create a new storage instance
Storage storage = new Storage("data.json");

// Load existing data or create new file
storage.Load();

// Set some values
storage.storageObject["name"] = "John Doe";
storage.storageObject["age"] = 30;
storage.storageObject["isActive"] = true;

// Save to file
storage.Save();
```

### Bulk Operations

```csharp
// Define multiple keys and values at once
dynamic[] keys = { "setting1", "setting2", "setting3" };
dynamic?[] values = { "value1", 42, true };

storage.QuickDefine(keys, values);
storage.Save();
```

### Retrieving Data

```csharp
// Load data from file
storage.Load();

// Access values
string name = storage.storageObject["name"];
int age = storage.storageObject["age"];
bool isActive = storage.storageObject["isActive"];
```

### Getting All Keys

```csharp
dynamic[] keys = storage.GetKeys();
foreach (var key in keys)
{
    Console.WriteLine($"Key: {key}, Value: {storage.storageObject[key]}");
}
```

### Clearing Storage

```csharp
// Clear all data
storage.Clear();

// Clear and save immediately
storage.Clear(save: true);
```

## API Reference

### Storage Class

#### Constructor
- `Storage(string filePath)` - Creates a new storage instance with the specified file path

#### Methods
- `Check()` - Ensures the storage file exists, creates an empty JSON object if it doesn't
- `Load()` - Loads data from the JSON file into memory
- `Save()` - Saves the current storage object to the JSON file
- `QuickDefine(dynamic[] keys, dynamic?[] values)` - Sets multiple key-value pairs at once
- `GetKeys()` - Returns an array of all keys in the storage
- `Clear(bool save = false)` - Removes all data from storage, optionally saves immediately

#### Properties
- `storageObject` - Dictionary containing the key-value data

## Requirements

- .NET 9.0 or later
- System.Text.Json (included in .NET Core/.NET 5+)

## License

This project is licensed under the Apache License 2.0 - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Author

Ovadiah Shalikhadonai