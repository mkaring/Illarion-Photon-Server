using System;
using Illarion.Server.Setup.Properties;
using Microsoft.Extensions.CommandLineUtils;

namespace Illarion.Server.Setup
{
  internal class Program
  {
    internal static void Main(params string[] args)
    {
      var app = new CommandLineApplication
      {
        Name = "dotnet Illarion.Server.Setup.dll",
        Description = Resources.ApplicationDescription
      };
      app.HelpOption("-?|-h|--help");
      app.VersionOption("--version", Resources.ApplicationName, Resources.ApplicationName + " 1.0.0");

      app.Command("migrate", MigrateDatabase.Configure);

      app.Execute(args);
    }
  }
}
