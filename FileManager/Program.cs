using FileManager;
using FileManager.Commands;

var handler = new PathHandler();

Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>()
{
    { "ls", new LsCommand() },
    { "cd", new CdCommand() },
    { "mkdir", new MkdirCommand()},
    { "rm", new RmCommand() },
    { "rmf", new RmfCommand() },
    { "cp", new CpCommand() },
    { "mv", new MvCommand() },
    { "exec", new ExecCommand() },
    { "cat", new CatCommand() },
    { "touch", new TouchCommand() },
    { "pwd", new PwdCommand() },
    { "clear", new ClearCommand() },
    { "exit", new ExitCommand() }
};

while (true)
{
    Console.Write($"{handler.CurrentPath} > ");
    string userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput))
    {
        continue;
    }
    
    string commandName = userInput.Split(' ')[0].ToLower();

    if (commands.TryGetValue(commandName, out ICommand command))
    {
        string[] arg = userInput.Split(' ').Skip(1).ToArray();
        await command.Execute(handler, arg);
    }
    else
    {
        Console.WriteLine("Command not found");
    }
}