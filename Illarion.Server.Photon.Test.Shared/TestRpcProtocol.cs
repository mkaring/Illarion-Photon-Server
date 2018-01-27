using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using Photon.SocketServer.Rpc;
using Photon.SocketServer.Rpc.Protocols;
using Photon.SocketServer.Rpc.Reflection;
using Photon.SocketServer.Security;
using PhotonHostRuntimeInterfaces;

namespace Illarion.Server.Photon
{
  public sealed class TestRpcProtocol : IRpcProtocol
  {
    ProtocolType IRpcProtocol.ProtocolType => throw new NotImplementedException();

    int IRpcProtocol.HeaderSize => throw new NotImplementedException();

    MessageContentType IRpcProtocol.MessageContentType => throw new NotImplementedException();

    void IRpcProtocol.Serialize(Stream stream, object obj, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeEventData(EventData eventData, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeEventDataEncrypted(IEventData eventData, ICryptoProvider cryptoProvider, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeInitRequest(string appName, Version version, ushort sdkId, bool usingIPv6) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeInitRequestV2(string appName, string serverAddress, Version version, object custom) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeInitResponse(object responseObject) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeInternalOperationRequest(OperationRequest operationRequest) =>
      throw new NotImplementedException();
    
    byte[] IRpcProtocol.SerializeInternalOperationResponse(OperationResponse operationResponse) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeMessage(object message, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeMessageEncrypted(object message, ICryptoProvider cryptoProvider, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeOperationRequest(OperationRequest operationRequest, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeOperationRequestEncrypted(OperationRequest operationRequest, ICryptoProvider cryptoProvider, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeOperationResponse(OperationResponse operationResponse, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeOperationResponseEncrypted(OperationResponse operationResponse, ICryptoProvider cryptoProvider, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeRawMessage(byte[] message, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    byte[] IRpcProtocol.SerializeRawMessageEncrypted(byte[] message, ICryptoProvider cryptoProvider, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryConvertParameter(ObjectMemberInfo<DataMemberAttribute> parameterInfo, ref object value) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParse(Stream stream, out object obj, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParse(byte[] data, int startIndex, int length, out object value, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseEncrypted(byte[] data, ICryptoProvider cryptoProvider, int startIndex, int length, out object value, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseEventData(byte[] data, out EventData eventData, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseEventDataEncrypted(byte[] data, ICryptoProvider cryptoProvider, out EventData eventData, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseMessageHeader(byte[] data, out RtsMessageHeader header) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseOperationRequest(byte[] data, out OperationRequest operationRequest, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseOperationRequestEncrypted(byte[] data, ICryptoProvider cryptoProvider, out OperationRequest operationRequest, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseOperationResponse(byte[] data, out OperationResponse operationResponse, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();

    bool IRpcProtocol.TryParseOperationResponseEncrypted(byte[] data, ICryptoProvider cryptoProvider, out OperationResponse operationResponse, CustomTypeCache privateCustomTypeCache) =>
      throw new NotImplementedException();
  }
}
