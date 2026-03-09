using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;
    public GameObject bulletPrefab;
    public Camera playerCamera;
    public InputHandler input;
    public AudioSource shot;

    public float fireRate = 1f;
    public float nextFireTime;
    public float spread = 0.5f;
    public float range = 200f;

    public Transform gunTransform;
    public float recoilKickback = 1f;
    public float recoilAngle = 2f;
    public float recoilReturnSpeed = 8f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        if (gunTransform == null) gunTransform = transform;

        originalPosition = gunTransform.localPosition;
        originalRotation = gunTransform.localRotation;
    }
    void Update()
    {
        if (input.shoot_key_pressed && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
            ApplyRecoil();
        }

        gunTransform.localPosition = Vector3.Lerp(gunTransform.localPosition, originalPosition, Time.deltaTime * recoilReturnSpeed);
        gunTransform.localRotation = Quaternion.Slerp(gunTransform.localRotation, originalRotation, Time.deltaTime * recoilReturnSpeed);
    }

    private void Fire()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        if (shot != null) shot.Play();
        for (int i = 0; i < 12; i++)
        {
            Vector2 rand = Random.insideUnitCircle;
            float spreadRad = spread * Mathf.Deg2Rad;
            float offsetRight = rand.x * Mathf.Tan(spreadRad);
            float offsetUp = rand.y * Mathf.Tan(spreadRad);

            if (bulletPrefab != null)
            {
                Ray ray = new Ray(playerCamera.transform.position,
                    (playerCamera.transform.forward
                    + playerCamera.transform.right * offsetRight
                    + playerCamera.transform.up * offsetUp).normalized);
                RaycastHit hit;
                Vector3 targetPoint;
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    targetPoint = hit.point;
                }
                targetPoint = ray.GetPoint(100f);
                Vector3 direction = (targetPoint - muzzlePoint.position).normalized;

                GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.LookRotation(direction));
            }
        }


    }
    void ApplyRecoil()
    {
        gunTransform.localPosition -= Vector3.forward * recoilKickback;
        gunTransform.localRotation *= Quaternion.Euler(-recoilAngle, Random.Range(-0.5f, 0.5f), 0);
    }
}
