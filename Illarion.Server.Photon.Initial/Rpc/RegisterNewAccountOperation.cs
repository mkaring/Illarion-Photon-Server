using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Illarion.Net.Common.Operations.Initial;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon.Rpc
{
  internal sealed class RegisterNewAccountOperation : Operation
  {
    internal RegisterNewAccountOperation(IRpcProtocol protocol, OperationRequest request) : base(protocol, request)
    {
    }

    [DataMember(Name = nameof(AccountName), Code = (byte)RegisterNewAccountOperationParameterCode.AccountName)]
    [Required, StringLength(16, MinimumLength = 4)]
    public string AccountName { get; set; }

    [DataMember(Name = nameof(EMail), Code = (byte)RegisterNewAccountOperationParameterCode.EMail)]
    [EmailAddress, Required]
    public string RawEMail { get; set; }

    internal MailAddress EMail => new MailAddress(RawEMail);

    [DataMember(Name = nameof(Password), Code = (byte)RegisterNewAccountOperationParameterCode.Password)]
    [Required, StringLength(40, MinimumLength = 8)]
    public string Password { get; set; }
  }
}
