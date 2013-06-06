using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.Phonebook
{
    class PhonebookApp
    {
        static void Main(string[] args)
        {
            List<PhoneEntry> phoneEntries = GetPhones();
            PhoneBook phoneBook = new PhoneBook(phoneEntries);

            List<string> commands = GetCommands();

            ExecuteCommands(commands, phoneBook);
        }

        private static void ExecuteCommands(List<string> commands, PhoneBook phoneBook)
        {
            foreach (var command in commands)
            {
                List<PhoneEntry> found = new List<PhoneEntry>();
                string[] arguments = command.Split();
                if (arguments.Length == 1)
                {
                    found = phoneBook.Find(arguments[0]);
                }
                else if (arguments.Length == 2)
                {
                    found = phoneBook.Find(arguments[0], arguments[1]);
                }

                PrintFoundEntries(found, command);
            }
        }

        private static void PrintFoundEntries(List<PhoneEntry> found, string command)
        {
            Console.WriteLine("Command: {0}", command);
            foreach (var item in found)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("\n");
        }

        private static List<string> GetCommands()
        {
            List<string> commands = new List<string>();
            StreamReader sr = new StreamReader("..\\..\\commands.txt");
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string command = sr.ReadLine();
                    var matches = Regex.Matches(command, @"""([^""]*)");
                    if (matches.Count == 2)
                    {
                        var match = matches[0].ToString();
                        commands.Add(match.Substring(1, match.Length - 1));
                    }
                    else if (matches.Count == 4)
                    {
                        var match1 = matches[0].ToString();
                        var match2 = matches[2].ToString();
                        commands.Add(match1.Substring(1, match1.Length - 1) + " " + match2.Substring(1, match2.Length - 1));
                    }
                }
            }

            return commands;
        }

        private static List<PhoneEntry> GetPhones()
        {
            StreamReader sr = new StreamReader("..\\..\\phones.txt");
            List<PhoneEntry> phoneEntries = new List<PhoneEntry>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    string text = sr.ReadLine();
                    string[] entryData = text.Split('|');

                    string[] names = entryData[0].Trim().Split();

                    CreateEntry(phoneEntries, entryData, names);
                }
                
            }

            return phoneEntries;
        }

        private static void CreateEntry(List<PhoneEntry> phoneEntries, string[] entryData, string[] names)
        {
            if (names.Length == 3)
            {
                PhoneEntry phoneEntry = new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim(),
                    names[2].Trim(), names[1].Trim());

                phoneEntries.Add(phoneEntry);
            }
            else if (names.Length == 2)
            {
                PhoneEntry phoneEntry = new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim(),
                    names[1].Trim());

                phoneEntries.Add(phoneEntry);
            }
            else
            {
                PhoneEntry phoneEntry = new PhoneEntry(names[0].Trim(), entryData[1].Trim(), entryData[2].Trim());

                phoneEntries.Add(phoneEntry);
            }
        }

    }
}
