using System;

namespace DocFlow.Domain.Shared
{
  [Serializable]
  public class Money
  {
    public static readonly Currency DEFAULT_CURRENCY = new Currency("EUR");
    public static readonly Money Zero = new Money(Decimal.Zero);

    private Decimal _denomination;

    public string CurrencyCode { get; private set; }

    protected Money()
    {
    }

    public Money(Decimal denomination, Currency currency) :  this(denomination, currency.CurrencyCode)
    {     
    }

    private Money(Decimal denomination, string currencyCode)
    {
      _denomination = denomination;
      CurrencyCode = currencyCode;
    }

    public Money(Decimal denomination) : this(denomination, DEFAULT_CURRENCY)
    {
      
    }

    public Money(double denomination, Currency currency)
      : this(new Decimal(denomination), currency.CurrencyCode)
    {
    }

    public Money(double denomination, string currencyCode)
      : this(new Decimal(denomination), currencyCode)
    {      
    }

    public Money(double denomination)
      : this(denomination, DEFAULT_CURRENCY)
    {      
    }

    public Money MultiplyBy(double multiplier)
    {
      return MultiplyBy(new Decimal(multiplier));
    }

    public Money MultiplyBy(Decimal multiplier)
    {
      return new Money(_denomination * multiplier, CurrencyCode);
    }

    public Money Add(Money money)
    {
      if (!CompatibleCurrency(money))
      {
        throw new ArgumentException("Currency mismatch");
      }

      return new Money(_denomination + money._denomination, DetermineCurrencyCode(money));
    }

    public Money Subtract(Money money)
    {
      if (!CompatibleCurrency(money))
        throw new ArgumentException("Currency mismatch");

      return new Money(_denomination - money._denomination, DetermineCurrencyCode(money));
    }

    /**
     * Currency is compatible if the same or either money object has zero value.
     */

    private bool CompatibleCurrency(Money money)
    {
      return IsZero(_denomination) || IsZero(money._denomination) || CurrencyCode.Equals(money.CurrencyCode);
    }

    private bool IsZero(Decimal testedValue)
    {
      return Decimal.Zero.CompareTo(testedValue) == 0;
    }

    /**
     * @return currency from this object or otherCurrencyCode. Preferred is the
     *         one that comes from Money that has non-zero value.
     */

    private Currency DetermineCurrencyCode(Money otherMoney)
    {
      string resultingCurrenctCode = IsZero(_denomination) ? otherMoney.CurrencyCode : CurrencyCode;
      return new Currency(resultingCurrenctCode);
    }

    public Currency GetCurrency()
    {
      return new Currency(CurrencyCode);
    }

    public bool GreaterThan(Money other)
    {
      return _denomination.CompareTo(other._denomination) > 0;
    }

    public bool LessThan(Money other)
    {
      return _denomination.CompareTo(other._denomination) < 0;
    }

    public bool LessOrEquals(Money other)
    {
      return _denomination.CompareTo(other._denomination) <= 0;
    }

    public override string ToString()
    {
      return string.Format("{0} {1}", Math.Round(_denomination,2,MidpointRounding.ToEven), CurrencyCode);
    }

    protected bool Equals(Money other)
    {
      return _denomination == other._denomination && string.Equals(CurrencyCode, other.CurrencyCode);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Money)obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (_denomination.GetHashCode() * 397) ^ (CurrencyCode != null ? CurrencyCode.GetHashCode() : 0);
      }
    }


  }
}
