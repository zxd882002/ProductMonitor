namespace ProductMonitorControlLibrary.Models;

public class PageNavigateEvent: PubSubEvent<string>
{
    public string PageNavigateName { get; set; }
}