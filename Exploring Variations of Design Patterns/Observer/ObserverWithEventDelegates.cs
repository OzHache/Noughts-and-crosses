public class SubjectWithDelegate
{
    public event Action<string> OnNotify;

    public void Notify(string message)
    {
        OnNotify?.Invoke(message);
    }
}

// Usage:
SubjectWithDelegate subject = new SubjectWithDelegate();
subject.OnNotify += (message) => Console.WriteLine($"Received message: {message}");

// Comments: Using event delegates simplifies observer management and is built into C#.
// It's more concise but can be tricky to debug and may lead to memory leaks if not unsubscribed properly.
