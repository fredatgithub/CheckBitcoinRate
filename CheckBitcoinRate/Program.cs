using System;
using System.Collections.Generic;
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
        DisplayColorLetters(ConsoleColor.White, $" soit ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateDollar)} ");
        DisplayColorLetters(ConsoleColor.Red, $"dollars.");

        //display($"Le {item.Date}, le taux en euros est de {FormatNumber(item.RateEuros)} et le taux en dollar est de {FormatNumber(item.RateDollar)}");
      }

      listOfRates = new List<BitCoin>();
      string queryMin = "SELECT TOP 1 [Date], [RateEuros], [RateDollar] FROM [CryptoCurrencies].[dbo].[BitCoin] ORDER BY RateEuros ASC;";
      using (var context = new BitCoinContext())
      {
        listOfRates = context.BitCoins.SqlQuery(queryMin).ToList();
      }

      display(string.Empty);
      display(string.Empty);
      Console.ForegroundColor = ConsoleColor.Green;
      foreach (var item in listOfRates)
      {
        DisplayColorLetters(ConsoleColor.White, "Le ");
        DisplayColorLetters(ConsoleColor.Green, $"{item.Date}");
        DisplayColorLetters(ConsoleColor.White, $", le taux le plus ");
        DisplayColorLetters(ConsoleColor.Red, $"bas");
        DisplayColorLetters(ConsoleColor.White, $"  est de ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateEuros)} ");
        DisplayColorLetters(ConsoleColor.Red, $"euros");
        DisplayColorLetters(ConsoleColor.White, $"  soit ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateDollar)} ");
        DisplayColorLetters(ConsoleColor.Red, $"dollars.");
      }

      listOfRates = new List<BitCoin>();
      string queryMax = @"SELECT TOP 1 [Date], [RateEuros], [RateDollar] FROM [CryptoCurrencies].[dbo].[BitCoin] 	ORDER BY RateEuros DESC;";
      using (var context = new BitCoinContext())
      {
        listOfRates = context.BitCoins.SqlQuery(queryMax).ToList();
      }

      display(string.Empty);
      display(string.Empty);
      Console.ForegroundColor = ConsoleColor.Green;
      foreach (var item in listOfRates)
      {
        DisplayColorLetters(ConsoleColor.White, "Le ");
        DisplayColorLetters(ConsoleColor.Green, $"{item.Date}");
        DisplayColorLetters(ConsoleColor.White, $", le taux le plus ");
        DisplayColorLetters(ConsoleColor.Red, $"haut");
        DisplayColorLetters(ConsoleColor.White, $" est de ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateEuros)} ");
        DisplayColorLetters(ConsoleColor.Red, $"euros");
        DisplayColorLetters(ConsoleColor.White, $" soit ");
        DisplayColorLetters(ConsoleColor.Green, $"{FormatNumber(item.RateDollar)} ");
        DisplayColorLetters(ConsoleColor.Red, $"dollars.");
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
