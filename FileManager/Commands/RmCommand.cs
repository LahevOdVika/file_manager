namespace FileManager.Commands;

public class RmCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("Please specify a file/s to delete");
            Console.ResetColor();
        }

        foreach (var file in args)
        {
            var fullPath = Path.Combine(handler.CurrentPath, file);
            if (Directory.Exists(fullPath))
            {
                Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
                Console.WriteLine($"Can't delete a directory {file}/");
                Console.ResetColor();       
            }
            else if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;   
                Console.WriteLine($"File {file} doesn't exist in this directory.");
                Console.ResetColor();       
            }
        }
        return Task.CompletedTask;
    }
}