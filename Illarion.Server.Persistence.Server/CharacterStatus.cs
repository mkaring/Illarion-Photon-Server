using System.Diagnostics.CodeAnalysis;

namespace Illarion.Server.Persistence.Server
{
  [SuppressMessage("Microsoft.Naming", "CA1717:OnlyFlagsEnumsShouldHavePluralNames", Justification = "Status is not a plural.")]
  public enum CharacterStatus
  {
    Default = 0,
    Blocked = 1
  }
}
