using Core.Enums;

namespace Core.Models;

public sealed class AppSettings
{
    public BrowserTypes BrowserType { get; set; }
    public TimeSpan WaitTime { get; set; }
}
