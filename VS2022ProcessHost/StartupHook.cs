using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.IO;
using VS2022ProcessHost;

internal class StartupHook
{
    public static void Initialize()
    {
        if (!ShouldRun()) return;

        Console.SetOut(new ConsoleTemperamentalWriter());
    }

    private static bool ShouldRun()
        => System.Runtime.Loader.AssemblyLoadContext.Default.Assemblies.Where(a => a.EntryPoint != null).FirstOrDefault()?.EntryPoint.GetParameters()?.Length == 0;    
}
