namespace CSharpProject.Delegates.YouTube;

public class YouTubeNotificationDemo
{
    public static void Test()
    {
        // 創建一個 YouTube 頻道
        var channel = ChannelCreator.TryCreateChannel("程式設計教學");
        if (channel is null)
            return;

        // 創建幾個用戶
        var user1 = new User("小明");
        var user2 = new User("小華");
        var user3 = new User("小美");

        // 用戶訂閱頻道
        user1.SubscribeChannel(channel);
        user2.SubscribeChannel(channel);
        user3.SubscribeChannel(channel);

        // 頻道上傳新影片
        channel.UploadVideo("C# 事件教學 EP1");

        // 用戶2取消訂閱
        user2.UnsubscribeChannel(channel);

        // 再次上傳新影片
        channel.UploadVideo("C# 事件教學 EP2");
    }
}