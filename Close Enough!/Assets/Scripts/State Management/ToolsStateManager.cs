using UnityEngine;

namespace CloseEnough
{
	/// <summary>
	/// Implements state pattern for the tools menu.
	/// </summary>
	public class ToolsStateManager : MonoBehaviour
	{
		public static ToolsStateManager singleton;
		public string IdleString;
        public string DisableString;
		public ToolState[] states;
		public ToolState CurrentState;

        void Awake()
        {
            singleton = this;
            CurrentState = states[4];
		}
      
		/// <summary>
		/// Checks if the current state is idle.
		/// </summary>
		/// <returns><c>true</c> if idle, <c>false</c> otherwise.</returns>
		public bool IsIdle ()
		{
			return CurrentState.Name.Equals (IdleString);
		}

		/// <summary>
		/// Calls the current state's exit method and calls the next state's enter method.
		/// </summary>
		/// <param name="stateName">State name.</param>
		public void TransitionState (string stateName)
		{
            Debug.Log("transitioning to " + stateName);
			if (CurrentState.Name == stateName) return;
            if (CurrentState.Name == DisableString)
            {
                if (stateName != IdleString) return;
            }

			foreach (var state in states) {
				if (!state.Name.Equals (stateName))
					continue;

				if (CurrentState == state) {
					TransitionState (IdleString);
					return;
				}

				CurrentState.Exit ();
				state.Enter ();
				CurrentState = state;

				return;
			}
		}

		/// <summary>
		/// Check to see if the player clicks anywhere else.
		/// </summary>
		void LateUpdate ()
		{
			if (CurrentState.Name.Equals (IdleString))
				return;
			if (!CurrentState.CancelOnTouch)
				return;

            if (Input.touchCount > 0)
            {
                var pos = Input.GetTouch(0).position;
            }
			else if (Input.GetMouseButton (0)) {
				var pos = Input.mousePosition;

				if (!UIRaycastDetector.singleton.IsPositionOverUI (pos)) {
					TransitionState (IdleString);
				}
			}
		}
	}
}