using FileManager;
using FileManager.Commands;

var handler = new PathHandler();
var keyboardManager = new KeyboardManager();

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

keyboardManager._prefix = handler.CurrentPath;

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);
    if (key.Key == ConsoleKey.Enter)
    {
        if (keyboardManager.NewLine())
        {

            var commandLine = keyboardManager.BufferToCommand();
            keyboardManager.ClearBuffer();
            keyboardManager.NewLine();
            
            if (commands.TryGetValue(commandLine[0], out ICommand command))
            {
                string[] arg = commandLine.Skip(1).ToArray();
                await command.Execute(handler, arg);
                keyboardManager._prefix = handler.CurrentPath;
            }
            else
            {
                Console.WriteLine("Command not found");
            }
        }
    } else if (key.Key == ConsoleKey.Tab)
    {
        var commandLine = keyboardManager.BufferToCommand()[0];
        
        
        var completions = commands.ToList().Where(x => x.Key.StartsWith(commandLine)).Select(x => x.Key).ToList();
        
        if (completions.Count == 1)
        {
            keyboardManager.ClearBuffer();
            keyboardManager.UpdateConsole();
            
            Console.Write(completions[0]);
            
            keyboardManager.AddChars(completions[0].ToCharArray());
        }
    }
    else if (key.Key == ConsoleKey.Backspace)
    {
        keyboardManager.RemoveLastChar();
    }
    else
    {
        keyboardManager.AddChar(key.KeyChar);
    }
    
    keyboardManager.UpdateConsole();
}