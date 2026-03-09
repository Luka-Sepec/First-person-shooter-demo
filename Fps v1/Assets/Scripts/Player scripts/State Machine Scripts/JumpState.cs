using UnityEngine;

public class JumpState : State
{
    public JumpState(StateMachine stateMachine) : base(stateMachine) { }

    public float jumpVelocity = 20f;
    public override void Enter()
    {
        Debug.Log("Current state: JumpState");
        stateMachine.VelocityY(jumpVelocity);
    }
    public override void Exit()
    {
        ;
    }
    public override void HandleInput()
    {
        ;
    }
    public override void LogicUpdate()
    {
        stateMachine.ChangeState(stateMachine.moveStateAir);
    }
    public override void PhysicsUpdate()
    {
        ;
    }
}
