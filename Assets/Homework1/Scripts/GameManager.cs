using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Ball _ball;
	[SerializeField] private CoinCollector _coinCollector;
	[SerializeField] private List<Coin> _coinsInScene;

	[SerializeField] private float _maxTimeToLose;

	private int _coinsCountToWin;

	private float _currentTime;

	private bool _isPlaying;

	private void Awake()
	{
		_coinsCountToWin = _coinsInScene.Count;

		_isPlaying = true;
		_currentTime = 0;
	}

	private void Update()
	{
		if (_isPlaying)
		{
			CheckGameState();
		}
	}

	private void CheckGameState()
	{
		CheckTime(FindRemainingTime());

		CheckCoinsNumber(CalculateCoins());
	}

	private void CheckTime(float remainingTime)
	{
		if (remainingTime <= 0)
		{
			Debug.Log("ÂÛ ÏÐÎÈÃÐÀËÈ!");
			StopGame();
		}
	}

	private float FindRemainingTime()
	{
		_currentTime += Time.deltaTime;
		float remainingTime = _maxTimeToLose - _currentTime;

		Debug.Log($"Äî êîíöà èãðû îñòàëîñü: {remainingTime.ToString("0.000")} c");
		return remainingTime;
	}

	private int CalculateCoins()
	{
		int collectedCoins = 0;

		foreach (Coin coin in _coinsInScene)
		{
			if (coin.IsCollected)
				collectedCoins++;
		}

		return collectedCoins;
	}

	private void CheckCoinsNumber(int countCoins)
	{
		if (countCoins == _coinsCountToWin)
		{
			Debug.Log("ÂÛ ÏÎÁÅÄÈËÈ!");
			StopGame();
		}
	}

	private void StopGame()
	{
		_ball.StopBall();

		_isPlaying = false;
	}
}
