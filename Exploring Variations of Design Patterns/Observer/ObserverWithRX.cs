// This requires the System.Reactive NuGet package
using System.Reactive.Subjects;

public class RxSubject
{
    private Subject<string> _subject = new Subject<string>();

    public IObservable<string> AsObservable() => _subject;

    public void Notify(string message)
    {
        _subject.OnNext(message);
    }
}

// Usage:
RxSubject rxSubject = new RxSubject();
IDisposable subscription = rxSubject.AsObservable().Subscribe(message => Console.WriteLine($"Received message: {message}"));

// Remember to dispose of the subscription when it's no longer needed
// subscription.Dispose();

// Comments: Reactive Extensions (Rx) provide a powerful way to work with asynchronous data streams.
// This approach is ideal for complex scenarios but has a steeper learning curve.
