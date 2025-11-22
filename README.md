# Extension Members - C# 14 New features

## How to Define Extension Methods and Members with the new Approach

Now we have a clearer and more readable way to define extension methods, also we can define static extension members and extension members. 

Below is an example on how to define extension methods, extension members and static extension methods:

```csharp
static class PersonExtensions
{
    extension(Person)
    {
        // static extension method for cloning the person object, resetting the purchases
        public static Person Clone(Person person) => person with { Purchases = []};

        // example of an instance operation as extension
        public static Person operator +(Person basePerson, Person second) =>
            basePerson with { Purchases = [ ..basePerson.Purchases, ..second.Purchases ]};
    }
    
    extension(Person person)
    {
        // example of extension member
        public string FullName => $"{person.FisrtName} {person.LastName}";

        // new way to define extension methods
        public string GetFullName() => $"{person.FisrtName} {person.LastName}";

        // extension defining operators
        public void operator += (Person toMerge) => 
            person.Purchases.AddRange(toMerge.Purchases);
    }

    // the new approach is also compatible with the existing extension methods
    // both approaches can co-exist    
    public static string GetFullNameOld(this Person person) =>
        $"{person.FisrtName} {person.LastName}";
}
```

## How to use it

```csharp
// calling an extension method (exactly as before C# 14)
person.GetFullName();

// accessing an extension member
person.FullName;

// calling an extension static method
var clone = Person.Clone(person);
```
