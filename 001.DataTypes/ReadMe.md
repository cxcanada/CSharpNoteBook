# Reference Types

There are two kinds of types in C#: *reference* types and *value* types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. 

With ***reference*** types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. *Default value* of all reference-type fields is `null`.
> Reference type docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types)


With ***value*** types, each variable has its own copy of the data, and it is not possible for operations on one variable to affect the other (except in the case of in, ref and out parameter variables; see in, ref and out parameter modifier).
*Default value* of all value-type fields is `0`.
> Value type docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types)

## **Built-in Types**

|Value Types                 |Reference Types|
|:--------------------------:|:-------------:|
|Integral numeric            |Dymaic         |
|Floating-point numeric      |object         |
|Bool                        |string         |
|Char                        |               |

## **Keywords used to declare Types**
|Value Types   |Reference Types|
|:------------:|:-------------:|
|[struct](./ValueTypes/struct/ReadMe.md)|[class](./ReferenceTypes/class/ReadMe.md)|
|[enum](./ValueTypes/enum/ReadMe.md)|[interface](./ReferenceTypes/interface/ReadMe.md)|
|     |[delegate](./ReferenceTypes/delegate/ReadMe.md)|
|     |[record](./ReferenceTypes/record/ReadMe.md)|