using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace zadacha_3
{
    public class Currency
    {
        public double Dollar { get; set; }
        public Currency(string name, double dollar)
        {
            Dollar = dollar;
        }
        public double ConvertToUSD(Currency target, double amount)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (target == null || amount < 0) Console.WriteLine("Ошибка ввода");
            double amountIntUSD = amount / Dollar;
            double convert = amountIntUSD * target.Dollar;
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения операции: {stopwatch.Elapsed}");
            return convert;
        }
    }
    class Ruble : Currency
    {
        public Ruble() : base("Рубль", 0.1541) { }
    }
    class Hrivna : Currency
    {
        public Hrivna() : base("Гривна", 0.3800) { }
    }
    class Leu : Currency
    {
        public Leu() : base("Леи", 0.8574) { }
    }
    class Program
    {
        static void Main()
        {
            Ruble ruble = new Ruble();
            Hrivna hrivna = new Hrivna();
            Leu leu = new Leu();
            Console.WriteLine("Выберите исходную валюту (1 - RUB, 2 - UAH, 3 - MDL):");
            double source = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите сумму для конвертации:");
            double amountTo = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Выберите нужную валюту (1 - RUB, 2 - UAH, 3 - MDL):");
            int aim = Convert.ToInt32(Console.ReadLine());
            double resultAmount = 0;

            switch (aim)
            {
                case 1: // Рубль
                    resultAmount = ruble.ConvertToUSD(ruble, amountTo);
                    Console.WriteLine($"{amountTo} RUB = {resultAmount:0.###} USD");
                    break;
                case 2: // Гривна
                    resultAmount = ruble.ConvertToUSD(hrivna, amountTo);
                    Console.WriteLine($"{amountTo} RUB = {resultAmount:0.###} UAH");
                    break;
                case 3: // Леи
                    resultAmount = ruble.ConvertToUSD(leu, amountTo);
                    Console.WriteLine($"{amountTo} RUB = {resultAmount:0.###} MDL");
                    break;
                default:
                    Console.WriteLine("Неподдерживаемая целевая валюта.");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine(" Повторить ввод данных? ( 1-yes, 0-no ): ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (a == 1) { Main(); }
            return;
        }
    }
}