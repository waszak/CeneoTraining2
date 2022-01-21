using DocFlow.Domain.Documents;
using DocFlow.Domain.Users;
using Xunit;
using System;

namespace DocFlow.Infrastructure.Repo
{
  public class DocumentSpec
  {
    private static DocumentType TYPE = DocumentType.PROCEDURE;
    private static User CREATOR = new User(Guid.NewGuid());
    private static User VERIFIER = new User(Guid.NewGuid());

    [Fact]
    public void Can_Not_Verify_By_Author()
    {
      // Arrange
      Document document = new Document(TYPE, CREATOR);

      // Act, Assert
      Assert.Throws<DocumentOpeartionException>(() => document.Verify(CREATOR));
    }

    [Fact]
    public void Should_Back_To_Verified_When_Changing_Title()
    {
      // Arrange
      //TODO zamienic na Assembler
      Document document = new Document(TYPE, CREATOR);
      document.ChangeTitle("title 1");
      document.Verify(VERIFIER);
      //when
      document.ChangeTitle("title 2");
      // Act
      //TODO zamienic na AssertObject
      Assert.Equal(DocumentStatus.DRAFT, document.Status);
    }

    [Fact]
    public void Should_Publish_Verified()
    {
      // Arrange
      //TODO zamienic na Assembler
      Document document = new Document(TYPE, CREATOR);
      document.Verify(VERIFIER);
      //when
      document.Publish();
      // Act
      //TODO zamienic na AssertObject
      Assert.Equal(DocumentStatus.PUBLISHED, document.Status);
    }
  }
}