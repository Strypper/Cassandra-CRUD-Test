namespace test;

public static class ConsoleHelpers
{
    public static string ColorizeText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        string coloredText = text;
        Console.ResetColor();
        return coloredText;
    }
}
