using UnityEngine;

public class GameHandler : MonoBehaviour
{
	private bool _isPlaying;

	[SerializeField] private Roller _roller;
	[SerializeField] private Platform _platform;
	[SerializeField] private FinishButton _button;

	private void Awake()
	{
		_isPlaying = true;
	}

	private void Update()
	{
		if (_isPlaying)
			CheckButton();
		else
			StopGame();
	}

	private void StopGame()
	{
		Debug.Log("онгдпюбкъел! спнбемэ опнидем!");

		_roller.Stop();
		_platform.Stop();
	}

	private void CheckButton()
	{
		if (_button.IsActivated)
			_isPlaying = false;
		else
			_isPlaying = true;
	}
}
