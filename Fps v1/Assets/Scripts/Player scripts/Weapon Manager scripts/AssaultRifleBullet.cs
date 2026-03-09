using UnityEngine;

public class AssaultRifleBullet : MonoBehaviour
{
    public float speed = 300f;
    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 move = transform.forward * speed * Time.deltaTime;
        Vector3 nextPosition = currentPosition + move;

        if (Physics.Raycast(currentPosition, transform.forward, out RaycastHit hit, move.magnitude))
        {
            Debug.Log("Assault rifle hit");
            Destroy(gameObject);
            return;
        }

        transform.position = nextPosition;  
    } 
}
