var person = new Person("Wilson", "Neto", []);
person.Purchases.Add(new Purchase("Notebook"));

var person2 = new Person("Wilson", "N.", []);
person2.Purchases.Add(new Purchase("Keyboard"));


Console.WriteLine(person);
Console.WriteLine(person.GetFullNameOld());
Console.WriteLine(person.GetFullName());
Console.WriteLine(person.FullName);

person += person2;

var mergedPerson = person + person2;

Console.WriteLine(person.Purchases.Count);

var clone = Person.Clone(person);
Console.WriteLine(clone);

internal record Person(string FisrtName, string LastName, List<Purchase> Purchases);

internal record Purchase(string ProductName);

static class PersonExtensions
{
    extension(Person)
    {
        public static Person Clone(Person person) => person with { Purchases = []};

        public static Person operator +(Person basePerson, Person second) =>
            basePerson with { Purchases = [ ..basePerson.Purchases, ..second.Purchases ]};
    }
    
    extension(Person person)
    {
        public string FullName => $"{person.FisrtName} {person.LastName}";
        
        public string GetFullName() => $"{person.FisrtName} {person.LastName}";

        public void operator += (Person toMerge) => 
            person.Purchases.AddRange(toMerge.Purchases);
        
        // public Purchase this[int index] => person.Purchases[index];
    }
    
    public static string GetFullNameOld(this Person person) =>
        $"{person.FisrtName} {person.LastName}";
}