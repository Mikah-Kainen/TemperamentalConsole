using System;

public class Program
{
    static void Main()
    {
        var hooks = Environment.GetEnvironmentVariable("DOTNET_STARTUP_HOOKS");

        for (int i = 0; i < 14; i++)
        {
            Console.WriteLine("I like dogs!!");
        }
    }
}