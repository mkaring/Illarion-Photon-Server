namespace Illarion.Server
{
  public enum MapChatChannelType
  {
    /// <summary>The global chat channel is the one that can be heared on the entire map.</summary>
    Global,

    /// <summary>The "speaking" channel is the one sending the chat to all characters nearby.</summary>
    Speaking,

    /// <summary>The "yelling" channel is the one sending the chat to characters in a great range.</summary>
    Yelling,

    /// <summary>The "whispering" channel sends the text to characters very close by.</summary>
    Whispering
  }
}
