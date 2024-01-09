public class LazySingleton
{
    private static Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());

    // Private constructor ensures no external instantiation.
    private LazySingleton() {}

    // Public property to access the singleton instance.
    public static LazySingleton Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    // Example method to demonstrate functionality.
    public void DoSomething() { }
}

// Comments: Lazy<T> provides thread-safe lazy initialization without the need for explicit locking mechanisms.
// It's more efficient because it only creates the singleton instance when it's actually needed.
