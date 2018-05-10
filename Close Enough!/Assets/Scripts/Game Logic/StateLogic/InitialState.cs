namespace CloseEnough
{
    public class InitialState : BaseGameState
    {
        public override BaseGameState GetNextState()
        {
            return new DrawingState();
        }

		public override void OnEnter()
		{
			// Create an InitialGameHandler.
			// Note: Just calling the constructor will automatically store this as a singleton.
			new InitialGameHandler();
		}

		public override void OnExit()
		{
			// Remove the reference to the initial state handler.
			InitialGameHandler.singleton = null;
		}
	}
}