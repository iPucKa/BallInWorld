using UnityEngine;

public class Coin : MonoBehaviour
{
	private bool _isCollected;
	public bool IsCollected => _isCollected;

	private int _minCoinValue = 1;
	private int _maxCoinValue = 10;

	private int _coinValue;
	public int CoinValue => _coinValue;

	private void Awake()
	{
		_coinValue = Random.Range(_minCoinValue, _maxCoinValue + 1);
	}

	public void Collect()
	{
		_isCollected = true;
		gameObject.SetActive(false);
	}
}
