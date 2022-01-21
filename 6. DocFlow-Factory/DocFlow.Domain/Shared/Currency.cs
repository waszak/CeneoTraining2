namespace DocFlow.Domain.Shared
{
  public class Currency
  {
    public Currency(string currencyCode)
    {
      CurrencyCode = currencyCode;
    }

    public string CurrencyCode { get; private set; }

  }
}