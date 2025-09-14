namespace JsonStorage;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

public class Storage
{
    public Dictionary<string, dynamic?> storageObject = new Dictionary<string, dynamic?>();
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
        Dictionary<string, dynamic?>? loadObject = JsonSerializer.Deserialize<Dictionary<string, dynamic?>>(File.ReadAllText(file));
        if (loadObject != null)
        {
            storageObject = loadObject;
        }
    }
    public void Save()
    {
        Check();
        string stringObject = JsonSerializer.Serialize(storageObject, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(file, stringObject);
    }

    public void QuickDefine(string[] keys, dynamic?[] values)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            storageObject[keys[i]] = values[i];
        }
    }

    public string[] GetKeys()
    {
        return storageObject.Keys.ToArray();
    }

    public void Clear(bool save = false)
    {
        
        string[] keys = GetKeys();
        for (int i = 0; i < keys.Length; i++)
        {
            storageObject.Remove(keys[i]);
        }
        if (save)
        {
            Save();
        }
    }
}