public class ThreadSafeSingletonTemplate<T> where T : new()
{
    private static T _instance;
    private static readonly object _lock = new object();

    // Constructor is protected to prevent instantiation.
    protected ThreadSafeSingletonTemplate() {}

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}

// Usage:
public class MyClass { }

// This line will create a thread-safe singleton instance of MyClass.
var mySingletonInstance = ThreadSafeSingletonTemplate<MyClass>.Instance;

// Comments: This implementation uses a generic type parameter (T) to create a thread-safe singleton of any class.
// The double-check locking ensures that only one instance is created in a multithreaded environment.
// The 'new()' constraint on T ensures that only classes with parameterless constructors can be used.
