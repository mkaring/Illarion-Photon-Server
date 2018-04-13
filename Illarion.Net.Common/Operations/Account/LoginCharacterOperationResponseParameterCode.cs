namespace Illarion.Net.Common.Operations.Account
{
  public enum LoginCharacterOperationResponseParameterCode : byte
  {
    /// <summary>The ID of the map where the character spawns on. Encoded as <see cref="int"/>.</summary>
    SpawnMap = 0,
    SpawnLocation,
    SpawnDirection,
  }
}
