using UnityEngine;

public class MoveStateGround : State
{
    public MoveStateGround(StateMachine stateMachine) : base(stateMachine) { }

    public float movementSpeed = 20f;
    public Vector3 moveDirection;
    public override void Enter()
    {
        Debug.Log("Current state: MoveStateGround");
    }
    public override void Exit()
    {
        ;
    }
    public override void HandleInput()
    {
        if (stateMachine.input.jump_key_pressed) stateMachine.ChangeState(stateMachine.jumpState);
        if (stateMachine.input.moveDirection == Vector3.zero) stateMachine.ChangeState(stateMachine.idleState);
    }
    public override void LogicUpdate()
    {
        moveDirection = stateMachine.input.moveDirection;
        moveDirection = stateMachine.transform.TransformDirection(moveDirection.normalized);
    }
    public override void PhysicsUpdate()
    {
        stateMachine.VelocityX(moveDirection.x * movementSpeed);
        stateMachine.VelocityZ(moveDirection.z * movementSpeed);
    }
}
