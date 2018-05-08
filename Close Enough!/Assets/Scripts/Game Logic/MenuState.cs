using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CloseEnough
{
    public class MenuState : BaseGameState
    {
        public override BaseGameState GetNextState()
        {
            return new InitialState();
        }
    }
}