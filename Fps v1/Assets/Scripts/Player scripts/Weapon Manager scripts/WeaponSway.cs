using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public InputHandler input;

    public float swayAmount = 0.2f;
    public float smoothAmount = 6f;
    private Quaternion initialRotation;
    
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    void Update()
    {
        Vector2 lookInput = input.lookInput;

        Quaternion xRotation = Quaternion.AngleAxis(-lookInput.y * swayAmount, Vector3.right);
        Quaternion yRotation = Quaternion.AngleAxis(lookInput.x * swayAmount, Vector3.up);

        Quaternion targetRotation = initialRotation * xRotation * yRotation;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smoothAmount);
    }
}
