<Query Kind="Statements" />

// Coords
Coords p1 = new Coords();		  // default constructor assigns default values to fields.
Console.WriteLine("p1: " + p1);   // (0, 0)

Coords p2 = new Coords(1,2);
Console.WriteLine("p2: " + p2);   // (1, 2)

Coords p3 = p2;
p3.X = 5;
// p3.Y = 10;  // cannot change Y
Console.WriteLine("p3: " + p3);   // (5, 2)

Console.WriteLine("p2 after p3 changes: " + p2);   
// Coords as struct value-type, p2 variable has an instance of the type and will not affect other instances of the type. Even p3 is copied from p2, p3 has a copy of p2 instance, and they have no direct relationship after the copy is finished.


// Person
Dog d1 = new Dog();
Console.WriteLine("d1: " + d1);

Dog d2 = new Dog("Molly", 3);
Console.WriteLine("d2: " + d2);

Dog d3 = d2;
// d3.Name = "Mike";   // cannot change Name - init-only property
// d3.Age = 5;         // cannot change Age - readonly
Console.WriteLine("d3: " + d3);

// My Structs
public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; set;}
    public double Y { get;} // no setter => readonly. cannot mutate Y after initialization. 

    public override string ToString() => $"({X}, {Y})";
}


public readonly struct Dog
{
	public Dog(string name, int age){
		Name = name;
		Age = age;
	}
	public string Name {get; init;}
	public int Age {get;}  //cannot have setter since it's readonly
	
	public override string ToString() => $"(Name: {Name}, Age: {Age})";
}