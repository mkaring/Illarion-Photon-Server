using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illarion.Server
{
  public interface IWorldManager
  {
    IWorld GetWorld(int index);
  }
}
