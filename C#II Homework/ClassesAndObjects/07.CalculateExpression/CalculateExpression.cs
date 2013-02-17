using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

class AlgorithmExpression
{
    static string outputStack = String.Empty;
    static string inputStack = String.Empty;

    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture =
            System.Globalization.CultureInfo.InvariantCulture;
        string inputLine = Console.ReadLine();
        double result = ShuntingYardAlgorithm(inputLine);
        Console.WriteLine("Result: {0:F2}", result);
    }

    static double ShuntingYardAlgorithm(string inputLine)
    {

        inputLine = CheckAndResolveUnaryMinus(inputLine);
        inputLine = FindAndResolveFunctions(inputLine);
        outputStack = string.Empty;
        inputStack = string.Empty;
        string beforeCalculations = CreateStacks(inputLine);
        double result = Calculate(beforeCalculations); 

        return result;
    }

    static string FindAndResolveFunctions(string inputLine)
    {
        int length = inputLine.Length;
        for (int i = 0; i < length; i++)
        {
            if (i < length -2 && string.Compare(inputLine.Substring(i,2), "ln") == 0)
            {
                string function = GetArguments(inputLine, i, 2);
                i += function.Length;

                double result = ShuntingYardAlgorithm(function);
                double functionResult = Math.Log(result, 2.71828);
                inputLine = ReplaceWithResult(inputLine, function, functionResult, "ln");
            }
            else if (i < length - 5 && string.Compare(inputLine.Substring(i, 4), "sqrt") == 0)//inputLine[i] == 's' && inputLine[i + 1] == 'q')
            {
                string function = GetArguments(inputLine, i, 4);
                i += function.Length;
                double result = ShuntingYardAlgorithm(function);
                double functionResult = Math.Sqrt(result);

                inputLine = ReplaceWithResult(inputLine, function, functionResult, "sqrt");
            }
            else if (inputLine[i] == 'p' && inputLine[i+1] == 'o')
            {
                string function = GetArguments(inputLine, i, 3);
                i += function.Length;
                string[] powParameters = function.Split(',');
                powParameters[0] = powParameters[0].Remove(0, 1);
                powParameters[1] = powParameters[1].Remove(powParameters[1].Length - 1, 1);
                double baseNum = ShuntingYardAlgorithm(powParameters[0]);
                double exponent = ShuntingYardAlgorithm(powParameters[1]);
                double functionResult = Math.Pow(baseNum, exponent);

                inputLine = ReplaceWithResult(inputLine, function, functionResult, "pow");
            }
        }

        return inputLine;
    }

    static string ReplaceWithResult(string inputLine, string function, double functionResult, string funcToRep)
    {
        string replaceFunction = funcToRep + function;
        string newFunction = "(" + functionResult.ToString() + ")";
        return inputLine.Replace(replaceFunction, newFunction);
    }


    static string GetArguments(string statement, int index, int startPos)
    {
        StringBuilder function = new StringBuilder();
        int brackets = 1;
        function.Append(statement[index + startPos]);
        index += startPos + 1;
        while (index < statement.Length && brackets != 0)
        {
            if (statement[index] == '(')
            {
                brackets++;
            }
            else if (statement[index] == ')')
            {
                brackets--;
            }

            function.Append(statement[index]);
            index++;
        }
        return function.ToString();
    }

    static string CheckAndResolveUnaryMinus(string inputLine)
    {
        if (inputLine[0] == '-')
        {
            inputLine = '0' + inputLine;
        }
        inputLine = inputLine.Replace(" ", "");
        inputLine = inputLine.Replace("(-", "(0-");
        inputLine = inputLine.Replace(",-", ",0-");
        
        return inputLine;
    }

    static double Calculate(string inputLine)
    {
        double temp, result = 0;
        List<double> numbersStack = new List<double>();
        string[] numbers = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        
        foreach(var num in numbers)
        {
            temp = 0;
            result = 0;

            if (double.TryParse(num, out temp))
            {
                numbersStack.Add(temp);
            }
            else
            {
                int length = numbersStack.Count;
                if (length < 2) break;
                result = Calculate2Numbers(numbersStack[length - 2], numbersStack[length - 1], num[0]);
                numbersStack.RemoveRange(length - 2, 2);
                numbersStack.Add(result);
            }

            result = numbersStack[0];
        }

        return result;
    }

    static string CreateStacks(string inputLine)
    {
        int length = inputLine.Length;
        for (int i = 0; i < length; i++)
        {
            if ((inputLine[i] >= '0' && inputLine[i] <= '9') || inputLine[i] == '.')
            {
                outputStack += inputLine[i];
            }
            else if (inputLine[i] == ')')
            {
                ClearStacks();
            }
            else
            {
                outputStack += ' ';
                EvalPriorities(inputLine[i]);
            }
        }

        for (int i = inputStack.Length - 1; i >= 0; i--)
        {
            outputStack += ' ';
            outputStack += inputStack[i];
        }

        return outputStack;
    }

    static void ClearStacks()
    {
        for (int i = inputStack.Length - 1; i >= 0; i--)
        {
            if (inputStack[i] != '(')
            {
                outputStack += ' ';
                outputStack += inputStack[i];
            }
            else
            {
                inputStack = inputStack.Remove(i, inputStack.Length - i);
                break;
            }
        }
    }

    static void EvalPriorities(char currentToken)
    {
        int length = inputStack.Length;
        if (length == 0)
        {
            inputStack += currentToken;
        }
        else
        {
            int currTokenPriority = GetOperationPriority(currentToken);
            int prevTokenPriority = GetOperationPriority(inputStack[length - 1]);

            if (currentToken != '(' && currTokenPriority <= prevTokenPriority)
            {
                outputStack += inputStack[length - 1];
                outputStack += ' ';
                inputStack = inputStack.Remove(length - 1, 1);
                inputStack += currentToken;

            }
            else
            {
                inputStack += currentToken;
            }
        }
    }

    static int GetOperationPriority(char operation)
    {
        switch (operation)
        {
            case '*': return 3;
            case '/': return 3;
            case '+': return 2;
            case '-': return 2;
            case '(': return 0;
            default: return 0;
        }
    }

    static double Calculate2Numbers(double firstNumber, double secondNumber, char operation)
    {
        switch (operation)
        {
            case '*': return firstNumber * secondNumber;
            case '/': return firstNumber / secondNumber;
            case '+': return firstNumber + secondNumber;
            case '-': return firstNumber - secondNumber;
            case '(': return 0;
            default: return 0;
        }
    }

    
}