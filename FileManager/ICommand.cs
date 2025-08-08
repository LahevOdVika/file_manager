namespace FileManager;

public interface ICommand
{
    Task Execute(PathHandler handler, string[] args);
}