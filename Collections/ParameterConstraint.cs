namespace CSharpProject.Collections;

public class ParameterConstraint
{
    // 展示值類型約束
    public class StructContainer<T> where T : struct
    {
        public T Value { get; set; }
    }

    // 展示參考類型約束
    public class ClassContainer<T> where T : class
    {
        public T? Instance { get; set; }
    }

    // 展示多重約束：必須是類別且有無參數建構函式
    public class MultipleConstraints<T> where T : class, new()
    {
        public T CreateNew() => new T();
    }

    // 展示介面約束
    public class InterfaceConstraint<T> where T : IComparable
    {
        public bool IsGreaterThan(T first, T second)
        {
            return first.CompareTo(second) > 0;
        }
    }

    class PlayerTeam : Team<Player>
    {
        public override void AddMember(Player player) { }
    }

    class Player { }

    class Team<T>
    {
        public virtual void AddMember(T member) { }
    }

    public class InheritedGenericClass<K, T> : MyGenericClass<K, T>
    where K : struct
    where T : MustDeriveClass, IMustImplItf1, IMustImplItf2, new()
    {

    }

    public class MyGenericClass<K, T> : MyBase, ISomeInterface
    where K : struct
    where T : MustDeriveClass, IMustImplItf1, IMustImplItf2, new()
    {

    }

    public class MyBase
    {

    }

    public interface ISomeInterface
    {

    }

    public class MustDeriveClass
    {

    }

    public interface IMustImplItf1
    {

    }

    public interface IMustImplItf2
    {

    }

    public static void Test()
    {
        // 測試值類型約束
        var structContainer = new StructContainer<int> { Value = 42 };

        // 測試參考類型約束
        var classContainer = new ClassContainer<string> { Instance = "Hello" };

        // 測試多重約束
        var multipleConstraints = new MultipleConstraints<List<int>>();
        var newList = multipleConstraints.CreateNew();

        // 測試介面約束
        var interfaceConstraint = new InterfaceConstraint<int>();
        bool result = interfaceConstraint.IsGreaterThan(10, 5); // 返回 true
    }
}
