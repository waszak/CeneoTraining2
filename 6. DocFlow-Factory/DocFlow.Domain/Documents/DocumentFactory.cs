using DocFlow.Domain.Documents.Configuration;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;
using System;

namespace DocFlow.Domain.Documents
{
  public class DocumentFactory : IDocumentFactory
  {
    INumberGeneratorFactory _numberGeneratorFactory;

    public DocumentFactory(INumberGeneratorFactory numberGeneratorFactory)
    {
      _numberGeneratorFactory = numberGeneratorFactory;
    }

    public Document Create(DocumentType type, User author)
    {
      INumberGenerator generator = _numberGeneratorFactory.Create();
      var number = generator.Generate();
      return new Document(type, author, number, DocumentStatus.DRAFT, DateTime.Now);
    }
  }

  public interface IConigurationData
  {
    IConfigurationData GetConfiguration();
  }
}