using Xunit;
using StockTrading;


namespace StockTradingTests
{
  public class LowDailyPriceShould
  {
    [Fact]
    public void FindLowest_AssignIndexOfLow()
    {
      var lowDailyPrice = new LowDailyPrice();
      var pricesArray = new decimal[] { 15.45m, 24.56m, 12.4m, 32 };


      lowDailyPrice.FindLowest(pricesArray);
      var indexOfLow = lowDailyPrice.IndexOfLow;

      Assert.True(indexOfLow == 2, "IndexOfLow should have value 2");

    }

    [Fact]
    public void FindLowest_AssignLowest()
    {
      var lowDailyPrice = new LowDailyPrice();
      var pricesArray = new decimal[] { 15.45m, 24.56m, 12.4m, 32 };


      lowDailyPrice.FindLowest(pricesArray);
      var lowPrice = lowDailyPrice.LowPrice;

      Assert.True(lowPrice == 12.4m, "LowPrice should have value 12.4m.");

    }
  }
}
