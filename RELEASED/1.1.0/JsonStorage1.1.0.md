# Json Storage 1.1.0
## By Ovadiah Shalikhadonai

Json Storage is a nuget package containing functions for working with and creating storage files using json in your .NET project.

### Getting started

Once you have the nuget package correctly included in your project, you can include it in your script using ``using JsonStorage;``. You can then setup a storage object using ``Storage objectName = new Storage("exampleFilePath.json");``. You can replace ``objectName`` with whatever you want to name your object. Replace ``exampleFilePath.json`` with the path to where you would like your file to be created. I would recommend letting the program create the file itself but you can also create the file yourself if you want. After creating the object, you will want to load your object (which will also prepare the file for being written on,) by using the ``Storage.Load();`` function. This will both load the information onto your json file onto your object so it can be properly used and create a file at the specified directory if it does not already exist.

### Objects

#### storageObject
The ``storageObject`` is a ``Dictionary<dynamic, dynamic?>``. This is where you will interact with the information you have stored for your project.

#### file
The ``file`` is a ``string`` that contains the path to your storage file. It is private so it cannot be accessed or modified, if you want to change the path to your storage file you can change it when you create your object.

### Functions

#### Check()
This function is used to make sure the file for your project exists. It is called automatically with most of the functions in this package but can be called explicitly if there is a reason.

#### Load()
This functions loads the data from the file to the ``storageObject``. 

#### Save()
This function saves the information from the ``storageObject`` to the specified file.

#### QuickDefine(dynamic[] keys, dynamic[]? values)
This function is used to quickly add a set of keys and values to the ``storageObject``. You do not need to do this for only one value, as you can just access the value through the ``storageObject`` directly. 
You input an array of the keys and an array of the corresponding values in order.

#### GetKeys()
This function returns an array of the keys in the ``storageObject``.

#### Clear(bool save = false)
This function removes all the key value pairs from the ``storageObject``. You can tell it to save your ``storageObject`` explicitly by adding ``true`` as an argument. If you don't want it to save the object you don't need any arguments.

### Changelog

#### 1.1.0
Updated clear function to require explicit arguments in order to automatically save the file. The organization of files was also changed and moved around on this update.