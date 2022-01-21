using DocFlow.Domain.Documents;
using System;
using System.Collections.Generic;

namespace DocFlow.Infrastructure.Repo
{
  public class FakeDocumentRepository : IDocumentRepository
  {
    private static IDictionary<DocumentNumber, Document> fakeDatabase = new Dictionary<DocumentNumber, Document>();

    public void Save(Document document)
    {
      fakeDatabase[document.Number] = document;
    }

    public Document Load(DocumentNumber number)
    {
      return fakeDatabase[number];
    }

    public Document Load(Guid id)
    {
      // TODO Auto-generated method stub
      return null;
    }
  }
}