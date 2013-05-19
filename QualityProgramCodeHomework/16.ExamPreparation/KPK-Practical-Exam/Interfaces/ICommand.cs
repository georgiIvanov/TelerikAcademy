using System;
using System.Linq;
using System.Text;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public interface ICommand
    {
        Command Type { get; set; }

        string OriginalForm { get; set; }

        string Name { get; set; }

        string[] Parameters { get; set; }

        Command ParseCommandType(string commandName);

        string ParseName();

        string[] ParseParameters();
    }
}
