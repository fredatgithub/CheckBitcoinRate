using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CheckBitcoinRate
{
  internal class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      display("Checking the latest rate of the bitcoin in a database");
      display(string.Empty);
      List<BitCoin> listOfRates = new List<BitCoin>();
      using (var context = new BitCoinContext())
      {
        listOfRates = context.BitCoins.SqlQuery("SELECT TOP(1) Date, RateEuros, RateDollar FROM CryptoCurrencies.dbo.BitCoin ORDER BY [Date] DESC;").ToList();
      }

      Console.ForegroundColor = ConsoleColor.Green;
      foreach (var item in listOfRates)
      {
        DisplayColorLetters(ConsoleColor.White, "Le ");
        DisplayColorLetters(ConsoleColor.Green, $"{item.Date}");
        DisplayColorLetters(ConsoleColor.White, $", le taux est de ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateEuros)} ");
        DisplayColorLetters(ConsoleColor.Red, $"euros");
        DisplayColorLetters(ConsoleColor.White, $" et ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateDollar)} ");
        DisplayColorLetters(ConsoleColor.Red, $"dollars.");

        //display($"Le {item.Date}, le taux en euros est de {FormatNumber(item.RateEuros)} et le taux en dollar est de {FormatNumber(item.RateDollar)}");
      }

      display(string.Empty);
      display(string.Empty);
      Console.ForegroundColor = ConsoleColor.White;
      display("Press any key to exit:");
      Console.ReadKey();
    }

    private static string FormatNumber(double number)
    {
      return string.Format("{0,1:N2}", number);
    }

    private static void DisplayColorLetters(ConsoleColor color, string message)
    {
      Console.ForegroundColor= color;
      Console.Write(message);
    }
  }
}
