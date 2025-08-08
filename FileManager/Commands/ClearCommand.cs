namespace FileManager.Commands;

public class ClearCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        Console.Clear();
        return Task.CompletedTask;
    }
}