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

      Assert.True(exists != null, "Class Program should have a method: GetPrices");

    }


    [Fact]
    public void GetPrices_ReturnsFormattedLowAndHighResult()
    {
      var str = "1.2,3.4, 5.6";
      var expected = "1(1.20),3(5.60)";

      var actual = Program.GetPrices(str);

      Assert.True(expected.Equals(actual), "This method should return a correctly formatted string with two days and prices");

    }


    [Fact]
    public void GetPrices_ReturnsIncorrectDataStatus()
    {
      var str = "a,bc";
      var expected = "\nIncorrect data format.";

      var actual = Program.GetPrices(str);

      Assert.True(expected.Equals(actual), "This method should return a correctly formatted warning");

    }


    [Fact]
    public void ConvertToDecimal_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("ConvertToDecimal", new Type[] { typeof(string) });

      Assert.True(exists != null, "Class Program should have a method: ConvertToDecimal");

    }

    [Fact]
    public void ConvertToDecimal_StringToArray()
    {
      string str = "1.2,3.4, 5.6";
      var expected = new decimal[] { 1.2m,3.4m,5.6m };

      var actual = Program.ConvertToDecimal(str);

      Assert.Equal(expected, actual);
      
    }


    [Fact]
    public void FormatResults_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("FormatResults", new Type[] { typeof(LowDailyPrice), typeof(HighDailyPrice) });

      Assert.True(exists != null, "Class Program should have a method: FormatResults");

    }

  

    [Fact]
    public void ToggleContinue_Exists()
    {
      var program = new Program();

      var objectType = program.GetType();
      var exists = objectType.GetMethod("ToggleContinue", new Type[]{typeof(ConsoleKey)});

      Assert.True(exists != null, "Class Program should have a method: ToggleContinue");

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
