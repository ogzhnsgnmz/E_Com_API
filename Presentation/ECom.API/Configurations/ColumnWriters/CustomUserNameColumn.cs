using Serilog.Core;

namespace ECom.API.Configurations.ColumnWriters;

public class CustomUserNameColumn : ILogEventEnricher
{
    public void Enrich(Serilog.Events.LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var (username, value) = logEvent.Properties.FirstOrDefault(x => x.Key == "UserName");
        if (value != null)
        {
            var getValue = propertyFactory.CreateProperty(username, value);
            logEvent.AddPropertyIfAbsent(getValue);
        }
    }
}
