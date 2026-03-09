using System.Threading;
using UnityEngine;

public class AssaultRifle : MonoBehaviour
{
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;
    public GameObject bulletPrefab;
    public Camera playerCamera;
    public InputHandler input;
    public AudioSource shot;

    public float fireRate = 0.2f;
    public float nextFireTime;

    public Transform gunTransform;
    public float recoilKickback = 0.05f;
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
    void Fire()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }
        if (shot != null) shot.Play();


        if (bulletPrefab != null)
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            RaycastHit hit;
            Vector3 targetPoint;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                targetPoint = hit.point;
            }
            else targetPoint = ray.GetPoint(100f);

            Vector3 direction = (targetPoint - muzzlePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.LookRotation(direction));
            
        }
    }

    void ApplyRecoil()
    {
        gunTransform.localPosition -= Vector3.forward * recoilKickback;
        gunTransform.localRotation *= Quaternion.Euler(-recoilAngle, Random.Range(-0.5f, 0.5f), 0);
    }
}
