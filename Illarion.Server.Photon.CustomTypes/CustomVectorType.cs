using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Illarion.Net.Common;

namespace Illarion.Server.Photon
{
  internal static class CustomVectorType
  {
    internal static Type CustomType => typeof(Vector3);
    internal static byte CustomTypeId => (byte) CustomTypeCode.Vector;

    internal static byte[] Serialize(object value)
    {
      if (value == null) throw new ArgumentNullException(nameof(value));
      var vector = (Vector3) value;

      var vectorArray = new float[3];
      vector.CopyTo(vectorArray);

      var result = new byte[12];
      Buffer.BlockCopy(vectorArray, 0, result, 0, 12);
      return result;
    }

    internal static object Deserialize(byte[] data)
    {
      if (data == null) throw new ArgumentNullException(nameof(data));
      if (data.Length != 12) throw new ArgumentException("Data is expected to have a length of 12 byte.", nameof(data));

      var result = new float[3];
      Buffer.BlockCopy(data, 0, result, 0, 12);
      return new Vector3(result[0], result[1], result[2]);
    }
  }
}
