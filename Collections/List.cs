namespace JsonStorage;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class StorageList<T> : Storage<T> where T : new()
{
    public new List<T> container = new List<T>();
    private string file;

    public StorageList(string filePath) : base(filePath)
    {
        file = filePath;
    }

    // Shorthand for StorageList.container.Clear()
    public void Clear()
    {
        container.Clear();
    }

    // Load is ovverriden to provide support specificly for lists
    public new void Load()
    {
        Check();
        List<T>? loadObject = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(file));
        if (loadObject != null)
        {
            container = loadObject;
        }
    }

    public new void Save()
    {
        Check();
        string stringObject = JsonSerializer.Serialize(this.container, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, stringObject);
    }

    // Shorthand for StorageList.container.Count
    public int Count()
    {
        return container.Count;
    }
}