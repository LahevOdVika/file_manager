namespace FileManager.Commands;

public class RmfCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("Please specify a folder/s to delete");
            Console.ResetColor();
        }

        foreach (var folder in args)
        {
            var fullPath = Path.Combine(handler.CurrentPath, folder);
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);       
            }
            else if (File.Exists(fullPath))
            {
                Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
                Console.WriteLine($"Can't delete a file {folder}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;   
                Console.WriteLine($"Folder {folder} doesn't exist in this directory.");
                Console.ResetColor();       
            }
        }
        return Task.CompletedTask;
    }
}