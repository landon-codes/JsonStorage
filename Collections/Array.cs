namespace JsonStorage;
using System.IO;
using System.Text.Json;

public class StorageArray<T> : Storage<T> where T : new()
{
    public new T[] container = new T[0];
    private string file;

    public StorageArray(string filePath, int size) : base(filePath)
    {
        container = new T[size];
        file = filePath;
    }

    // Reset all values in the array to their default value
    public void Clear()
    {
        for (int i = 0; i < container.Length; i++)
        {
            container[i] = new T();
        }
    }

    // Load is ovverriden to provide support specificly for arrays
    public new void Load()
    {
        Check();
        T[]? loadObject = JsonSerializer.Deserialize<T[]>(File.ReadAllText(file));
        if (loadObject != null)
        {
            container = loadObject;
        }
    }

    // Shorthand for StorageArray.container.Length
    public int Length()
    {
        return container.Length;
    }
}