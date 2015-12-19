using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            // For local testing
            //Environment.SetEnvironmentVariable("HOME", @"d:\tmp");
            //Environment.SetEnvironmentVariable("WEBSITE_INSTANCE_ID", @"qwertyuiop");

            // Get the first 6 chars of the instance ID to differentiate from other instances
            string instanceId = Environment.GetEnvironmentVariable("WEBSITE_INSTANCE_ID");
            instanceId = instanceId.Substring(0, 6);

            string logFolder = Environment.ExpandEnvironmentVariables(@"%HOME%\LogFiles\application");
            Directory.CreateDirectory(logFolder);
            string logFile = Path.Combine(logFolder, $"logs_{instanceId}.txt");

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    // First arg is the program to run
                    FileName = args[0],

                    // Rest of the args are passed to the program
                    Arguments = String.Join(" ", args, 1, args.Length - 1),
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };

            process.Start();

            for (;;)
            {
                string line = process.StandardOutput.ReadLine();
                if (line == null) break;
                File.AppendAllLines(logFile, new string[] { line });
                Console.WriteLine(line);
            }

            process.WaitForExit();
        }
    }
}
