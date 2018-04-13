using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Illarion.Server
{
  internal sealed class Character : ICharacter
  {
    internal World World { get; }

    public Vector3 Location { get; set; }

    public Vector3 Velocity { get; set; }

    public Vector3 FacingDirection { get; set; }

    public ICharacterCallback Callback { get; internal set; }

    internal Character(World world)
    {
      World = world ?? throw new ArgumentNullException(nameof(world));
    }

    bool ICharacter.UpdateMovement(Vector3 location, Vector3 velocity, Vector3 facing)
    {
      Location = location;
      Velocity = velocity;
      FacingDirection = facing;

      return true;
    }
  }
}
