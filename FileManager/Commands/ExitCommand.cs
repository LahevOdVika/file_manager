namespace FileManager.Commands;

public class ExitCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        System.Diagnostics.Process.GetCurrentProcess().Kill();
        return Task.CompletedTask;
    }
}