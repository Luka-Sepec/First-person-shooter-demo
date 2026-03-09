using System.Threading;
using UnityEngine;

public class SniperRifle : MonoBehaviour
{
    public InputHandler input;
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;
    public Camera playerCamera;
    public GameObject bulletPrefab;
    public GameObject sniperModel;
    public AudioSource shot;

    public float fireRate = 1.0f;
    public float nextFireTime;
    public float range = 1500f;

    public Transform gunTransform;
    public float recoilKickback = 0.3f;
    public float recoilAngle = 2f;
    public float recoilReturnSpeed = 8f;

    public Vector3 originalPosition;
    public Quaternion originalRotation;
    public float defaultFOV;
    
    void Start()
    {
        if (gunTransform == null) gunTransform = transform;
        defaultFOV = playerCamera.fieldOfView;
        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    private void OnEnable()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        if (input.shoot_key_pressed && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
            ApplyRecoil();
        }

        sniperModel.SetActive(playerCamera.fieldOfView > 12f);

        if (input.right_click_key_pressed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(-0.615f, 0f, 0f), 0.25f);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, 10f, 0.25f);
            playerCamera.GetComponent<PlayerCameraScript>().SetSensitivity(5f);
        }
        else
        {
            gunTransform.localPosition = Vector3.Lerp(gunTransform.localPosition, originalPosition, Time.deltaTime * recoilReturnSpeed);
            playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, defaultFOV, 0.25f);
            playerCamera.GetComponent<PlayerCameraScript>().SetSensitivity(15f);
        }
        gunTransform.localRotation = Quaternion.Slerp(gunTransform.localRotation, originalRotation, Time.deltaTime * recoilReturnSpeed);

    }

    private void Fire()
    {
        if (muzzleFlash != null) muzzleFlash.Play();
        if (shot != null) shot.Play();
        if (bulletPrefab != null)
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            Vector3 targetPoint;

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                targetPoint = hit.point;
            }
            else targetPoint = ray.GetPoint(100f);

            Vector3 direction = (targetPoint - muzzlePoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab,muzzlePoint.position, Quaternion.LookRotation(direction));
        }
    }

    private void ApplyRecoil()
    {
        gunTransform.localPosition -= Vector3.forward * recoilKickback;
        gunTransform.localRotation *= Quaternion.Euler(recoilAngle, Random.Range(-0.5f, 0.5f), 0);
    }
}
