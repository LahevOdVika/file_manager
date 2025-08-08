using FileManager;

namespace FileManager.Commands;

public class LsCommand : ICommand
{
    
    public Task Execute(PathHandler handler, string[] args)
    {
        try
        {
            var entries = Directory.GetFileSystemEntries(handler.CurrentPath);
            foreach (var entry in entries)
            {
                string entryName = Path.GetFileName(entry);

                if (entryName.StartsWith('.'))
                {
                    continue;
                }
                
                if (Directory.Exists(entry))
                {
                    Console.ForegroundColor = (ConsoleColor)FileTypeColors.Folder;
                }
                else
                {
                    Console.ForegroundColor = (ConsoleColor)FileTypeColors.File;
                }
                Console.WriteLine(entryName);
                Console.ResetColor();
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have access to this folder");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found");       
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        } finally
        {
            Console.ResetColor();
        }
        return Task.CompletedTask;
    }
}