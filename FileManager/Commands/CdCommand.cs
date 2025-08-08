namespace FileManager.Commands;

public class CdCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            handler.GoUserFolder();
        } 
        else if (args[0] == "..")
        {
            handler.TryGoBack();
        }
        else
        {
            string fullPath = Path.Combine(handler.CurrentPath, args[0]);
            handler.TryChangePath(fullPath);
        }
        return Task.CompletedTask;
    }
}