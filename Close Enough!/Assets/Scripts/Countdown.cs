using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Countdown timer
/// </summary>
[RequireComponent(typeof(Text))]
public class Countdown : MonoBehaviour {
	public Countdown instance;
	public float CountdownTime;

	public delegate void CountdownFinish();
	public CountdownFinish OnCountdownFinish;

    Text _countdownText;
	float _timer;

	void Awake()
	{
		_countdownText = GetComponent<Text>();
	}

	/// <summary>
	/// Enables timer and text to countdown
	/// </summary>
	void OnEnable()
	{
		_timer = CountdownTime;
		_countdownText.text = Mathf.Ceil(CountdownTime).ToString();	
	}

	/// <summary>
	/// Updates countdown each second
	/// </summary>
	void Update()
	{
		_timer -= Time.deltaTime;
		_countdownText.text = Mathf.Ceil(_timer).ToString();

		if (_timer <= 0) {
			OnCountdownFinish();
			gameObject.SetActive(false);
		}
	}
}
