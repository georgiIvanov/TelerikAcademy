using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem04_Free_Content;
using Problem04_Free_Content.Enumerators;

namespace Problem04_Free_Content
{
    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case Command.AddBook:
                    {
                        InsertInCatalog(catalog, command, sb, Content.Book, "Book Added");
                    } 
                    break;
                case Command.AddMovie:
                    {
                        InsertInCatalog(catalog, command, sb, Content.Movie, "Movie added");
                    }
                    break;
                case Command.AddSong:
                    {
                        InsertInCatalog(catalog, command, sb, Content.Song, "Song added");
                    }
                    break;
                case Command.AddApplication:
                    {
                        InsertInCatalog(catalog, command, sb, Content.Application, "Application added");
                    }
                    break;
                case Command.Update:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new FormatException("Must provide two parameters.");
                        }
                        int updatedEntries = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
                        sb.AppendLine(String.Format("{0} items updated", updatedEntries));
                    }
                    break;
                case Command.Find:
                    {
                        SearchInCatalog(catalog, command, sb);
                    }
                    break;
                default:
                    {
                        throw new InvalidCastException("Incorrect command!");
                    }
            }
        }

        private static void InsertInCatalog(ICatalog catalog, ICommand command, StringBuilder sb, Content content, string userOutput)
        {
            catalog.Add(new CatalogEntry(content, command.Parameters));
            sb.AppendLine(userOutput);
        }

        private static void SearchInCatalog(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new Exception("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                sb.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    sb.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}
