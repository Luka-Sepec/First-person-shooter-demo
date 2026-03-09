using UnityEngine;

public class SniperRifleBullet : MonoBehaviour
{
    public float speed = 1500f;
    public float lifetime = 1f;
    
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
            Debug.Log("Sniper rifle hit");
            Destroy(gameObject);
            return;
        }

        transform.position = nextPosition;
    }
}
