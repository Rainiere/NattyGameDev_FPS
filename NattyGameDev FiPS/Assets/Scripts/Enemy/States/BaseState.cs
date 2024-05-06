public abstract  class BaseState
{

    public Enemy enemy;
    public StateMachine _StateMachine;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}