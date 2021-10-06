# **Access Modifiers**

> Resources: 
> 
> [MS docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/access-modifiers)
>  
> [C# Modifiers](http://diranieh.com/NETCSharp/Modifiers.htm#Access%20Modifiers)

Access modifiers are keywords used to specify the declared accessibility of types and type members. The four access modifiers are discussed in the table below:

## **public**

public is an access modifier for types and type members. This is the most permissive access level as there are no restrictions on accessing a public type or type member.

**Accessibility Level:**  Access is not restricted.

## **internal**

internal is an access modifier for types and type members. internal members are accessible only within file of the same assembly. It is an error to reference an internal type or internal type member outside the assembly within which it was declared. 

A common use of internal access is in component-based development because it enables a group of components to interact in a private matter without being exposed to the outer world. For example, a Data Access Layer could have several classes with internal members that are only used by the DAL.

**Accessibility Level:**  Access is limited to the current assembly (project).

## **protected**

protected is an access modifier for type members only. A protected member is only accessible within the body of the containing type and from within any classes derived from the containing type.

**Accessibility Level:**  Access is limited to the containing class, and classes derived from the containing class

## **private**
private is an access modifier for type members only. private access is the least accessible and such members are only accessible within the body of the containing type.

Note that nested types within the same containing body can also access those private members.

**Accessibility Level:** 	Access is limited to the containing type.