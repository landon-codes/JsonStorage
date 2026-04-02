namespace JsonStorage;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class StorageDictionary<TKey, TValue> : Storage<Dictionary<TKey, TValue>> where TKey : notnull
{
    public new Dictionary<TKey, TValue> container = new Dictionary<TKey, TValue>();
    private string file;

    public StorageDictionary(string filePath) : base(filePath)
    {
        file = filePath;
    }

    // Shorthand for StorageDictionary.container.Clear()
    public void Clear()
    {
        container.Clear();
    }

    // Load is ovverriden to provide support specificly for dictionaries
    public new void Load()
    {
        Check();
        Dictionary<TKey, TValue>? loadObject = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(File.ReadAllText(file));
        if (loadObject != null)
        {
            container = loadObject;
        }
    }

    // Shorthand for StorageDictionary.container.Count
    public int Count()
    {
        return container.Count;
    }
}