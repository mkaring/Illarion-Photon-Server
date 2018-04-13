using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Illarion.Net.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Photon.SocketServer;

namespace Illarion.Server.Photon
{
  public static class CustomTypeRegistry
  {
    public static void RegisterCustomTypes(IServiceProvider services)
    {
      ILogger log = services.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(CustomTypeRegistry));

      if (!Protocol.TryRegisterCustomType(CustomVectorType.CustomType, CustomVectorType.CustomTypeId, CustomVectorType.Serialize, CustomVectorType.Deserialize))
      {
        log.LogError("Failed to register custom type: {0} (ID: {1:d})", CustomVectorType.CustomType.Name, CustomVectorType.CustomTypeId);
      }
    }
  }
}
