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


    private readonly ICostCalculationFactory _costCalculation;
    private readonly IDocumentFactory _documentFactory;

    public FlowProcess(IConfigurationData configuration,
        ICostCalculationFactory costCalculationFactory,
        IDocumentFactory documentFactory)
    {
      _configuration = configuration;

      _costCalculation = costCalculationFactory;
      _documentFactory = documentFactory;
    }

    public DocumentNumber CreateDocument(Guid creatorId, DocumentType type, string title)
    {
      User creator = userRepo.Load(creatorId);

      var document = _documentFactory.Create(type, creator);
     
      document.ChangeTitle(title);

      documentRepo.Save(document);
      return document.Number;
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
        return _costCalculation.Create();
    }
  }
}