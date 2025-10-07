using System.Text;

namespace FileManager;
public class KeyboardManager
{
    private LinkedList<char> _inputBuffer = [];
    public string _prefix;
    
    public void RemoveLastChar()
    {
        if (_inputBuffer.Count > 0)
        {
            _inputBuffer.RemoveLast();
        }
    }

    public void AddChars(char[] chars)
    {
        foreach (var c in chars)
        {
            _inputBuffer.AddLast(c);   
        }
    }

    public void AddChar(char c)
    {
        _inputBuffer.AddLast(c);
    }

    public void ClearBuffer()
    {
        _inputBuffer.Clear();
    }

    public void UpdateConsole()
    {
        int currentLine = Console.CursorTop;

        Console.SetCursorPosition(0, currentLine);
        Console.Write(_prefix);
        Console.Write(new string(' ', Console.WindowWidth - _prefix.Length));
        Console.SetCursorPosition(_prefix.Length + 1, currentLine);

        foreach (var c in _inputBuffer)
        {
            Console.Write(c);
        }
    }

    public bool NewLine()
    {
        if (_inputBuffer.Count == 0)
        {
            Console.WriteLine();
            return false;
        }
        return true;
    }

    public List<string> BufferToCommand()
    {
        StringBuilder temp = new StringBuilder();

        List<string> commandLine = [];

        foreach (char c in _inputBuffer)
        {
            if (c == ' ')
            {
                commandLine.Add(temp.ToString());
                temp.Clear();
            }
            else
            {
                temp.Append(c);
            }
        }
        
        commandLine.Add(temp.ToString());
        temp.Clear();

        return commandLine;
    }
}