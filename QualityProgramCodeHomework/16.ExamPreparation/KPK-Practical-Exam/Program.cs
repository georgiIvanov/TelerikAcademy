using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            foreach (ICommand item in GetCommands())
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> GetCommands()
        {
            List<ICommand> commands = new List<ICommand>();
            bool end = false;

            do
            {
                string inputLine = Console.ReadLine();
                end = (inputLine.Trim() == "End");
                if (!end)
                {
                    commands.Add(new CommandParser(inputLine));
                }

            }
            while (!end);

            return commands;
        }
    }

    

    

    


}
