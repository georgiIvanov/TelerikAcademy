using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.BasicLanguage
{
    class BasicLanguage
    {
        static StringBuilder result = new StringBuilder();

        static void Main(string[] args)
        {
            StringBuilder buffer = new StringBuilder();
            bool inBrackets = false;

            while (true)
            {
                int nextConsoleToken = Console.Read();
                if (nextConsoleToken == -1)
                {
                    break;
                }

                char nextChar = (char)nextConsoleToken;
                if (nextChar == '(')
                {
                    inBrackets = true;
                }
                if (nextChar == ')')
                {
                    inBrackets = false;
                }

                if (nextChar == ';' && !inBrackets)
                {
                    string statement = buffer.ToString();
                    statement = statement.Trim();
                    if (ProcessStatement(statement))
                    {
                        break;
                    }
                    buffer.Clear();
                }
                else
                {
                    if (inBrackets)
                    {
                        buffer.Append(nextChar);
                    }
                    else if(!char.IsWhiteSpace(nextChar))
                    {
                        buffer.Append(nextChar);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }

        private static bool ProcessStatement(string statement)
        {
            long count = 1;
            string[] commands = statement.Split(')');
            for (int i = 0; i < commands.Length; i++)
            {
                string cmd = commands[i];
                if(cmd.StartsWith("EXIT") == true)
                {
                    return true;
                }
                else if(cmd.StartsWith("PRINT") == true)
                {
                    int startIndex = cmd.IndexOf('(') + 1;
                    string content = cmd.Substring(startIndex);
                    if (content.Length > 0)
                    {
                        for (int c = 0; c < count; c++)
                        {
                            result.Append(content);
                        }
                    }
                }
                else if (cmd.StartsWith("FOR") == true)
                {
                    int startIndex = cmd.IndexOf('(') + 1;
                    int commaIndex = cmd.IndexOf(',');
                    if (commaIndex == -1)
                    {
                        string forCountStr = cmd.Substring(startIndex);
                        int forCount = int.Parse(forCountStr);
                        count = count * forCount;
                    }
                    else
                    {
                        string forCountStr = cmd.Substring(startIndex, commaIndex - startIndex);
                        int forStartCount = int.Parse(forCountStr);

                        int forEndCount = int.Parse(cmd.Substring(commaIndex+1));
                        int forCount = (forEndCount - forStartCount + 1);
                        count *= forCount;
                    }
                }
            }

            return false;
        }
    }
}
