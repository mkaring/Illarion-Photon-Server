using Illarion.Server.Persistence.Server;
using Microsoft.EntityFrameworkCore;

namespace Illarion.Server.Persistence
{
  public interface IServerContext : IIllarionContext
  {
    DbSet<Character> Characters { get; set; }
    DbSet<CharacterAttribute> CharacterAttributes { get; set; }
  }
}
