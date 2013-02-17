using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPreparation
{
    class TestPreparation
    {
        static void Main(string[] args)
        {
            //question 1
            //char zero = '0';
            //char one = '1';
            //char two = '2';
            //char three = '3';
            //char four = '4';
            //char five = '5';
            //char six = '6';
            //char seven = '7';
            //char eight = '8';
            //char nine = '9';

            //string ns = (nine + two + five).ToString();

            //int n = ((nine - '0') * 10 + two - '0') * 10 + five - '0';
            //Console.WriteLine(n == ns);


            //question 2
            //int i = 0x10; //convert to decimal => 16^0*0 + 16^1 * 1
            //int j = 0x2; //16^0*2
            //Console.WriteLine(i<<j); //16<<2, 64

            
            //question 3 what will appear?
            //string str = @"\\//""";
            //Console.WriteLine(str);

            //question 4
            //double a = 0.2;
            //decimal b = 0.3m;
            //Console.WriteLine(a + b);

            //question 5
            //string a = "1";
            //long b = 1L;
            //Console.WriteLine(b+a);
            ////11, they are concatenated, because a is string

            //queestion 6
            //byte number = 0;
            //for (int i = 0; i <= 32; i++)
            //{
            //    number >>= i;
            //    for (int j = 0; j >= -32; j--)
            //    {
            //        number <<= Math.Abs(j);
            //    }
            //}
            //Console.WriteLine(number); //0, number is 0 from the start

            //question 7
            //byte b1 = 1; //00000001
            //int i1 = 2;  //00000010
            //int result1 = b1 << i1; // 00000100 == 4
            //int result2 = i1 << b1; // 00000100 == 4
            //int result3 = (i1 + b1) << (i1 - b1); // 3<<1 == 6
            //Console.WriteLine("{0}, {1}, {2} ", result1, result2, result3);


            //question 8
            //double first = 0.0f;
            //double second = 0.0;

            //for (int i = 0; i < 12; i++)
            //{
            //    first += 0.1; //1.2
            //}
            //for (int i = 0; i < 4; i++)
            //{
            //    second += 0.3; //1.2
            //}
            //Console.WriteLine(first == second);

            //question 9
            //int n1 = 4; //0100
            //int n2 = 6; //0110
            //int n3 = 8; //1000
            //int result1 = n1 ^ n2 & n3;// & has higher priority, == 4
            //int result2 = (n1 ^ n2) & n3; //0010 & 1000 == 0
            //int result3 = n1 ^ (n2 & n3); // == 4

            //bool equa112 = result1 == result2;
            //bool equal13 = result1 == result3;
            //bool equal23 = result2 == result3; //false
            //Console.WriteLine("{0} {1} {2}", equa112, equal13, equal23);


            //question 10
            //int a = 3;
            //int b = 5;
            //int result = a+++ ++b;//+ is combined directly by pairs
            //Console.WriteLine("{0} {1} {2}", ++a, b++, --result);

            //question 11
            //Console.Write("Fill line {0}", 1, 2);

            //question 12
            //int a = 1;
            //int b = 2;
            //Console.Write("{0, -10}{1, 10}", a, b);
            ////18 empty symbols between them
            
            //question 13
            //bool isTrue = true;
            //bool isFalse = false;
            //if (!!(!(isTrue && isFalse) || !(isTrue || isFalse)))
            //{
            //    Console.WriteLine(isFalse);
            //}
            //else
            //{
            //    Console.WriteLine(isTrue);

            //}
            //False



            //q14
            //int i = 1;
            //int j = 1;
            //switch (i)
            //{
            //    case 1:
            //        i = 1;
            //        break;
            //    case j:
            //        i = 2;
            //        break;
            //    case i:
            //        i = 3;
            //        break;
            //    default:
            //        i = 4;
            //        break;
            //}
            //Console.WriteLine(i);
            ////compile error: A constant value is expected
            //null can be in a case!

            //q15
            //int number = 5;
            //if (number++ == ++number)
            //{
            //    Console.WriteLine(number + 1);
            //}
            //else
            //{
            //    Console.WriteLine(number + 2);
            //}
            ////number == 9

            //q16
            //int? number = new int?();
            //switch (number)
            //{
            //    case 1:
            //        Console.WriteLine(1); break;
            //    case null: Console.WriteLine(4); break;
            //}
            /////null is ok, 4


            //q 17
            //int toto = 1;
            //for (int i = 2; i <= 4; i++, toto++)
            //{
            //    for (int j = i; j < i + 1; j += 2, toto += i < j ? 1 : -1)
            //    {
            //        toto <<= 2;
            //    }
            //}
            //Console.WriteLine(toto - 57);

            //q18
            //int count = 0;
            //for (int i = 1, j = 2; i < j; i++, j++)
            //{
            //    count++;
            //    if (i == 3) i++; break;
            //}
            //Console.WriteLine(count);
            //the loop will repeat onCe

            //q18
            //string[] elements = { "ab", "12" };
            //foreach (var e in elements)
            //{
            //    foreach (var ch in e)
            //    {
            //        Console.Write(ch);
            //    }
            //    Console.Write(e);
            //}



            //q19
            //int n = 4, f = 0;
            //do
            //{
            //    f *= n;
            //    n--;
            //}while(n > 0);
            //Console.WriteLine(f);


            //q20
            //for (int i = 1; i <= 4; i = i*2)
            //{
            //    Console.Write(i + " ");
            //}
            //1 2 4

            //q21
            //int sum = 0;
            //while (sum < 10)
            //    for (int i = 0; i <= 2; i++)
            //        sum += i;
            //Console.WriteLine(sum);
            //12



            //Example test by K*rtev


            //string formatting = "{0}, {1}";
            //Console.WriteLine(formatting, 10, 20);
            //output: 10, 20


            //int a = int.MaxValue;
            //a += 1;
            //Console.WriteLine(a);
            ////^NoException

            //int a = 1;
            //if ((bool)a)
            //{
            //    Console.WriteLine(1);
            //}
            //else
            //{
            //    Console.WriteLine(2);
            //}
            ////^ Cannot cast to bool!!!



            //int a = 2;
            //int b = 3;
            //int c = 4;
            //Console.WriteLine("{0} {1} {2} {3} {4}", a++, ++a, a++ + b++, c-- - --c, c>b?true:false);
            //We change b, before c>b?: therefor {4} is False

            //int a = 2;
            //int b = 3;
            //int c = 4;
            //Console.WriteLine("{0} {1} {2} {3} {4}", ++a, a++ + b++, c-- - --c, c > b ? true : false);
            //Runtime error - FormatException, arguments are less than the indexes

            //Learn formatting strings!!!
            //Console.WriteLine("{0:D6}", 123);
            //Console.WriteLine("{0:F2}", 123);
            //Console.WriteLine("{0,6}{1,-6}", 123, 456);



            //int a = 2;
            //int b = 29;
            //int result = ((~a & b) >> 1) * 2 + 2;
            //Console.WriteLine(result);
            ////after (~a & b) >> 1) we have 14


            //double a = 27.123;
            //float b = 21.1234f;
            //int result = (int)a ^ (int)b;
            //Console.WriteLine(result);
            //output: 14


            //int num = 6 | 14;
            //bool a = (6 & 14) < (6 ^ 14);
            //bool b = (6 | 14) > (6 ^ 14);
            //bool c = !((6 & 14) < (6 | 14));

            //if (!(a && b) || (a && c))
            //{
            //    Console.WriteLine(!a);
            //}
            //else
            //{
            //    Console.WriteLine(!c);
            //}



            //int result = 1;
            //for (int i = 0; i < 56; i++)
            //{
            //    result *= 16;
            //    for (int j = 0; j < 4; j++)
            //    {
            //        result /= 2;
            //    }
            //}
            //Console.WriteLine(result);
            ////^ We divide 16 in 2 four times, there for result is 1 after the second loop



            //char a = '/u003A';
            //Console.WriteLine(a);
            //// it has to be \ in the literal


            //Console.WriteLine(Convert.ToInt32(null));
            ////output: 0


            //int result = 0;
            //for (double i = 0; i < 1; i += 0.1)
            //{
            //    result += 1;
            //}
            //Console.WriteLine(result);
            ////output: 11, 10*0.1 == 0.99999999999999989 :/


            //int? a = null;
            //int result = a ?? 5.5;
            ////compile error, 1) a and 5.5 are different types 2) ?? cant be applied to double and double

            //int? a = null;
            //int result = a ?? 5;
            //Console.WriteLine(result);

            //int? test = null;
            //int? test2 = null;
            //Console.WriteLine(test + test2);
            //Console.WriteLine(test2 + 123);

            //int result = 1;
            //for (int i = 0; i <= int.MaxValue/4; i++)
            //{
            //    result += 4;
            //}
            //Console.WriteLine(result);



            //double a = 2;
            //double b = 3;
            //decimal result = b / a;



            //bool isTrue = false;
            //bool isFalse = true;
            //if (!((isTrue || isTrue) & isTrue) ^ ((isTrue && isFalse) || isTrue))
            //{
            //    Console.WriteLine(isTrue);
            //}
            //else
            //{
            //    Console.WriteLine(isFalse);
            //}



        }
    }
}
