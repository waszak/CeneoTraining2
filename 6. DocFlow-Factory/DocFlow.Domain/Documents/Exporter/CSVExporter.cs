using System;
using System.IO;

namespace DocFlow.Domain.Documents
{
  class CSVExporter : IExporter
  {
    private DocumentNumber _number;

    public void Build(DocumentNumber number)
    {
      _number = number;
    }

    public void Build(DocumentStatus status)
    {
      throw new NotImplementedException();
    }

    public void Build(string title)
    {
      throw new NotImplementedException();
    }

    public Stream GetResult()
    {
      MemoryStream s = new MemoryStream();
      using (StreamWriter sw = new StreamWriter(s))
      {
        sw.Write(_number);
        sw.Write(";");        
      }

      return s;
    }
  }
}