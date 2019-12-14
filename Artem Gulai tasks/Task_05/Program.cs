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

            int mode;
            Console.WriteLine("Choose mode:" + Environment.NewLine + "1. Listen." + Environment.NewLine + "2. Restore."
                       + Environment.NewLine + "3. Clear history." + Environment.NewLine + "0. Exit.");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out mode))
                {
                    Console.WriteLine("Wrong input. Try again.");
                    continue;
                }

                if (mode == 0)
                    return;

                if (mode == 3)
                {
                    MyBackupSystem.MyBackupSystem.DeleteHistory(path);
                    Console.ReadLine();
                    return;
                }

                if (mode > 2 || mode < 1)
                {
                    Console.WriteLine("Wrong number. Try again.");
                    continue;
                }
                break;
            }
            MyBackupSystem.MyBackupMode backupMode = (MyBackupSystem.MyBackupMode)mode;
            MyBackupSystem.MyBackupSystem backupSystem = new MyBackupSystem.MyBackupSystem(path, (MyBackupSystem.MyBackupMode) backupMode);

            if (backupMode == MyBackupSystem.MyBackupMode.Listen)
            {
                Console.WriteLine("Listening mode. Press enter to exit.");
                Console.ReadLine();
                backupSystem.SaveHistory(path);
                Console.WriteLine("Press enter to exit.");
            }
            else
            {
                Console.WriteLine("Restoring mode.");
                backupSystem.RestoreFiles();
                Console.WriteLine("Press enter to exit.");
            }
            Console.ReadLine();
        }
    }
}
