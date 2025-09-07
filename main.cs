using System;
using JsonStorage;

class Program
{
    public static void Main(string[] args)
    {
        Storage Storage = new Storage("storage.json");
        Storage.Load();

        Storage.QuickDefine(["Animal", "Color", "Diet", "Size"], ["Cow", "White/Black/Brown", "Plant", "Large"]);
        Storage.Save();

        Console.WriteLine("Hello World!");
    }
}