namespace FileManager.Commands;

public class PwdCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        handler.PrintCurrentPath();
        return Task.CompletedTask;
    }
}