public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }
}

public class Subject
{
    private List<IObserver> _observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}

// Comments: This basic implementation follows the traditional Observer pattern and is suitable for simple scenarios.
// It can become cumbersome to manage as the number of observers increases.
