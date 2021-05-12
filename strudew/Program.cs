using System;
using System.IO;
using System.IO.Compression;

namespace strudew
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Environment.UserName;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Made with coffe by Zero Meia\n");

            string path_in = @$"C:\Users\{user}\AppData\Roaming\StardewValley\Saves\";
            string path_out = $@"C:\Users\{user}\Downloads";

            string[] saves = Directory.GetDirectories(path_in, "*", SearchOption.TopDirectoryOnly);
            int save_total = saves.Length - 1;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Total Saves Found: {save_total + 1}\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            for (int i = 0; i <= save_total; i++)
            {
                Console.WriteLine($"[{i}] {saves[i]}");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nSelect Save to Share: ");
            int shared = Convert.ToInt32(Console.ReadLine());


            DirectoryInfo shared_name = new DirectoryInfo(saves[shared]);
            ZipFile.CreateFromDirectory(saves[shared], path_out + "\\" + shared_name.Name + ".zip");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Done! Please check the folder: {path_out}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
