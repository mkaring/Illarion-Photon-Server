using System;

namespace Illarion.Server.Persistence.Accounts
{
  public class Account
  {
    public Account()
    {
    }

    public Account(string accountName) => AccountName = accountName;

    public Guid AccountId { get; private set; }
    public string AccountName { get; private set; }
    public string Password { get; set; }
    public string EMail { get; set; }
    public string Status { get; set; }
    public DateTime LastSeen { get; set; }
    public DateTime Registered { get; private set; }
  }
}