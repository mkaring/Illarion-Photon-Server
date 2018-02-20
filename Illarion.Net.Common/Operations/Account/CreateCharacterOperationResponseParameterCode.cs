namespace Illarion.Net.Common.Operations.Account
{
  public enum CreateCharacterOperationResponseParameterCode : byte
  {
    /// <summary>
    /// The list of fields that were invalid during the attempt of character creation.
    /// Encoded as <see cref="System.Collections.Generic.List{byte}"/>.
    /// </summary>
    /// <remarks>
    /// The IDs that may be present in this list are the request parameter codes. In case the character creation is
    /// successful this field contains an empty list.
    /// </remarks>
    /// <seealso cref="CreateCharacterOperationRequestParameterCode"/>
    InvalidFields,

    /// <summary>
    /// A list of error messages. The index of each message matches the field index in the <see cref="InvalidFields"/>
    /// parameter. Encoded as <see cref="System.Collections.Generic.List{string}"/>.
    /// </summary>
    /// <remarks>The length of the list matches the length of the list in <see cref="InvalidFields"/>.</remarks>
    InvalidParamterMessages,

    /// <summary>
    /// The ID of the character that was created. This field is only present in case the creation of the character
    /// was successful. Encoded as <see cref="string"/>.
    /// </summary>
    CharacterId
  }
}
