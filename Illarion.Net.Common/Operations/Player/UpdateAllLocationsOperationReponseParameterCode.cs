namespace Illarion.Net.Common.Operations.Player
{
  public enum UpdateAllLocationsOperationReponseParameterCode : byte
  {
    /// <summary>
    /// The list of all locations. Encoded as <see cref="PlayerOperationCode.UpdateLocation"/> responses.
    /// </summary>
    Locations = 0
  }
}
