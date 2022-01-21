using DocFlow.Domain.Documents;
using DocFlow.Domain.Documents.Cost;
using DocFlow.Domain.Documents.Numbers;
using DocFlow.Domain.Users;
using DocFlow.Infrastructure.Repo;
using System;
using DocFlow.Domain.Documents.Configuration;

namespace DocFlow.Application.Services
{
  public class FlowProcess
  {
    private readonly IConfigurationData _configuration;
    private IDocumentRepository documentRepo = new FakeDocumentRepository();

    private IUserRepository userRepo = new FakeUserRepository();

    public FlowProcess(IConfigurationData configuration)
    {
      _configuration = configuration;
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Load(creatorId);

      Document document = new Document(type, creator,CreateNumber()); //TODO factory
      document.ChangeTitle(title);

      documentRepo.Save(document);
      return document.Number;
    }

    private DocumentNumber CreateNumber()
    {
      if (_configuration.QualitySystem == QualitySystemType.QEP)
      {
        return new QepNumberGenerator().Generate();
      }
      if (_configuration.QualitySystem == QualitySystemType.ISO)
      {
        return new IsoNumberGenerator().Generate();
      }
      throw new InvalidOperationException();
    }

    public void VerifyDocument(Guid verifierId, DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);
      User verifier = userRepo.Load(verifierId);

      document.Verify(verifier);

      documentRepo.Save(document);
    }

    public void PublishDocument(DocumentNumber documentNumber)
    {
      Document document = documentRepo.Load(documentNumber);

      document.Publish(CreateCostCalculator()); //TODO walidacja i liczenie cen

      documentRepo.Save(document);

      //print
      //notify
      //...
    }

    private ICostCalculator CreateCostCalculator()
    {
      if (_configuration.ColorPrintingEnabled) 
      {
        return new ColorCalculator();
      }
      else
      {
        return new BwCostCalulator();
      }
    }
  }
}