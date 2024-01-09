public interface IAttackStrategy
{
    void Execute();
}

public class MeleeAttack : IAttackStrategy
{
    public void Execute()
    {
        // Implementation for melee attack
        Console.WriteLine("Performing a melee attack.");
    }
}

public class RangedAttack : IAttackStrategy
{
    public void Execute()
    {
        // Implementation for ranged attack
        Console.WriteLine("Performing a ranged attack.");
    }
}

public class Character
{
    private IAttackStrategy _attackStrategy;

    public Character(IAttackStrategy attackStrategy)
    {
        _attackStrategy = attackStrategy;
    }

    public void SetStrategy(IAttackStrategy strategy)
    {
        _attackStrategy = strategy;
    }

    public void Attack()
    {
        _attackStrategy.Execute();
    }
}

// Comments: This basic implementation allows for flexible attack behaviors but can lead to numerous strategy classes
// if many different behaviors are needed. Suitable for scenarios with a manageable number of strategies.
