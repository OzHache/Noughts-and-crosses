public class CharacterWithDelegates
{
    public Action AttackStrategy { get; set; }

    public void Attack()
    {
        AttackStrategy?.Invoke();
    }
}

// Usage:
CharacterWithDelegates character = new CharacterWithDelegates();
character.AttackStrategy = () => Console.WriteLine("Performing a melee attack.");
character.Attack();

// Comments: Using delegates simplifies the implementation and avoids creating multiple strategy classes.
// It's great for simple strategies but might reduce code clarity and maintainability for more complex behaviors.
