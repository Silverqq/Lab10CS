using System;

public delegate void MyEventHandler(string value);

class FirstClass
{
    public string Name { get; set; }

    public event MyEventHandler MyEvent;

    public void GenerateEvent()
    {
        OnMyEvent(Name);
    }

    protected virtual void OnMyEvent(string name)
    {
        MyEvent?.Invoke(name);
    }
}

class SecondClass
{
    public void HandleEvent(string name)
    {
        Console.WriteLine($"Событие сгенерировано через объект: {name}");
    }
}

class Program
{
    static void Main()
    {
        FirstClass obj1 = new FirstClass { Name = "Объект 1" };
        FirstClass obj2 = new FirstClass { Name = "Объект 2" };

        SecondClass obj3 = new SecondClass();

        obj1.MyEvent += obj3.HandleEvent;
        obj2.MyEvent += obj3.HandleEvent;

        obj1.GenerateEvent();
        obj2.GenerateEvent();
    }
}
