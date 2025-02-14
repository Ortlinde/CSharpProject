namespace CSharpProject.LanguageFeatures;

// 舊方式
public class TypeAttribute : Attribute
{
    public TypeAttribute(Type t) => ParamType = t;
    public Type ParamType { get; }
}

// 新方式
public class GenericAttribute<T> : Attribute
{ }

public class OldGenericAttributeExample
{
    // 使用時
    [TypeAttribute(typeof(string))]
    public string? Method() => default;
}

public class GenericAttributeExample
{
    // 使用時
    [GenericAttribute<string>]
    public string? Method() => default;
}
