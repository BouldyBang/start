using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorBouldy
{
    class CalculatorBouldy
    {
        private static bool IsStart { get; set; } = true;//ХУЙ
        private static double Result { get; set; } = 0;
        private static double Number { get; set; } = 0;
        private static string Input { get; set; } = "";
        private const string Reset = "reset";
        private const string End = "end";
        /*private static void Start()
        {
            IsStart = true;
            Result = 0;
            Number = 0;
            Calc();
        }*/
        private static void Calc()
        {
            Input = Console.ReadLine();
            if (string.Equals(Input, End, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Bye");
                return;
            }
            /*if (string.Equals(Input, Reset, StringComparison.CurrentCultureIgnoreCase))
            {
                Start();
            }*/
            if (!double.TryParse(Input, out var numberParse))
            {
                if (Input != "+" && Input != "-" && Input != "*" && Input != "/")
                {
                    Console.WriteLine("Вы внесли ошибку при внесении данных");
                    Calc();
                    return;
                }
                IsStart = false;
                switch (Input)
                {
                    case "+":
                        Calc();
                        Result += Number;
                        break;
                    case "-":
                        Calc();
                        Result -= Number;
                        break;
                    case "*":
                        Calc();
                        Result *= Number;
                        break;
                    case "/":
                        Calc();
                        if (Number == 0)
                        {
                            Console.WriteLine("NaN");
                            break;
                        }
                        Result /= Number;
                        break;
                    default:
                        throw new ArgumentException(nameof(Input));
                }
                Console.WriteLine($"Равна {Result.ToString(CultureInfo.InvariantCulture)}");
            }
            else
            {
                if (IsStart)
                {
                    Result = numberParse;
                }
                else
                {
                    Number = numberParse;
                    IsStart = true;
                    return;
                }
            }
            Calc();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите уравнение; \"reset\" чтобы начать заного; \"end\" чтобы закончить");
            Calc();
            Console.ReadKey();
        }
    }
}