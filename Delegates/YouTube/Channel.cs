namespace CSharpProject.Delegates.YouTube;

public class Channel
{
    private string _channelName;
    public event EventHandler<VideoUploadedEventArgs>? VideoUploaded;

    public Channel(string channelName)
    {
        _channelName = channelName;
    }

    public void UploadVideo(string videoTitle)
    {
        Console.WriteLine($"\n[頻道動態] {_channelName} 上傳了新影片！");
        OnVideoUploaded(new VideoUploadedEventArgs
        {
            ChannelName = _channelName,
            VideoTitle = videoTitle
        });
    }

    protected virtual void OnVideoUploaded(VideoUploadedEventArgs e)
    {
        VideoUploaded?.Invoke(this, e);
    }
}