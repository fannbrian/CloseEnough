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
			if (RoundManager.instance.IsRunning) {
				WarningPanel.SetActive(true);
			}
		}
	}
}