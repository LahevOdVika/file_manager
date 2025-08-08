namespace FileManager.Commands;

public class TouchCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        switch (args.Length)
        {
            case 0:
                Console.WriteLine("Please specify a name for the file");
                break;
            case > 1:
                Console.WriteLine("Too many arguments");
                break;
            default:
                string fullPath =  Path.Combine(handler.CurrentPath, args[0]);
                if (!Directory.Exists(fullPath) && !File.Exists(fullPath))
                    File.Create(Path.Combine(handler.CurrentPath, args[0]));
                break;
        }
        return Task.CompletedTask;
    }
}