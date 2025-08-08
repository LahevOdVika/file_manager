namespace FileManager.Commands;

public class MkdirCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        switch (args.Length)
        {
            case 0:
                Console.WriteLine("Please specify a name for the directory");
                break;
            case > 1:
                Console.WriteLine("Too many arguments");
                break;
            default:
                string fullPath =  Path.Combine(handler.CurrentPath, args[0]);
                if (!Directory.Exists(fullPath) && !File.Exists(fullPath))
                    Directory.CreateDirectory(Path.Combine(handler.CurrentPath, args[0]));
                break;
        }
        return Task.CompletedTask;
    }
}