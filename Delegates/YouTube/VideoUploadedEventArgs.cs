namespace CSharpProject.Delegates.YouTube;

public class VideoUploadedEventArgs : EventArgs
{
    public string? ChannelName { get; set; }
    public string? VideoTitle { get; set; }
}