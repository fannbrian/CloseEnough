using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class Timer : MonoBehaviour
	{
		public static Timer instance;

		public Text timerText;
		public Text timesUp;

		public AudioClip ticker;
		public AudioClip ding;

		public delegate void TimerFinish();
		public TimerFinish OnTimerFinish;

		AudioSource aud;

		bool _isRunning = false;
		float _timer = 0;
		int _lastTimer = 0;

		void Awake()
		{
			instance = this;
			timesUp.gameObject.SetActive(false);
			aud = GetComponent<AudioSource>();
		}

		void NextRound()
		{
			timesUp.gameObject.SetActive(false);
			OnTimerFinish();
		}

		void Update()
		{
			if (!_isRunning) return;

			_timer -= Time.deltaTime;
			var timerInt = (int)Mathf.Ceil(_timer);

			if (_timer <= 0)
			{
				timerText.gameObject.SetActive(false);

				if (!RoundManager.instance.IsRunning)
                {
                    timesUp.gameObject.SetActive(true);
                }

				_isRunning = false;
				aud.PlayOneShot(ding);
				if (RoundManager.instance.Type == RoundType.Drawing)
                {
					ToolsStateManager.singleton.Enable(false);
                }
				Invoke("NextRound", 2);
			}
			else
			{
				timerText.text = timerInt.ToString();

				if (timerInt <= 3)
				{
					if (_lastTimer != timerInt)
					{
						aud.PlayOneShot(ticker);
					}
				}            
			}
			_lastTimer = timerInt;
		}

		public void StartTimer(float time)
		{
			timerText.gameObject.SetActive(true);
			_timer = time;
			_isRunning = true;
		}

		public void StopTimer()
		{
			timerText.gameObject.SetActive(false);
            timesUp.gameObject.SetActive(false);
			_isRunning = false;
		}
	}
}