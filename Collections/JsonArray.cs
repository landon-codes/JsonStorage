using System.Text.Json;

namespace JsonStorage;

public class JsonArray<T> : IStorage
{
	public string Path;
	
	public T this[int index]
	{
		get => _container[index];
		set => _container[index] = value;
	}  

	private T[] _container = null!;

	private readonly bool _canOverwrite;

	private readonly int _count;

	public JsonArray(int count, string path, bool overwrite = true, bool autoRead = false)
	{
		Path = path;
		_canOverwrite = overwrite;
		_count = count;

		if (autoRead)
			Read();
		else
			_container = new T[count];
	}

	public void Read()
	{
		var jsonString = File.ReadAllText(Path);

		// Checks for an empty file to prevent deserialization errors.
		if (jsonString == "")
			_container = new T[_count];
		else
		{
			var newContainer = JsonSerializer.Deserialize<T[]>(jsonString);

			if (newContainer == null)
				throw new InvalidDataException("File returned null while reading.");

			_container = newContainer;
		}
	}

	public void Write()
	{
		if (!_canOverwrite && File.Exists(Path))
			throw new Exception("The storage object was configured to not overwrite any data.\nThe path to write already exists!");

		JsonSerializerOptions options = new()
		{
			WriteIndented = true
		};
		var jsonString = JsonSerializer.Serialize(_container, options);

		File.WriteAllText(Path, jsonString);
	}

	public System.Collections.IEnumerator GetEnumerator()
	{
		return _container.GetEnumerator();
	}

	public static implicit operator T[](JsonArray<T> arr)
	{
		return arr._container;
	}
}
