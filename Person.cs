using System;

public class Person
{
    private string _firstName = null!;
    private string _lastName = null!;
    private DateTime _birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public Person(): this(firstName: "Невідомо", lastName:"Невідомо", new DateTime(1, 1, 1))
    {
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; } 
    }

    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value; }
    }

    public DateTime BirthDate
    {
        get { return _birthDate; }
        set { _birthDate = value; }
    }

    public int BirthYear
    {
        get { return _birthDate.Year; }
        set {
            _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day); 
        }
    }

    public override string ToString() => $"Person: {FirstName} {LastName}, Дата народження: {BirthDate.ToShortDateString()}";

    public virtual string ToShortString()=>$"{FirstName} {LastName}";
}