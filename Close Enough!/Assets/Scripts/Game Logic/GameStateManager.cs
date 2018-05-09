using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough {
    public class GameStateManager : MonoBehaviour {
        public BaseGameState CurrentState;
		public static GameStateManager singleton;

		public GameStateManager() {
			singleton = this;
		}

		public void TransitionNextState() {
			var nextState = CurrentState.GetNextState();
			CurrentState.OnExit();
			nextState.OnEnter();
			CurrentState = nextState;
		}

        void Start()
        {
            CurrentState = new MenuState();
        }
    }
}