using System.ComponentModel;

namespace CSharpProject.Delegates;

public class EventExample
{
    public void Test()
    {
        // 創建發布者和訂閱者
        var publisher = new Publisher();
        var subscriber = new Subscriber();

        // 訂閱事件
        Subscriber.Subscribe(HandledEvent);

        // 發布者發送通知
        subscriber.OnNotify();

        // 取消訂閱
        Subscriber.Unsubscribe(HandledEvent);

        // 再次發送通知（這次不會收到）
        subscriber.OnNotify();
    }

    public void HandledEvent(string msg) => Console.WriteLine($"收到事件: {msg}");
}

file class Publisher
{
}

file class Subscriber
{
    public delegate void NotifyEventHandler(string message);
    public static event NotifyEventHandler? Notify;

    public static void Subscribe(NotifyEventHandler handler)
    {
        Notify += handler;
    }

    public static void Unsubscribe(NotifyEventHandler handler)
    {
        Notify -= handler;
    }

    public void OnNotify()
    {
        Notify?.Invoke("觸發事件!");
    }
}
