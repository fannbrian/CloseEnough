using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough {
    public class GameStateManager : MonoBehaviour {
        public BaseGameState CurrentState;
        public string CURRENT_STATE;
		public static GameStateManager singleton;

		public GameStateManager() {
			singleton = this;
		}

		public void TransitionNextState() {
			var nextState = CurrentState.GetNextState();
			CurrentState.OnExit();

            if (nextState == null) return;

            nextState.OnEnter();
			CurrentState = nextState;
            CURRENT_STATE = CurrentState.GetType().Name;
		}

        public void TransitionToNode(StackNode node)
        {
            BaseGameState nextState;

            if (GameData.instance.CurrentRound == GameData.instance.PlayerCount)
            {
                nextState = new GalleryState();
            }
            else if (node.Type == DrawingStackConstants.TYPE_DRAWING)
            {
                nextState = new GuessingState();
            }
            else if (node.Type == DrawingStackConstants.TYPE_WORD)
            {
                nextState = new DrawingState();
            }
        }
        
        void Start()
        {
            CurrentState = new InitialState();
            CurrentState.OnEnter();
        }
    }
}