namespace ExpandingUnitNonAPI;

public interface IIOService
{
    string ReadLine();
    void Write(string text);
}

public class IOService : IIOService
{
    public string ReadLine()
    {
        return Console.ReadLine()!;
    }

    public void Write(string text)
    {
        Console.Write(text);
    }
}