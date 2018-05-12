using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CloseEnough
{
	public class Timer : MonoBehaviour
	{
		public static Timer instance;

		public int timer = 30;
		public int starttimer = 3;

		bool countdownDisplay;

		public Text startcountdown;
		public Text countdown;
		public Text timesUp;

		public AudioClip ticker;
		public AudioClip ding;

		AudioSource aud;

		bool _isInitialCountdown = true;
		bool _isRunning = false;
		float _timer = 0;
		int _lastTimer = 0;

		public bool IsCountdown() {
			return _isInitialCountdown;
		}

		// Use this for initialization
		void Awake()
		{
			instance = this;
			startcountdown.gameObject.SetActive(false);
			timesUp.gameObject.SetActive(false);
			aud = GetComponent<AudioSource>();
		}

		void NextRound()
		{
			timesUp.gameObject.SetActive(false);
			countdown.gameObject.SetActive(false);
			GamePlay.instance.FinishRound();
		}

		void Update()
		{
			if (!_isRunning) return;

			_timer -= Time.deltaTime;
			var timerInt = (int)Mathf.Ceil(_timer);

			if (_timer <= 0)
			{
				if (_isInitialCountdown)
				{
					startcountdown.gameObject.SetActive(false);
					_timer = timer;
					_isInitialCountdown = false;
                    if (GamePlay.instance.isDrawing)
                    {
						ToolsStateManager.singleton.Enable(true);
                    }
				}
				else
				{
					countdown.gameObject.SetActive(false);
					timesUp.gameObject.SetActive(true);
					_isRunning = false;
					aud.PlayOneShot(ding);
                    if (GamePlay.instance.isDrawing)
                    {
						ToolsStateManager.singleton.Enable(false);
                    }
					Invoke("NextRound", 2);
				}
			}
			else
			{
				if (_isInitialCountdown)
				{
					startcountdown.text = timerInt.ToString();
				}
				else
				{
					countdown.text = timerInt.ToString();

					if (timerInt <= 3)
					{
						if (_lastTimer != timerInt)
						{
							aud.PlayOneShot(ticker);
						}
					}
				}
			}
			_lastTimer = timerInt;
		}

		public void StartTimer()
		{
			if (GamePlay.instance.isDrawing) {
				ToolsStateManager.singleton.Enable(false);
			}
			startcountdown.gameObject.SetActive(true);
			countdown.gameObject.SetActive(true);
			_timer = starttimer;
			_isRunning = true;
		}

		public void ResetTimer(bool isDrawing)
		{
			_isRunning = false;
			_isInitialCountdown = true;
			_timer = 0;
			startcountdown.gameObject.SetActive(false);
			countdown.gameObject.SetActive(false);

			if (isDrawing)
			{
				timer = 30;
			}
			else
			{
				timer = 20;
			}

			startcountdown.text = starttimer.ToString();
			countdown.text = timer.ToString();
		}
	}
}