namespace CSharpProject.LanguageFeatures;

file record struct Person(string Name, int Age);

file record Employee(string Name, int Age, string Department);

public class MyMonoBehaviour : MonoBehaviour
{
    public void Start()
    {
        Debug.Log("Start");
    }
}

// public class Person
// {
//     public string Name { get; init; }
//     public int Age { get; init; }

//     public Person(string name, int age)
//     {
//         Name = name;
//         Age = age;
//     }

//     public override bool Equals(object obj)
//     {
//         // 自動實現值相等性比較
//     }

//     public override int GetHashCode()
//     {
//         // 自動實現基於所有屬性的哈希碼
//     }
// }