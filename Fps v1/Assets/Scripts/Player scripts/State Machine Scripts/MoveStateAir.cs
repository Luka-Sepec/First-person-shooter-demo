using UnityEngine;
using UnityEngine.EventSystems;

public class MoveStateAir : State
{
    public MoveStateAir(StateMachine stateMachine) : base(stateMachine) { }

    public float movementSpeed = 20f;
    public Vector3 moveDirection;
    public override void Enter()
    {
        Debug.Log("Current state: MoveStateAir");
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
        if (stateMachine.Is_On_Ground()) stateMachine.ChangeState(stateMachine.moveStateGround);
        moveDirection = stateMachine.input.moveDirection;
        moveDirection = stateMachine.transform.TransformDirection(moveDirection.normalized);
    }
    public override void PhysicsUpdate()
    {
        stateMachine.VelocityX(moveDirection.x * movementSpeed);
        stateMachine.VelocityZ(moveDirection.z * movementSpeed);
    }
}
