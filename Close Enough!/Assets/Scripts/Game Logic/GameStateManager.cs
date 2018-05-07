using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough {
    public class GameStateManager : MonoBehaviour {
        public BaseGameState CurrentState;

        private void Start()
        {
            CurrentState = new MenuState();
        }
    }
}