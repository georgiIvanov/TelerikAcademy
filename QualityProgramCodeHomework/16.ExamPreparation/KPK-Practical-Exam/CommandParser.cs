using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public class CommandParser : ICommand
    {
        readonly char[] paramsSeparators = { ';' };
        readonly char commandEnd = ':';

        public Command Type { get; set; }
        public string OriginalForm { get; set; }
        public string Name { get; set; }
        public string[] Parameters { get; set; }
        private int commandNameEndIndex;

        public CommandParser(string input)
        {
            this.OriginalForm = input.Trim();

            this.Parse();
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.ParseName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }

        public Command ParseCommandType(string commandName)
        {
            Command type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("Command cannot contain \";\" or \";\".");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    {
                        type = Command.AddBook;
                    } break;

                case "Add movie":
                    {
                        type = Command.AddMovie;
                    } break;

                case "Add song":
                    {
                        type = Command.AddSong;
                    } break;

                case "Add application":
                    {
                        type = Command.AddApplication;
                    } break;

                case "Update":
                    {
                        type = Command.Update;
                    } break;

                case "Find":
                    {
                        type = Command.Find;
                    } break;

                default:
                    {
                        throw new MissingFieldException("Invalid command name!");
                    }
            }

            return type;
        }

        public string ParseName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 2);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 2, paramsLength);

            string[] parameters = paramsOriginalForm.Split(paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            return parameters;
        }

        public int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(commandEnd);
            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                string trimmedParameter = this.Parameters[i].Trim();
                this.Parameters[i] = trimmedParameter;
            }
        }

        public override string ToString()
        {
            StringBuilder commandBuilder = new StringBuilder();
            commandBuilder.AppendFormat("{0} ", this.Name);

            foreach (string param in this.Parameters)
            {
                commandBuilder.AppendFormat("{0} ", param);
            }
            return commandBuilder.ToString();
        }
    }
}
