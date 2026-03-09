using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    public Vector2 lookInput;
    public Vector3 lookDirection;
    public Vector3 moveDirection;
    public float scrollValue;

    public bool jump_key_pressed;
    public bool shoot_key_pressed;
    public bool right_click_key_pressed;
    private void OnEnable()
    {
        input.actions["Look"].performed += context => lookInput = context.ReadValue<Vector2>();
        input.actions["Look"].canceled += context => lookInput = Vector2.zero;

        input.actions["Move"].performed += context =>
        {
            moveDirection = context.ReadValue<Vector3>();
            lookDirection = moveDirection;
        };
        input.actions["Move"].canceled += context => moveDirection = Vector3.zero;

        input.actions["Jump"].performed += context => jump_key_pressed = true;
        input.actions["Jump"].canceled += context => jump_key_pressed = false;

        input.actions["MouseScroll"].performed += context => scrollValue = context.ReadValue<float>();
        input.actions["MouseScroll"].canceled += context => scrollValue = 0;

        input.actions["Shoot"].performed += context => shoot_key_pressed = true;
        input.actions["Shoot"].canceled += context => shoot_key_pressed = false;

        input.actions["RightClick"].performed += context => right_click_key_pressed = true;
        input.actions["RightClick"].canceled += context => right_click_key_pressed = false;
    }

    private void OnDisable()
    {
        input.actions["Look"].performed -= context => lookInput = context.ReadValue<Vector2>();
        input.actions["Look"].canceled -= context => lookInput = Vector2.zero;

        input.actions["Move"].performed -= context =>
        {
            moveDirection = context.ReadValue<Vector3>();
            lookDirection = moveDirection;
        };
        input.actions["Move"].canceled -= context => moveDirection = Vector3.zero;

        input.actions["Jump"].performed -= context => jump_key_pressed = true;
        input.actions["Jump"].canceled -= context => jump_key_pressed = false;

        input.actions["MouseScroll"].performed -= context => scrollValue = context.ReadValue<float>();
        input.actions["MouseScroll"].canceled -= context => scrollValue = 0;

        input.actions["Shoot"].performed -= context => shoot_key_pressed = true;
        input.actions["Shoot"].canceled -= context => shoot_key_pressed = false;

        input.actions["RightClick"].performed -= context => right_click_key_pressed = true;
        input.actions["RightClick"].canceled -= context => right_click_key_pressed = false;
    }
}
