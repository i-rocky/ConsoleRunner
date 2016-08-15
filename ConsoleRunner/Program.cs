/**
 * This program can execute an external program
 * Send input
 * Get output
 * Get execution time 
 */



using System;
using System.Diagnostics;

namespace ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            run();
            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
        static void run()
        {
            var process = new Process
            {
                StartInfo =
                                  {
                                      FileName = @"p.exe",
                                      RedirectStandardInput = true,
                                      RedirectStandardError = true,
                                      RedirectStandardOutput = true,
                                      UseShellExecute = false,
                                      CreateNoWindow = true,
                                      ErrorDialog = false
                                  }
            };


            process.EnableRaisingEvents = false;

            process.Start();

            var standardInput = process.StandardInput;
            standardInput.AutoFlush = true;
            var standardOutput = process.StandardOutput;
            var standardError = process.StandardError;

            standardInput.WriteLine("Hello World");
            standardInput.WriteLine("3");
            standardInput.WriteLine("4");
            standardInput.WriteLine("5.5");
            standardInput.Close();
            if (!process.WaitForExit(10 * 1000))
            {
                process.Kill();
            }
            var exitCode = process.ExitCode;
            var outputData = standardOutput.ReadToEnd();
            var errorData = standardError.ReadToEnd();
            TimeSpan d = process.ExitTime - process.StartTime;
            process.Close();
            process.Dispose();
            Console.WriteLine(outputData);
            Console.WriteLine("Error: " + errorData);
            Console.WriteLine("Time taken: " + d.TotalSeconds);
            Console.WriteLine("Exit Code: " + exitCode);
        }

    }
}


