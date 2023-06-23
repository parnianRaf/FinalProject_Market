using System;
namespace FinalProject_Market.Cache;
public class MedalConfigs
{

}
public class RootObject
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public Logging Logging { get; set; }
    public Medal Medal { get; set; }
}

public class ConnectionStrings
{
    public string DefaultConnection { get; set; }
    public string UserLog { get; set; }
}

public class Logging
{
    public LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public string Default { get; set; }
    public string Microsoft_AspNetCore { get; set; }
}

public class Medal
{
    public double MedalPrice { get; set; }
    public double MedalDiscount { get; set; }
}

