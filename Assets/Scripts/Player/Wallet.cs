using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Balance { get; private set; }

    public void IncreaseBalance(int amount)
    {
        Balance += amount;

        ShowBalance(Balance);
    }

    public void ShowBalance(int balance)
    {
        print(balance);
    }
}