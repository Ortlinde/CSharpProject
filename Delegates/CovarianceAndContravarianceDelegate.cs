namespace CSharpProject.Delegates;

public class CovarianceAndContravarianceDelegate
{
    public static void Test()
    {
        // 委派宣稱回傳 Animal，但實際方法回傳 Dog
        GetAnimal getAnimal = Dog.GetDog;
        // Dog繼承自 Animal，所以可以轉型為 Animal並回傳
        Animal animal = getAnimal.Invoke();

        // 委派宣稱接受 Dog，但實際方法接受 Animal
        DogHandler dogHandler = Animal.AnimalHandler;
        // Dog繼承 Animal的方法，因此 Animal使用的方法，Dog也可以使用
        if (animal is Dog dog)
        {
            dogHandler.Invoke(dog);
        }
    }
}

file delegate Animal GetAnimal();
file delegate void DogHandler(Dog dog);

file class Animal
{
    public Animal() => Console.WriteLine(ToString());

    private void Print() => Console.WriteLine(ToString());
    public static void AnimalHandler(Animal animal) => animal.Print();

    public override string ToString() => "Animal";
}

file class Dog : Animal
{
    public static Dog GetDog() => new();

    public override string ToString() => "Dog";
}
