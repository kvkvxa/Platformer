using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _scorePerCoin = 1;
    public int Balance { get; private set; }

    public void IncreaseBalance()
    {
        Balance += _scorePerCoin;

        ShowBalance(Balance);
    }

    public void ShowBalance(int balance)
    {
        print(balance);
    }
}