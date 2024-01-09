public enum AttackType
{
    Melee, Ranged
}

public class CharacterStateMachine
{
    private Dictionary<AttackType, IAttackStrategy> _strategies;

    public CharacterStateMachine()
    {
        _strategies = new Dictionary<AttackType, IAttackStrategy>
        {
            { AttackType.Melee, new MeleeAttack() },
            { AttackType.Ranged, new RangedAttack() }
        };
    }

    public void Attack(AttackType type)
    {
        if (_strategies.ContainsKey(type))
        {
            _strategies[type].Execute();
        }
    }
}

// Comments: Implementing the strategy pattern as a state machine is useful for more complex scenarios 
// with multiple states and transitions. It provides clear state management but can be overkill for simple use cases.
