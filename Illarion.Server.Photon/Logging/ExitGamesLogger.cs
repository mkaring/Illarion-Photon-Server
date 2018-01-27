using System;
using Microsoft.Extensions.Logging;

namespace Illarion.Server.Photon.Logging
{
  internal sealed class ExitGamesLogger : ExitGames.Logging.ILogger
  {
    private readonly string _category;
    private readonly ILogger _logger;

    bool ExitGames.Logging.ILogger.IsDebugEnabled => _logger.IsEnabled(LogLevel.Debug);

    bool ExitGames.Logging.ILogger.IsErrorEnabled => _logger.IsEnabled(LogLevel.Error);

    bool ExitGames.Logging.ILogger.IsFatalEnabled => _logger.IsEnabled(LogLevel.Critical);

    bool ExitGames.Logging.ILogger.IsInfoEnabled => _logger.IsEnabled(LogLevel.Information);

    bool ExitGames.Logging.ILogger.IsWarnEnabled => _logger.IsEnabled(LogLevel.Warning);

    string ExitGames.Logging.ILogger.Name => _category;

    internal ExitGamesLogger(string category, ILogger logger)
    {
      _category = category;
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    void ExitGames.Logging.ILogger.Debug(object message) => _logger.LogDebug(message?.ToString());

    void ExitGames.Logging.ILogger.Debug(object message, Exception exception) => _logger.LogDebug(exception, message?.ToString());

    void ExitGames.Logging.ILogger.DebugFormat(string format, params object[] args) => _logger.LogDebug(format, args);

    void ExitGames.Logging.ILogger.DebugFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogDebug(string.Format(provider, format, args));

    void ExitGames.Logging.ILogger.Error(object message) => _logger.LogError(message?.ToString());

    void ExitGames.Logging.ILogger.Error(object message, Exception exception) => _logger.LogError(exception, message?.ToString());

    void ExitGames.Logging.ILogger.ErrorFormat(string format, params object[] args) => _logger.LogError(format, args);

    void ExitGames.Logging.ILogger.ErrorFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogError(string.Format(provider, format, args));

    void ExitGames.Logging.ILogger.Fatal(object message) => _logger.LogCritical(message?.ToString());

    void ExitGames.Logging.ILogger.Fatal(object message, Exception exception) => _logger.LogCritical(exception, message?.ToString());

    void ExitGames.Logging.ILogger.FatalFormat(string format, params object[] args) => _logger.LogCritical(format, args);

    void ExitGames.Logging.ILogger.FatalFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogCritical(string.Format(provider, format, args));

    void ExitGames.Logging.ILogger.Info(object message) => _logger.LogInformation(message?.ToString());

    void ExitGames.Logging.ILogger.Info(object message, Exception exception) => _logger.LogInformation(exception, message?.ToString());

    void ExitGames.Logging.ILogger.InfoFormat(string format, params object[] args) => _logger.LogInformation(format, args);

    void ExitGames.Logging.ILogger.InfoFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogInformation(string.Format(provider, format, args));

    void ExitGames.Logging.ILogger.Warn(object message) => _logger.LogWarning(message?.ToString());

    void ExitGames.Logging.ILogger.Warn(object message, Exception exception) => _logger.LogWarning(exception, message?.ToString());

    void ExitGames.Logging.ILogger.WarnFormat(string format, params object[] args) => _logger.LogWarning(format, args);

    void ExitGames.Logging.ILogger.WarnFormat(IFormatProvider provider, string format, params object[] args) => _logger.LogWarning(string.Format(provider, format, args));
  }
}
