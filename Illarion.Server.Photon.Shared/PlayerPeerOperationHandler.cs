using System;
using Illarion.Net.Common.Operations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;

namespace Illarion.Server.Photon
{
  public abstract class PlayerPeerOperationHandler : IOperationHandler
  {
    private readonly ILogger _logger;

    protected PlayerPeerOperationHandler(IServiceProvider serviceProvider) =>
      _logger = serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(PlayerPeerOperationHandler));

    public virtual void OnDisconnect(PeerBase peer)
    {
      if (peer == null) OnDisconnect(null);

      var connectedUser = peer as PlayerPeerBase;
      if (connectedUser == null) throw new ArgumentException("Unexpected type of peer.", nameof(peer));

      OnDisconnect(connectedUser);
    }

    public OperationResponse OnOperationRequest(PeerBase peer, OperationRequest operationRequest, SendParameters sendParameters)
    {
      if (peer == null) return OnOperationRequest(null, operationRequest, sendParameters);

      var connectedUser = peer as PlayerPeerBase;
      if (connectedUser == null) throw new ArgumentException("Unexpected type of peer.", nameof(peer));

      try
      {
        return OnOperationRequest(connectedUser, operationRequest, sendParameters);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error while processing operation request.");
        return InternalErrorResponse(operationRequest, ex);
      }
    }

    protected abstract void OnDisconnect(PlayerPeerBase peer);
    protected abstract OperationResponse OnOperationRequest(PlayerPeerBase peer, OperationRequest operationRequest, SendParameters sendParameters);

    protected static OperationResponse InvalidOperation(OperationRequest operationRequest) =>
      new OperationResponse(operationRequest.OperationCode)
      {
        ReturnCode = (int)ReturnCode.InvalidOperation,
        DebugMessage = "InvalidOperation: " + operationRequest.OperationCode
      };

    protected static OperationResponse InternalErrorResponse(OperationRequest operationRequest, Exception exception) =>
      new OperationResponse(operationRequest.OperationCode)
      {
        ReturnCode = (int)ReturnCode.InternalServerError,
        DebugMessage = exception.Message
      };

    protected static OperationResponse MalformedRequestResponse(OperationRequest operationRequest, Operation operation) =>
      new OperationResponse(operationRequest.OperationCode)
      {
        ReturnCode = (int)ReturnCode.MalformedRequest,
        DebugMessage = operation.GetErrorMessage()
      };
  }
}
