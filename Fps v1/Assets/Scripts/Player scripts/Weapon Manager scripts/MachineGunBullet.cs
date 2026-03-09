using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    public float speed = 600f;
    public float lifetime = 2f;
    
    void Start()
    { 
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 move = transform.forward * speed * Time.deltaTime;
        Vector3 nextPosition = transform.position + move;

        if (Physics.Raycast(currentPosition, transform.forward, out RaycastHit hit, move.magnitude))
        {
            Debug.Log("Machine gun hit");
            Destroy(gameObject);
            return;
        }

        transform.position = nextPosition;
    }

    
}
