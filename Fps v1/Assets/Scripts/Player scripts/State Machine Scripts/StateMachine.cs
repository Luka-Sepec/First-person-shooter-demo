using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public new CapsuleCollider collider;
    public InputHandler input;

    public State currentState;
    public IdleState idleState;
    public MoveStateGround moveStateGround;
    public MoveStateAir moveStateAir;
    public JumpState jumpState;

    private ConstantForce gravity;
    public float gravityScale = 5f;

    void Awake()
    {
        idleState = new IdleState(this);
        moveStateGround = new MoveStateGround(this);
        moveStateAir = new MoveStateAir(this);
        jumpState = new JumpState(this);
        gravity = gameObject.AddComponent<ConstantForce>();
        gravity.force = new Vector3(0f, -9.81f * gravityScale, 0f);
    }
    void Start()
    {
        ChangeState(idleState);
        rigidbody.freezeRotation = true;
    }
    void Update()
    {
        currentState.HandleInput();
        currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        currentState.PhysicsUpdate();
    }
    public void ChangeState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }
    public bool Is_On_Ground()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.2f);
    }

    public void VelocityX(float velocityX)
    {
        Vector3 temp = rigidbody.linearVelocity;
        temp.x = velocityX;
        rigidbody.linearVelocity = temp;
    }

    public void VelocityY(float velocityY)
    {
        Vector3 temp = rigidbody.linearVelocity;
        temp.y = velocityY;
        rigidbody.linearVelocity = temp;
    }

    public void VelocityZ(float velocityZ)
    {
        Vector3 temp = rigidbody.linearVelocity;
        temp.z = velocityZ;
        rigidbody.linearVelocity = temp;
    }
}
