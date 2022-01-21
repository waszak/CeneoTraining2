using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocFlow.Domain.Users.Roles
{
  public class Auditor : BaseUserRole
  {
    public Auditor(string name)
      : base(name)
    {
    }
  }
}