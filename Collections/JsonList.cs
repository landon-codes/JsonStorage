using System.Text.Json;

namespace JsonStorage;

public class JsonList<T> : IStorage
{
	public string Path;

	public T this[int index]
	{
		get => _container[index];
		set => _container[index] = value;
	}

	public int Count => _container.Count;

	private List<T> _container = null!;

	private bool _canOverwrite;
	
	public JsonList(string path, bool overwrite = true, bool autoRead = false)
	{
		Path = path;
		_canOverwrite = overwrite;

		if (autoRead)
			Read();
		else
			_container = new List<T>();
	}

	public void Read()
	{
		var jsonString = File.ReadAllText(Path);

		if (jsonString == "")
			_container = new List<T>();
		else
		{
			var newContainer = JsonSerializer.Deserialize<List<T>>(jsonString);

			if (newContainer == null)
				throw new Exception("When reading the file, it returned null.");

			_container = newContainer;
		}
	}

	public void Write()
	{
		if (!_canOverwrite && File.Exists(Path))
			throw new Exception("The storage object was configured to not overwrite files.\nThe file to write to already exists!");
			
		JsonSerializerOptions options = new()
		{
			WriteIndented = true
		};
		var jsonString = JsonSerializer.Serialize<List<T>>(_container, options);

		File.WriteAllText(Path, jsonString);
	}

	public void Add(T value)
	{
		_container.Add(value);
	}

	public void Remove(T value)
	{
		_container.Remove(value);
	}

	public void RemoveAt(int index)
	{
		_container.RemoveAt(index);
	}

	public void AddRange(IEnumerable<T> collection)
	{
		_container.AddRange(collection);
	}

	public void RemoveRange(int index, int count)
	{
		_container.RemoveRange(index, count);
	}

	public List<T>.Enumerator GetEnumerator()
	{
		return _container.GetEnumerator();
	}

	public static implicit operator List<T>(JsonList list)
	{
		return list._container;
	{
}
