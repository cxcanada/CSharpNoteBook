# Reference Types

There are two kinds of types in C#: `reference` types and `value` types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. 

With `reference` types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. 

With `value` types, each variable has its own copy of the data, and it is not possible for operations on one variable to affect the other (except in the case of in, ref and out parameter variables; see in, ref and out parameter modifier).


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
|struct        |class          |
|enum          |interface      |
|              |delegate       |
|              |record         |