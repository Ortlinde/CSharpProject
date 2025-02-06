using System.Diagnostics.CodeAnalysis;

file class Person
{
    // init 關鍵字：只能在建構時設定
    public string? Name { get; init; }

    // required 關鍵字：必須在建構時提供
    public required string Id { get; set; }

    // 混合使用
    public required string Email { get; init; }

    public Person() { }

    [SetsRequiredMembers]
    public Person(string name, string id, string email)
    => (Name, Id, Email) = (name, id, email);
}

// 使用範例
class TestProgram
{
    public static void Test()
    {
        // 使用物件初始設定式來設定
        var person = new Person
        {
            Name = "張三",      // init 允許在初始化時設定
            Id = "A123456789",  // required 必須設定
            Email = "test@example.com",
        };

        // 使用建構函式來設定
        var person2 = new Person(name: "李四", id: "B123456789", email: "test2@example.com");

        // person.Name = "李四";      // 錯誤！init 屬性無法在初始化後修改
        person.Id = "B123456789";     // 可以，因為是一般的 set
    }
}