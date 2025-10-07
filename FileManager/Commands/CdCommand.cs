namespace FileManager.Commands;

public class CdCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            handler.GoUserFolder();
        } 
        else
        {
            handler.TryChangePath(args[0]);
        }
        return Task.CompletedTask;
    }
}