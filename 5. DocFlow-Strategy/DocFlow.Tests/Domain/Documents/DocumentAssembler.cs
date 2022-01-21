using System;
using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Users;
using Moq;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentAssembler
  {
    private DocumentType type = DocumentType.PROCEDURE;
    private User author = new User(Guid.NewGuid());
    private DocumentStatus _status;
    private Mock<ICostCalculator> _costCalculatorMock = new Mock<ICostCalculator>();

    public Document Build()
    {
      if (_status == DocumentStatus.PUBLISHED)
      {
        var result = new Document(type, author, new DocumentNumber("1"));
        result.Verify(new User(Guid.NewGuid()));
        result.Publish(_costCalculatorMock.Object);
        return result;
      }

      throw new NotSupportedException();
    }

    public DocumentAssembler Published()
    {
      _status = DocumentStatus.PUBLISHED;
      return this;
    }

    public DocumentAssembler Verified()
    {
      _status = DocumentStatus.VERIFIED;
      return this;
    }
  }
}