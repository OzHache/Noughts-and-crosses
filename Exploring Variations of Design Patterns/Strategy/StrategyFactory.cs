public interface IStrategy
{
    void Execute();
}

public class ConcreteStrategyA : IStrategy
{
    public void Execute()
    {
        // Implementation for Strategy A
    }
}

public class ConcreteStrategyB : IStrategy
{
    public void Execute()
    {
        // Implementation for Strategy B
    }
}

public class StrategyFactory
{
    public static IStrategy GetStrategy(string type)
    {
        switch (type)
        {
            case "A": return new ConcreteStrategyA();
            case "B": return new ConcreteStrategyB();
            default: throw new ArgumentException("Invalid type", nameof(type));
        }
    }
}

public class Context
{
    private IStrategy _strategy;

    public void SetStrategy(string type)
    {
        _strategy = StrategyFactory.GetStrategy(type);
    }

    public void ExecuteStrategy()
    {
        _strategy.Execute();
    }
}
