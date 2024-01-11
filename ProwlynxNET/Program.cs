using ProwlynxNET.Core.Services.Argument;
using ProwlynxNET.Engine;

namespace ProwlynxNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var obfuscator = new Obfuscator();

            var coreTask = obfuscator.CreateTask(@"..\..\..\..\TestAppCore\bin\Debug\net8.0\TestAppCore.dll");
            // Perhaps we want to specify exact arguments for a particular protection.
            // We can do that here and later call it to check.
            var argService = new ArgumentService("ExampleProtection");
            argService.Add("test", "value");
            // Add the service.
            coreTask.ArgumentProvider.AddService(argService);
            // Run our task to obfuscate.
            obfuscator.RunTask(coreTask);

            var fwTask = obfuscator.CreateTask(@"..\..\..\..\TestAppFW\bin\Debug\TestAppFW.exe");
            obfuscator.RunTask(fwTask);
        }
    }
}
