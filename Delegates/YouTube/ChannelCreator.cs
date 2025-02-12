namespace CSharpProject.Delegates.YouTube;

public class ChannelCreator
{
    private class Result
    {
        public bool IsSuccess { get; private set; }
        public string? ErrorMessage { get; private set; }
        private Channel? _channel;

        public Channel Channel => IsSuccess
            ? _channel!
            : throw new InvalidOperationException("Cannot access Channel when Result is not successful");

        private Result() { }

        public static Result Success(Channel channel) =>
            new Result { IsSuccess = true, _channel = channel };

        public static Result Failure(string error) =>
            new Result { IsSuccess = false, ErrorMessage = error };
    }

    public static Channel? TryCreateChannel(string channelName)
    {
        var channelCreator = new ChannelCreator();
        var result = channelCreator.CreateChannelResult(channelName);

        if (result.IsSuccess)
        {
            return result.Channel;
        }

        Console.WriteLine($"頻道創建失敗: {result.ErrorMessage}");
        return null;
    }

    private Result CreateChannelResult(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
        {
            return Result.Failure("頻道名稱不能為空");
        }
        return Result.Success(new Channel(channelName));
    }
}