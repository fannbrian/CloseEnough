namespace CloseEnough
{
    public abstract class BaseGameState
    {
        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public abstract BaseGameState GetNextState();
    }
}