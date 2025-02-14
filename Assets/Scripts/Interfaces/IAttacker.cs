public interface IAttacker
{
    int Damage { get; }

    void Attack(IDamagable target);
}