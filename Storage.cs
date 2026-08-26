namespace JsonStorage;

public interface IStorage
{
	public void Write();
	public void Read();
	public bool Check();
}
