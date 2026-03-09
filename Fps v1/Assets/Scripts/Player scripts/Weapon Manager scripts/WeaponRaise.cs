using UnityEngine;

public class WeaponRaise : MonoBehaviour
{
    public float raiseHeight = -0.5f;
    public float raiseSpeed = 6f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    void Start()
    {
        initialPosition = transform.localPosition;
        targetPosition = initialPosition;
    }

    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * raiseSpeed);
    }

    public void RaiseWeapon()
    {
        transform.localPosition = initialPosition + Vector3.up * raiseHeight;
        targetPosition = initialPosition;
    }
}

