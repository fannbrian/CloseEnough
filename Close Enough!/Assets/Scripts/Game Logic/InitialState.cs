namespace CloseEnough
{
    public class InitialState : BaseGameState
    {
        public override BaseGameState GetNextState()
        {
            return new DrawingState();
        }
    }
}