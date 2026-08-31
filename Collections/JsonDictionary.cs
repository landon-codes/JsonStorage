using System.Text.Json;

namespace JsonStorage;

public class JsonDictionary<TKey, TValue> : IStorage where TKey : notnull
{
	public string Path;

	public TValue  this[TKey key]
	{
		get => _container[key];
		set => _container[key] = value;
	}

	public Dictionary<TKey, TValue>.KeyCollection Keys => _container.Keys;

	private bool _canOverwrite;

	private Dictionary<TKey, TValue> _container = null!;

	public JsonDictionary(string path, bool overwrite = true, bool autoRead = false)
	{
		Path = path;
		_canOverwrite = overwrite;

		if (autoRead)
			Read();
		else
			_container = new Dictionary<TKey, TValue>();
	}

	public void Write()
	{
		if (!_canOverwrite && File.Exists(Path))
			throw new Exception($"The JsonDictionary object was configured to not allow overwriting data.\n An instance of the file that is being written already exists!");
	
		JsonSerializerOptions options = new()
		{
			WriteIndented = true
		};
		var jsonString = JsonSerializer.Serialize(_container, options);

		File.WriteAllText(Path, jsonString);
	}

	public void Read()
	{		
		var jsonString = File.ReadAllText(Path);

		// Sets the container to an empty class if the file to read is null.
		// Otherwise, initializes the object with the data from the Json file.
		if (jsonString == "")
			_container = new Dictionary<TKey, TValue>();
		else
		{
			var newContainer = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(jsonString);

			if (newContainer == null)
				throw new InvalidDataException("When reading a Json file, it returned null.");

			_container = newContainer;
		}
	}

	public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
	{
		return _container.GetEnumerator();
	}

	public static implicit operator Dictionary<TKey, TValue>(JsonDictionary dict)
	{
		return dict._container;
	}
}
