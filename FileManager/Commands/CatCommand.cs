namespace FileManager.Commands;

public class CatCommand : ICommand
{
    public async Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("Please specify a file to cat");
            Console.ResetColor();
        }

        string fullPath = Path.Combine(handler.CurrentPath, args[0]);
        
        if (File.Exists(fullPath))
        {
            try
            {
                await foreach (var line in File.ReadLinesAsync(fullPath))
                {
                    Console.WriteLine(line);
                }
            } catch (Exception e)
            {
                Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
                Console.WriteLine($"An error occurred: {e.Message}");
                Console.ResetColor();

            }
        }
        else
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine($"File {fullPath} doesn't exist in this directory.");
            Console.ResetColor();       
        }
    }
}