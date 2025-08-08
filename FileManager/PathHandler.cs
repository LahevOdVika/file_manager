namespace FileManager;

public class PathHandler
{
    public string CurrentPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public void PrintCurrentPath() => Console.WriteLine(CurrentPath);
    
    public void TryChangePath(string path)
    {
        if (!Directory.Exists(path))
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("Directory not found");
            return;
        }
        
        CurrentPath = path;
    }

    public void TryGoBack()
    {
        if (CurrentPath == Path.GetPathRoot(CurrentPath))
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("You can't go back");
            Console.ResetColor();       
            return;       
        }
        string parentPath = Path.GetDirectoryName(CurrentPath)!;
        TryChangePath(parentPath);       
    }
    
    public void GoUserFolder() => TryChangePath(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
}