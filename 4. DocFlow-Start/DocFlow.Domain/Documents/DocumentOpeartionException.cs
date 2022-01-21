using System;

namespace DocFlow.Domain.Documents
{
  public class DocumentOpeartionException : InvalidOperationException
  {

    public DocumentNumber Number { get; private set; }

    public DocumentOpeartionException(DocumentNumber number, string message) : base(message)
    {
      Number = number;
    }    
  }
}