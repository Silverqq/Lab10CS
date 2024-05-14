using System;

class FirstClass
{
    public string Name { get; set; }

    public event EventHandler<EventArgs<string>> MyEvent;

    public void GenerateEvent()
    {
        OnMyEvent(Name);
    }

    protected virtual void OnMyEvent(string name)
    {
        MyEvent?.Invoke(this, new EventArgs<string>(name));
    }
}

class EventArgs<T> : EventArgs
{
    public T Value { get; }

    public EventArgs(T value)
    {
        Value = value;
    }
}

class SecondClass
{
    public void HandleEvent(object sender, EventArgs<string> e)
    {
        Console.WriteLine($"Событие сгенерировано через объект: {e.Value}");
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
