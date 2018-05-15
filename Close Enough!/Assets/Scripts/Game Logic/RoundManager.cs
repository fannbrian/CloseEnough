using UnityEngine;

namespace CloseEnough
{
	public enum RoundType {
		Drawing,
        Guessing
	}

	public class RoundManager
	{
		public static RoundManager instance;
		public RoundType Type;
		public bool IsRunning;
		protected float TimerLength;

        /// <summary>
        /// Starts countdown
        /// </summary>
		public virtual void StartRound() {
            var countdown = PanelReference.singleton.Countdown;

            countdown.SetActive(true);
			countdown.GetComponent<Countdown>().OnCountdownFinish += OnCountdownFinish;
        }
      
        /// <summary>
        /// Detaches event from timer.
        /// </summary>
		public virtual void EndRound() {
			if (!IsRunning) return;
            PanelReference.singleton.Timer.GetComponent<Timer>().OnTimerFinish -= OnTimerFinish;
			PanelReference.singleton.WarningPanel.SetActive(false);
			IsRunning = false;
		}

        /// <summary>
        /// Start timer
        /// </summary>
		public virtual void OnCountdownFinish() {
            PanelReference.singleton.Countdown.GetComponent<Countdown>().OnCountdownFinish -= OnCountdownFinish;
			var timerObj = PanelReference.singleton.Timer;
			timerObj.SetActive(true);

			var timer = timerObj.GetComponent<Timer>();
			timer.StartTimer(TimerLength);
			timer.OnTimerFinish += OnTimerFinish;

			IsRunning = true;
		}

        public virtual void OnTimerFinish() {
			EndRound();
		}      
	}
}