using UnityEngine;
using UnityEngine.UI;

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

	void OnEnable()
	{
		_timer = CountdownTime;
		_countdownText.text = Mathf.Ceil(CountdownTime).ToString();	
	}

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
