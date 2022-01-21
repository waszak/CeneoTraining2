namespace DocFlow.Domain.Documents
{
  public class DocumentNumber
  {
    public string Number { get; private set; }

    public DocumentNumber(string number)
    {
      Number = number;
    }

    public override string ToString()
    {
      return Number;
    }
  }
}
