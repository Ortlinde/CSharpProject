using System.Collections;

namespace CSharpProject.LanguageFeatures;

public class LINQExample
{
    public void Example()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };

        // 找出偶數並排序
        var evenNumbers = numbers
            .Where(n => n % 2 == 0)
            .OrderByDescending(n => n);

        // 將數字轉換為字符串描述
        var descriptions = numbers
            .Select(n => $"數字 {n} 是 {(n % 2 == 0 ? "偶數" : "奇數")}");

        // 輸出結果
        Console.WriteLine("偶數（降序）：" + string.Join(", ", evenNumbers));
        Console.WriteLine("描述：\n" + string.Join("\n", descriptions));
    }

    public void DeferredExecutionExample()
    {
        // 延遲執行示例
        int[] numbers = [1, 2, 3, 4, 5];
        var query = from n in numbers
                    where n % 2 == 0
                    select n;

        numbers[1] = 10;  // 修改原始數據

        foreach (var n in query)
        {
            Console.WriteLine(n);  // 輸出: 10, 4
        }

        numbers[1] = 2;

        foreach (var n in query)
        {
            Console.WriteLine(n);  // 輸出: 2, 4
        }
    }

    public void ImmediateExecutionExample()
    {
        // 立即執行示例
        int[] numbers = [1, 2, 3, 4, 5];
        var result = (from n in numbers
                      where n % 2 == 0
                      select n).ToList();

        numbers[1] = 10;  // 修改原始數據

        foreach (var n in result)
        {
            Console.WriteLine(n);  // 輸出: 2, 4
        }
    }

    public void GroupExample()
    {
        // 假設有一個非泛型的 ArrayList
        ArrayList mixedList = ["Hello", 123, "World", 456];

        // 使用 OfType<T> 只獲取字符串類型的元素
        var onlyStrings = mixedList.OfType<string>();
        // 結果將只包含 "Hello" 和 "World"

        // 使用 OfType<T> 只獲取整數類型的元素
        var onlyIntegers = mixedList.OfType<int>();
        // 結果將只包含 123 和 456

        Console.WriteLine("字符串元素：");
        foreach (var str in onlyStrings)
        {
            Console.WriteLine(str);
        }

        Console.WriteLine("整數元素：");
        foreach (var num in onlyIntegers)
        {
            Console.WriteLine(num);
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CurrentHP { get; set; } = 100;
        public bool IsAlive { get; private set; } = true;

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public List<Player> team = [
        new Player("John", 10),
        new Player("Alex", 20),
        new Player("John", 30),
        new Player("Alex", 40),
    ];

    public void OperatorExample()
    {
        var names =
        from player in team
        select player.Name;
    }

    public void OperatorExample2()
    {
        var alivePlayers =
        from player in team
        where player.IsAlive
        select player;
    }

    public void OperatorExample3()
    {
        var playerHP =
        from player in team
        select new { player.Name, player.CurrentHP };

        foreach (var hp in playerHP)
        {
            Console.WriteLine($"{hp.Name} 的 HP 是 {hp.CurrentHP}");
        }
    }

    public void OperatorExample4()
    {
        var HPRank =
        from player in team
        orderby player.CurrentHP
        select new { player.Name, player.CurrentHP };

        HPRank = team
        .OrderByDescending(player => player.CurrentHP)
        .Select(player => new { player.Name, player.CurrentHP });
    }
}