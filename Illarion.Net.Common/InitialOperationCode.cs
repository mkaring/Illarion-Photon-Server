namespace Illarion.Net.Common
{
  public enum InitialOperationCode : byte
  {
    /// <summary>Set the culture of the messages for this connection.</summary>
    /// <seealso cref="Operations.Initial.SetCultureOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Initial.SetCultureOperationReturnCode"/>
    SetCulture = 0,

    /// <summary>Login to a specific account on the server.</summary>
    /// <remarks>This command has to be send encrypted.</remarks>
    /// <seealso cref="Operations.Initial.LoginAccountOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Initial.LoginAccountOperationReturnCode"/>
    LoginAccount,

    /// <summary>Register a new account for the game.</summary>
    /// <remarks>This command has to be send encrypted.</remarks>
    /// <seealso cref="Operations.Initial.RegisterNewAccountOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Initial.RegisterNewAccountOperationReturnCode"/>
    RegisterNewAccount
  }
}
