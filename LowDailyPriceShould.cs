using System;
using Xunit;
using StockTrading;


namespace StockTradingTests
{
  public class LowDailyPriceShould
  {

    [Fact]
    public void FindLowest_Exists()
    {
      var lowDailyPrice = new LowDailyPrice();

      var objectType = lowDailyPrice.GetType();
      var exists = objectType.GetMethod("FindLowest");

      Assert.True(exists != null, "LowDailyPrice should have a method: FindLowest");

    }

    [Fact]
    public void FindLowest_AssignIndexOfLow()
    {
      var lowDailyPrice = new LowDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };

      lowDailyPrice.FindLowest(pricesArray);
      var indexOfLow = lowDailyPrice.IndexOfLow;

      Assert.True(indexOfLow == 1, "IndexOfLow should have value: 1");

    }

    [Fact]
    public void FindLowest_AssignLowest()
    {
      var lowDailyPrice = new LowDailyPrice();
      var pricesArray = new decimal[] { 1m, 0m, 2m };

      lowDailyPrice.FindLowest(pricesArray);
      var lowPrice = lowDailyPrice.LowPrice;

      Assert.True(lowPrice == 0m, "LowPrice should have value: 0m");

    }
  }
}
