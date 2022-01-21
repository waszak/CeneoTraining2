
using System;
using DocFlow.Domain.Users;

namespace DocFlow.Infrastructure.Repo
{

  public class FakeUserRepository : IUserRepository
  {
    public User Load(Guid userId)
    {
      return new User(userId);
    }
  }
}