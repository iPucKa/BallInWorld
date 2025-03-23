using UnityEngine;

public class CoinCollector : MonoBehaviour
{
	private Ball _ball;

	private void Awake()
	{
		_ball = GetComponent<Ball>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Coin coin = other.GetComponent<Coin>();

		if (coin != null)
		{
			coin.Collect();

			_ball.GetCoin(coin.CoinValue);
		}
	}
}
