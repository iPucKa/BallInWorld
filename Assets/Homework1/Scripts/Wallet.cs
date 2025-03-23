using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _currentMoney;
    public void AddCoin(int value)
    {
        _currentMoney += value;

        Debug.Log($"В кошелечек добавлена денежка. У Вас {_currentMoney} монеток");
    }
}
