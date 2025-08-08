namespace FileManager.Commands;

public class ExecCommand : ICommand
{
    public Task Execute(PathHandler handler, string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Please specify a command to execute");
            return Task.CompletedTask;
        }
        
        var command = args[0];
        
        var processedArgs = args.Skip(1).Select(arg =>
        {
            if (!arg.StartsWith('-') && !Path.IsPathRooted(arg))
            {
                return Path.Combine(handler.CurrentPath, arg);
            }

            return arg;
        });

        try
        {
            System.Diagnostics.Process.Start(command, processedArgs);
        }
        catch (System.ComponentModel.Win32Exception)
        {
            Console.WriteLine($"Error: Command or file '{command}' not found.");
        } catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return Task.CompletedTask;
    }
}