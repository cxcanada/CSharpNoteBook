# **Structure**
> Structure docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct).

A  *structure type* (or *struct type*) is a value type that can encapsulate data and related functionality. 

Structure types have value semantics. That is, a variable of a structure type contains an instance of the type. By default, variable values are copied on assignment, passing an argument to a method, and returning a method result. In the case of a structure-type variable, an instance of the type is copied.

Typically, you use structure types to design small data-centric types that provide little or no behavior. For example, .NET uses structure types to represent a number (both integer and real), a Boolean value, a Unicode character, a time instance. If you're focused on the behavior of a type, consider defining a class. Class types have reference semantics. That is, a variable of a class type contains a reference to an instance of the type, not the instance itself.


## **Define a struct**
To define a structure type, use the `struct` keyword:

```C#
Coords p1 = new Coords(1, 2)
Console.WriteLine(p1)   // (1, 2)

public struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
```
In this example, we create a variable `p1` and store it in the stack with `null` value. 
On assignment, we create an instance of `Coords` struct type with initial values, and then the copy of instance is assigned to the variable `p1`. Since `Coords` is a value-type struct, `p1` variable and its value (the newly created `Coords` instance) will be stored in the *stack*, not the *heap*.

<br />


## **`readonly` struct** -- Read Only
Because structure types have value semantics, we recommend you to define *immutable* structure types.

Use the `readonly` modifier to declare that a structure type is *immutable*. All data members of a readonly struct must be *read-only* as follows:
- Any field declaration must have the `readonly` modifier
- Any property, including auto-implemented ones, must be read-only. In C# 9.0 and later, a property may have an `init` accessor.

That guarantees that no member of a readonly struct modifies the state of the struct. In C# 8.0 and later, that means that other instance members except constructors are implicitly readonly.

<br/>

### **Note**
```text
In a readonly struct, a data member of a mutable reference type still can mutate its own state. For example, you can't replace a List<T> instance, but you can add new elements to it.
```

<br/>



```c#
// readonly struct with init-only property setters, available in C# 9.0 and later:
public readonly struct Coords
{
    public Coords(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; init; }
    public double Y { get; init; }

    public override string ToString() => $"({X}, {Y})";
}

```

<br/>



<br />



## **`readonly` instance members**
> readonly instance members docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/readonly-instance-members)

### **Note**
```text
An instance member is essentially anything within a class that is not marked as static. That is, that it can only be used after an instance of the class has been made (with the new keyword). This is because instance members belong to the object, whereas static members belong to the class.

Members include fields, properties, methods etc.
```
<br />

If you can't declare the whole *struct* type as `readonly`, you can use `readonly` modifier to mark the instance members that don't modify the state of a struct.

Within a `readonly` instance member, you can't assign to structure's instance fields. However, a `readonly` member can call a non-`readonly` member. In that case the compiler creates a copy of the structure instance and calls the non-`readonly` member on that copy. As a result, the original structure instance is not modified. 

<br>

---

<br>

Typically, you apply the `readonly` modifier to the following kinds of instance members:

### **Methods**
```c#
public readonly double Sum(){
    return X + Y
}

public readonly override string ToString() => $"{X}, {Y}"
```

<br/>

### **Properties**
  1.  **Manual-implemented properties**
   
      When `readonly` is applied to the property syntax, it means that all accessors are readonly as shown in *Prop1*. 
      `readonly` can only be applied to accessors which do not mutate the containing type as shown in *Prop2*.


```c#
public readonly int Prop1
{
    get
    {
        return this._store["Prop2"];
    }
    set
    {
        this._store["Prop2"] = value;
    }
}

public int Prop2
{
    readonly get
    {
        return this._prop3;
    }
    set
    {
        this._prop3 = value;
    }
}
```

<br/>

  2. **Auto-implemented properties**

     `readonly` can be applied to some auto-implemented properties, but it won't have a meaningful effect. The compiler will treat all auto-implemented getters as readonly whether or not the readonly keyword is present.

```c#
// Allowed
public readonly int Prop4 { get; }
public int Prop5 { readonly get; }
public int Prop6 { readonly get; set; }

// Not allowed
public readonly int Prop7 { get; set; }
public int Prop8 { get; readonly set; }
```

<br/>

3. **Init accessor**
   
     In C# 9.0 and later, you may apply the readonly modifier to a property or indexer with an init accessor:
```c#
public readonly double X { get; init; }
```


<br />

## **Nondestructive mutation**

