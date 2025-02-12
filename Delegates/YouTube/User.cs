namespace CSharpProject.Delegates.YouTube;

public class User
{
    private string _userName;

    public User(string userName)
    {
        _userName = userName;
    }

    public void SubscribeChannel(Channel channel)
    {
        channel.VideoUploaded += OnVideoUploaded;
        Console.WriteLine($"[訂閱通知] {_userName} 訂閱了頻道");
    }

    public void UnsubscribeChannel(Channel channel)
    {
        channel.VideoUploaded -= OnVideoUploaded;
        Console.WriteLine($"[取消訂閱] {_userName} 取消訂閱了頻道");
    }

    private void OnVideoUploaded(object? sender, VideoUploadedEventArgs e)
    {
        Console.WriteLine($"[收到通知] {_userName} 收到通知：{e.ChannelName} 上傳了新影片「{e.VideoTitle}」");
    }
}