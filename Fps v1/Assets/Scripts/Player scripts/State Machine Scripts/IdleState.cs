using UnityEngine;

public class IdleState : State
{
    public IdleState(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Current state: IdleState");
    }
    public override void Exit()
    {
        ;
    }
    public override void HandleInput()
    {
        if (stateMachine.input.jump_key_pressed) stateMachine.ChangeState(stateMachine.jumpState); ;
        if (stateMachine.input.moveDirection != Vector3.zero) stateMachine.ChangeState(stateMachine.moveStateGround);
    }
    public override void LogicUpdate()
    {

    }
    public override void PhysicsUpdate()
    {
        stateMachine.rigidbody.linearVelocity = Vector3.Lerp(stateMachine.rigidbody.linearVelocity, Vector3.zero, 0.25f);
    }
}
