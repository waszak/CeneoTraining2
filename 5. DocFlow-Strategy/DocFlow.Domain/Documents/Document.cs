using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Shared;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents
{
  public class Document
  {
    public DocumentNumber Number { get; private set; }

    public DocumentStatus Status { get; private set; }

    public DocumentType Type { get; private set; }

    public User Author { get; private set; }

    public string Title { get; private set; }

    public DateTime CreateDate { get; private set; }

    public DateTime? ExpiryDate { get; private set; }

    public Money PrintingCost { get; private set; }

    public string Body { get; private set; }
    public decimal PageCount { get; private set; }

    public Document(DocumentType type, User author, DocumentNumber number)
    {
      Type = type;
      Author = author;

      //TODO przenieść logikę do fabryki, ukryć konstruktor
      Status = DocumentStatus.DRAFT;
      CreateDate = new DateTime();
      Number = number;
    }

    public void ChangeTitle(string newTitle)
    {
      if (newTitle == Title)
      {
        return;
      }
      if (Status == DocumentStatus.PUBLISHED || Status == DocumentStatus.ARCHIVED)
      {
        throw new DocumentOpeartionException(Number, "Can not change title if status is: " + Status);
      }
      Title = newTitle;
      Status = DocumentStatus.DRAFT;
    }

    //===== Flow ======

    public void Verify(User verifier)
    {
      if (Status != DocumentStatus.DRAFT)
      {
        throw new DocumentOpeartionException(Number, "Can not verify if status is: " + Status);
      }
      if (verifier.Equals(Author))
      {
        throw new DocumentOpeartionException(Number, "Can not verify by author");
      }

      Status = DocumentStatus.VERIFIED;
    }

    public void Publish(ICostCalculator costCalculator)
    {
      if (Status != DocumentStatus.VERIFIED)
      {
        throw new DocumentOpeartionException(Number, "Can not publish if status is: " + Status);
      }
      Status = DocumentStatus.PUBLISHED;

      PrintingCost = costCalculator.Calculate();

      //TODO pozbyć się singletona!
      //EventsEngine.getInstance().publish(new DocumentPublishedEvent(number));
    }

    public void Archive()
    {
      Status = DocumentStatus.ARCHIVED;
    }
  }
}