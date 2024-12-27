using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private BalanceTextDisplayer _balanceTextDisplayer;

    public int Balance { get; private set; }

    public void IncreaseBalance(int amount)
    {
        Balance += amount;

        _balanceTextDisplayer.ShowBalance(Balance);
    }
}