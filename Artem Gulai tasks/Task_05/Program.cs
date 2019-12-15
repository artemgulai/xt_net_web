using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            RunBackupSystem();
        }

        static void RunBackupSystem()
        {
            Console.WriteLine("Enter the path to directory you want to backup:");
            string path;
            while(true)
            {
                path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    break;
                }
                Console.WriteLine("Wrong path. Try again.");
            }

            MyBackupSystem.MyBackupSystem myBackupSystem = new MyBackupSystem.MyBackupSystem(path);

            while (true)
            {
                Console.WriteLine("Choose mode:" + Environment.NewLine +
                                  "1. Listen." + Environment.NewLine + 
                                  "2. Restore." + Environment.NewLine + 
                                  "3. Clear history." + Environment.NewLine + 
                                  "0. Exit.");

                if (!int.TryParse(Console.ReadLine(), out int mode))
                {
                    Console.WriteLine("Wrong input. Try again.");
                    continue;
                }

                if (mode > 3 || mode < 0)
                {
                    Console.WriteLine("Wrong number. Try again.");
                    continue;
                }

                MyBackupSystem.MyBackupMode backupMode = (MyBackupSystem.MyBackupMode)mode;
                switch(backupMode)
                {
                    case MyBackupSystem.MyBackupMode.Listen:
                        Console.WriteLine("Listening mode. Press enter to save history and exit mode.");
                        myBackupSystem.SetMode(backupMode);
                        Console.ReadLine();
                        myBackupSystem.SaveHistory(path);
                        Console.WriteLine("Press enter to exit mode.");
                        break;
                    case MyBackupSystem.MyBackupMode.Restore:
                        Console.WriteLine("Restoring mode.");
                        myBackupSystem.SetMode(backupMode);
                        Console.WriteLine("Press enter to exit mode.");
                        break;
                    case MyBackupSystem.MyBackupMode.DeleteHistory:
                        Console.WriteLine("Deleting history.");
                        myBackupSystem.SetMode(backupMode);
                        Console.WriteLine("Press enter to exit mode.");
                        break;
                    case MyBackupSystem.MyBackupMode.Exit:
                        Console.WriteLine("Good luck. Press enter to exit.");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("Something went wrong. Press enter to try again.");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
