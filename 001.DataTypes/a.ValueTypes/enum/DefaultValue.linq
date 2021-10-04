<Query Kind="Program" />

//https://stackoverflow.com/questions/4967656/what-is-the-default-value-for-enum-variable

void Main()
{
	Console.WriteLine("E :" + default(E));
	Console.WriteLine("F :" + default(F));
	Console.WriteLine("G :" + default(G));
	
	Console.WriteLine("E: Enum type: " + default(E).GetType().IsEnum);
	Console.WriteLine("F: Enum type: " + default(F).GetType().IsEnum);
	Console.WriteLine("G: Enum type: " + default(G).GetType().IsEnum);
}

enum E
{
    Foo, Bar, Baz, Quux
}

enum F
{
    // Give each element a custom value
    Foo = 1, Bar = 2, Baz = 3, Quux = 0
}

enum G
{
    Foo = 1, Bar = 2, Baz = 3, Quux = 4
}