> Docs [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#nondestructive-mutation)

<br />

## **Limitations with the design of a structure type**

> Docs [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#nondestructive-mutation)

- A constructor of a structure type must initialize all instance fields of the type.
- A structure type can't inherit from other class or structure type and it can't be the base of a class. However, a structure type can implement interfaces.

<br />

## **Parameterless constructors and field initializers**

new content from C# 10.0
> Docs [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/struct#nondestructive-mutation)

### **Parameterless constructors**

Every structure type provides an implicit parameterless constructor that produces the default value of the type. Starting C# 10.0, you can declare a parameterless constructor. Example as follows:

```c#
public readonly struct Measurement
{
    public Measurement()
    {
        Value = double.NaN;
        Description = "Undefined";
    }

    public Measurement(double value, string description)
    {
        Value = value;
        Description = description;
    }

    public double Value { get; init; }
    public string Description { get; init; }

    public override string ToString() => $"{Value} ({Description})";
}

public static void Main()
{
    var m1 = new Measurement();
    Console.WriteLine(m1);  // output: NaN (Undefined)

    var m2 = default(Measurement);   // default value expression
    Console.WriteLine(m2);  // output: 0 ()

    var ms = new Measurement[2];   // structure-type array
    Console.WriteLine(string.Join(", ", ms));  // output: 0 (), 0 ()
}
```
As the preceding example shows, the default value expression ignores a parameterless constructor and produces the default value of a structure type, which is the value produced by setting all *value-type* fields to their default values (the 0-bit pattern) and all *reference-type* fields to null.

*Structure-type array* instantiation also ignores a parameterless constructor and produces an array populated with the default values of a structure type.


<br />

### **Field initializer**

Field initializer gives a *struct* the ability to assign default values to the instance member fields. AKA default values assigner.

Beginning with C# 10.0, you can also initialize an instance field or property at its declaration, as the following example shows:

```c#
public readonly struct Measurement
{
    public Measurement(double value)
    {
        Value = value;
    }

    public Measurement(double value, string description)
    {
        Value = value;
        Description = description;
    }

    public double Value { get; init; }
    public string Description { get; init; } = "Ordinary measurement"; //initializer

    public override string ToString() => $"{Value} ({Description})";
}

public static void Main()
{
    var m1 = new Measurement(5);
    Console.WriteLine(m1);  // output: 5 (Ordinary measurement)

    var m2 = new Measurement();
    Console.WriteLine(m2);  // output: 0 ()
}
```
<br />

If you don't declare a parameterless constructor explicitly, a structure type provides a parameterless constructor whose behavior is as follows:

- ***Explicit instance Constructor or No field Initializer*** If a structure type has explicit instance constructors or has no field initializers, an implicit parameterless constructor produces the default value of a structure type, regardless of field initializers, as the preceding example shows.
- ***Field initializer only***. If a structure type has no explicit instance constructors and has field initializers, the compiler synthesizes a public parameterless constructor that performs the specified field initializations, as the following example shows: 

```c#
public struct Coords // No constructor in this struct
{
    // Both fields have initializers
    public double X = double.NaN;  // Field initializer
    public double Y = double.NaN;  // Field initializer

    public override string ToString() => $"({X}, {Y})";
}

public static void Main()
{
    var p1 = new Coords();
    Console.WriteLine(p1);  // output: (NaN, NaN)

    var p2 = default(Coords);
    Console.WriteLine(p2);  // output: (0, 0)

    var ps = new Coords[3];
    Console.WriteLine(string.Join(", ", ps));  // output: (0, 0), (0, 0), (0, 0)
}
```
As the preceding example shows, the default value expression and array instantiation ignore field initializers.


<br />


## **Instantiation of a structure type**

In C#, you must initialize a declared variable before it can be used. Because a structure-type variable can't be null (unless it's a variable of a nullable value type), you must instantiate an instance of the corresponding type. There are several ways to do that.

Typically, you instantiate a structure type by calling an appropriate constructor with the new operator. Every structure type has at least one constructor. That's an implicit parameterless constructor, which produces the default value of the type. You can also use a default value expression to produce the default value of a type.

If all instance fields of a structure type are accessible, you can also instantiate it without the new operator. In that case you must initialize all instance fields before the first use of the instance. The following example shows how to do that:

```c#
public static class StructWithoutNew
{
    public struct Coords
    {
        public double x;
        public double y;
    }

    public static void Main()
    {
        Coords p;
        p.x = 3;
        p.y = 4;
        Console.WriteLine($"({p.x}, {p.y})");  // output: (3, 4)
    }
}
```
