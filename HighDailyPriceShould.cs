using System;
using Xunit;
using StockTrading;


namespace StockTradingTests
{
  public class HighDailyPriceShould
  {

    [Fact]
    public void FindHighest_Exists()
    {
      var highDailyPrice = new HighDailyPrice();

      var objectType = highDailyPrice.GetType();
      var exists = objectType.GetMethod("FindHighest",new Type[] { typeof(decimal[]), typeof(int)});

      Assert.True(exists != null, "HighDailyPrice should have a method: FindHighest.");

    }

    [Fact]
    public void FindHighest_AssignIndexOfHigh()
    {
      var highDailyPrice = new HighDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };
      var indexOfLow = 0;

      highDailyPrice.FindHighest(pricesArray, indexOfLow);
      var indexOfHigh = highDailyPrice.IndexOfHigh;

      Assert.True(indexOfHigh == 2, "IndexOfHigh should have value: 2");

    }

    [Fact]
    public void FindHighest_AssignIndexOfHigh_LowOnLastDay()
    {
      var highDailyPrice = new HighDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };
      var indexOfLow = 2;

      highDailyPrice.FindHighest(pricesArray, indexOfLow);
      var indexOfHigh = highDailyPrice.IndexOfHigh;

      Assert.True(indexOfHigh == null, "IndexOfHigh should have value: null");

    }

    [Fact]
    public void FindHighest_AssignHighest()
    {
      var highDailyPrice = new HighDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };
      var indexOfLow = 0;

      highDailyPrice.FindHighest(pricesArray, indexOfLow);
      var highPrice = highDailyPrice.HighPrice;

      Assert.True(highPrice == 2m, "LowPrice should have value: 2m");

    }

    [Fact]
    public void FindHighest_AssignHighest_LowOnLastDay()
    {
      var highDailyPrice = new HighDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };
      var indexOfLow = 2;

      highDailyPrice.FindHighest(pricesArray, indexOfLow);
      var highPrice = highDailyPrice.HighPrice;

      Assert.True(highPrice == 0, "LowPrice should have value: 0");

    }
  }
}
