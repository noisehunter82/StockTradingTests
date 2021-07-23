using System;
using Xunit;
using StockTrading;


namespace StockTradingTests
{
  public class ProgramShould
  {

    [Fact]
    public void GetPrices_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("GetPrices", new Type[] { typeof(string) });

      Assert.True(exists != null, "Class Program should have a method 'GetPrices' that takes a string as argument");

    }


    [Fact]
    public void GetPrices_ReturnsFormattedLowAndHighResult()
    {
      var str = "1.2,3.4, 5.6";
      var expected = "\n1(1.20),3(5.60)";

      var actual = Program.GetPrices(str);

      Assert.True(expected.Equals(actual), "Should return a correctly formatted string with two days and prices");

    }


    [Fact]
    public void GetPrices_ReturnsIncorrectDataStatus()
    {
      var str = "a,bc";
      var expected = "\nIncorrect data format.";

      var actual = Program.GetPrices(str);

      Assert.True(expected.Equals(actual), "Should return a correctly formatted warning");

    }


    [Fact]
    public void ConvertToDecimal_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("ConvertToDecimal", new Type[] { typeof(string) });

      Assert.True(exists != null, "Class Program should have a method 'ConvertToDecimal' that takes a string as argument");

    }

    [Fact]
    public void ConvertToDecimal_StringToArray()
    {
      var str = "1.2,3.4, 5.6";
      var expected = new decimal[] { 1.2m,3.4m,5.6m };

      var actual = Program.ConvertToDecimal(str);

      Assert.Equal(expected, actual);
      
    }


    [Fact]
    public void FormatResults_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("FormatResults", new Type[] { typeof(int), typeof(decimal), typeof(int),typeof(decimal)});

      Assert.True(exists != null, "Class Program should have a method 'FormatResults' that takes two int and two decimal values as arguments");

    }


   [Fact]
    public void FormatResults_ReturnsFormattedLowAndHighResult()
    {

      var lowIndex = 0;
      var lowPrice = 1.2m;
      var highIndex = 2;
      var highPrice = 3.4m;
      var expected = new String("\n1(1.20),3(3.40)");

      var actual = Program.FormatResults(lowIndex, lowPrice, highIndex, highPrice);

      Assert.True(expected.Equals(actual), "Should return a correctly formatted result string");
    }


    [Fact]
    public void FormatResults_ReturnsFormattedLowAndHighResult_HighDayNotAvailable()
    {

      var lowIndex = 2;
      var lowPrice = 1.2m;
      var highIndex = 0;
      var highPrice = 0m;
      var expected = new String("\n3(1.20),N/A(0.00)");

      var actual = Program.FormatResults(lowIndex, lowPrice, highIndex, highPrice);

      Assert.True(expected.Equals(actual), "Should return a correctly formatted result string");
    }

    [Fact]
    public void ToggleContinue_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("ToggleContinue", new Type[]{typeof(ConsoleKey)});

      Assert.True(exists != null, "Class Program should have a method 'ToggleContinue' that takes a ConsoleKey as argument");

    }


    [Fact]
    public void ToggleContinue_AssignContinueOnEscapeKey()
    {
      var key = ConsoleKey.Escape;

      Program.ToggleContinue(key);
      
      Assert.True(Program.Continue == false, "Value of Continue should be set to: false");

    }

    [Fact]
    public void ToggleContinue_AssignContinueOnAnyKey()
    {
      var key = ConsoleKey.B;

      Program.ToggleContinue(key);

      Assert.True(Program.Continue == true, "Value of Continue should be set to: true");

    }
  }
}
