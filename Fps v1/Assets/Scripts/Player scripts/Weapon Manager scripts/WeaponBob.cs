using UnityEngine;

public class WeaponBob : MonoBehaviour
{
    public float bobSpeed;
    public float bobSpeedIdle = 3f;
    public float bobSpeedMove = 6f;
    public float bobAmount = 0.01f;
    public InputHandler input;

    private Vector3 initialPosition;
    private float timer;

    void Start()
    {
        initialPosition = transform.localPosition;    
    }

    private void Update()
    {
        if (input.moveDirection != Vector3.zero) bobSpeed = bobSpeedMove;
        else bobSpeed = bobSpeedIdle;

        timer += Time.deltaTime * bobSpeed;
        float offsetY = Mathf.Sin(timer) * bobAmount;
        transform.localPosition = initialPosition + new Vector3(0, offsetY, 0);

    }
}
