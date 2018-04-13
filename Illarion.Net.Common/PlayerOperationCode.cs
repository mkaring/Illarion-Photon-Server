namespace Illarion.Net.Common
{
  /// <summary>
  /// These are the operation codes that can be used to control the game and actually play the character.
  /// </summary>
  public enum PlayerOperationCode : byte
  {
    /// <summary>
    /// This should be used by the client to report that it is done loading the current map. Upon sending it the server
    /// will spawn the character on the map and report back once it is done.
    /// </summary>
    LoadingReady = 0,

    /// <summary>
    /// Exit the game and return to the logged in account operation code. Removes the player from the current game.
    /// Once this is successful the <see cref="AccountOperationCode"/> is active.
    /// </summary>
    LogoutPlayer,

    /// <summary>
    ///   Update the location, looking direction and velocity of the character. This should be send very often.
    ///   It may be send as message since the server is not reponding with the meaningful message anyway.
    /// </summary>
    /// <seealso cref="Operations.Player.UpdateLocationReturnCode"/>
    /// <seealso cref="Operations.Player.UpdateLocationOperationRequestParameterCode"/>
    /// <seealso cref="Operations.Player.UpdateLocationOperationReponseParameterCode"/>
    UpdateLocation,

    /// <summary>
    /// This operation is actively send by the server and it contains location updates for every character presently
    /// monitored by the client receiving.
    /// It is possible to for the client to send this command in order to issue the server to send a update right now.
    /// </summary>
    /// <seealso cref="Operations.Player.UpdateAllLocationReturnCode"/>
    /// <seealso cref="Operations.Player.UpdateAllLocationsOperationReponseParameterCode"/>
    UpdateAllLocations,

    /// <summary>
    /// This command is send by the server to report the current appearance of a specific character to the client.
    /// </summary>
    UpdateAppearance,

    /// <summary>
    ///   <para>
    ///     This command should be send by the player in order to send a message to the server and to other players.
    ///   </para>
    ///   <para>
    ///     The server is sending this command in order to inform the player about any messages spoken including it's
    ///     own.
    ///   </para>
    /// </summary>
    SendMessage,
  }
}
