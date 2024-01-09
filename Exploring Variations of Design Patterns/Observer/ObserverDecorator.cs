public interface IObservable
{
    void Attach(IObserver observer);
    void Notify();
}

public class ConcreteObservable : IObservable
{
    // Standard observable implementation
}

public class ObservableDecorator : IObservable
{
    private IObservable _wrappedObservable;

    public ObservableDecorator(IObservable observable)
    {
        _wrappedObservable = observable;
    }

    public void Attach(IObserver observer)
    {
        _wrappedObservable.Attach(observer);
    }

    public void Notify()
    {
        // Additional functionality before notifying
        Console.WriteLine("Decorator pre-processing");

        _wrappedObservable.Notify();

        // Additional functionality after notifying
        Console.WriteLine("Decorator post-processing");
    }
}
