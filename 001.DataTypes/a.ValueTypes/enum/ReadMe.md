# **Enumeration types**
> Enumeration docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).

An *enumeration type* is a value type defined by a set of named constants of the underlying integral numeric type. 


## **Define an enum**
To define an enumeration type, use the `enum` keyword and specify the names of enum members:
```c#
enum Season
{
    Spring,  // = 0
    Summer,  // = 1
    Autumn,  // = 2
    Winter   // = 3
}
```

<br />

You cannot define a *method* inside the definition of an enumeration type. To add funcionality to an enumeration type, create an [extention method](#).


<br />

## **Default value**
The **default value** of an enumeration type `E` is the value produced by expression `(E)0`, even if zero doesn't have the corresponding enum member:
```c#
enum E
{
    Foo, Bar, Baz, Quux
}
default(E) // return Foo as it is the first-occuring element

enum F
{
    // Give each element a custom value
    Foo = 1, Bar = 2, Baz = 3, Quux = 0
}
default(F) // return Quux as the value of Quux is assigned 0.

enum G
{
    Foo = 1, Bar = 2, Baz = 3, Quux = 4
}
default(G) // return 0, althought it's type remains as G
```

>Complete explaination click [here]((https://stackoverflow.com/questions/4967656/what-is-the-default-value-for-enum-variable)).

<br />

You use an enumertion type to represent a choice from a set of mutually exclusive values or a combination of choices. To represent a combination of choices, define an enumeration type as bit flags.

> More bit flags click [here](https://docs.microsoft.com/en-us/dotnet/api/system.flagsattribute?view=net-5.0).


<br />

## **Enumeration types as bit flags**

If you want an enumeration type to represent a combination of choices, define enum members for thoses choices such that an individual choice is a bit field. That is, the associated values of those enum members should be the power of two. Then you can use bitwise logical operators | or & to combine choices or intersect combinations of choices, repectively. To indicate that an enumeration type declares bit fields, apply the Flags attribute to it.

> bitwise logical operator click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#enumeration-logical-operators)

```c#
[Flags]
public enum Days
{
    None      = 0b_0000_0000,  // 0
    Monday    = 0b_0000_0001,  // 1
    Tuesday   = 0b_0000_0010,  // 2
    Wednesday = 0b_0000_0100,  // 4
    Thursday  = 0b_0000_1000,  // 8
    Friday    = 0b_0001_0000,  // 16
    Saturday  = 0b_0010_0000,  // 32
    Sunday    = 0b_0100_0000,  // 64
    Weekend   = Saturday | Sunday
}

public class FlagsEnumExample
{
    public static void Main()
    {
        Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
        Console.WriteLine(meetingDays);
        // Output:
        // Monday, Wednesday, Friday

        Days workingFromHomeDays = Days.Thursday | Days.Friday;
        Console.WriteLine($"Join a meeting by phone on {meetingDays & workingFromHomeDays}");
        // Output:
        // Join a meeting by phone on Friday

        bool isMeetingOnTuesday = (meetingDays & Days.Tuesday) == Days.Tuesday;
        Console.WriteLine($"Is there a meeting on Tuesday: {isMeetingOnTuesday}");
        // Output:
        // Is there a meeting on Tuesday: False

        var a = (Days)37;
        Console.WriteLine(a);
        // Output:
        // Monday, Wednesday, Saturday
    }
}

```
<br/>


## **The System.Enum type**
The System.Enum type is the abstract base class of all enumeration types. It provides a number of methods to get information about an enumeration type and its values.

>System.Enum docs click [here](https://docs.microsoft.com/en-us/dotnet/api/system.enum?view=net-5.0)

## **Conversions**

For any enumeration type, there exist explicit conversions between the enumeration type and its underlying integral type. If you `cast` an enum value to its underlying type, the result is the associated integral value of an enum member.

```c#
public enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

public class EnumConversionExample
{
    public static void Main()
    {
        Season a = Season.Autumn;
        Console.WriteLine($"Integral value of {a} is {(int)a}");  // output: Integral value of Autumn is 2

        var b = (Season)1;
        Console.WriteLine(b);  // output: Summer

        var c = (Season)4;
        Console.WriteLine(c);  // output: 4
    }
}
```

> More `cast` operator information click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression)

<br/>

Use the `Enum.IsDefined` method to determine whether an enumeration type contains an enum member with the certain associated value.
> More `Enum.IsDefined` operator information click [here](https://docs.microsoft.com/en-us/dotnet/api/system.enum.isdefined?view=net-5.0)