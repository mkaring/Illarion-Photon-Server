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
    [Required]
    public string CultureName { get; set; }

    internal CultureInfo Culture
    {
      get
      {
        if (string.IsNullOrWhiteSpace(CultureName))
          return CultureInfo.InvariantCulture;
        return CultureInfo.GetCultureInfo(CultureName) ?? CultureInfo.InvariantCulture;
      }
    }
  }
}
