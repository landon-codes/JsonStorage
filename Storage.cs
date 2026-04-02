namespace JsonStorage;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public interface IStorage
{
    void Load();
    void Save();
}

public class Storage<T> : IStorage
{
    public T? container; 
    private string file;

    public Storage(string filePath)
    {
        file = filePath;
    }

    public void Check()
    {
        if (!File.Exists(file))
        {
            File.WriteAllText(file, "{}");
        }
    }
    public void Load()
    {
        Check();
        T? loadObject = JsonSerializer.Deserialize<T>(File.ReadAllText(file));
        if (loadObject != null)
        {
            container = loadObject;
        }
    }
    public void Save()
    {
        Check();
        string stringObject = JsonSerializer.Serialize(container, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, stringObject);
    }
}