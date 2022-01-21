namespace DocFlow.Domain.Users.Roles
{
  public abstract class BaseUserRole : IUserRole
  {
    public string Name { get; private set; }

    public BaseUserRole(string name)
    {
      Name = name;
    }
  }
}