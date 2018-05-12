using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CloseEnough
{
	public class TryOpenWarning : MonoBehaviour
	{
		public GameObject WarningPanel;
		public void OpenWarning()
		{
			if (!Timer.instance.IsCountdown() && !GamePlay.instance.IsRoundDone()) {
				WarningPanel.SetActive(true);
			}
		}
	}
}