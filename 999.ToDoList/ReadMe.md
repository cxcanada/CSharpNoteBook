# To Do List

- static keyword
```c#
    public static class Car(){

    }
```


<br/>

- abstract keyword    
  >abstract docs click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/abstract)
```c#
public abstract class Enum : ValueType, IComparable, IConvertible, IFormattable
```
The abstract modifier indicates that the thing being modified has a missing or incomplete implementation. The abstract modifier can be used with classes, methods, properties, indexers, and events. Use the abstract modifier in a class declaration to indicate that a class is intended only to be a base class of other classes, not instantiated on its own. Members marked as abstract must be implemented by non-abstract classes that derive from the abstract class.
  

<br/>

- Cast expression
  > Cast expression click [here](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/type-testing-and-cast#cast-expression)


- AsEnumerable()


- IQueryable()

- IEnumerable, IList interface
```c#
IEnumerable<int> numbers = new int[] { 10, 20, 30 };
```


- Memmory allocation - Stack and Heap
  > More information click [here](https://www.youtube.com/watch?v=clOUdVDDzIM&t=5s)
    - stack: store local variables. 
      -  a value type variable holds *an instance of the type* in the stack (memory location).
      -  a reference type variable holds *a refernece of the instance*( stored in the heap) to the object in the stack (memory location).
    - heap:  store class instances