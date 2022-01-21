using DocFlow.Domain.Documents;
using Xunit;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentAssert
  {

    private Document document;

    public DocumentAssert(Document document)
    {
      this.document = document;
    }

    public DocumentAssert IsPublished()
    {
      Assert.Equal(DocumentStatus.PUBLISHED, document.Status);
      Assert.NotNull(document.Title);
      Assert.NotNull(document.Author);
      //...

      return this;
    }
  }
}