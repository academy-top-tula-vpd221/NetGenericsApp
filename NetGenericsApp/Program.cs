SendMessage<EmailMessage>(new EmailMessage("Hello world", "Hello"));



void SendMessage<T>(T message) where T: Message 
{
    Console.WriteLine($"Send message: {message.Text}");
}

void GenericWelcome()
{
    Employee<int> bob = new() { Id = 123, Name = "Bob" };
    Employee<int> tom = new() { Id = 555, Name = "Tom" };

    Employee<string> joe = new() { Id = "XI02", Name = "Joe" };

    Employee<int>.Code = 1000;
    Employee<string>.Code = "AAAAA";

    Console.WriteLine(bob);
    Console.WriteLine(tom);
    Console.WriteLine(joe);

    Workshop workshop = new();
    workshop.Swap<Employee<int>>(ref bob, ref tom);

    Console.WriteLine(bob);
    Console.WriteLine(tom);
}
class Workshop
{
    public void Swap<T>(ref T a, ref T b)
    {
        T temp = a; 
        a = b; 
        b = temp;
    }
}
class Employee<T> where T: class
{
    public static T Code;
    public T Id { get; set; }
    public string? Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name {Name}, Code {Code}";
    }
}

class Manager<T> : Employee<T> where T: Message
{

}

class ManagerInt : Employee<Message>
{

}

class Message
{
    public string? Text { set; get; }
    public Message(string? text)
    {
        Text = text;
    }
}

class SmsMessage : Message
{
    public string Number { set; get; }
    public SmsMessage(string? text, string? number) : base(text) 
    {
        Number = number;
    }
}

class EmailMessage : Message
{
    public string Subject { set; get; }
    public EmailMessage(string? text, string? subject) : base(text) 
    {
        Subject = subject;
    }
}

class User
{

}

class Messanger<T, U> 
    where T : Message
    where U : User
{
    void SendMessage(T message)
    {
        Console.WriteLine($"Send message: {message.Text}");
    }
}