using UnityEngine;

public abstract class State
{
    public StateMachine stateMachine;   

    public State(StateMachine stateMachine) {  this.stateMachine = stateMachine; }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void HandleInput();
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
}
