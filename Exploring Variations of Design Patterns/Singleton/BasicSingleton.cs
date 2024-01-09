public class BasicSingleton
{
    private static BasicSingleton _instance;

    // Private constructor ensures no external instantiation.
    private BasicSingleton() {}

    // Public method to access the singleton instance.
    public static BasicSingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BasicSingleton();
            }
            return _instance;
        }
    }

    // Example method to demonstrate functionality.
    public void DoSomething() { }
}

// Comments: This basic implementation is easy to understand and implement but is not thread-safe.
// It's suitable for single-threaded applications where lazy initialization and thread safety are not concerns.
