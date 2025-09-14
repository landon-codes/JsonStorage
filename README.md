# JsonStorage
## By Ovadiah Shalikhadonai

### Introduction
The JsonStorage nuget package contains functions and data to make creating and managing app storage with C# easier.

### Gettings Started
There are many ways to include this nuget package into your project, so you can search for ways, or use your preffered method to include the nuget package in your project. Once you have the package included you can add it using a ``using`` referance (``using JsonStorage;``). You will need to instantate the class and pass the path to your json file (it can be specific or relative to the current path) in a string:
```csharp
Storage example = new Storage("linkToJsonFile.json");
```
You do not need to create the json file. If there is no file of the specified name and path, it will be created automatically. You will also want to run ``Storage.Load()`` after instantation (replate ``Storage`` with the name of your object).
**Example:**

```csharp
using JsonStorage;

public class Storage
{
    public static void Main(string[] args)
    {
        Storage example = new Storage("linkToJsonFile.json");
        example.Load();
    }
}
```
### Objects

**storageObject**

``<public Dictionary<string, dynamic?>>``

This is the public dictionary where you will interact with your data.

**file**
``<private string>``

This is where the file location is stored when the class is created.
### Functions

**Check()**
``<public void>``

This function is used to make sure there is a storage file. If there is not a file at the specified location from instantation, it will create one and prepare an empty json object (``{}``).

**Load()**
``<public void>``

This loads the data from the json file to the ``storageObject`` dictionary so that it can be used.

**Save()**
``<public void>``

This saves the data from the ``storageObject`` onto the json file.

**QuickDefine(string[] keys, dynamic?[] values)**

``<public void>``

This is used to quickly define a set of key/value pairs in the ``storageObject``.

*Example:*

```csharp
Storage.QuickDefine(["Greeting", "Language"], ["Hello", "English"]);
```

This will add the key value pairs ``Greeting:Hello`` and ``Language:English`` to the ``storageObject``.

**GetKeys()**

``<public string[]>``

This returns an array containing the keys in the dictionary

**Clear(bool save = false)**

``<public void>``

This removes all the key-value pairs from the ``storageObject``. You can add the argument ``true`` if you don't it to save the storage file after being called.

### Changelog

**1.1.0**

The clear function no longer requires input to stop it from saving automatically, and requires explicit input to save instead.

