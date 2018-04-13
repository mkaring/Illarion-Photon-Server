using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Illarion.Net.Common
{
  public enum CustomTypeCode : byte
  {
    /// <summary>This type is encoded as a three dimensional vector.</summary>
    /// <remarks>Encoded with three <see cref="float"/> values. The values are used in the vector in order.</remarks>
    Vector = 0
  }
}
