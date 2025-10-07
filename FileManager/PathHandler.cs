namespace FileManager;

public class PathHandler
{
    public string CurrentPath { get; private set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

    public void PrintCurrentPath() => Console.WriteLine(CurrentPath);
    
    public void TryChangePath(string newPath)
    {
        string potentialPath;
        if (Path.IsPathRooted(newPath))
        {
            potentialPath = newPath;
        }
        else
        {
            potentialPath = Path.Combine(CurrentPath, newPath);
        }

        if (!Directory.Exists(potentialPath))
        {
            Console.ForegroundColor = (ConsoleColor)FileTypeColors.Error;
            Console.WriteLine("Directory not found");
            Console.ResetColor();
            return;
        }
        
        CurrentPath = Path.GetFullPath(potentialPath);
    }
    
    public void GoUserFolder() => TryChangePath(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
}