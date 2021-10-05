# Structure
> Structure docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).

A  *structure type* (or *struct type*) is a value type that can encapsulate data and related functionality. 




## **Define a struct**
To define a structure type, use the `struct` keyword:

```C#
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


<br />


## **`readonly` struct**


<br />



## **readonly instance members**


<br />


## **Nondestructive mutation**


<br />

## **Limitations with the design of a structure type**


<br />

## **Parameterless constructors and field initializers**



<br />


<br />

## ****


<br />


<br />

## ****


<br />