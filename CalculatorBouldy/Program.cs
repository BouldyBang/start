using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorBouldy
{
    class CalculatorBouldy
    {
        private static bool IsStart { get; set; } = true;
        private static double Result { get; set; } = 0;
        private static double Number { get; set; } = 0;
        private static string Input { get; set; } = "";
        private const string Reset = "reset";
        private const string End = "end";

        public static void Start()
        {
            IsStart = true;
            Result = 0;
            Number = 0;
            Finish();
            return;
        }

        public static void Finish()
        {
            Input = Console.ReadLine();
            if (string.Equals(Input, End, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Bye");
                return;
            }
            if (string.Equals(Input, Reset, StringComparison.CurrentCultureIgnoreCase))
            {
                Start();
            }
            if (!double.TryParse(Input, out double NumberParse))
            {
                switch (Input)
                {
                    case "+":
                        IsStart = false;
                        Finish();
                        Result += Number;
                        Console.WriteLine($" Равна {Result.ToString()}");
                        break;
                    case "-":
                        IsStart = false;
                        Finish();
                        Result -= Number;
                        Console.WriteLine($" Равна {Result.ToString()}");
                        break;
                    case "*":
                        IsStart = false;
                        Finish();
                        Result *= Number;
                        Console.WriteLine($" Равна {Result.ToString()}");
                        break;
                    case "/":
                        IsStart = false;
                        Finish();
                        if (Number == 0)
                        {
                            Console.WriteLine("NaN");
                            break;
                        }
                        Result /= Number;
                        Console.WriteLine($" Равна {Result.ToString()}");
                        break;
                    default:
                        Console.WriteLine("Вы внесли ошибку при внесении данных");
                        break;
                }
            }
            else
            {
                if (IsStart == true)
                {
                    Result = NumberParse;
                }
                else
                {
                    Number = NumberParse;
                    IsStart = true;
                    return;
                }
            }
            Finish();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите уравнение; \"reset\" чтобы начать заного; \"end\" чтобы закончить");
            Start();
            Console.ReadKey();
        }
    }
}