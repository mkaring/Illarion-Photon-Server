using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class SetCultureOperation : Operation
  {
    internal SetCultureOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(CultureName), Code = (byte)SetCultureOperationParameterCode.CultureName)]
    [Required, MinLength(1)]
    public string CultureName { get; set; }

    internal CultureInfo Culture
    {
      get
      {
        if (string.IsNullOrWhiteSpace(CultureName))
          return CultureInfo.InvariantCulture;

        try
        {
          var foundCulture = CultureInfo.GetCultureInfo(CultureName);
          if (foundCulture == null || foundCulture.UseUserOverride)
            return CultureInfo.InvariantCulture;

          return foundCulture;
        }
        catch
        {
          return CultureInfo.InvariantCulture;
        }
      }
    }
  }
}
